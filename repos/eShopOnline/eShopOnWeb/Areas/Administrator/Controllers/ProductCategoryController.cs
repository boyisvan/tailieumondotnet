using eShopOnWeb.Model.Entities;
using eShopOnWeb.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace eShopOnWeb.Areas.Administrator.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;
        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<ProductCategory> productCategories = _service.GetAllProductCategory();
            return View(productCategories);
        }
    }
}
