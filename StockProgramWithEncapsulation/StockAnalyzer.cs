using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgramWithEncapsulation
{
   public class StockAnalyzer
    {
        private readonly StockDataParser _parser;
        public StockAnalyzer(StockDataParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<StockDirectionDetails> findStockStatus()
        {
            var quotes = _parser.CsvToObject();

            var locator = new StockStatusFinder(quotes);

            return locator.Locate();
        }
    }
}
