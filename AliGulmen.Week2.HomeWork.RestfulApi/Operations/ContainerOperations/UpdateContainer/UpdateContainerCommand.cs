using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using AliGulmen.Week2.HomeWork.RestfulApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.UpdateContainer
{
    public class UpdateContainerCommand
    {

        public int ContainerId { get; set; }
        public Container Model { get; set; }
        private static List<Container> ContainerList = DataGenerator.ContainerList;


        public UpdateContainerCommand()
        {

        }

        public void Handle()
        {
            if (Model is null)
                throw new InvalidOperationException("No data entered!");


            var container = ContainerList.SingleOrDefault(c => c.containerId == ContainerId); //at first, find the container to update
            if (container is null)
                throw new InvalidOperationException("Container is not found!");


   
            container.ValidateWith(Model);

        }
    }
}
