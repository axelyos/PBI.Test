using System;
using System.Linq;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dateForROI = new DateTime(2015, 5, 14);
                var volForRIO = 1000;

                var grubData = PBI.Test.BusinessLogic.StockParser.Parse("GRUB");
                var glwData = PBI.Test.BusinessLogic.StockParser.Parse("GLW");

                var grubMinPrice = grubData.Min(x => x.Price);
                var grubMaxPrice = grubData.Max(x => x.Price);
                var grubAveragePrice = grubData.Average(x => x.Price);
                var grubMaxSpike = grubData.OrderByDescending(x => x.Change).FirstOrDefault();
                var grubCOI = grubData.OrderBy(x => x.Date).FirstOrDefault().Price * volForRIO;
                var grubCVOI = grubData.Where(x => x.Date == dateForROI).FirstOrDefault().Price * volForRIO;
                var grubROI = (grubCVOI - grubCOI) / grubCOI;

                var glwMinPrice = glwData.Min(x => x.Price);
                var glwMaxPrice = glwData.Max(x => x.Price);
                var glwAveragePrice = glwData.Average(x => x.Price);
                var glwMaxSpike = glwData.OrderByDescending(x => x.Change).FirstOrDefault();
                var glwCOI = glwData.OrderBy(x => x.Date).FirstOrDefault().Price * volForRIO;
                var glwCVOI = glwData.Where(x => x.Date == dateForROI).FirstOrDefault().Price * volForRIO;
                var glwROI = (glwCVOI - glwCOI) / glwCOI;

                Console.WriteLine($"GRUB min: {string.Format("{0:n2}", grubMinPrice)}, max: {string.Format("{0:n2}", grubMaxPrice)}, avg: {string.Format("{0:n2}", grubAveragePrice)}");
                Console.WriteLine($"GRUB spike: {string.Format("{0:n2}", grubMaxSpike?.Change)}% at {string.Format("{0:dd/MM/yyyy}", grubMaxSpike?.Date)}");
                Console.WriteLine($"GRUB ROI for {volForRIO} shares from 01/01/2015 to {string.Format("{0:dd/MM/yyyy}", dateForROI)}: {string.Format("{0:p2}", grubROI)}");

                Console.WriteLine($"GLW min: {string.Format("{0:n2}", glwMinPrice)}, max: {string.Format("{0:n2}", glwMaxPrice)}, avg: {string.Format("{0:n2}", glwAveragePrice)}");
                Console.WriteLine($"GLW spike: {string.Format("{0:n2}", glwMaxSpike?.Change)}% at {string.Format("{0:dd/MM/yyyy}", glwMaxSpike?.Date)}");
                Console.WriteLine($"GLW ROI for {volForRIO} shares from 01/01/2015 to {string.Format("{0:dd/MM/yyyy}", dateForROI)}: {string.Format("{0:p2}", glwROI)}");

                Console.WriteLine("Hello World!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
