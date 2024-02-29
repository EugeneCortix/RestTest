using Microsoft.AspNetCore.Mvc;
using Rest.Models;
using System.Diagnostics;
using Rest.MyFolder;



namespace Rest.Controllers
{
    
    public class HomeController : Controller
    {
       // public List<Record> Data;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Get
        [HttpGet, Route ("getroute/{what}/{n}")]
        public JsonResult Get(string what, int n)
        {
            string res = "";
            bool time = false;
            bool val = false;
            if (what == "time") time = true;
            if (what == "val") val = true;
            if (what == "all") 
            {
                time = true;
                val = true;
            };
            var cl = new Class();
            cl.Reader();
            if(n >= cl.Data.Count)
            {
                foreach (var item in cl.Data)
                {
                    if (time) res += item.Time + ' ';
                    if (val) res += item.Value;
                    res += '\n';
                }
            } else
            {
                if (time) res += cl.Data[n].Time + ' ';
                if (val) res += cl.Data[n].Value;
            }
            return new JsonResult(res);
        }
    }
}