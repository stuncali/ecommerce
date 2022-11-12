using Ecommerce.BL.Abstract;
using Ecommerce.DTO.Concerete.Category;
using Ecommerce.Entity.Concrete;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Ecommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CategoryViewModel model = new()
            {
                Categories = _categoryService.GetAll().Select(p=> new CategoryDTO
                {
                    Id= p.Id,
                    Name=p.Name,
                    Description=p.Description
                }).ToList(),
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CategoryViewModel model = new();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel model)
        {
            try
            {
                _categoryService.Add(new Category { 
                    Name=model.Category.Name,
                    Description=model.Category.Description,
                });
                TempData["SuccessMessage"] = string.Format("{0} kategorisi kayıt edildi.", model.Category.Name);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = string.Format("{0} sebebiyle kayıt edilemedi.", e.Message);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryService.Get(id);
            CategoryViewModel model = new()
            {
                Category = new CategoryDTO
                {
                    Id= category.Id,
                    Name= category.Name,
                    Description=category.Description
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            try
            {
                _categoryService.Update(new Category
                {
                    Id=model.Category.Id,
                    Name = model.Category.Name,
                    Description = model.Category.Description
                });
                TempData["SuccessMessage"] = string.Format("{0} kategorisi güncellendi.", model.Category.Name);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = string.Format("{0} sebebiyle güncelleme yapılamadı.",e.Message);
            }           
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(new Category { Id = id});
                TempData["SuccessMessage"] = string.Format("Kategori bilgisi silindi.");
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = string.Format("{0} sebebiyle kategori silinemedi.", e.Message);
            }
            return RedirectToAction("Index");
        }
    
    }
}
