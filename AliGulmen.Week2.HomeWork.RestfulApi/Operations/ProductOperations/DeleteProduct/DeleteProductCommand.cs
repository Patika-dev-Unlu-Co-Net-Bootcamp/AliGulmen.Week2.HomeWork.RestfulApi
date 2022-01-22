using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {
        public int ProductId { get; set; }
        private static List<Product> ProductList = DataGenerator.ProductList;

        public DeleteProductCommand()
        {

        }



        public void Handle()
        {

            var ourRecord = ProductList.SingleOrDefault(b => b.productId == ProductId); //is it exist?
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            ProductList.Remove(ourRecord);

        }
    }
}
