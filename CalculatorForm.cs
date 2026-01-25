using System;
using System.Windows.Forms;

// This program is a calculator built with C#, WinForms mode.
// Made by @VukiP, who is alive.

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
        private bool IsError = false;   
        private bool CalculationPerformed = false; // For proper Backspace functioning.

        private readonly List<string> MemoryHistory = []; // Memory, dude, memory.
        public Calculator()
        {
            InitializeComponent();
            MemoryHistory = [];
            MemoryDeleteButton.Enabled = false;
            MemoryCopyButton.Enabled = false;
            MemoryListView.Columns.Add("Memory", -2, HorizontalAlignment.Right); // Absolutely necessary for memory to even work.
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
                ResultsBox.Text += '.'; // Yay, decimals!
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
        private void SetError(string message)  
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
                foreach (Control c in Controls)
                {
                    if (c is Button button && button.Parent != MemoryPanel)
                    {
                        button.Enabled =
                        button.Name == "ClearAllButton" ||
                        button.Name == "ClearEntryButton";
                    }
                }
            }
        }
        private void ResetAfterError() 
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
        private void MemoryListView_DoubleClick(object sender, EventArgs e) // Pasting into ResultsBox and CurrentOpBox.
        {
            // Do nothing if no item is selected.
            if (MemoryListView.SelectedItems.Count == 0)
            { 
                return;
            }
            // Get the text of the selected Memory entry.
            string entry = MemoryListView.SelectedItems[0].Text;

            // Find the position of the '=' character in the Memory string.
            int equalsIndex = entry.IndexOf('=');

            // If '=' is not found, do nothing.
            if (equalsIndex < 0)
            { 
                return;
            }

            // Extract the expression (everything before '=') and trim whitespace.
            string expression = entry[..equalsIndex].Trim();

            // Extract the result (everything after '=') and trim whitespace.
            string result = entry[(equalsIndex + 1)..].Trim();

            ResultsBox.Text = result;
            CurrentOpBox.Text = expression + " =";

            if (IsError)
            {
                ResetAfterError();
            }

            CurrentOperation = "";
            IsOperationPending = true;
            CalculationPerformed = false;
        }
        private void AddMemoryEntry(string expression)
        {
            if (IsError)
            { 
               return;
            }

            string entry = $"{expression} = {ResultsBox.Text}";

            // Add the entry to the internal MemoryHistory list.
            MemoryHistory.Add(entry);

            // Create a new ListView item for display in the MemoryListView.
            var item = new ListViewItem([entry]);

            // Add the item to the MemoryListView.
            MemoryListView.Items.Add(item);

            // Automatically scroll the MemoryListView to make the newest item visible.
            item.EnsureVisible();
        }
        private void MemoryListView_SelectedIndexChanged(object sender, EventArgs e) // Handles the selection change event for the MemoryListView.
        {
            // Enable the Delete and Copy buttons only if an item is selected.
            bool hasSelection = MemoryListView.SelectedItems.Count > 0;
            MemoryDeleteButton.Enabled = hasSelection;
            MemoryCopyButton.Enabled = hasSelection;
        }
        private void MemoryCopyButton_Click(object sender, EventArgs e)
        {
            // Do nothing if no item is selected.
            if (MemoryListView.SelectedItems.Count == 0)
            { 
                return; 
            }

            // Copy the text of the selected item to the clipboard.
            Clipboard.SetText(MemoryListView.SelectedItems[0].Text);
        }
        private void MemoryDeleteButton_Click(object sender, EventArgs e) 
        {
            // If Shift is held, clear all memory.
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                MemoryListView.Items.Clear(); // Remove all items from the ListView.
                MemoryHistory.Clear(); // Clear the internal memory history.
                MemoryDeleteButton.Enabled = false; 
                MemoryCopyButton.Enabled = false;
                return;
            }

            // Do nothing if no item is selected.
            if (MemoryListView.SelectedIndices.Count == 0)
            {
                return;
            }

            // Get the index of the selected item.
            int index = MemoryListView.SelectedIndices[0];

            // Remove the selected item from the ListView.
            MemoryListView.Items.RemoveAt(index);

            // Remove the corresponding entry from the internal memory history.
            MemoryHistory.RemoveAt(index);
        }

    }
}