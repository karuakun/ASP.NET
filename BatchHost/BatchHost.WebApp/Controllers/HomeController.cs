using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BatchHost.Service.Jobs.Sample;
using Microsoft.AspNetCore.Mvc;
using BatchHost.WebApp.Models;
using Hangfire;

namespace BatchHost.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var queueId = BackgroundJob.Enqueue(() => new SampleJob().Execute(new SampleParameter { EnqueueTime = DateTime.Now}));

            //BackgroundJob.ContinueWith(queueId, () => Console.WriteLine("Compleate"));
            
            return View();
        }



        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
