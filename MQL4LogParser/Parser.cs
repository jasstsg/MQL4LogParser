﻿using MQL4LogParser.Enums;
using MQL4LogParser.Extensions;
using MQL4LogParser.Models;

namespace MQL4LogParser
{
    public class Parser
    {
        public Logger Logger { get; set; }
        public List<Order> Orders { get; private set; } = new List<Order>();

        public void Parse(string inFilePath)
        {
            Logger.SystemLogFilePath = Path.ChangeExtension(inFilePath, $"MQL4LogParser-{DateTime.Now.ToString("yyyyMMddTHHmmss")}.log");
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

                // Update the order record with new action history
                if (line.Contains(Operation.OPEN))
                {
                    CurrentOrder.History.AddOpen(words[2], words[3]);
                }
                else if (line.Contains(Operation.CLOSE))
                {
                    CurrentOrder.History.AddClose(words[2], words[3]);
                }
                else if (line.Contains(Operation.STOP))
                {
                    CurrentOrder.History.AddStop(words[2], words[3]);
                }
                else if (line.Contains(Operation.TAKE))
                {
                    CurrentOrder.History.AddTake(words[2], words[3]);
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

        public void WriteHourlyReport(string outFilePath, DateTime start, DateTime end)
        {
            Logger.WriteLine("Writing Hourly Report.  Please wait...");
            using (StreamWriter sw = new StreamWriter(outFilePath))
            {
                sw.WriteLine("Hour,Opens,Closes,Stops,Takes");
                foreach (KeyValuePair<DateTime, OrderStats.HourlyOrderStat> pair in OrderStats.ByTheHour)
                {
                    if (start <= pair.Key && pair.Key <= end)
                    {
                        sw.WriteLine($"{pair.Key},{pair.Value.Opens},{pair.Value.Closes},{pair.Value.Stops},{pair.Value.Takes}");
                    }
                }
            }
            Logger.WriteLine($"Report completed.  Generated '{outFilePath}'\n");
        }
    }
}
