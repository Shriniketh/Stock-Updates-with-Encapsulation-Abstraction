using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgramWithEncapsulation
{
    public class LoadFileStockData : ILoadData
    {
        private readonly string LoadData;

        public LoadFileStockData(string loaddata)
        {
            LoadData = loaddata;
        }

        public string LoadFileData()
        {
            return File.ReadAllText(LoadData);
        }

    }
}
