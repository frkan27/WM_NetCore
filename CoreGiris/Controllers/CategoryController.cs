﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGiris.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreGiris.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var db = new MyContext();//product sayısını ı görmesi için ürün ekledik.yoksa hep 0 yapıyordu...
            var data = db.Categories.Include(x=>x.Products).OrderBy(x => x.CategoryName).ToList();
            return View(data);
        }
        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var db = new MyContext();
            db.Categories.Add(new Category()
            {
                CategoryName = model.CategoryName

            });
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]

        public IActionResult Delete(int id=0)
        {
            var db = new MyContext();
            var category = db.Categories.FirstOrDefault(x=>x.Id==id);
            if(category==null)
            {
                TempData["Message"] = "Kategori bulunamadı";
                return RedirectToAction("Index");
              
            }
            if (category.Products.Count > 0)
            {
                TempData["Message"] = $"{category.CategoryName} isimli Kategori silemezsiniz";
                return RedirectToAction("Index");
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["Message"] = $"{category.CategoryName} isimli Kategori silinmiştir.";
            return RedirectToAction(nameof(Index));
        }
    }
}