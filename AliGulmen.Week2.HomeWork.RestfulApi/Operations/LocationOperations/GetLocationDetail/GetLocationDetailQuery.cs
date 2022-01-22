using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.LocationOperations.GetLocationDetail
{
    public class GetLocationDetailQuery
    {
        private static List<Location> LocationList = DataGenerator.LocationList;
        public int LocationId { get; set; } //the id which will come from outside

        public GetLocationDetailQuery()
        {

        }

        public Location Handle()
        {
            var location = LocationList.Where(l => l.locationId == LocationId).SingleOrDefault();
            if (location is null)
                throw new InvalidOperationException("The location is not exist!");


            return location;



        }
    }
}
