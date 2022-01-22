using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.CreateRotation
{
    public class CreateRotationCommand
    {
        //we haven't used Viewmodels and mappers yet. So, I'm going to create these with simplest way!
        public Rotation Model { get; set; }
        private static List<Rotation> RotationList = DataGenerator.RotationList;

        public CreateRotationCommand()
        {

        }


        public void Handle()
        {

            if (Model == null)
                throw new InvalidOperationException("No data entered!");

            var rotation = RotationList.SingleOrDefault(u => u.rotationCode == Model.rotationCode); //check if we already have that Rotation

            if (rotation is not null) //if the user not send any data, we will return bad request
                throw new InvalidOperationException("You already have this rotation in your list!");

            rotation = Model;
            RotationList.Add(rotation);

        }
    }
}
