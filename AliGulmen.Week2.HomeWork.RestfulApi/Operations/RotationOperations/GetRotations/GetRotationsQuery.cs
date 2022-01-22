using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotations
{
    public class GetRotationsQuery
    {
        private static List<Rotation> RotationList = DataGenerator.RotationList;

        public GetRotationsQuery()
        {

        }

        public List<Rotation> Handle()
        {
            var rotationList = RotationList.OrderBy(u => u.rotationId).ToList<Rotation>();
            return rotationList;

        }
    }
}
