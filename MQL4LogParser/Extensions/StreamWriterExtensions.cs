namespace MQL4LogParser.Extensions
{
    public static class StreamWriterExtensions
    {
        public static void WriteRow(this StreamWriter sw, int id, string operation, DateTime datetime)
        {
            sw.WriteLine($"{id},{operation},{datetime}");
        }
    }
}
