using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBI.Test.BusinessLogic.Models
{
    public class StockAnalysis
    {
        public string Stock { get; set; }
        public List<StockData> StockData { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal AveragePrice { get; set; }
        public StockData MaxSpike { get; set; }
        public decimal ROI { get; set; }
        public decimal VolumeForROI { get; set; }
        public DateTime DateForROI { get; set; }

    }
}
