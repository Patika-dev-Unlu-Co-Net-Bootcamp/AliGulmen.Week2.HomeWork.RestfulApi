using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Operations.StockOperations.GetStocks
{
    public class GetStocksQuery
    {
        private static List<Stock> StockList = DataGenerator.StockList;

        public GetStocksQuery()
        {

        }

        public List<Stock> Handle()
        {
            var stockList = StockList.OrderBy(u => u.productId).ToList<Stock>();
            return stockList;

        }
    }
}
