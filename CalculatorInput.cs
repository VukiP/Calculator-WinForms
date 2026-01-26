using System;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class Calculator : Form
    {
        private void DigitButton_Click(object sender, EventArgs e) // Digit buttons wired to one event handler. 
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
                ResultsBox.Text += '.'; // Yay, decimals!
            }

            UpdateCurrentOpBox();
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
                    ResultsBox.Text = ResultsBox.Text[..^5]; // Crude workaround, not gonna lie. 
                }

                UpdateCurrentOpBox();
            }

            else
            {
                return;
            }
        }
        private void UpdateCurrentOpBox() // Update OpBox depending on it's state.
        {
            if (IsError)
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
