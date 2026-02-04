namespace CalculatorWinForms
{
    partial class Calculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            DigitOneButton = new Button();
            DigitTwoButton = new Button();
            DigitThreeButton = new Button();
            DigitFourButton = new Button();
            DigitFiveButton = new Button();
            DigitSixButton = new Button();
            DigitSevenButton = new Button();
            DigitEightButton = new Button();
            DigitNineButton = new Button();
            DigitZeroButton = new Button();
            DecimalButton = new Button();
            ClearEntryButton = new Button();
            EqualsButton = new Button();
            AddButton = new Button();
            ClearAllButton = new Button();
            SubtractButton = new Button();
            MultiplyButton = new Button();
            DivideButton = new Button();
            AdditiveInverseButton = new Button();
            PercentButton = new Button();
            ReciprocalButton = new Button();
            RootButton = new Button();
            PowerButton = new Button();
            BackspaceButton = new Button();
            ResultsBox = new TextBox();
            CurrentOpBox = new TextBox();
            MemoryPanel = new Panel();
            MemoryListView = new ListView();
            MemoryToolbarPanel = new Panel();
            MemoryCopyButton = new Button();
            MemoryDeleteButton = new Button();
            MemoryToggleButton = new Button();
            MemoryPanel.SuspendLayout();
            MemoryToolbarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DigitOneButton
            // 
            DigitOneButton.BackColor = Color.Gainsboro;
            DigitOneButton.FlatStyle = FlatStyle.Flat;
            DigitOneButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitOneButton.Location = new Point(28, 132);
            DigitOneButton.Name = "DigitOneButton";
            DigitOneButton.Size = new Size(89, 71);
            DigitOneButton.TabIndex = 0;
            DigitOneButton.Text = "1";
            DigitOneButton.UseMnemonic = false;
            DigitOneButton.UseVisualStyleBackColor = true;
            DigitOneButton.Click += DigitButton_Click;
            // 
            // DigitTwoButton
            // 
            DigitTwoButton.BackColor = Color.Gainsboro;
            DigitTwoButton.FlatStyle = FlatStyle.Flat;
            DigitTwoButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitTwoButton.Location = new Point(123, 132);
            DigitTwoButton.Name = "DigitTwoButton";
            DigitTwoButton.Size = new Size(89, 71);
            DigitTwoButton.TabIndex = 1;
            DigitTwoButton.Text = "2";
            DigitTwoButton.UseVisualStyleBackColor = false;
            DigitTwoButton.Click += DigitButton_Click;
            // 
            // DigitThreeButton
            // 
            DigitThreeButton.BackColor = Color.Gainsboro;
            DigitThreeButton.FlatStyle = FlatStyle.Flat;
            DigitThreeButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitThreeButton.Location = new Point(218, 132);
            DigitThreeButton.Name = "DigitThreeButton";
            DigitThreeButton.Size = new Size(89, 71);
            DigitThreeButton.TabIndex = 2;
            DigitThreeButton.Text = "3";
            DigitThreeButton.UseVisualStyleBackColor = false;
            DigitThreeButton.Click += DigitButton_Click;
            // 
            // DigitFourButton
            // 
            DigitFourButton.BackColor = Color.Gainsboro;
            DigitFourButton.FlatStyle = FlatStyle.Flat;
            DigitFourButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitFourButton.Location = new Point(28, 209);
            DigitFourButton.Name = "DigitFourButton";
            DigitFourButton.Size = new Size(89, 71);
            DigitFourButton.TabIndex = 3;
            DigitFourButton.Text = "4";
            DigitFourButton.UseVisualStyleBackColor = false;
            DigitFourButton.Click += DigitButton_Click;
            // 
            // DigitFiveButton
            // 
            DigitFiveButton.BackColor = Color.Gainsboro;
            DigitFiveButton.FlatStyle = FlatStyle.Flat;
            DigitFiveButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitFiveButton.Location = new Point(123, 209);
            DigitFiveButton.Name = "DigitFiveButton";
            DigitFiveButton.Size = new Size(89, 71);
            DigitFiveButton.TabIndex = 4;
            DigitFiveButton.Text = "5";
            DigitFiveButton.UseVisualStyleBackColor = false;
            DigitFiveButton.Click += DigitButton_Click;
            // 
            // DigitSixButton
            // 
            DigitSixButton.BackColor = Color.Gainsboro;
            DigitSixButton.FlatStyle = FlatStyle.Flat;
            DigitSixButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitSixButton.Location = new Point(218, 209);
            DigitSixButton.Name = "DigitSixButton";
            DigitSixButton.Size = new Size(89, 71);
            DigitSixButton.TabIndex = 5;
            DigitSixButton.Text = "6";
            DigitSixButton.UseVisualStyleBackColor = false;
            DigitSixButton.Click += DigitButton_Click;
            // 
            // DigitSevenButton
            // 
            DigitSevenButton.BackColor = Color.Gainsboro;
            DigitSevenButton.FlatStyle = FlatStyle.Flat;
            DigitSevenButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitSevenButton.Location = new Point(28, 285);
            DigitSevenButton.Name = "DigitSevenButton";
            DigitSevenButton.Size = new Size(89, 71);
            DigitSevenButton.TabIndex = 6;
            DigitSevenButton.Text = "7";
            DigitSevenButton.UseVisualStyleBackColor = false;
            DigitSevenButton.Click += DigitButton_Click;
            // 
            // DigitEightButton
            // 
            DigitEightButton.BackColor = Color.Gainsboro;
            DigitEightButton.FlatStyle = FlatStyle.Flat;
            DigitEightButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitEightButton.Location = new Point(123, 285);
            DigitEightButton.Name = "DigitEightButton";
            DigitEightButton.Size = new Size(89, 71);
            DigitEightButton.TabIndex = 7;
            DigitEightButton.Text = "8";
            DigitEightButton.UseVisualStyleBackColor = false;
            DigitEightButton.Click += DigitButton_Click;
            // 
            // DigitNineButton
            // 
            DigitNineButton.BackColor = Color.Gainsboro;
            DigitNineButton.FlatStyle = FlatStyle.Flat;
            DigitNineButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitNineButton.Location = new Point(218, 286);
            DigitNineButton.Name = "DigitNineButton";
            DigitNineButton.Size = new Size(89, 71);
            DigitNineButton.TabIndex = 8;
            DigitNineButton.Text = "9";
            DigitNineButton.UseVisualStyleBackColor = false;
            DigitNineButton.Click += DigitButton_Click;
            // 
            // DigitZeroButton
            // 
            DigitZeroButton.BackColor = Color.Gainsboro;
            DigitZeroButton.FlatStyle = FlatStyle.Flat;
            DigitZeroButton.Font = new Font("Maiandra GD", 19.8000011F);
            DigitZeroButton.Location = new Point(28, 362);
            DigitZeroButton.Name = "DigitZeroButton";
            DigitZeroButton.Size = new Size(184, 71);
            DigitZeroButton.TabIndex = 9;
            DigitZeroButton.Text = "0";
            DigitZeroButton.UseVisualStyleBackColor = false;
            DigitZeroButton.Click += DigitButton_Click;
            // 
            // DecimalButton
            // 
            DecimalButton.BackColor = Color.Gainsboro;
            DecimalButton.FlatStyle = FlatStyle.Flat;
            DecimalButton.Font = new Font("Maiandra GD", 19.8000011F);
            DecimalButton.Location = new Point(218, 363);
            DecimalButton.Name = "DecimalButton";
            DecimalButton.Size = new Size(89, 71);
            DecimalButton.TabIndex = 10;
            DecimalButton.Text = ",";
            DecimalButton.UseVisualStyleBackColor = false;
            DecimalButton.Click += DecimalButton_Click;
            // 
            // ClearEntryButton
            // 
            ClearEntryButton.BackColor = SystemColors.ScrollBar;
            ClearEntryButton.FlatStyle = FlatStyle.Flat;
            ClearEntryButton.Font = new Font("Maiandra GD", 19.8000011F);
            ClearEntryButton.Location = new Point(313, 132);
            ClearEntryButton.Name = "ClearEntryButton";
            ClearEntryButton.Size = new Size(78, 71);
            ClearEntryButton.TabIndex = 11;
            ClearEntryButton.Text = "CE";
            ClearEntryButton.UseVisualStyleBackColor = false;
            ClearEntryButton.Click += ClearEntryButton_Click;
            // 
            // EqualsButton
            // 
            EqualsButton.BackColor = Color.CornflowerBlue;
            EqualsButton.FlatStyle = FlatStyle.Flat;
            EqualsButton.Font = new Font("Maiandra GD", 19.8000011F);
            EqualsButton.Location = new Point(28, 439);
            EqualsButton.Name = "EqualsButton";
            EqualsButton.Size = new Size(531, 71);
            EqualsButton.TabIndex = 22;
            EqualsButton.Text = "=";
            EqualsButton.UseVisualStyleBackColor = false;
            EqualsButton.Click += EqualsButton_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = SystemColors.ScrollBar;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Font = new Font("Maiandra GD", 19.8000011F);
            AddButton.Location = new Point(313, 209);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(78, 71);
            AddButton.TabIndex = 14;
            AddButton.Text = "+";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += SimpleOp_Click;
            // 
            // ClearAllButton
            // 
            ClearAllButton.BackColor = SystemColors.ScrollBar;
            ClearAllButton.FlatStyle = FlatStyle.Flat;
            ClearAllButton.Font = new Font("Maiandra GD", 19.8000011F);
            ClearAllButton.Location = new Point(397, 132);
            ClearAllButton.Name = "ClearAllButton";
            ClearAllButton.Size = new Size(78, 71);
            ClearAllButton.TabIndex = 12;
            ClearAllButton.Text = "AC";
            ClearAllButton.UseVisualStyleBackColor = false;
            ClearAllButton.Click += ClearAllButton_Click;
            // 
            // SubtractButton
            // 
            SubtractButton.BackColor = SystemColors.ScrollBar;
            SubtractButton.FlatStyle = FlatStyle.Flat;
            SubtractButton.Font = new Font("Maiandra GD", 19.8000011F);
            SubtractButton.Location = new Point(397, 209);
            SubtractButton.Name = "SubtractButton";
            SubtractButton.Size = new Size(78, 71);
            SubtractButton.TabIndex = 15;
            SubtractButton.Text = "-";
            SubtractButton.UseVisualStyleBackColor = false;
            SubtractButton.Click += SimpleOp_Click;
            // 
            // MultiplyButton
            // 
            MultiplyButton.BackColor = SystemColors.ScrollBar;
            MultiplyButton.FlatStyle = FlatStyle.Flat;
            MultiplyButton.Font = new Font("Maiandra GD", 19.8000011F);
            MultiplyButton.Location = new Point(313, 286);
            MultiplyButton.Name = "MultiplyButton";
            MultiplyButton.Size = new Size(78, 71);
            MultiplyButton.TabIndex = 16;
            MultiplyButton.Text = "×";
            MultiplyButton.UseVisualStyleBackColor = false;
            MultiplyButton.Click += SimpleOp_Click;
            // 
            // DivideButton
            // 
            DivideButton.BackColor = SystemColors.ScrollBar;
            DivideButton.FlatStyle = FlatStyle.Flat;
            DivideButton.Font = new Font("Maiandra GD", 19.8000011F);
            DivideButton.Location = new Point(397, 285);
            DivideButton.Name = "DivideButton";
            DivideButton.Size = new Size(78, 71);
            DivideButton.TabIndex = 17;
            DivideButton.Text = "÷";
            DivideButton.UseVisualStyleBackColor = false;
            DivideButton.Click += SimpleOp_Click;
            // 
            // AdditiveInverseButton
            // 
            AdditiveInverseButton.BackColor = SystemColors.ScrollBar;
            AdditiveInverseButton.FlatStyle = FlatStyle.Flat;
            AdditiveInverseButton.Font = new Font("Maiandra GD", 19.8000011F);
            AdditiveInverseButton.Location = new Point(313, 362);
            AdditiveInverseButton.Name = "AdditiveInverseButton";
            AdditiveInverseButton.Size = new Size(78, 71);
            AdditiveInverseButton.TabIndex = 19;
            AdditiveInverseButton.Text = "+/-";
            AdditiveInverseButton.UseVisualStyleBackColor = false;
            AdditiveInverseButton.Click += AdditiveInverseButton_Click;
            // 
            // PercentButton
            // 
            PercentButton.BackColor = SystemColors.ScrollBar;
            PercentButton.FlatStyle = FlatStyle.Flat;
            PercentButton.Font = new Font("Maiandra GD", 19.8000011F);
            PercentButton.Location = new Point(481, 362);
            PercentButton.Name = "PercentButton";
            PercentButton.Size = new Size(78, 71);
            PercentButton.TabIndex = 21;
            PercentButton.Text = "%";
            PercentButton.UseVisualStyleBackColor = false;
            PercentButton.Click += PercentButton_Click;
            // 
            // ReciprocalButton
            // 
            ReciprocalButton.BackColor = SystemColors.ScrollBar;
            ReciprocalButton.FlatStyle = FlatStyle.Flat;
            ReciprocalButton.Font = new Font("Maiandra GD", 19.8000011F);
            ReciprocalButton.Location = new Point(397, 362);
            ReciprocalButton.Name = "ReciprocalButton";
            ReciprocalButton.Size = new Size(78, 71);
            ReciprocalButton.TabIndex = 20;
            ReciprocalButton.Text = "1/x";
            ReciprocalButton.UseVisualStyleBackColor = false;
            ReciprocalButton.Click += ReciprocalButton_Click;
            // 
            // RootButton
            // 
            RootButton.BackColor = SystemColors.ScrollBar;
            RootButton.FlatStyle = FlatStyle.Flat;
            RootButton.Font = new Font("Maiandra GD", 19.8000011F);
            RootButton.Location = new Point(481, 285);
            RootButton.Name = "RootButton";
            RootButton.Size = new Size(78, 71);
            RootButton.TabIndex = 18;
            RootButton.Text = "√x";
            RootButton.UseVisualStyleBackColor = false;
            RootButton.Click += RootButton_Click;
            // 
            // PowerButton
            // 
            PowerButton.BackColor = SystemColors.ScrollBar;
            PowerButton.FlatStyle = FlatStyle.Flat;
            PowerButton.Font = new Font("Maiandra GD", 19.8000011F);
            PowerButton.Location = new Point(481, 209);
            PowerButton.Name = "PowerButton";
            PowerButton.Size = new Size(78, 71);
            PowerButton.TabIndex = 16;
            PowerButton.Text = "x²";
            PowerButton.UseVisualStyleBackColor = false;
            PowerButton.Click += PowerButton_Click;
            // 
            // BackspaceButton
            // 
            BackspaceButton.BackColor = SystemColors.ScrollBar;
            BackspaceButton.FlatStyle = FlatStyle.Flat;
            BackspaceButton.Font = new Font("Maiandra GD", 19.8000011F);
            BackspaceButton.Location = new Point(481, 132);
            BackspaceButton.Name = "BackspaceButton";
            BackspaceButton.Size = new Size(78, 71);
            BackspaceButton.TabIndex = 13;
            BackspaceButton.Text = "⌫";
            BackspaceButton.UseVisualStyleBackColor = false;
            BackspaceButton.Click += BackspaceButton_Click;
            // 
            // ResultsBox
            // 
            ResultsBox.BackColor = Color.WhiteSmoke;
            ResultsBox.Font = new Font("Maiandra GD", 22F);
            ResultsBox.ForeColor = Color.Black;
            ResultsBox.Location = new Point(28, 70);
            ResultsBox.Name = "ResultsBox";
            ResultsBox.ReadOnly = true;
            ResultsBox.RightToLeft = RightToLeft.No;
            ResultsBox.Size = new Size(531, 51);
            ResultsBox.TabIndex = 23;
            ResultsBox.Text = "0";
            ResultsBox.TextAlign = HorizontalAlignment.Right;
            // 
            // CurrentOpBox
            // 
            CurrentOpBox.BackColor = Color.White;
            CurrentOpBox.BorderStyle = BorderStyle.None;
            CurrentOpBox.Font = new Font("Maiandra GD", 14F);
            CurrentOpBox.Location = new Point(159, 36);
            CurrentOpBox.Name = "CurrentOpBox";
            CurrentOpBox.ReadOnly = true;
            CurrentOpBox.RightToLeft = RightToLeft.No;
            CurrentOpBox.Size = new Size(400, 28);
            CurrentOpBox.TabIndex = 24;
            CurrentOpBox.Text = "Made by VukiP.";
            CurrentOpBox.TextAlign = HorizontalAlignment.Right;
            // 
            // MemoryPanel
            // 
            MemoryPanel.Controls.Add(MemoryListView);
            MemoryPanel.Controls.Add(MemoryToolbarPanel);
            MemoryPanel.Font = new Font("Maiandra GD", 19.8000011F);
            MemoryPanel.Location = new Point(581, 15);
            MemoryPanel.Name = "MemoryPanel";
            MemoryPanel.Size = new Size(370, 495);
            MemoryPanel.TabIndex = 25;
            // 
            // MemoryListView
            // 
            MemoryListView.BorderStyle = BorderStyle.None;
            MemoryListView.Font = new Font("Maiandra GD", 14F);
            MemoryListView.FullRowSelect = true;
            MemoryListView.HeaderStyle = ColumnHeaderStyle.None;
            MemoryListView.Location = new Point(0, 52);
            MemoryListView.Name = "MemoryListView";
            MemoryListView.Size = new Size(374, 440);
            MemoryListView.TabIndex = 27;
            MemoryListView.UseCompatibleStateImageBehavior = false;
            MemoryListView.View = View.Details;
            MemoryListView.SelectedIndexChanged += MemoryListView_SelectedIndexChanged;
            MemoryListView.DoubleClick += MemoryListView_DoubleClick;
            // 
            // MemoryToolbarPanel
            // 
            MemoryToolbarPanel.Controls.Add(MemoryCopyButton);
            MemoryToolbarPanel.Controls.Add(MemoryDeleteButton);
            MemoryToolbarPanel.Location = new Point(3, 3);
            MemoryToolbarPanel.Name = "MemoryToolbarPanel";
            MemoryToolbarPanel.Size = new Size(364, 46);
            MemoryToolbarPanel.TabIndex = 0;
            // 
            // MemoryCopyButton
            // 
            MemoryCopyButton.Font = new Font("Maiandra GD", 20F);
            MemoryCopyButton.Location = new Point(0, -3);
            MemoryCopyButton.Name = "MemoryCopyButton";
            MemoryCopyButton.Size = new Size(185, 49);
            MemoryCopyButton.TabIndex = 25;
            MemoryCopyButton.Text = "COPY";
            MemoryCopyButton.UseVisualStyleBackColor = true;
            MemoryCopyButton.Click += MemoryCopyButton_Click;
            // 
            // MemoryDeleteButton
            // 
            MemoryDeleteButton.Font = new Font("Maiandra GD", 20F);
            MemoryDeleteButton.Location = new Point(182, -3);
            MemoryDeleteButton.Name = "MemoryDeleteButton";
            MemoryDeleteButton.Size = new Size(185, 49);
            MemoryDeleteButton.TabIndex = 26;
            MemoryDeleteButton.Text = "DELETE";
            MemoryDeleteButton.UseVisualStyleBackColor = true;
            MemoryDeleteButton.Click += MemoryDeleteButton_Click;
            // 
            // MemoryToggleButton
            // 
            MemoryToggleButton.Font = new Font("Maiandra GD", 19.8000011F);
            MemoryToggleButton.Location = new Point(28, 15);
            MemoryToggleButton.Name = "MemoryToggleButton";
            MemoryToggleButton.Size = new Size(89, 49);
            MemoryToggleButton.TabIndex = 26;
            MemoryToggleButton.Text = "<";
            MemoryToggleButton.UseVisualStyleBackColor = true;
            MemoryToggleButton.Click += MemoryToggleButton_Click;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(967, 525);
            Controls.Add(MemoryToggleButton);
            Controls.Add(MemoryPanel);
            Controls.Add(CurrentOpBox);
            Controls.Add(ResultsBox);
            Controls.Add(BackspaceButton);
            Controls.Add(PowerButton);
            Controls.Add(RootButton);
            Controls.Add(ReciprocalButton);
            Controls.Add(PercentButton);
            Controls.Add(AdditiveInverseButton);
            Controls.Add(DivideButton);
            Controls.Add(MultiplyButton);
            Controls.Add(SubtractButton);
            Controls.Add(ClearAllButton);
            Controls.Add(AddButton);
            Controls.Add(EqualsButton);
            Controls.Add(ClearEntryButton);
            Controls.Add(DecimalButton);
            Controls.Add(DigitZeroButton);
            Controls.Add(DigitNineButton);
            Controls.Add(DigitEightButton);
            Controls.Add(DigitSevenButton);
            Controls.Add(DigitSixButton);
            Controls.Add(DigitFiveButton);
            Controls.Add(DigitFourButton);
            Controls.Add(DigitThreeButton);
            Controls.Add(DigitTwoButton);
            Controls.Add(DigitOneButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Calculator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculator ";
            MemoryPanel.ResumeLayout(false);
            MemoryToolbarPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DigitOneButton;
        private Button DigitTwoButton;
        private Button DigitThreeButton;
        private Button DigitFourButton;
        private Button DigitFiveButton;
        private Button DigitSixButton;
        private Button DigitSevenButton;
        private Button DigitEightButton;
        private Button DigitNineButton;
        private Button DigitZeroButton;
        private Button DecimalButton;
        private Button ClearEntryButton;
        private Button EqualsButton;
        private Button AddButton;
        private Button ClearAllButton;
        private Button SubtractButton;
        private Button MultiplyButton;
        private Button DivideButton;
        private Button AdditiveInverseButton;
        private Button PercentButton;
        private Button ReciprocalButton;
        private Button RootButton;
        private Button PowerButton;
        private Button BackspaceButton;
        private TextBox ResultsBox;
        private TextBox CurrentOpBox;
        private Panel MemoryPanel;
        private Panel MemoryToolbarPanel;
        private Button MemoryDeleteButton;
        private Button MemoryCopyButton;
        private ListView MemoryListView;
        private Button MemoryToggleButton;
    }
}
