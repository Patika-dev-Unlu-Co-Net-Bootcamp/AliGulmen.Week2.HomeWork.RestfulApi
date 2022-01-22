using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotationProducts
{
    public class GetRotationProductsQuery
    {
        private static List<Rotation> RotationList = DataGenerator.RotationList;
        private static List<Product> ProductList = DataGenerator.ProductList;

        public int RotationId { get; set; } //the id which will come from outside

        public GetRotationProductsQuery()
        {

        }

        public List<Product> Handle()
        {

            var products = ProductList.Where(p => p.rotationId == RotationId).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException("There is no product defined with this rotation");

            return products;



        }
    }
}
