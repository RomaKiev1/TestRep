using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmaChartsSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
            ///////////////////////////////1
        }

        public ActionResult About()
        {
            return View();
        }

        public class GraphData
        {
            public string date { get; set; }
            public string Visits { get; set; }
            public string hits { get; set; }
            public string views { get; set; }
        }


        public ActionResult DataForGraph()
        {

            List<GraphData> GraphData_list = new List<GraphData>();
            DateTime firstday = DateTime.Parse("2012-08-10 10:04:24").Subtract(new TimeSpan(50,0,0,0));
            Random rand = new Random();
            for (int j = 0; j < 50; j++)
            {
                GraphData new_graphdata = new GraphData();
                new_graphdata.date = firstday.Year+","+firstday.Month+","+firstday.Day;
                new_graphdata.hits = rand.Next(1,150).ToString();
                new_graphdata.Visits = rand.Next(1, 150).ToString();
                new_graphdata.views = rand.Next(1, 150).ToString();
                GraphData_list.Add(new_graphdata);
                firstday = firstday.AddDays(1); 
            }

            return Json(GraphData_list, JsonRequestBehavior.AllowGet);
        }
    }
}
