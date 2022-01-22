using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.LocationOperations.GetLocations
{
    public class GetLocationsQuery
    {
        private static List<Location> LocationList = DataGenerator.LocationList;

        public GetLocationsQuery()
        {

        }

        public List<Location> Handle()
        {
            var locationList = LocationList.OrderBy(l => l.locationId).ToList<Location>();
            return locationList;

        }
    }
}
