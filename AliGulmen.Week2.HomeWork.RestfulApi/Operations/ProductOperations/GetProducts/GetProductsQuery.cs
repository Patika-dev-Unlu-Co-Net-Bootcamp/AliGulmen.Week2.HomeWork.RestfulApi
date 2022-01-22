using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.GetProducts
{
    public class GetProductsQuery
    {
        private static List<Product> ProductList = DataGenerator.ProductList;

        public GetProductsQuery()
        {

        }

        public List<Product> Handle()
        {
            var productList = ProductList.OrderBy(p => p.productId).ToList<Product>();
            return productList;

        }
    }
}
