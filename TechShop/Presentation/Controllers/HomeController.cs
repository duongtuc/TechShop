using AutoMapper;
using Presentation.Infrastructure.Core;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShop.Model.Models;
using TechShop.Service;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        ICommonService _commonService;
        public HomeController(IProductService productService, IProductCategoryService productCategoryService, ICommonService commonService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
        }

        [OutputCache(Duration = 3600,Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideViewModer = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideViewModer;

            var lastestProductModel = _productService.GetLastest(3);
            var topProductModel = _productService.GetHotProduct(3);

            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topProductModel);

            homeViewModel.LastestProducts = lastestProductViewModel;
            homeViewModel.TopSaleProducts = topProductViewModel;

            return View(homeViewModel);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView("_Footer", footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("_Header");
        }
        public ActionResult Category()
        {
            var categories = _productCategoryService.GetAll();

            var categoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel> >(categories);

            return PartialView("_Category", categoryViewModel);
        }
    }
}