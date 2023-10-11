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

            this.Text = $"MQL4 Log Parser v{Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion")}";
            StartDateTimePicker.CustomFormat = " ";
            EndDateTimePicker.CustomFormat = " ";

            this.Logger = new Logger(LoggerTextBox);
            this.Parser = new Parser()
            {
                Logger = this.Logger
            };
        }

        #region Control Event Handlers
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
        }

        private void ProcessLogFileButton_Click(object sender, EventArgs e)
        {
            OrderStats.Reset();
            this.Parser.Orders.Clear();

            string selectedFile = LogFilePathTextBox.Text;
            if (!File.Exists(selectedFile))
            {
                this.Logger.WriteLine($"The file '{selectedFile}' does not exist.");
            }
            else
            {
                this.Parser.Parse(selectedFile);

                EnableDateTimePicker(StartDateTimePicker, OrderStats.FirstOrderOperationTimestamp);
                EnableDateTimePicker(EndDateTimePicker, OrderStats.LastOrderOperationTimestamp);

                StandardReportButton.Enabled = true;
                DailyReportButton.Enabled = true;
                HourlyReportButton.Enabled = true;
            }
        }

        private void EnableDateTimePicker(DateTimePicker dtp, DateTime defaultValue)
        {
            dtp.MinDate = OrderStats.FirstOrderOperationTimestamp;
            dtp.MaxDate = OrderStats.LastOrderOperationTimestamp;
            dtp.Value = defaultValue;
            dtp.Enabled = true;
            dtp.CustomFormat = "MMM dd, yyyy - HH:mm:ss";
        }

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