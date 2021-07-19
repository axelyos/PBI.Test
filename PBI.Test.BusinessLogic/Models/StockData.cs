using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBI.Test.BusinessLogic.Models
{
    public class StockData
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public string Vol { get; set; } 
        public decimal Change { get; set; }
    }
}
