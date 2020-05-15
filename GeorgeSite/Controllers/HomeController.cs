using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeorgeSite.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace GeorgeSite.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryWrapper Repository;

        public HomeController(IRepositoryWrapper repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            return View(Repository.ItemRepository.FindAll());
        }

        [HttpPost]
        public IActionResult Search(string id)
        {
            ViewBag.search_term = id;
            return View(Repository.ItemRepository.FindByCondition(item => item.Name.Contains(id)));
        }



    }
}