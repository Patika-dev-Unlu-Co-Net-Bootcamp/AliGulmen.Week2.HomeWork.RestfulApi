using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.CreateProduct;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.DeleteProduct;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.GetProductContainers;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.GetProductDetail;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.GetProductListByRotation;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.GetProducts;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.UpdateProduct;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ProductOperations.UpdateProductAvailability;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase


    {


        public ProductController()
        { }

        /************************************* GET *********************************************/

        //Get all records
        //GET api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var query = new GetProductsQuery();
            var result = query.Handle();
            return Ok(result);
        }



        //GET api/products/1
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var query = new GetProductDetailQuery();
            query.ProductId = id;

            var result = query.Handle();
            return Ok(result);
        }

        //Get all containers for selected product
        //GET api/products/1/Containers
        [HttpGet("{id}/Containers")]
        public IActionResult GetContainersByProduct(int id)
        {
            var query = new GetProductContainersQuery();
            query.ProductId = id;

            var result = query.Handle();
            return Ok(result);
        }


        //Get all products belongs to specific rotation
        //GET api/products/list?rotationId=1
        [HttpGet("list")]
        public IActionResult GetProductsByRotation([FromQuery] int rotationId)
        {

            var query = new GetProductListQuery();
            query.RotationId = rotationId;

            var result = query.Handle();
            return Ok(result);
        }


        /************************************* POST *********************************************/



        //POST api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            var command = new CreateProductCommand();
            command.Model = newProduct;
            command.Handle();

            return Created("~api/products", newProduct); //http 201
        }



        /************************************* PUT *********************************************/


        //Update all informations
        //PUT api/products/id
        [HttpPut("{id}")]
        public IActionResult Update(int id,Product newProduct)
        {

            var command = new UpdateProductCommand();
            command.ProductId = id;
            command.Model = newProduct;


            command.Handle();
            return NoContent(); //http 204 
        }


        /************************************* DELETE *********************************************/


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var command = new DeleteProductCommand();
            command.ProductId = id;
            command.Handle();
            return NoContent(); //http 204 
        }



        /************************************* PATCH *********************************************/

        //udate availability information
        //PATCH api/products/id
        [HttpPatch("{id}")]
        public IActionResult UpdateAvailability(int id, bool isActive)
        {
            var command = new UpdateProductAvbCommand();
            command.ProductId = id;
            command.IsActive = isActive;


            command.Handle();
            return NoContent(); //http 204

        }






    }
}
