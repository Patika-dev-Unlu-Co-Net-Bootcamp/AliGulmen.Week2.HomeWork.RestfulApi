using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    {
        public int ProductId { get; set; }
        public Product Model { get; set; }
        private static List<Product> ProductList = DataGenerator.ProductList;


        public UpdateProductCommand()
        {

        }

        public void Handle()
        {
            if (Model is null)
                throw new InvalidOperationException("No data entered!");


            var product = ProductList.SingleOrDefault(u => u.productId == ProductId); //at first, find the product to update
            if (product is null)
                throw new InvalidOperationException("Product is not found!");


           
            product.productId = Model.productId != default ? Model.productId : product.productId;
            product.productCode = Model.productCode != default ? Model.productCode : product.productCode;
            product.description = Model.description != default ? Model.description : product.description;
            product.rotationId = Model.rotationId != default ? Model.rotationId : product.rotationId;
            product.isActive = Model.isActive != default ? Model.isActive : product.isActive;
            product.lifeTime = Model.lifeTime != default ? Model.lifeTime : product.lifeTime;


        }
    }
}
