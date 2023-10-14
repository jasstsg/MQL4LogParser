namespace MQL4LogParser
{
    partial class MQL4LogParserForm
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
            InputGroupBox = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            ProcessLogFileButton = new Button();
            ShiftHoursNumericUpDown = new NumericUpDown();
            BrowseButton = new Button();
            LogFilePathTextBox = new TextBox();
            BrowseLogFilesDialog = new OpenFileDialog();
            OutputGroupBox = new GroupBox();
            HourlyReportButton = new Button();
            DailyReportButton = new Button();
            EndDateTimePicker = new DateTimePicker();
            StartDateTimePicker = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            StandardReportButton = new Button();
            InformationGroupBox = new GroupBox();
            LoggerTextBox = new TextBox();
            InputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ShiftHoursNumericUpDown).BeginInit();
            OutputGroupBox.SuspendLayout();
            InformationGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // InputGroupBox
            // 
            InputGroupBox.Controls.Add(label4);
            InputGroupBox.Controls.Add(label3);
            InputGroupBox.Controls.Add(ProcessLogFileButton);
            InputGroupBox.Controls.Add(ShiftHoursNumericUpDown);
            InputGroupBox.Controls.Add(BrowseButton);
            InputGroupBox.Controls.Add(LogFilePathTextBox);
            InputGroupBox.Location = new Point(11, 11);
            InputGroupBox.Name = "InputGroupBox";
            InputGroupBox.Size = new Size(674, 92);
            InputGroupBox.TabIndex = 0;
            InputGroupBox.TabStop = false;
            InputGroupBox.Text = "Input";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(160, 57);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 8;
            label4.Text = "hours";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 57);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 7;
            label3.Text = "Shift log date by";
            // 
            // ProcessLogFileButton
            // 
            ProcessLogFileButton.Enabled = false;
            ProcessLogFileButton.Location = new Point(204, 51);
            ProcessLogFileButton.Name = "ProcessLogFileButton";
            ProcessLogFileButton.Size = new Size(459, 27);
            ProcessLogFileButton.TabIndex = 2;
            ProcessLogFileButton.Text = "Process log file";
            ProcessLogFileButton.UseVisualStyleBackColor = true;
            ProcessLogFileButton.Click += ProcessLogFileButton_Click;
            // 
            // ShiftHoursNumericUpDown
            // 
            ShiftHoursNumericUpDown.Location = new Point(105, 55);
            ShiftHoursNumericUpDown.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            ShiftHoursNumericUpDown.Minimum = new decimal(new int[] { 12, 0, 0, int.MinValue });
            ShiftHoursNumericUpDown.Name = "ShiftHoursNumericUpDown";
            ShiftHoursNumericUpDown.Size = new Size(49, 23);
            ShiftHoursNumericUpDown.TabIndex = 0;
            ShiftHoursNumericUpDown.TextAlign = HorizontalAlignment.Center;
            ShiftHoursNumericUpDown.ValueChanged += ShiftHoursNumericUpDown_ValueChanged;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(563, 16);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(100, 25);
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "Browse log files";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // LogFilePathTextBox
            // 
            LogFilePathTextBox.Location = new Point(6, 18);
            LogFilePathTextBox.Name = "LogFilePathTextBox";
            LogFilePathTextBox.Size = new Size(551, 23);
            LogFilePathTextBox.TabIndex = 0;
            LogFilePathTextBox.TextChanged += LogFilePathTextBox_TextChanged;
            // 
            // OutputGroupBox
            // 
            OutputGroupBox.Controls.Add(HourlyReportButton);
            OutputGroupBox.Controls.Add(DailyReportButton);
            OutputGroupBox.Controls.Add(EndDateTimePicker);
            OutputGroupBox.Controls.Add(StartDateTimePicker);
            OutputGroupBox.Controls.Add(label2);
            OutputGroupBox.Controls.Add(label1);
            OutputGroupBox.Controls.Add(StandardReportButton);
            OutputGroupBox.Location = new Point(11, 109);
            OutputGroupBox.Name = "OutputGroupBox";
            OutputGroupBox.Size = new Size(674, 80);
            OutputGroupBox.TabIndex = 1;
            OutputGroupBox.TabStop = false;
            OutputGroupBox.Text = "Output";
            // 
            // HourlyReportButton
            // 
            HourlyReportButton.Enabled = false;
            HourlyReportButton.Location = new Point(360, 19);
            HourlyReportButton.Name = "HourlyReportButton";
            HourlyReportButton.Size = new Size(150, 52);
            HourlyReportButton.TabIndex = 6;
            HourlyReportButton.Text = "Hourly Report";
            HourlyReportButton.UseVisualStyleBackColor = true;
            HourlyReportButton.Click += HourlyReportButton_Click;
            // 
            // DailyReportButton
            // 
            DailyReportButton.Enabled = false;
            DailyReportButton.Location = new Point(516, 19);
            DailyReportButton.Name = "DailyReportButton";
            DailyReportButton.Size = new Size(150, 52);
            DailyReportButton.TabIndex = 5;
            DailyReportButton.Text = "Daily Report";
            DailyReportButton.UseVisualStyleBackColor = true;
            DailyReportButton.Click += DailyReportButton_Click;
            // 
            // EndDateTimePicker
            // 
            EndDateTimePicker.CustomFormat = "MMM dd, yyyy - HH:mm:ss";
            EndDateTimePicker.Enabled = false;
            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.Location = new Point(43, 48);
            EndDateTimePicker.Name = "EndDateTimePicker";
            EndDateTimePicker.Size = new Size(158, 23);
            EndDateTimePicker.TabIndex = 4;
            // 
            // StartDateTimePicker
            // 
            StartDateTimePicker.CustomFormat = "MMM dd, yyyy - HH:mm:ss";
            StartDateTimePicker.Enabled = false;
            StartDateTimePicker.Format = DateTimePickerFormat.Custom;
            StartDateTimePicker.Location = new Point(43, 21);
            StartDateTimePicker.Name = "StartDateTimePicker";
            StartDateTimePicker.Size = new Size(158, 23);
            StartDateTimePicker.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 54);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 2;
            label2.Text = "End";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 27);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Start";
            // 
            // StandardReportButton
            // 
            StandardReportButton.Enabled = false;
            StandardReportButton.Location = new Point(204, 19);
            StandardReportButton.Name = "StandardReportButton";
            StandardReportButton.Size = new Size(150, 52);
            StandardReportButton.TabIndex = 0;
            StandardReportButton.Text = "Standard Report";
            StandardReportButton.UseVisualStyleBackColor = true;
            StandardReportButton.Click += StandardReportButton_Click;
            // 
            // InformationGroupBox
            // 
            InformationGroupBox.Controls.Add(LoggerTextBox);
            InformationGroupBox.Location = new Point(11, 195);
            InformationGroupBox.Name = "InformationGroupBox";
            InformationGroupBox.Size = new Size(674, 224);
            InformationGroupBox.TabIndex = 2;
            InformationGroupBox.TabStop = false;
            InformationGroupBox.Text = "Information";
            // 
            // LoggerTextBox
            // 
            LoggerTextBox.Location = new Point(7, 17);
            LoggerTextBox.Multiline = true;
            LoggerTextBox.Name = "LoggerTextBox";
            LoggerTextBox.ReadOnly = true;
            LoggerTextBox.ScrollBars = ScrollBars.Vertical;
            LoggerTextBox.Size = new Size(658, 200);
            LoggerTextBox.TabIndex = 0;
            // 
            // MQL4LogParserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 426);
            Controls.Add(InformationGroupBox);
            Controls.Add(OutputGroupBox);
            Controls.Add(InputGroupBox);
            Name = "MQL4LogParserForm";
            Text = "MQL4 Log Parser v1.1";
            FormClosing += MQL4LogParserForm_FormClosing;
            InputGroupBox.ResumeLayout(false);
            InputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ShiftHoursNumericUpDown).EndInit();
            OutputGroupBox.ResumeLayout(false);
            OutputGroupBox.PerformLayout();
            InformationGroupBox.ResumeLayout(false);
            InformationGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox InputGroupBox;
        private TextBox LogFilePathTextBox;
        private OpenFileDialog BrowseLogFilesDialog;
        private GroupBox OutputGroupBox;
        private Button StandardReportButton;
        private GroupBox InformationGroupBox;
        private TextBox LoggerTextBox;
        private Label label1;
        private DateTimePicker EndDateTimePicker;
        private DateTimePicker StartDateTimePicker;
        private Label label2;
        private Button ProcessLogFileButton;
        private Button BrowseButton;
        private Button DailyReportButton;
        private Button HourlyReportButton;
        private Label label3;
        private NumericUpDown ShiftHoursNumericUpDown;
        private Label label4;
    }
}