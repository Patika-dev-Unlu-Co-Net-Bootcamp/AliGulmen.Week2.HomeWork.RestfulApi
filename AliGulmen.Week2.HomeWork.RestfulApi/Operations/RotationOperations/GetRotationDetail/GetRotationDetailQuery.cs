using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotationDetail
{
    public class GetRotationDetailQuery
    {

        private static List<Rotation> RotationList = DataGenerator.RotationList;
        public int RotationId { get; set; } //the id which will come from outside

        public GetRotationDetailQuery()
        {

        }

        public Rotation Handle()
        {
            var rotation = RotationList.Where(u => u.rotationId == RotationId).SingleOrDefault();
            if (rotation is null)
                throw new InvalidOperationException("The rotation is not exist!");


            return rotation;



        }
    }
}
