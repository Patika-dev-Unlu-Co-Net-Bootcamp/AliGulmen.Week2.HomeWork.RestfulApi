using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Services.StorageService
{
    public class WarehouseStorage : IStorageService
    {
        private static List<Stock> StockList = DataGenerator.StockList;
        public void AddToStock(Container container)
        {
            
            //if the client has warehouse all containers will be added to stockOnRack stock.

            var stock = StockList.FirstOrDefault(s => s.productId == container.productId);
            if (stock != null)
                stock.stockOnRack += 1;
            else
                StockList.Add(new Stock { productId = container.productId, readyToShip = 0, stockOnRack = 1 });
        }

        public void Locate(Container container)
        {
            //The container will be relocated to first empty place on rack. let's assume that 2. location
            container.locationId = 232;
        }
    }
}
