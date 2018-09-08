using System;
using Microsoft.AspNetCore.Mvc;

namespace Downstream
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return Content("home");
        }

        [HttpGet("/error")]
        public IActionResult Error()
        {
            throw new Exception();
        }
    }
}