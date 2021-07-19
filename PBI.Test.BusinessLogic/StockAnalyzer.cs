using System;
using System.Linq;

namespace PBI.Test.BusinessLogic
{
    public static class StockAnalyzer
    {
        public static Models.StockAnalysis Analyze(string Stock, DateTime dateForROI, decimal volumeForROI)
        {
            var result = new Models.StockAnalysis() { Stock = Stock, VolumeForROI = volumeForROI, DateForROI = dateForROI };
            result.StockData = StockParser.Parse(Stock);

            result.MinPrice = result.StockData.Min(x => x.Price);
            result.MaxPrice = result.StockData.Max(x => x.Price);
            result.AveragePrice = result.StockData.Average(x => x.Price);
            result.MaxSpike = result.StockData.OrderByDescending(x => x.Change).FirstOrDefault();
            var coi = result.StockData.OrderBy(x => x.Date).FirstOrDefault().Price * volumeForROI;
            var cvoi = result.StockData.Where(x => x.Date == dateForROI).FirstOrDefault().Price * volumeForROI;
            result.ROI = (cvoi - coi) / coi;

            return result;
        }
    }
}
