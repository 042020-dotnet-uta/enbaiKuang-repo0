using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1) {
            ViewData["Message"] = $"Hello {name}";
            ViewData["NumTimes"] = numTimes;
            return View();
        }

        //public string Index() {
        //    return "This the the default action.";
        //}

        //public string Welcome() {
        //    return "This is the Welcome action method";
        //}

        //public string Welcome2(int input) {
        //    return $"This {input} is the number you sent.";
        //}
    }
}