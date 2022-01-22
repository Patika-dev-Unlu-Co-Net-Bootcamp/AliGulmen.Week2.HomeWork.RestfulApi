using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.CreateContainer
{
    public class CreateContainerCommand
    {
        public Container Model { get; set; }
        private static List<Container> ContainerList = DataGenerator.ContainerList;

        public CreateContainerCommand()
        {

        }


        public void Handle()
        {

            if (Model == null)
                throw new InvalidOperationException("No data entered!");

            var container = ContainerList.SingleOrDefault(c => c.containerId == Model.containerId); //check if we already have that Container

            if (container is not null) //if the user not send any data, we will return bad request
                throw new InvalidOperationException("You already have this container in your list!");

            container = Model;
            ContainerList.Add(container);

        }
    }
}
