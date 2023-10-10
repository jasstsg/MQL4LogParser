using MQL4LogParser.Models;

namespace MQL4LogParser
{
    public partial class MQL4LogParserForm : Form
    {
        private Parser Parser;
        public MQL4LogParserForm()
        {
            InitializeComponent();

            this.Text = $"MQL4 Log Parser v{Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion")}";
            StartDateTimePicker.CustomFormat = " ";
            EndDateTimePicker.CustomFormat = " ";

            Parser = new Parser()
            {
                Logger = new Logger(LoggerTextBox)
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
            Parser.Orders.Clear();

            Parser.Parse(BrowseLogFilesDialog.FileName);

            EnableDateTimePicker(StartDateTimePicker, OrderStats.FirstOrderOperationTimestamp);
            EnableDateTimePicker(EndDateTimePicker, OrderStats.LastOrderOperationTimestamp);

            GenerateStandardReportButton.Enabled = true;
            GenerateHourlyReportButton.Enabled = true;
            GenerateOpenedAtHourlyReportButton.Enabled = true;
        }

        private void EnableDateTimePicker(DateTimePicker dtp, DateTime defaultValue)
        {
            dtp.MinDate = OrderStats.FirstOrderOperationTimestamp;
            dtp.MaxDate = OrderStats.LastOrderOperationTimestamp;
            dtp.Value = defaultValue;
            dtp.Enabled = true;
            dtp.CustomFormat = "MMM dd, yyyy - HH:mm:ss";
        }

        private void GenerateStandardReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parser.WriteStandardReport($"{BrowseLogFilesDialog.FileName}.csv", StartDateTimePicker.Value, EndDateTimePicker.Value);
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

        private void GenerateHourlyReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parser.WriteHourlyReport($"{BrowseLogFilesDialog.FileName}_Hourly.csv", StartDateTimePicker.Value, EndDateTimePicker.Value);
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

        private void GenerateOpenedAtHourlyReportButton_Click(object sender, EventArgs e)
        {

            try
            {
                Parser.WriteOpenedAtHourlyReport($"{BrowseLogFilesDialog.FileName}_OpenedAtHourly.csv", StartDateTimePicker.Value, EndDateTimePicker.Value);
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

        #endregion

        private void LogException(System.IO.IOException ex)
        {
            LogException("ERROR: Tried to write to a .csv file that was already open.  Please close all .csv files before generating new ones.", ex);
        }

        private void LogException(string specificMessage, Exception ex)
        {
            Parser.Logger.WriteLine($"\n{specificMessage}\n\nError Details:\n{ex.ToString()}");
        }
    }
}