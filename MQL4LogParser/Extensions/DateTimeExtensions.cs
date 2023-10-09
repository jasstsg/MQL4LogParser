namespace MQL4LogParser.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundDownToNearestHour(this DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour);
        }

        public static DateTime ToDateTime(string date, string time)
        {
            return DateTime.ParseExact($"{date} {time}", "yyyy.MM.dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static bool IsBetween(this DateTime datetime, DateTime start, DateTime end)
        {
            return start <= datetime && end < datetime;
        } 
    }
}
