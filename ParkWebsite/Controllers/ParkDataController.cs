using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ParkWebsite.Models;
using ParkWebsite.ViewModels;

namespace ParkWebsite.Controllers
{
    public class ParkDataController : Controller
    {
        private readonly ILogger<ParkDataController> _logger;


        public ParkDataController(ILogger<ParkDataController> logger)
        {
            _logger = logger; 

        }

        public IActionResult ParkData(string search)
        {
            Data dt = new Data();
            ParkViewModel pvM = new ParkViewModel();

            if (!string.IsNullOrEmpty(search)) {
                ViewBag.Search = true;
                pvM.Parks = dt.GetParksFromSearch(search);
            }
            else
            {
                ViewBag.Search = false;
            }


            return View(pvM);
        }
    }
}
