namespace CalculatorWinForms
{
    public partial class Calculator : Form
    {
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
        private void MemoryToggleButton_Click(object sender, EventArgs e)
        {
            if (IsMemoryVisible)
            {
                // Hide memory and shrink the window.
                MemoryPanel.Visible = false;
                this.Width -= MemoryPanelWidth;
                MemoryToggleButton.Text = ">";
            }
            else
            {
                // Show memory and expand the window.
                this.Width += MemoryPanelWidth;
                MemoryPanel.Visible = true;
                MemoryToggleButton.Text = "<";
            }

            IsMemoryVisible = !IsMemoryVisible;
        }
    }
}
