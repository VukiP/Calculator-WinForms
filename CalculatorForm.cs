using System;
using System.Windows.Forms;

// This program is a calculator built with C#, WinForms mode.
// And below this is the source code, with comments.

namespace CalculatorWinForms
{
    public partial class Calculator : Form
    {
        private double FirstValue = 0;
        private double SecondValue = 0;

        // Stores the last operand used in repeated ("sticky") operations.
        // Example: '2 + 3 ====' -> LastOperand = 3, so the sequence goes like this: 5 -> 8 -> 11 -> 14.
        private double LastOperand = 0;

        private string CurrentOperation = "";
        private bool IsOperationPending = false;
        private bool IsError = false;   // Tracks whether the calculator is in an error state.
        private bool CalculationPerformed = false; // For proper Backspace functioning.
        public Calculator()
        {
            InitializeComponent(); 
        }
        private void Digit_Click(object sender, EventArgs e) // Digit buttons wired to one event handler. 
        {
            Button clicked = (Button)sender; 

            if (IsOperationPending || ResultsBox.Text == "0") 
            {
                ResultsBox.Text = clicked.Text; 
                IsOperationPending = false; 
                CurrentOpBox.Text = ""; 
            }

            else 
            {
                ResultsBox.Text += clicked.Text; 
            }

            UpdateCurrentOpBox();
        }
        private void DecimalButton_Click(object sender, EventArgs e)  
        {
            if (!ResultsBox.Text.Contains('.')) 
            {
                ResultsBox.Text += '.'; 
            }

            UpdateCurrentOpBox();
        }
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
                CurrentOpBox.Text = expressionLabel + " ="; 
                IsOperationPending = true; 
            }
        }
        private void ClearAllButton_Click(object sender, EventArgs e) 
        {
            ResultsBox.Text = "0"; 
            FirstValue = 0;
            SecondValue = 0;
            LastOperand = 0;
            CurrentOperation = string.Empty;
            CurrentOpBox.Text = ""; 
            IsOperationPending = false;
            CalculationPerformed = false;

            ResetAfterError(); 
            UpdateCurrentOpBox(); 
        }
        private void ClearEntryButton_Click(object sender, EventArgs e) 
        {
            ResultsBox.Text = "0"; 

            // CASE A: Operator is active -> Clear the right operand.
            if (!string.IsNullOrEmpty(CurrentOperation))
            {
                SecondValue = 0; 
                LastOperand = 0; 
                IsOperationPending = true;
                CalculationPerformed = false;
                CurrentOpBox.Text = $"{FirstValue} {CurrentOperation}"; 
            }
            // CASE B: No operator active -> Clear entry only.
            else
            {
                FirstValue = 0; 
                IsOperationPending = true; 
                CurrentOpBox.Text = "Made by VukiP."; 
            }

            ResetAfterError(); 
        }
        private void BackspaceButton_Click(object sender, EventArgs e) 
        {
            if (!CalculationPerformed)
            {
                if (!ResultsBox.Text.Contains('E'))
                {
                    // CASE A: More than one character in the display.
                    if (ResultsBox.Text.Length > 1)
                    {
                        ResultsBox.Text = ResultsBox.Text[..^1]; // Slice off the last character.
                        LastOperand = double.Parse(ResultsBox.Text);
                    }
                    // CASE B: Only one character left -> Reset to 0.
                    else
                    {
                        SecondValue = 0;
                        LastOperand = 0;
                        ResultsBox.Text = "0";
                    }
                }
                else
                {
                    ResultsBox.Text = ResultsBox.Text[..^5]; // Not gonna lie, this way of preventing errors with scientific notations is AWFUL.
                                                             // I'll fix this when I gather enough coding knowledge.
                }

                UpdateCurrentOpBox();
            }

            else 
            {
                return;
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
        }
        private void ReciprocalButton_Click(object sender, EventArgs e) // Event handler for  Reciprocal (1/x).
        {
            try 
            {
                FirstValue = double.Parse(ResultsBox.Text); 

                if (FirstValue == 0)
                {
                    throw new DivideByZeroException(); 
                }

                double input = FirstValue; 
                FirstValue = 1 / FirstValue; 
                ResultsBox.Text = FirstValue.ToString(); 
                CurrentOpBox.Text = $"1/({input}) ="; 
            }
            catch (DivideByZeroException) // Division by zero caught!
            {
                SetError("Cannot divide by zero!"); 
            }
        }
        private void PercentButton_Click(object sender, EventArgs e) 
        {
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
        private void RootButton_Click(object sender, EventArgs e)  // Event handler for 'square root' button.
        {
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
        }
        private void PowerButton_Click(object sender, EventArgs e)  // Event handler for 'power' button.
        {
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
                    FirstValue /= SecondValue; 
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
        }
        private void SetError(string message)  // Error handling: Puts calculator into error mode.
        {
            ResultsBox.Text = message; 
            CurrentOpBox.Text = "Reset the calculator!"; 
            IsError = true; 
            DisableAllButtons(); 
            CurrentOpBox.Refresh();

            // (graphical improvement)
            ResultsBox.SelectionStart = ResultsBox.Text.Length; 
            ResultsBox.SelectionLength = 0;
        }

        private void DisableAllButtons() 
        {
            if (IsError) 
            {
                foreach (Control c in this.Controls) 
                {
                    if (c is Button b) 
                    {
                        b.Enabled = b.Name == "ClearAllButton" || b.Name == "ClearEntryButton"; // Leave AC and CE enabled ONLY.
                    }
                }
            }
        }

        private void ResetAfterError() // Reset Calculator after Error -> Re‑enable all buttons.
        {
            IsError = false; 
            foreach (Control c in this.Controls) 
            {
                if (c is Button b) 
                {
                    b.Enabled = true; 
                }
            }
        }
        private void UpdateCurrentOpBox() // Update OpBox depending on it's state.
        {
            if(IsError) 
            {
                return;
            }

            // CASE A: Operator exists but waiting for input.
            if (!string.IsNullOrEmpty(CurrentOperation) && IsOperationPending)
            {
                CurrentOpBox.Text = $"{FirstValue} {CurrentOperation}"; // Example: User uses 456, then + -> OpBox.Text= "456 +".
            }
            // CASE B: Operator exists and user is typing a number.
            else if (!string.IsNullOrEmpty(CurrentOperation) && !IsOperationPending)
            {
                CurrentOpBox.Text = $"{FirstValue} {CurrentOperation} {ResultsBox.Text}"; // Example: User uses 456, then +, and continues typing something(789 -> OpBox.Text= "456 + 789").
            }
            // CASE C: Sticky repeat after equals.
            else if (string.IsNullOrEmpty(CurrentOperation) && LastOperand != 0 && IsOperationPending)
            {
                CurrentOpBox.Text = $"{FirstValue} {LastOperand} ="; // For sticky operations (456+ ====).
            }
            // DEFAULT CASE: 
            else
            {
                CurrentOpBox.Text = "Made by VukiP."; 
            }
        }
    }
}