using Data.Repositories;
using Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Tellbal.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products/[action]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<Image> _ImageRepository;

        public ProductsController(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<Image> imageRepository)
        {
            _ProductRepository = productRepository;
            _CategoryRepository = categoryRepository;
            _ImageRepository = imageRepository;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        [AllowAnonymous] //  clear this after complete authentication
        public ActionResult getProducts()
        {
            var products = _ProductRepository.TableNoTracking.ToList();
            return Ok(products);
        }
        [HttpPost]
        [AllowAnonymous] //  clear this after complete authentication
        public ActionResult Products(Product product)
        {
            _ProductRepository.Add(new Product
            {
                CategoryId = product.CategoryId,
                Price = product.Price,
                Description = product.Description,
                Discount = product.Discount,
                About = product.About,
                ProductName = product.ProductName,
                ProductType = product.ProductType,
                Images = product.Images,

            });

            return Ok();
        }
        [HttpGet("{id}")]
        [AllowAnonymous] //  clear this after complete authentication
        public ActionResult getProducts(Guid id)
        {
            var product = _ProductRepository.TableNoTracking
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return Ok(product);
        }

        /// <summary>
        /// Creates Category
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///       "name": "mobile",
        ///       "childCategories": [
        ///         {
        ///           "name": "iphone",
        ///           "childCategories": [
        ///            {
        ///             "name":"iphone12"
        ///            }
        ///           ]
        ///         }
        ///        ]
        ///      }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created Category</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [AllowAnonymous] //  clear this after complete authentication
        public ActionResult Category(Category category)
        {
            _CategoryRepository.Add(category);
            return Ok();
        }
        [HttpGet]
        [AllowAnonymous] //  clear this after complete authentication
        public ActionResult getCategory()
        {
            var categories = _CategoryRepository.Entities.Include(p => p.Products).ToList();
            return Ok(categories);
        }
    }
}
