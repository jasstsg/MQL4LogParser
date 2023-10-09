using MQL4LogParser.Models;

namespace MQL4LogParser
{
    public partial class MQL4LogParserForm : Form
    {
        private Parser Parser;
        public MQL4LogParserForm()
        {
            InitializeComponent();

            Parser = new Parser()
            {
                Logger = new Logger(LoggerTextBox)
            };
        }

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

            StartDateTimePicker.MinDate = OrderStats.FirstOrderOperationTimestamp;
            StartDateTimePicker.MaxDate = OrderStats.LastOrderOperationTimestamp;
            StartDateTimePicker.Value = OrderStats.FirstOrderOperationTimestamp;
            StartDateTimePicker.Enabled = true;

            EndDateTimePicker.MinDate = OrderStats.FirstOrderOperationTimestamp;
            EndDateTimePicker.MaxDate = OrderStats.LastOrderOperationTimestamp;
            EndDateTimePicker.Value = OrderStats.LastOrderOperationTimestamp;
            EndDateTimePicker.Enabled = true;

            StartDateTimePicker.Enabled = true;
            EndDateTimePicker.Enabled = true;
            GenerateStandardReportButton.Enabled = true;
            GenerateHourlyReportButton.Enabled = true;
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