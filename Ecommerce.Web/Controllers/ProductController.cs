using Ecommerce.BL.Abstract;
using Ecommerce.DTO.Concerete.Category;
using Ecommerce.DTO.Concerete.Product;
using Ecommerce.Entity.Concrete;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ProductViewModel model = new()
            {
                Products = _productService.GetAll().Select(p=> new ProductItemDTO
                {
                    Id=p.Id,
                    Name=p.Name,
                    Category=p.Category.Name,
                    Price=p.Price,
                    Stock=p.Stock
                }).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductViewModel model = new()
            {
                Categories = _categoryService.GetAll().Select(p => new CategoryItemDTO
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            try
            {
                _productService.Add(new Product{
                    Name= model.Product.Name,
                    CategoryId=model.Product.CategoryId,
                    Price=model.Product.Price,
                    Stock = model.Product.Stock
                });

                TempData["SuccessMessage"] = string.Format("{0} ürünü kayıt edildi.", model.Product.Name);
                
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = string.Format("{0} sebebiyle kayıt edilemedi.", e.Message);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.Get(id);
            ProductViewModel model = new()
            {
                Product = new ProductDTO { Id= id ,Name=product.Name,CategoryId=product.CategoryId,Price=product.Price,Stock=product.Stock},
                Categories = _categoryService.GetItems().Select(p => new CategoryItemDTO { Id = p.Id, Name = p.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            try
            {
                _productService.Update(new Product
                {
                    Id=model.Product.Id,
                    Name = model.Product.Name,
                    CategoryId = model.Product.CategoryId,
                    Stock = model.Product.Stock,
                    Price = model.Product.Price
                });
                TempData["SuccessMessage"] = string.Format("{0} ürünü güncellendi.", model.Product.Name);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = string.Format("{0} ürününe güncelleme yapılamadı.", e.Message);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(new Product { Id = id });
                TempData["SuccessMessage"] = string.Format("Ürün bilgisi silindi.");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = string.Format("{0} sebebiyle ürün silinemedi.", e.Message);
            }
            return RedirectToAction("Index");
        }
    
       
    
    }
}
