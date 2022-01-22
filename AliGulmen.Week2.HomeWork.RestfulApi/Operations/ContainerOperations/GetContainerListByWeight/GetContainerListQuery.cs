using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.GetContainerListByWeight
{
    public class GetContainerListQuery
    {

        private static List<Container> ContainerList = DataGenerator.ContainerList;
        public int MaxWeight { get; set; } 

        public GetContainerListQuery()
        {

        }

        public List<Container> Handle()
        {
            var containers = ContainerList
                                    .Where(c => c.weight <= MaxWeight)
                                    .OrderBy(c => c.weight)
                                    .ToList();
            if (containers is null)
                throw new InvalidOperationException("The container is not exist!");


            return containers;

        }
    }
}
