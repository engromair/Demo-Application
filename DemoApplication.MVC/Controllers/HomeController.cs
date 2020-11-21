using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoApplication.MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using DemoApplication.MVC.Models.Repositories;
using DemoApplication.MVC.ViewModels;

namespace DemoApplication.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IStudentRepository studentRepository;
        public HomeController(IHttpClientFactory clientFactory, IStudentRepository _studentRepository)
        {
            _clientFactory = clientFactory;
            studentRepository = _studentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var StudentCount = await studentRepository.GetAll();

            var homePageObj = new HomePage()
            {
                StudentCount = StudentCount.Count()
            };
            //var INR = currencyObj.rates..ToString();
            return View(homePageObj);
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
