namespace MQL4LogParser
{
    public class Logger
    {
        private TextBox LoggerTextBox { get; set; }
        public Logger(TextBox loggerTextBox)
        {
            LoggerTextBox = loggerTextBox;
        }

        public void WriteLine(string message)
        {
            string log = $"{message.Replace("\n", Environment.NewLine)}{Environment.NewLine}";
            LoggerTextBox.AppendText(log);
        }
    }
}
