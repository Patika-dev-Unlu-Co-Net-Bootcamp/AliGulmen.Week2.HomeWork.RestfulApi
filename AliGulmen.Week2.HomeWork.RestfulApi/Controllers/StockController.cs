using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.StockOperations.GetStocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private static List<Stock> StockList = DataGenerator.StockList;

        //GET api/stocks
        [HttpGet]
        public IActionResult GetStocks()
        {
            var query = new GetStocksQuery();
            var result = query.Handle();
            return Ok(result);
          
        }
    }
}
