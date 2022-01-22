using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.UomOperations.CreateUom
{
    public class CreateUomCommand
    {
        //we haven't used Viewmodels and mappers yet. So, I'm going to create these with simplest way!
        public Uom Model { get; set; }
        private static List<Uom> UomList = DataGenerator.UomList;

        public CreateUomCommand()
        {

        }


        public void Handle()
        {
           
            if (Model == null) 
                throw new InvalidOperationException("No data entered!");

             var uom = UomList.SingleOrDefault(u => u.uomId == Model.uomId); //check if we already have that Uom

            if (uom is not null) //if the user not send any data, we will return bad request
                throw new InvalidOperationException("You already have this uomCode in your list!");

            uom = Model;
            UomList.Add(uom);

        }
    }



}
