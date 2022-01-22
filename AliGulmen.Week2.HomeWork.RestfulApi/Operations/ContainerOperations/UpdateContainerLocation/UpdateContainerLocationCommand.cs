using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.UpdateContainerLocation
{
    public class UpdateContainerLocationCommand
    {
        public int ContainerId { get; set; }
        public int LocationId{ get; set; }
        private static List<Container> ContainerList = DataGenerator.ContainerList;


        public UpdateContainerLocationCommand()
        {

        }

        public void Handle()
        {

            var container = ContainerList.SingleOrDefault(c => c.containerId == ContainerId); //at first, find the uom to update
            if (container is null)
                throw new InvalidOperationException("Container is not found!");


            container.locationId = ContainerId != default ? ContainerId : container.locationId;


        }
    }
}
