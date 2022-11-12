using Ecommerce.BL.Abstract;
using Ecommerce.Web.Entities;
using Ecommerce.Web.Models;
using Ecommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        ICartSessionService _cartSessionService;
        ICartService _cartService;
        IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public JsonResult AddToCart(int id)
        {
            try
            {
                var product = _productService.Get(id);
                var productItem = new ProductItem
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price= product.Price
                };
                var cart = _cartSessionService.GetCart();
                _cartService.AddToCard(cart,productItem);
                _cartSessionService.SetCart(cart);
                product.Stock--;
                _productService.Update(product);
                return Json(new {result="1",total=cart.Total});
            }
            catch
            {
                return Json(new { result = "0", total = 0 });
            }            
        }

        public JsonResult GetTotal()
        {
            return Json(_cartSessionService.GetCart().Total);
        }

        public JsonResult ShowCart()
        {
            var cart = _cartSessionService.GetCart();
            List<CartItemViewModel> dataItems = cart.CartItems.Select(p => new CartItemViewModel
            {
                Name = p.Product.Name,
                Price = p.Product.Price,
                Quantity=p.Quantity,
                Total=p.Product.Price*p.Quantity
            }).ToList();
            var jsonData = new
            {
                recordsFiltered = dataItems.Count,
                recordsTotal = dataItems.Count,
                data = dataItems.OrderBy(p => p.Name).ToList()
            };
            return Json(jsonData);
        }
    
    }
}
