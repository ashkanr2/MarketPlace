using App.Domain.Core.AppServices.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Entities;
using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Product;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.User;
using App.Domain.Core.DataAccess;
using System.Threading;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment;
using System.Net;
using System.IO;

namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductAppservice _productAppservice;
        private readonly IALLProductAppservice _aLLProductAppservice;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IBoothAppservice _boothAppservice;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IImageAppservice _imageAppservice;
        public ProductController(IMapper mapper, IProductAppservice productAppservice, IALLProductAppservice aLLProductAppservice, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IBoothAppservice boothAppservice, IWebHostEnvironment hostingEnvironment, IImageAppservice imageAppservice)
        {
            _mapper = mapper;
            _productAppservice = productAppservice;
            _aLLProductAppservice = aLLProductAppservice;
            _userManager = userManager;
            _signInManager = signInManager;
            _boothAppservice = boothAppservice;
            _hostingEnvironment = hostingEnvironment;
            _imageAppservice = imageAppservice;
        }

        public async Task <IActionResult> Index( CancellationToken cancellationToken)
        {
            var userId = (await _signInManager.UserManager.GetUserAsync(User)).Id;
            var boothId = (await _boothAppservice.Getbooth(userId, cancellationToken))?.Id;
            if(boothId == null )
            {
                return RedirectToAction("Index", "Home");
            }   
            else
            {
                var products = await _productAppservice.GetBoothProducts(boothId.Value, cancellationToken);
                var BoothProducts = products.Select(a => new ProductViewModel
                {
                    Id = a.Id,
                    UnitPrice = a.UnitPrice,
                    IsAccepted = a.IsAccepted,
                    ProductName = a.Name,
                    category = a.AllProduct.Category.Title,
                    ProductImages = a.ProductImages,
                    IsDeleted = a.IsDeleted,
                    Allproduct=a.AllProduct.Name,
                }).ToList();

                return View(BoothProducts);
            }

        }
        public async Task <IActionResult> Create(CancellationToken cancellationToken)
        {
            var allproduct = await _aLLProductAppservice.GetAll(cancellationToken);
            ViewBag.Allproduct = allproduct;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product, CancellationToken cancellation)
        {
            var userId = (await _signInManager.UserManager.GetUserAsync(User)).Id;
            var boothId = (await _boothAppservice.Getbooth(userId, cancellation)).Id;
            if (product.Image != null && product.Image.Length > 0)
            {
                var fileNameWithoutExtension = DateTime.Now.Ticks.ToString();

                var wwwrootPath = _hostingEnvironment.WebRootPath;
                var uploadPath = Path.Combine(wwwrootPath, "uploads");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Get the original file extension
                var fileExtension = Path.GetExtension(product.Image.FileName);

                // Construct the new file name
                var fileName = fileNameWithoutExtension + fileExtension;

                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.Image.CopyToAsync(stream);
                }

                var imageNameInDatabase = fileNameWithoutExtension + ".jpg" + "_+_" + Path.GetFileNameWithoutExtension(product.Image.FileName).Replace(".", "");
                var ImageId = await _imageAppservice.Upload(imageNameInDatabase, false, cancellation);
           
           

            var prodductDto = new ProductDto
            {
                Name = product.ProductName,
                UnitPrice = product.UnitPrice,
                BoothId = boothId,
                AllProductId = product.AllProductId,
                AddTime = DateTime.Now,
                IsDeleted = false,
                IsAccepted = false,
                IsAvailable = true,

            };
               var productId = await _productAppservice.Create(prodductDto, cancellation);
                var image = new ProductImageDto
                {
                    ProductId = productId,
                    ImageId = ImageId
                };
            await _imageAppservice.UploadProductImage(image,cancellation);
               
            }
            return RedirectToAction("Index", "Product");
        }




        public async Task<IActionResult> Detail(int id, CancellationToken cancellation)
        {

            var product = await _productAppservice.GetDetail(id, cancellation);
            var productview = new ProductViewModel
            {
                Id = product.Id,
                UnitPrice = product.UnitPrice,
                IsAccepted = product.IsAccepted,
                boothId = product.BoothId,
                ProductName = product.Name,
                Allproduct = product.AllProduct.Name,
                //ProductImages= product.ProductImages,
            };
            return View(productview);
        }
        public async Task<IActionResult> Update(int id, CancellationToken cancellation)
        {
           
           var product = await _productAppservice.GetDetail(id, cancellation);
            var productview = new ProductViewModel
            {
                Id=product.Id,
                UnitPrice = product.UnitPrice,
                IsAccepted = product.IsAccepted,
                boothId= product.BoothId,
                ProductName= product.Name,
                AllProductId= product.AllProductId,
                //ProductImages= product.ProductImages,
            };
            return View(productview);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel entity, CancellationToken cancellation)
        {
            var info = await _productAppservice.GetDetail(entity.Id, cancellation);
            var product = new ProductDto
            {
                Id = entity.Id,
                Name = entity.ProductName,
                IsDeleted = entity.IsDeleted,
                UnitPrice= entity.UnitPrice,
                BoothId=info.BoothId,
                IsAccepted=info.IsAccepted,
                AllProductId=entity.AllProductId,
                IsAvailable=info.IsAvailable,
                AddTime=info.AddTime,
                
            };
            await _productAppservice.Update(product, cancellation);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> OnDelete (int Id, CancellationToken cancellation)
        {
            await _productAppservice.OnDelete(Id, cancellation);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellation)
        {
            await _productAppservice.SoftDelete(Id, cancellation);
            return RedirectToAction("Index");
        }
     
        //[HttpPost]
        //public ActionResult CreateImage(ImageDto model)
        //{
        //    HttpPostedFileBase file = Request.Files["ImageData"];
        //    ContentRepository service = new ContentRepository();
        //    int i = service.UploadImageInDataBase(file, model);
        //    if (i == 1)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}
