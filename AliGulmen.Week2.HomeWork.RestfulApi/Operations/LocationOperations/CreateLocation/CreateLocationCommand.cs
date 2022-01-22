using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.LocationOperations.CreateLocation
{
    public class CreateLocationCommand
    {
        public Location Model { get; set; }
        private static List<Location> LocationList = DataGenerator.LocationList;

        public CreateLocationCommand()
        {

        }


        public void Handle()
        {

            if (Model == null)
                throw new InvalidOperationException("No data entered!");

            var location = LocationList.SingleOrDefault(u => u.locationId == Model.locationId); //check if we already have that Location

            if (location is not null) //if the user not send any data, we will return bad request
                throw new InvalidOperationException("You already have this locationCode in your list!");

            location = Model;
            LocationList.Add(location);

        }
    }
}
