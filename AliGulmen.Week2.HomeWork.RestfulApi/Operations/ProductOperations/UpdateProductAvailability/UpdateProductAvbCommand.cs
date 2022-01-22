using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.UpdateProductAvailability
{
    public class UpdateProductAvbCommand
    {
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
        private static List<Product> ProductList = DataGenerator.ProductList;


        public UpdateProductAvbCommand()
        {

        }

        public void Handle()
        {

            var product = ProductList.SingleOrDefault(u => u.productId == ProductId); //at first, find the product to update
            if (product is null)
                throw new InvalidOperationException("Product is not found!");


            product.isActive = IsActive != default ? IsActive : product.isActive;


        }
    }
}
