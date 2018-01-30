using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgramWithEncapsulation
{
    public class StockProgram
    {
        static void Main(string[] args)
        {
            var Loader = GetLoaderFor(args[0]);

            var parser = new StockDataParser(Loader);

            var analyzer = new StockAnalyzer(parser);

            foreach (var item in analyzer.findStockStatus())
            {
                PrintStockStatus(item);
            }

            Console.ReadLine();
        }

        private static ILoadData GetLoaderFor(string filename)
        {
            ILoadData dataLoader;

            if (filename.StartsWith("https") || filename.StartsWith("http"))
            {
                Console.WriteLine("This Feature is still not available");

                dataLoader = null;
            }
            else
            {
                dataLoader = new LoadFileStockData(filename);
            }

            return dataLoader;
        }

        public enum StockDirection
        {
            up = 1,
            down = 2
        }

        private static void PrintStockStatus(StockDirectionDetails details)
        {
            if (details.Direction == StockDirection.up)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Stock Prices went up on " + details.StockQuote.Date.ToShortDateString());
            }
            else if (details.Direction == StockDirection.down)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Stock Prices went down on " + details.StockQuote.Date.ToShortDateString());
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
