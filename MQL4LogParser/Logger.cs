namespace MQL4LogParser
{
    public class Logger
    {
        public string SystemLogFilePath { get; set; }
        private TextBox LoggerTextBox { get; set; }
        public Logger(TextBox loggerTextBox)
        {
            LoggerTextBox = loggerTextBox;
        }

        public void WriteLine(string message)
        {
            string log = $"{message.Replace("\n", Environment.NewLine)}{Environment.NewLine}";
            
            LoggerTextBox.AppendText(log);

            if (!File.Exists(SystemLogFilePath))
            {
                File.Create(SystemLogFilePath).Close();
            }
            using (StreamWriter sw = new StreamWriter(SystemLogFilePath, true))
            {
                sw.Write($"[{DateTime.Now.ToString("yyyy.MM.dd-HH:mm:ss.ss")}]: {log}");
            }
        }
    }
}
