using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public Product Model { get; set; }
        private static List<Product> ProductList = DataGenerator.ProductList;

        public CreateProductCommand()
        {

        }


        public void Handle()
        {

            if (Model == null)
                throw new InvalidOperationException("No data entered!");

            var product = ProductList.SingleOrDefault(u => u.productId == Model.productId); //check if we already have that Product

            if (product is not null) //if the user not send any data, we will return bad request
                throw new InvalidOperationException("You already have this productCode in your list!");

            product = Model;
            ProductList.Add(product);

        }
    }
}
