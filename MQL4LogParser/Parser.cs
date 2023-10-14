using MQL4LogParser.Enums;
using MQL4LogParser.Extensions;
using MQL4LogParser.Models;

namespace MQL4LogParser
{
    public class Parser
    {
        private int _shiftHours { get; set; }
        public Logger Logger { get; set; }
        public List<Order> Orders { get; private set; } = new List<Order>();

        public void Parse(string inFilePath, int shiftHours)
        {
            _shiftHours = shiftHours;

            using (StreamReader sr = new StreamReader(inFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ParseLine(line);
                }
            }
            Logger.WriteLine($"Processed {Orders.Count} orders in {inFilePath}.");
            Logger.WriteLine($"\nOpens:\t{OrderStats.TotalOpens}\nCloses:\t{OrderStats.TotalCloses}\nStops:\t{OrderStats.TotalStops}\nTakes:\t{OrderStats.TotalTakes}\n");
        }

        private void ParseLine(string line)
        {
            string[] words = line.Split(' ', '\t');

            // Find out if the line contains an order
            int orderIndex = line.IndexOf('#');
            if (orderIndex > -1)
            {
                // Get the order number, and create a record for the order if it does not exist
                int order = int.Parse(line.Substring(orderIndex + 1).Split(' ')[0]);
                if (!Orders.Exists(o => o.Id.Equals(order)))
                {
                    Orders.Add(new Order(order));
                }

                Order CurrentOrder = Orders.First(o => o.Id.Equals(order));
                DateTime datetime;
                
                if (DateTimeExtensions.TryConvertToDateTime(words[2], words[3], out datetime, _shiftHours))
                {
                    // Update the order record with new action history
                    if (line.Contains(Operation.OPEN))
                    {
                        CurrentOrder.History.AddOpen(datetime);
                    }
                    else if (line.Contains(Operation.CLOSE))
                    {
                        CurrentOrder.History.AddClose(datetime);
                    }
                    else if (line.Contains(Operation.STOP))
                    {
                        CurrentOrder.History.AddStop(datetime);
                    }
                    else if (line.Contains(Operation.TAKE))
                    {
                        CurrentOrder.History.AddTake(datetime);
                    }
                }
            }
        }

        public void WriteStandardReport(string outFilePath, DateTime start, DateTime end)
        {
            Logger.WriteLine("Writing Standard Report.  Please wait...");
            using (StreamWriter sw = new StreamWriter(outFilePath))
            {
                sw.WriteLine("Order,Operation,DateTime");
                Orders = Orders.OrderBy(o => o.Id).ToList();
                foreach (Order order in Orders)
                {
                    foreach (KeyValuePair<Operation, DateTime> pair in order.History)
                    {
                        if (start <= pair.Value && pair.Value <= end)
                        {
                            sw.WriteRow(order.Id, $"{pair.Key}", pair.Value);
                        }
                    }
                }

            }
            Logger.WriteLine($"Report completed.  Generated '{outFilePath}'\n");
        }

        /*
        public void WriteHourlyReport(string outFilePath, DateTime start, DateTime end)
        {
            Logger.WriteLine("Writing Hourly Report.  Please wait...");
            using (StreamWriter sw = new StreamWriter(outFilePath))
            {
                sw.WriteLine("Hour,Opens,Closes,Stops,Takes");
                foreach (KeyValuePair<DateTime, OrderStats.OperationCounter> pair in OrderStats.ByTheHour)
                {
                    if (start <= pair.Key && pair.Key <= end)
                    {
                        sw.WriteLine($"{pair.Key},{pair.Value.Opens},{pair.Value.Closes},{pair.Value.Stops},{pair.Value.Takes}");
                    }
                }
            }
            Logger.WriteLine($"Report completed.  Generated '{outFilePath}'\n");
        }
        */

        public void WriteOpenedAtHourlyReport(string outFilePath, DateTime start, DateTime end)
        {
            Logger.WriteLine("Writing Hourly Report.  Please wait...");
            using (StreamWriter sw = new StreamWriter(outFilePath))
            {
                sw.WriteLine("Opened At Hour,Opens,Closes,Stops,Takes");
                foreach (KeyValuePair<DateTime, OrderStats.OperationCounter> pair in OrderStats.OpenedAtHour)
                {
                    if (start <= pair.Key && pair.Key <= end)
                    {
                        sw.WriteLine($"{pair.Key},{pair.Value.Opens},{pair.Value.Closes},{pair.Value.Stops},{pair.Value.Takes}");
                    }
                }
            }
            Logger.WriteLine($"Report completed.  Generated '{outFilePath}'\n");
        }

        public void WriteOpenedAtDailyReport(string outFilePath, DateTime start, DateTime end)
        {
            Logger.WriteLine("Writing Hourly Report.  Please wait...");
            using (StreamWriter sw = new StreamWriter(outFilePath))
            {
                sw.WriteLine("Opened On Day,Opens,Closes,Stops,Takes");
                foreach (KeyValuePair<DateTime, OrderStats.OperationCounter> pair in OrderStats.OpenedOnDay)
                {
                    if (start <= pair.Key && pair.Key <= end)
                    {
                        sw.WriteLine($"{pair.Key.ToString("yyyy-MM-dd")},{pair.Value.Opens},{pair.Value.Closes},{pair.Value.Stops},{pair.Value.Takes}");
                    }
                }
            }
            Logger.WriteLine($"Report completed.  Generated '{outFilePath}'\n");
        }
    }
}
