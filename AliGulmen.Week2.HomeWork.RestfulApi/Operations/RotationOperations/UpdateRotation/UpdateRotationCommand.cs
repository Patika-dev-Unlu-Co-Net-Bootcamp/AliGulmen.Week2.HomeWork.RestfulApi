using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.UpdateRotation
{
    public class UpdateRotationCommand
    {
        public int RotationId { get; set; }
        public Rotation Model { get; set; }
        private static List<Rotation> RotationList = DataGenerator.RotationList;


        public UpdateRotationCommand()
        {

        }

        public void Handle()
        {
            if (Model is null)
                throw new InvalidOperationException("No data entered!");


            var rotation = RotationList.SingleOrDefault(u => u.rotationId == RotationId); //at first, find the rotation to update
            if (rotation is null)
                throw new InvalidOperationException("Rotation is not found!");


            rotation.rotationId = Model.rotationId != default ? Model.rotationId : rotation.rotationId;
            rotation.rotationCode = Model.rotationCode != default ? Model.rotationCode : rotation.rotationCode;
           


        }
    }
}
