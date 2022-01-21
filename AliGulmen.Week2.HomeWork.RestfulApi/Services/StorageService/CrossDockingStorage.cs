using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Services.StorageService
{
    //CrossDocking : send shipping without storing containers inside the warehouse,
    //This saves time, storage space, and cost. In this option, the containers will be located directly on dockArea for shipping.
    //warehouse locations won't be an option for containers
    public class CrossDockingStorage : IStorageService
    {
        private static List<Stock> StockList = DataGenerator.StockList;
        public void AddToStock(Container container)
        {
            //there are two type of stock,
            //first one is readyToShip which defines the containers on dockArea,
            //second one stockOnRack which define stock on warehouse
            //if the client has crossdockingstorage all containers will be added to readyToShip stock.

            var stock = StockList.FirstOrDefault(s => s.productId > container.productId);
            if (stock != null)
                stock.readyToShip += 1;
            else
                StockList.Add(new Stock { productId=container.productId, readyToShip=1,stockOnRack=0});
        }

        public void Locate(Container container)
        {
            //The container will be relocated to DockArea anyway
            container.locationId = 1;
        }
    }
}
