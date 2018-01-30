using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgramWithEncapsulation
{
   public class StockStatusFinder
    {
        private readonly IList<StockQuoteData> _quotes;

        public StockStatusFinder(IList<StockQuoteData> quotes)
        {
            _quotes = quotes;
        }

        public IEnumerable<StockDirectionDetails> Locate()
        {
            for (int i = 0; i < _quotes.Count - 1; i++)
            {
                if (_quotes[i].ReversesDownFrom(_quotes[i + 1]))
                {
                    yield return new StockDirectionDetails(_quotes[i], StockProgram.StockDirection.down);
                }
                if (_quotes[i].ReversesUpFrom(_quotes[i + 1]))
                {
                    yield return new StockDirectionDetails(_quotes[i], StockProgram.StockDirection.up);
                }
            }
        }
    }
}
