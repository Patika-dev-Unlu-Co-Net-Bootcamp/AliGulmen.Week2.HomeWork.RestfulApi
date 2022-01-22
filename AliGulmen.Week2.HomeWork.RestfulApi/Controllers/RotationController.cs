using AliGulmen.Week2.HomeWork.RestfulApi.Entities;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.CreateRotation;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.DeleteRotation;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotationDetail;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotationLocations;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotationProducts;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.GetRotations;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.UpdateRotation;
using AliGulmen.Week2.HomeWork.RestfulApi.Operations.RotationOperations.UpdateRotationCode;
using Microsoft.AspNetCore.Mvc;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
	[ApiController]
	public class RotationController : ControllerBase
	{

		
		public RotationController()
		{ }

		/************************************* GET *********************************************/

		//Get all records
		//GET api/rotations
		[HttpGet]
		public IActionResult GetRotations()
		{
			var query = new GetRotationsQuery();
			var result = query.Handle();
			return Ok(result);
		}


		//Get only one record from list
		//GET api/rotations/1
		[HttpGet("{id}")]
		public IActionResult GetRotationById(int id)
		{
			var query = new GetRotationDetailQuery();
			query.RotationId = id;

			var result = query.Handle();
			return Ok(result);
		}


		//Get locations by rotation
		//GET api/rotations/1/Locations
		[HttpGet("{id}/Locations")]
		public IActionResult GetLocationsByRotation(int id)
		{
			var query = new GetRotationLocationsQuery();
			query.RotationId = id;

			var result = query.Handle();
			return Ok(result);
		}


		//Get products by rotation
		//GET api/rotations/1/Products
		[HttpGet("{id}/Products")]
		public IActionResult GetProductsByRotation(int id)
		{
			var query = new GetRotationProductsQuery();
			query.RotationId = id;

			var result = query.Handle();
			return Ok(result);
		}



		/************************************* POST *********************************************/



		//POST api/rotations
		[HttpPost]
		public IActionResult CreateRotation([FromBody] Rotation newRotation)
		{
			var command = new CreateRotationCommand();
			command.Model = newRotation;
			command.Handle();

			return Created("~api/rotations", newRotation); //http 201
		}



		/************************************* PUT *********************************************/


		//Update all informations
		//PUT api/rotations/id
		[HttpPut("{id}")]
		public IActionResult Update(int id,Rotation newRotation)
		{

			var command = new UpdateRotationCommand();
			command.RotationId = id;
			command.Model = newRotation;


			command.Handle();
			return NoContent(); //http 204 
		}


		/************************************* DELETE *********************************************/

		//DELETE api/rotations/id
		[HttpDelete("{id}")]

		public IActionResult Delete(int id)
		{
			var command = new DeleteRotationCommand();
			command.RotationId = id;
			command.Handle();

			return NoContent(); //http 204 
		}



		/************************************* PATCH *********************************************/

		//udate rotationCode information
		//PATCH api/rotations/id
		[HttpPatch("{id}")]
		public IActionResult UpdateCode(int id, string code)
		{
			var command = new UpdateRotationCodeCommand();
			command.RotationId = id;
			command.Code = code;


			command.Handle();
			return NoContent(); //http 204

		}





	}
}
