using System;
using System.Linq;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    /// <summary>
    /// 製品のイベントハンドラ
    /// </summary>
    public class ProductsController : ApiController
    {
        /// <summary>
        /// 製品情報
        /// </summary>
        private static Product[] _products = new Product[]
        {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        };

        /// <summary>
        /// 製品情報をすべて取得する
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult  GetAllProducts()
        {
            return Ok(_products);
        }

        /// <summary>
        /// 指定IDの製品情報を取得する
        /// </summary>
        /// <param name="id">識別子</param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// 製品情報の更新
        /// </summary>
        /// <param name="product">更新する製品の情報</param>
        /// <returns>HTTP応答</returns>
        public IHttpActionResult PutProduct(Product product)
        {
            if (product == null)
            {
                return InternalServerError();
            }
            var resultProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (resultProduct == null)
            {
                Array.Resize(ref _products, _products.Length + 1);
                _products[_products.Length - 1] = product;

                return Ok();
            }
            resultProduct.Id = product.Id;
            resultProduct.Name = product.Name;
            resultProduct.Category = product.Category;
            resultProduct.Price = product.Price;
            return Ok();
        }
    }
}
