using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBI.Test.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var grub = BusinessLogic.StockAnalyzer.Analyze("GRUB", new DateTime(2015, 5, 14), 1000);
            var glw = BusinessLogic.StockAnalyzer.Analyze("GLW", new DateTime(2015, 5, 14), 1000);
            return View(new List<BusinessLogic.Models.StockAnalysis>() { grub, glw });
        }

        public JsonResult GetChartData(string Security)
        {
            var data = BusinessLogic.StockAnalyzer.Analyze(Security, new DateTime(2015, 5, 14), 1000);

            return Json(data.StockData.OrderBy(x => x.Date));
        }
    }
}
