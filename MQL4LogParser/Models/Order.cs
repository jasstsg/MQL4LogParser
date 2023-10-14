using MQL4LogParser.Enums;
using MQL4LogParser.Extensions;

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

        public void AddOpen(DateTime datetime)
        {
            this.Add(Operation.OPEN, datetime);
            OrderStats.TrackStat(datetime, Operation.OPEN, this.Order);
        }

        public void AddClose(DateTime datetime)
        {
            this.Add(Operation.CLOSE, datetime);
            OrderStats.TrackStat(datetime, Operation.CLOSE, this.Order);
        }

        public void AddStop(DateTime datetime)
        {
            this.Add(Operation.STOP, datetime);
            OrderStats.TrackStat(datetime, Operation.STOP, this.Order);
        }

        public void AddTake(DateTime datetime)
        {
            this.Add(Operation.TAKE, datetime);
            OrderStats.TrackStat(datetime, Operation.TAKE, this.Order);
        }

        private new void Add(Operation operation, DateTime datetime)
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
        public class OperationCounter
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

        //public static Dictionary<DateTime, OperationCounter> ByTheHour = new Dictionary<DateTime, OperationCounter>();
        public static Dictionary<DateTime, OperationCounter> OpenedAtHour = new Dictionary<DateTime, OperationCounter>();
        public static Dictionary<DateTime, OperationCounter> OpenedOnDay = new Dictionary<DateTime, OperationCounter>();
       
        public static void Reset()
        {
            TotalOpens = 0;
            TotalCloses = 0;
            TotalStops = 0;
            TotalTakes = 0;
            Total = 0;
            FirstOrderOperationTimestamp = default;
            LastOrderOperationTimestamp = default;
            //ByTheHour.Clear();
            OpenedAtHour.Clear();
            OpenedOnDay.Clear();
        }

        public static void TrackStat(DateTime datetime, Operation operation, Order order)
        {
            // Get the current hour
            DateTime currentHour = datetime.RoundDownHour();
            DateTime currentDay = datetime.RoundDownDay();
            
            /*
            if (!ByTheHour.ContainsKey(currentHour))
            {
                ByTheHour.Add(currentHour, new OperationCounter());
            }
            */

            if (!OpenedAtHour.ContainsKey(currentHour))
            {
                OpenedAtHour.Add(currentHour, new OperationCounter());
            }

            if (!OpenedOnDay.ContainsKey(currentDay))
            {
                OpenedOnDay.Add(currentDay, new OperationCounter());
            }

            // Increment the relavent operation during that hour
            DateTime OpenedAtDateTime = !operation.Equals(Operation.OPEN) ? order.History[Operation.OPEN] : default;
            switch (operation)
            {
                case Operation.OPEN:
                    TotalOpens++;
                    //ByTheHour[currentHour].Opens++;
                    OpenedAtHour[currentHour].Opens++;
                    OpenedOnDay[currentDay].Opens++;
                    break;
                case Operation.CLOSE:
                    TotalCloses++;
                    //ByTheHour[currentHour].Closes++;
                    OpenedAtHour[OpenedAtDateTime.RoundDownHour()].Closes++;
                    OpenedOnDay[OpenedAtDateTime.RoundDownDay()].Closes++;
                    break;
                case Operation.STOP:
                    TotalStops++;
                    //ByTheHour[currentHour].Stops++;
                    OpenedAtHour[OpenedAtDateTime.RoundDownHour()].Stops++;
                    OpenedOnDay[OpenedAtDateTime.RoundDownDay()].Stops++;
                    break;
                case Operation.TAKE: 
                    TotalTakes++;
                    //ByTheHour[currentHour].Takes++;
                    OpenedAtHour[OpenedAtDateTime.RoundDownHour()].Takes++;
                    OpenedOnDay[OpenedAtDateTime.RoundDownDay()].Takes++;
                    break;
            }
        }
    }
}
