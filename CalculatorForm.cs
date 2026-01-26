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
        private bool IsMemoryVisible = true;
        private readonly int MemoryPanelWidth;

        private readonly List<string> MemoryHistory = []; // Memory dude, memory.
        public Calculator()
        {
            InitializeComponent();
            MemoryHistory = [];
            MemoryDeleteButton.Enabled = false;
            MemoryCopyButton.Enabled = false;
            MemoryListView.Columns.Add("Memory", -2, HorizontalAlignment.Right); // Absolutely necessary for memory to even work.
            MemoryPanelWidth = MemoryPanel.Width;
        }
    }
}