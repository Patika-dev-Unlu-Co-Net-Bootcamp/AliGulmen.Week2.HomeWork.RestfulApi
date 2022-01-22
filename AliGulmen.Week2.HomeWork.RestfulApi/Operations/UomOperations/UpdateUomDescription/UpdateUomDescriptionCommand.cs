using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.UomOperations.UpdateUomDescription
{
    public class UpdateUomDescriptionCommand
    {
        public int UomId { get; set; }
        public string Description { get; set; }
        private static List<Uom> UomList = DataGenerator.UomList;


        public UpdateUomDescriptionCommand()
        {

        }

        public void Handle()
        {
           
            var uom = UomList.SingleOrDefault(u => u.uomId == UomId); //at first, find the uom to update
            if (uom is null)
                throw new InvalidOperationException("Uom is not found!");


            uom.description = Description != default ? Description : uom.description;


        }
    }
}
