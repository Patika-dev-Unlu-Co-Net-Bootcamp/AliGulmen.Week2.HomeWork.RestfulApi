using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.UomOperations.DeleteUom
{

    public class DeleteUomCommand
    {
        //we haven't used Viewmodels and mappers yet. So, I'm going to create these with simplest way!
        public int UomId { get; set; }
        private static List<Uom> UomList = DataGenerator.UomList;

        public DeleteUomCommand()
        {

        }



        public void Handle()
        {

            var ourRecord = UomList.SingleOrDefault(b => b.uomId == UomId); //is it exist?
            if (ourRecord is null)
                throw new InvalidOperationException("There is no record to delete!");
          
            UomList.Remove(ourRecord);

        }
    }
}
