using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeorgeSite.Models.Data;
using GeorgeSite.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GeorgeSite.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class AdminController : Controller
    {
        IRepositoryWrapper Repository;

        public AdminController(IRepositoryWrapper repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {

            return View(Repository.ItemRepository.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            else if (!file.FileName.ToLower().Contains(".jpg"))
            {
                    return Content("only picture(jpg) please");
            }

            var arr = file.FileName.Split('.');
            string ext=".jpg";
            if (arr[arr.Length - 1].Contains("jpg"))
                ext = ".jpg";

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), @"wwwroot\ClientDocuments",
                        item.Id + Guid.NewGuid().ToString()+ ext);


            using (var stream = new FileStream(path, FileMode.CreateNew))
            {
                 file.CopyToAsync(stream);
                
            }
            item.ImageUrl = item.Id + Guid.NewGuid().ToString() + ext;
            Repository.ItemRepository.Create(item);
            Repository.ItemRepository.Save();
            return RedirectToAction("Index","Admin");
        }

    }
}