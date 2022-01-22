using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.LocationOperations.DeleteLocation
{
    public class DeleteLocationCommand
    {
        public int LocationId { get; set; }
        private static List<Location> LocationList = DataGenerator.LocationList;

        public DeleteLocationCommand()
        {

        }



        public void Handle()
        {

            var ourRecord = LocationList.SingleOrDefault(l => l.locationId == LocationId); //is it exist?
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");

            LocationList.Remove(ourRecord);

        }
    }
}
