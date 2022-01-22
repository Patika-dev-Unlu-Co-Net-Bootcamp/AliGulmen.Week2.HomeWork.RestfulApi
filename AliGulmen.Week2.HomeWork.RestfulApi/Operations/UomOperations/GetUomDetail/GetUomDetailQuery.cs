using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.UomOperations.GetUomDetail
{
    public class GetUomDetailQuery
    {
        private static List<Uom> UomList = DataGenerator.UomList;
        public int UomId { get; set; } //the id which will come from outside

        public GetUomDetailQuery()
        {

        }

        public Uom Handle()
        {
            var uom = UomList.Where(u => u.uomId == UomId).SingleOrDefault();
            if (uom is null)
                throw new InvalidOperationException("The book is not exist!");


            return uom;

          

        }
    }
}
