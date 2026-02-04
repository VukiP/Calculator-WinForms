namespace CalculatorWinForms
{
    public partial class Calculator : Form
    {
        private void SimpleOp_Click(object sender, EventArgs e) // Binary operations wired to one event handler.
        {
            Button clicked = (Button)sender;
            string newOp = clicked.Text;

            // CASE A: If there’s an existing operation and the user just typed a number.
            if (!string.IsNullOrEmpty(CurrentOperation) && !IsOperationPending)
            {
                SecondValue = double.Parse(ResultsBox.Text);
                LastOperand = SecondValue;
                Compute();
                CurrentOperation = newOp;
                IsOperationPending = true;
                UpdateCurrentOpBox();
            }

            // CASE B: If no operation is set yet, store the first operand.
            if (string.IsNullOrEmpty(CurrentOperation))
            {
                FirstValue = double.Parse(ResultsBox.Text);
                LastOperand = FirstValue; // Remember the operand for sticky calculations(e.g. '2+===').
                CurrentOperation = newOp;
                IsOperationPending = true;
                UpdateCurrentOpBox();
            }

            // CASE C: Operator already exists but we’re still waiting for the next number.
            CurrentOperation = newOp;
            IsOperationPending = true;
            LastOperand = double.Parse(ResultsBox.Text);
            UpdateCurrentOpBox();
        }
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            CalculationPerformed = true;
            // CASE A: No operator chosen yet, just finalize the display.
            if (string.IsNullOrEmpty(CurrentOperation))
            {
                CurrentOpBox.Text = $"{ResultsBox.Text} =";
                IsOperationPending = true;
                return;
            }
            // CASE B: Operator exists and the user just typed a number.
            if (!IsOperationPending)
            {
                SecondValue = double.Parse(ResultsBox.Text);
                LastOperand = SecondValue; // Save the SecondValue for sticky equals.
            }
            // CASE C: Sticky equals.
            else
            {
                SecondValue = LastOperand; // Reuse the last operand.
            }

            string expressionLabel = $"{FirstValue} {CurrentOperation} {SecondValue}";
            Compute();

            if (!IsError)
            {
                string fullEntry = $"{expressionLabel} = {ResultsBox.Text}";

                // Add to internal history
                MemoryHistory.Add(fullEntry);

                // Add to ListView with right alignment
                MemoryListView.Items.Add(new ListViewItem(fullEntry));

                // Update current operation display
                CurrentOpBox.Text = expressionLabel + " =";
                IsOperationPending = true;
            }
        }
        private void AdditiveInverseButton_Click(object sender, EventArgs e)
        {
            FirstValue = double.Parse(ResultsBox.Text);
            double input = FirstValue;

            if (FirstValue == 0)
            {
                return;
            }

            FirstValue *= -1;
            SecondValue = 0;
            LastOperand = 0;
            CurrentOperation = "";
            ResultsBox.Text = FirstValue.ToString();
            CurrentOpBox.Text = $"-({input}) =";
            AddMemoryEntry($"-({input})");
        }
        private void ReciprocalButton_Click(object sender, EventArgs e)
        {
            try
            {
                CalculationPerformed = true;
                FirstValue = double.Parse(ResultsBox.Text);

                if (FirstValue == 0)
                {
                    throw new DivideByZeroException();
                }

                double input = FirstValue;
                FirstValue = 1 / FirstValue;
                ResultsBox.Text = FirstValue.ToString();
                CurrentOpBox.Text = $"1/({input}) =";
                AddMemoryEntry($"1/({input})");
            }
            catch (DivideByZeroException) // Division by zero caught!
            {
                SetError("Cannot divide by zero!");
            }
        }
        private void PercentButton_Click(object sender, EventArgs e)
        {
            CalculationPerformed = true;
            double input = double.Parse(ResultsBox.Text);

            // CASE A: Percent of left operand (e.g., 200 + 10% = 200 + 20).
            if (!string.IsNullOrEmpty(CurrentOperation) && !IsOperationPending)
            {
                CurrentOpBox.Text = $"{FirstValue} {CurrentOperation} {input}%";
                SecondValue = FirstValue * input / 100;
                LastOperand = SecondValue;
                ResultsBox.Text = SecondValue.ToString();
                IsOperationPending = false;
            }
            // CASE B: Standalone percent before equals: treated as 0.
            else if (string.IsNullOrEmpty(CurrentOperation) && !IsOperationPending)
            {
                CurrentOpBox.Text = $"0 × {input}% =";
                ResultsBox.Text = "0";
                SecondValue = 0;
                LastOperand = 0;
            }
            // CASE C: After equals: percent of current result (FirstValue is the base here).
            else
            {
                double percentValue = FirstValue * input / 100;
                ResultsBox.Text = percentValue.ToString();
                CurrentOpBox.Text = $"{percentValue}=";
                SecondValue = percentValue;
                LastOperand = percentValue;
                CurrentOperation = string.Empty;
                IsOperationPending = true;
            }
        }
        private void RootButton_Click(object sender, EventArgs e)
        {
            CalculationPerformed = true;
            FirstValue = double.Parse(ResultsBox.Text);
            if (FirstValue < 0)
            {
                SetError("No real solution exists!");
                return;
            }

            double input = FirstValue;
            FirstValue = Math.Sqrt(FirstValue);
            ResultsBox.Text = FirstValue.ToString();
            CurrentOpBox.Text = $"√({input}) =";
            AddMemoryEntry($"√({input})");
        }
        private void PowerButton_Click(object sender, EventArgs e)
        {
            CalculationPerformed = true;
            FirstValue = double.Parse(ResultsBox.Text);
            double input = FirstValue;
            FirstValue = Math.Pow(FirstValue, 2);
            ResultsBox.Text = FirstValue.ToString();

            if (double.IsNaN(FirstValue) || double.IsInfinity(FirstValue)) // Guard against Incomputable values.
            {
                SetError("Value out of bounds!");
                return;
            }

            CurrentOpBox.Text = $"({input})² =";
            AddMemoryEntry($"({input})²");
        }
        private void Compute()  // Perform the actual computation based on the current operator.
        {
            switch (CurrentOperation)
            {
                case "+":
                    {
                        FirstValue += SecondValue;
                        break;
                    }
                case "-":
                    {
                        FirstValue -= SecondValue;
                        break;
                    }
                case "×":
                    {
                        FirstValue *= SecondValue;
                        break;
                    }
                case "÷":
                    {
                        if (SecondValue == 0)
                        {
                            SetError("Cannot divide by zero!");
                            return;
                        }
                        FirstValue /= (double)SecondValue;
                        break;
                    }
            }

            if ((double.IsInfinity(FirstValue) || double.IsNaN(FirstValue))) // Guard against Incomputable values.
            {
                SetError("Value out of bounds!");
                return;
            }

            ResultsBox.Text = FirstValue.ToString();
            IsOperationPending = true;
            CalculationPerformed = true;
        }
    }
}
