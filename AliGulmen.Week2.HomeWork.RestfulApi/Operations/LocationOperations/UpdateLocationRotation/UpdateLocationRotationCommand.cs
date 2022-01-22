using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.LocationOperations.UpdateLocationRotation
{
    public class UpdateLocationRotationCommand
    {
        public int LocationId { get; set; }
        public int RotationId { get; set; }
        private static List<Location> LocationList = DataGenerator.LocationList;


        public UpdateLocationRotationCommand()
        {

        }

        public void Handle()
        {

            var location = LocationList.SingleOrDefault(l => l.locationId == LocationId); //at first, find the uom to update
            if (location is null)
                throw new InvalidOperationException("Uom is not found!");


            location.rotationId = RotationId != default ? RotationId : location.rotationId;


        }
    }
}
