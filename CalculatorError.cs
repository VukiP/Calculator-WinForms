using System;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class Calculator : Form
    {
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
    }
}
