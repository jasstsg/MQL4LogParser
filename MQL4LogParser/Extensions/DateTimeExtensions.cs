using MQL4LogParser.Enums;

namespace MQL4LogParser.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundDownDay(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        public static DateTime RoundDownHour(this DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour);
        }

        public static bool TryConvertToDateTime(string date, string time, out DateTime datetime)
        {
             return DateTime.TryParseExact($"{date} {time}", "yyyy.MM.dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datetime);
        }
        public static bool TryConvertToDateTime(string date, string time, out DateTime datetime, int shiftHours)
        {
            bool result = TryConvertToDateTime(date, time, out datetime);
            datetime = datetime.AddHours(shiftHours);
            return result;
        }

        public static bool IsBetween(this DateTime datetime, DateTime start, DateTime end)
        {
            return start <= datetime && end < datetime;
        } 
    }

    
}
