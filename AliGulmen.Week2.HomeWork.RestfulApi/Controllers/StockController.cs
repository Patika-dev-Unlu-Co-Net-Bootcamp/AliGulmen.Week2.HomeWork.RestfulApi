using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
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
            if (StockList.Count == 0)
                return NotFound("There is not any record in the list!");

            return Ok(StockList);
        }
    }
}
