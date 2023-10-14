using MQL4LogParser.Extensions;
using MQL4LogParser.Models;

namespace MQL4LogParser
{
    public partial class MQL4LogParserForm : Form
    {
        private Parser Parser;
        private Logger Logger;
        public MQL4LogParserForm()
        {
            InitializeComponent();

            LoadApplicationSettings();

            this.Text = $"MQL4 Log Parser v{Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion")}";
            SetOutputControls(false);

            this.Logger = new Logger(LoggerTextBox);
            this.Parser = new Parser()
            {
                Logger = this.Logger
            };
        }

        private void MQL4LogParserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.INPUT_SHIFTHOURS = (int)(ShiftHoursNumericUpDown.Value);
            Properties.Settings.Default.Save();
        }

        #region Control Event Handlers

        #region Input Control Event Handlers
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (BrowseLogFilesDialog.ShowDialog() == DialogResult.OK)
            {
                LogFilePathTextBox.Text = BrowseLogFilesDialog.FileName;
            }
        }

        private void LogFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            bool hasValue = !String.IsNullOrEmpty(LogFilePathTextBox.Text);
            ProcessLogFileButton.Enabled = hasValue;
            ShiftHoursNumericUpDown.Enabled = hasValue;
        }

        private void ShiftHoursNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(LogFilePathTextBox.Text))
            {
                ProcessLogFile();
            }
            else
            {
                SetOutputControls(false);
            }
        }

        private void ProcessLogFileButton_Click(object sender, EventArgs e)
        {
            ProcessLogFile();
        }

        #endregion

        #region Output Control Event Handlers

        private void StandardReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parser.WriteStandardReport($"{BrowseLogFilesDialog.FileName}.Standard.csv", StartDateTimePicker.Value, EndDateTimePicker.Value);
            }
            catch (IOException ex)
            {
                LogException(ex);
            }
            catch (Exception ex)
            {
                LogException("", ex);
            }
        }

        /*
        private void GenerateHourlyReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parser.WriteHourlyReport($"{BrowseLogFilesDialog.FileName}_Hourly.csv", StartDateTimePicker.Value.RoundDownHour(), EndDateTimePicker.Value.RoundDownHour());
            }
            catch (System.IO.IOException ex)
            {
                LogException(ex);
            }
            catch (Exception ex)
            {
                LogException("", ex);
            }
        }
        */

        private void HourlyReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parser.WriteOpenedAtHourlyReport($"{BrowseLogFilesDialog.FileName}.Hourly.csv", StartDateTimePicker.Value.RoundDownHour(), EndDateTimePicker.Value.RoundDownHour());
            }
            catch (IOException ex)
            {
                LogException(ex);
            }
            catch (Exception ex)
            {
                LogException("", ex);
            }
        }

        private void DailyReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parser.WriteOpenedAtDailyReport($"{BrowseLogFilesDialog.FileName}.Daily.csv", StartDateTimePicker.Value.RoundDownDay(), EndDateTimePicker.Value.RoundDownDay());
            }
            catch (IOException ex)
            {
                LogException(ex);
            }
            catch (Exception ex)
            {
                LogException("", ex);
            }
        }

        #endregion

        #endregion

        private void ProcessLogFile()
        {
            OrderStats.Reset();
            this.Parser.Orders.Clear();
            LoggerTextBox.Clear();

            string selectedFile = LogFilePathTextBox.Text;
            if (!File.Exists(selectedFile))
            {
                this.Logger.WriteLine($"WARNING: The file '{selectedFile}' does not exist.");
            }
            else
            {
                this.Parser.Parse(selectedFile, (int)(ShiftHoursNumericUpDown.Value));
                SetOutputControls(true);
            }
        }

        private void LoadApplicationSettings()
        {
            ShiftHoursNumericUpDown.Value = Properties.Settings.Default.INPUT_SHIFTHOURS;
        }

        private void SetOutputControls(bool enabled)
        {
            SetDateTimePicker(StartDateTimePicker, OrderStats.FirstOrderOperationTimestamp, enabled);
            SetDateTimePicker(EndDateTimePicker, OrderStats.LastOrderOperationTimestamp, enabled);

            StandardReportButton.Enabled = enabled;
            DailyReportButton.Enabled = enabled;
            HourlyReportButton.Enabled = enabled;
        }

        private void SetDateTimePicker(DateTimePicker dtp, DateTime defaultValue, bool enabled)
        {
            if (enabled)
            {
                dtp.MinDate = OrderStats.FirstOrderOperationTimestamp;
                dtp.MaxDate = OrderStats.LastOrderOperationTimestamp;
                dtp.Value = defaultValue;
                dtp.Enabled = true;
                dtp.CustomFormat = "MMM dd, yyyy - HH:mm:ss";
            }
            else
            {
                dtp.Enabled = false;
                dtp.CustomFormat = " ";
            }
        }

        private void LogException(IOException ex)
        {
            LogException("ERROR: Tried to write to a .csv file that was already open.  Please close all .csv files before generating new ones.", ex);
        }

        private void LogException(string specificMessage, Exception ex)
        {
            Parser.Logger.WriteLine($"\n{specificMessage}\n\nError Details:\n{ex.ToString()}\n");
        }

    }
}