using CSharpEgitimKapm301.DataAccessLayer.Abstract;
using CSharpEgitimKapm301.DataAccessLayer.Context;
using CSharpEgitimKapm301.DataAccessLayer.Repositories;
using CSharpEgitimKapm301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKapm301.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Object> GetProductsWithCategoriy()
        {
            var context = new KampContext();
            var values = context.Products.
                Select(x => new 
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    ProductPrice = x.ProductPrice,
                    ProductStock = x.ProductStock,
                    CategoryName = x.Category.CategoryName
                }).ToList();

            return values.Cast<object>().ToList();
        }
    }
}
