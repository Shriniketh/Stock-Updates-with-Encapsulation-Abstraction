using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgramWithEncapsulation
{
    public class StockDataParser
    {
        private readonly ILoadData _dataLoader;
        public StockDataParser(ILoadData dataloader)
        {
            _dataLoader = dataloader;
        }

        public IList<StockQuoteData> CsvToObject()
        {
            var csvData = _dataLoader.LoadFileData().Split('\n');

            return (
               from line in csvData.Skip(1)
               let data = line.Split(',')
               select new StockQuoteData()
               {
                   Date = DateTime.Parse(data[0], new CultureInfo("en-US", false)),
                   Open = decimal.Parse(data[1]),
                   High = decimal.Parse(data[2]),
                   Low = decimal.Parse(data[3]),
                   Close = decimal.Parse(data[4])
               }).ToList();
        }
    }
}
