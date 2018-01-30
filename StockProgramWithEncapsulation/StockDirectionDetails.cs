using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StockProgramWithEncapsulation.StockProgram;

namespace StockProgramWithEncapsulation
{
    public class StockDirectionDetails
    {
        public StockDirectionDetails(StockQuoteData quote, StockDirection direction)
        {
            StockQuote = quote;
            Direction = direction;
        }
        public StockDirection Direction { get; set; }
        public StockQuoteData StockQuote { get; set; }
    }
}
