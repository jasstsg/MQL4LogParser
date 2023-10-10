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
            ProcessLogFileButton = new Button();
            BrowseButton = new Button();
            LogFilePathTextBox = new TextBox();
            BrowseLogFilesDialog = new OpenFileDialog();
            OutputGroupBox = new GroupBox();
            GenerateHourlyReportButton = new Button();
            EndDateTimePicker = new DateTimePicker();
            StartDateTimePicker = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            GenerateStandardReportButton = new Button();
            InformationGroupBox = new GroupBox();
            LoggerTextBox = new TextBox();
            GenerateOpenedAtHourlyReportButton = new Button();
            InputGroupBox.SuspendLayout();
            OutputGroupBox.SuspendLayout();
            InformationGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // InputGroupBox
            // 
            InputGroupBox.Controls.Add(ProcessLogFileButton);
            InputGroupBox.Controls.Add(BrowseButton);
            InputGroupBox.Controls.Add(LogFilePathTextBox);
            InputGroupBox.Location = new Point(11, 11);
            InputGroupBox.Name = "InputGroupBox";
            InputGroupBox.Size = new Size(777, 100);
            InputGroupBox.TabIndex = 0;
            InputGroupBox.TabStop = false;
            InputGroupBox.Text = "Input";
            // 
            // ProcessLogFileButton
            // 
            ProcessLogFileButton.Enabled = false;
            ProcessLogFileButton.Location = new Point(392, 57);
            ProcessLogFileButton.Name = "ProcessLogFileButton";
            ProcessLogFileButton.Size = new Size(379, 37);
            ProcessLogFileButton.TabIndex = 2;
            ProcessLogFileButton.Text = "Process Log File";
            ProcessLogFileButton.UseVisualStyleBackColor = true;
            ProcessLogFileButton.Click += ProcessLogFileButton_Click;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(6, 57);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(379, 37);
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "Browse Log Files";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // LogFilePathTextBox
            // 
            LogFilePathTextBox.Location = new Point(6, 26);
            LogFilePathTextBox.Name = "LogFilePathTextBox";
            LogFilePathTextBox.Size = new Size(765, 23);
            LogFilePathTextBox.TabIndex = 0;
            LogFilePathTextBox.TextChanged += LogFilePathTextBox_TextChanged;
            // 
            // OutputGroupBox
            // 
            OutputGroupBox.Controls.Add(GenerateOpenedAtHourlyReportButton);
            OutputGroupBox.Controls.Add(GenerateHourlyReportButton);
            OutputGroupBox.Controls.Add(EndDateTimePicker);
            OutputGroupBox.Controls.Add(StartDateTimePicker);
            OutputGroupBox.Controls.Add(label2);
            OutputGroupBox.Controls.Add(label1);
            OutputGroupBox.Controls.Add(GenerateStandardReportButton);
            OutputGroupBox.Location = new Point(11, 117);
            OutputGroupBox.Name = "OutputGroupBox";
            OutputGroupBox.Size = new Size(777, 81);
            OutputGroupBox.TabIndex = 1;
            OutputGroupBox.TabStop = false;
            OutputGroupBox.Text = "Output";
            // 
            // GenerateHourlyReportButton
            // 
            GenerateHourlyReportButton.Enabled = false;
            GenerateHourlyReportButton.Location = new Point(395, 21);
            GenerateHourlyReportButton.Name = "GenerateHourlyReportButton";
            GenerateHourlyReportButton.Size = new Size(185, 50);
            GenerateHourlyReportButton.TabIndex = 5;
            GenerateHourlyReportButton.Text = "Generate Hourly Report";
            GenerateHourlyReportButton.UseVisualStyleBackColor = true;
            GenerateHourlyReportButton.Click += GenerateHourlyReportButton_Click;
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
            // GenerateStandardReportButton
            // 
            GenerateStandardReportButton.Enabled = false;
            GenerateStandardReportButton.Location = new Point(204, 21);
            GenerateStandardReportButton.Name = "GenerateStandardReportButton";
            GenerateStandardReportButton.Size = new Size(185, 50);
            GenerateStandardReportButton.TabIndex = 0;
            GenerateStandardReportButton.Text = "Generate Standard Report";
            GenerateStandardReportButton.UseVisualStyleBackColor = true;
            GenerateStandardReportButton.Click += GenerateStandardReportButton_Click;
            // 
            // InformationGroupBox
            // 
            InformationGroupBox.Controls.Add(LoggerTextBox);
            InformationGroupBox.Location = new Point(12, 204);
            InformationGroupBox.Name = "InformationGroupBox";
            InformationGroupBox.Size = new Size(776, 234);
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
            LoggerTextBox.Size = new Size(763, 211);
            LoggerTextBox.TabIndex = 0;
            // 
            // GenerateOpenedAtHourlyReportButton
            // 
            GenerateOpenedAtHourlyReportButton.Enabled = false;
            GenerateOpenedAtHourlyReportButton.Location = new Point(586, 21);
            GenerateOpenedAtHourlyReportButton.Name = "GenerateOpenedAtHourlyReportButton";
            GenerateOpenedAtHourlyReportButton.Size = new Size(185, 50);
            GenerateOpenedAtHourlyReportButton.TabIndex = 6;
            GenerateOpenedAtHourlyReportButton.Text = "Generate Opened At Hourly Report";
            GenerateOpenedAtHourlyReportButton.UseVisualStyleBackColor = true;
            GenerateOpenedAtHourlyReportButton.Click += GenerateOpenedAtHourlyReportButton_Click;
            // 
            // MQL4LogParserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(InformationGroupBox);
            Controls.Add(OutputGroupBox);
            Controls.Add(InputGroupBox);
            Name = "MQL4LogParserForm";
            Text = "MQL4 Log Parser v1.1";
            InputGroupBox.ResumeLayout(false);
            InputGroupBox.PerformLayout();
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
        private Button GenerateStandardReportButton;
        private GroupBox InformationGroupBox;
        private TextBox LoggerTextBox;
        private Label label1;
        private DateTimePicker EndDateTimePicker;
        private DateTimePicker StartDateTimePicker;
        private Label label2;
        private Button ProcessLogFileButton;
        private Button BrowseButton;
        private Button GenerateHourlyReportButton;
        private Button GenerateOpenedAtHourlyReportButton;
    }
}