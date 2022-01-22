using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AliGulmen.Week2.HomeWork.RestfulApi.DbOperations;
using AliGulmen.Week2.HomeWork.RestfulApi.Services.StorageService;
using AliGulmen.Week2.HomeWork.RestfulApi.Extensions;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.GetContainers;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.GetContainerDetail;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.CreateContainer;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.UpdateContainer;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.DeleteContainer;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.UpdateContainerLocation;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.ContainerOperations.GetContainerListByWeight;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase

    {

         private readonly IStorageService _storageService;


        public ContainerController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        /************************************* GET *********************************************/

        //GET api/containers
        [HttpGet]
        public IActionResult GetContainers()
        {
            var query = new GetContainersQuery();
            var result = query.Handle();
            return Ok(result);
        }

        //GET api/containers/1
        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var query = new GetContainerDetailQuery();
            query.ContainerId = id;

            var result = query.Handle();
            return Ok(result);
        }


        //Get all containers by max weight ordered by weight
        //GET api/products/list?maxWeight=100
        [HttpGet("list")]
        public IActionResult GetContainersByMaxWeight([FromQuery] int maxWeight)
        {

            var query = new GetContainerListQuery();
            query.MaxWeight = maxWeight;

            var result = query.Handle();
            return Ok(result);
        }




        /************************************* POST *********************************************/



        //POST api/containers
        [HttpPost]
        public IActionResult CreateContainer([FromBody] Container newContainer)
        {
            var command = new CreateContainerCommand();
            command.Model = newContainer;
            command.Handle();

            return Created("~api/containers", newContainer); //http 201 
        }



        /************************************* PUT *********************************************/


        //Update all informations
        //PUT api/containers/id
        [HttpPut("{id}")]
        public IActionResult Update(int id,Container newContainer)
        {
            var command = new UpdateContainerCommand();
            command.ContainerId = id;
            command.Model = newContainer;


            command.Handle();

            return NoContent(); //http 204 

        }


        /************************************* DELETE *********************************************/

        //DELETE api/rotations/id
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var command = new DeleteContainerCommand();
            command.ContainerId = id;
            command.Handle();

            return NoContent(); //http 204
        }



        /************************************* PATCH *********************************************/


        [HttpPatch("{id}")]
        public IActionResult UpdateLocation(int id, int locationId)
        {
            var command = new UpdateContainerLocationCommand();
            command.ContainerId = id;
            command.LocationId = locationId;


            command.Handle();

            return NoContent(); //http 204


        }
    }
}
