using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.GetProductContainers
{
    public class GetProductContainersQuery
    {
        private static List<Container> ContainerList = DataGenerator.ContainerList;

        public int ProductId { get; set; } //the id which will come from outside

        public GetProductContainersQuery()
        {

        }

        public List<Container> Handle()
        {

            var containers = ContainerList.Where(c => c.productId == ProductId).ToList();
            if (containers.Count == 0)
                throw new InvalidOperationException("There is no container defined with this product");

            return containers;



        }
    }
}
