using System.Diagnostics;
using System.Threading.Tasks;
using BatchHost.BatchInterface;
using BatchHost.BatchInterface.BatchJobs.Sample;
using Microsoft.AspNetCore.Mvc;
using BatchHost.WebApp.Models;

namespace BatchHost.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {

            var jobId = BackgroundJob.Enqueue<ISampleJob>(job => job.Execute(new SampleParameter { }));
            var awaiter = new BatchJobMonitor();
            var data = await awaiter.WaitForExit<SampleResponse>(jobId);

            ViewData["Message"] = data.Message;
                
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
