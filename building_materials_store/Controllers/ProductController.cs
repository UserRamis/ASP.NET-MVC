using building_materials_store.Data;
using building_materials_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace building_materials_store.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db) 
        {
            _db= db;
        }
        
        
        
        
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Product;
            
            foreach (var  obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            }
            
            return View(objList);
        }

        
        //GET-Upsert
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.CategoryDropDown = CategoryDropDown;


            Product product=new Product();
            if(id==null)
            {
                return View(product);
            }
            else
            {
                product=_db.Product.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            
        }


        //POST-Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }





        //GET-DELETE
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult DeletePost(int id)
        {

            var obj = _db.Product.Find(id);
            if (obj==null)
            {
                return NotFound(); 
            }
            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            
        }



    }
}
