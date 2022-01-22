using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.GetContainers
{
    public class GetContainersQuery
    {
        private static List<Container> ContainerList = DataGenerator.ContainerList;

        public GetContainersQuery()
        {

        }

        public List<Container> Handle()
        {
            var containerList = ContainerList.OrderBy(c => c.containerId).ToList<Container>();
            return containerList;

        }
    }
}
