using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.UomOperations.UpdateUom
{
    public class UpdateUomCommand
    {
        public int UomId { get; set; }
        public Uom Model { get; set; }
        private static List<Uom> UomList = DataGenerator.UomList;


        public UpdateUomCommand()
        {

        }

        public void Handle()
        {
            if (Model is null)
                throw new InvalidOperationException("No data entered!");


            var uom = UomList.SingleOrDefault(u => u.uomId == UomId); //at first, find the uom to update
            if (uom is null)
                throw new InvalidOperationException("Uom is not found!");


            uom.uomId = Model.uomId != default ? Model.uomId : uom.uomId;
            uom.uomCode = Model.uomCode != default ? Model.uomCode : uom.uomCode;
            uom.description = Model.description != default ? Model.description : uom.description;


        }
    }
}
