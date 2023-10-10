using MQL4LogParser.Enums;
using MQL4LogParser.Extensions;
using System;
using static System.Windows.Forms.AxHost;

namespace MQL4LogParser.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public OrderHistory History { get; private set; }
        public Order(int id)
        {
            Id = id;
            History = new OrderHistory(this);
        }
    }

    public class OrderHistory : Dictionary<Operation, DateTime>
    {
        public Order Order { get; private set; }
        public OrderHistory(Order order)
        {
            Order = order;
        }

        public void AddOpen(string date, string time)
        {
            DateTime datetime = DateTimeExtensions.ToDateTime(date, time);
            this.Add(Operation.OPEN, datetime);
            OrderStats.TrackStat(datetime, Operation.OPEN, this.Order);
        }

        public void AddClose(string date, string time)
        {
            DateTime datetime = DateTimeExtensions.ToDateTime(date, time);
            this.Add(Operation.CLOSE, datetime);
            OrderStats.TrackStat(datetime, Operation.CLOSE, this.Order);
        }

        public void AddStop(string date, string time)
        {
            DateTime datetime = DateTimeExtensions.ToDateTime(date, time);
            this.Add(Operation.STOP, datetime);
            OrderStats.TrackStat(datetime, Operation.STOP, this.Order);
        }

        public void AddTake(string date, string time)
        {
            DateTime datetime = DateTimeExtensions.ToDateTime(date, time);
            this.Add(Operation.TAKE, datetime);
            OrderStats.TrackStat(datetime, Operation.TAKE, this.Order);
        }

        private void Add(Operation operation, DateTime datetime)
        {
            // Keep track of first and last operations timestamps
            if (OrderStats.Total == 0)
            {
                OrderStats.FirstOrderOperationTimestamp = datetime;
            }
            OrderStats.LastOrderOperationTimestamp = datetime;

            // Tracks total orders and add them to the history
            OrderStats.Total++;
            base.Add(operation, datetime);
        }
    }

    public static class OrderStats
    {
        public class HourlyOrderStat
        {
            public int Opens { get; set; } = 0;
            public int Closes { get; set; } = 0;
            public int Stops { get; set; } = 0;
            public int Takes { get; set; } = 0;
        }

        public static int TotalOpens = 0;
        public static int TotalCloses = 0;
        public static int TotalStops = 0;
        public static int TotalTakes = 0;
        public static int Total = 0;
        public static DateTime FirstOrderOperationTimestamp = default;
        public static DateTime LastOrderOperationTimestamp = default;

        public static Dictionary<DateTime, HourlyOrderStat> ByTheHour = new Dictionary<DateTime, HourlyOrderStat>();
        public static Dictionary<DateTime, HourlyOrderStat> OpenedAtHour = new Dictionary<DateTime, HourlyOrderStat>();
        public static void Reset()
        {
            TotalOpens = 0;
            TotalCloses = 0;
            TotalStops = 0;
            TotalTakes = 0;
            Total = 0;
            FirstOrderOperationTimestamp = default;
            LastOrderOperationTimestamp = default;
            ByTheHour.Clear();
        }

        public static void TrackStat(DateTime datetime, Operation operation, Order order)
        {
            // Get the current hour
            DateTime currentHour = datetime.RoundDownToNearestHour();
            
            // Create a new hour entry if needed
            if (!ByTheHour.ContainsKey(currentHour))
            {
                ByTheHour.Add(currentHour, new HourlyOrderStat());
            }

            if (!OpenedAtHour.ContainsKey(currentHour))
            {
                OpenedAtHour.Add(currentHour, new HourlyOrderStat());
            }

            // Increment the relavent operation during that hour
            DateTime OpenedAtDateTimeHour = !operation.Equals(Operation.OPEN) ? order.History[Operation.OPEN].RoundDownToNearestHour() : default;
            switch (operation)
            {
                case Operation.OPEN:
                    TotalOpens++;
                    ByTheHour[currentHour].Opens++;
                    OpenedAtHour[currentHour].Opens++;
                    break;
                case Operation.CLOSE:
                    TotalCloses++;
                    ByTheHour[currentHour].Closes++;
                    OpenedAtHour[OpenedAtDateTimeHour].Closes++;
                    break;
                case Operation.STOP:
                    TotalStops++;
                    ByTheHour[currentHour].Stops++;
                    OpenedAtHour[OpenedAtDateTimeHour].Stops++;
                    break;
                case Operation.TAKE: 
                    TotalTakes++;
                    ByTheHour[currentHour].Takes++;
                    OpenedAtHour[OpenedAtDateTimeHour].Takes++;
                    break;
            }
        }
    }
}
