using AliGulmen.Week2.HomeWork.RestfulApi.Operations.StockOperations.GetStocks;
using Microsoft.AspNetCore.Mvc;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StockController : ControllerBase
    {
      
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
