using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VehicleData.Application.Interfaces;
using VehicleData.Application.ViewModels;

namespace VehicleData.Controllers
{
    /// <summary>
    /// Add or Manage Vehicle details
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private IVehicleService _vehicleService;

        /// <summary>
        /// Add or Manage Vehicle details
        /// </summary>
        /// <param name="logger"> The logger</param>
        /// <param name="vehicleService">Vehicle service</param>
        public VehiclesController(ILogger<VehiclesController> logger,
            IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Get the vehicle based on the filters
        /// </summary>
        /// <param name="year">Vehicle year</param>
        /// <param name="make">Vehicle make</param>
        /// <param name="model">Vehicle model</param>
        /// <returns>List of vehicles</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] int? year, [FromQuery] string make, [FromQuery] string model)
        {
            var response = _vehicleService.GetVehicles(make, model, year);
            return Ok(response);
        }


        /// <summary>
        /// Get a vehichle by id
        /// </summary>
        /// <param name="id">Vehichle id</param>
        /// <returns>Vehichle matching Id</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _vehicleService.GetVehicleAsync(id);

                return (result == null) ? NotFound() : Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Add a new vehichle
        /// </summary>
        /// <param name="vehicleData">Vehicle data to insert</param>
        /// <returns>vehicle that was added</returns>
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleViewModel vehicleData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleAdded = await _vehicleService.AddVehicleAsync(vehicleData);
                    if (vehicleAdded != null)
                    {
                        return Ok(vehicleAdded);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        /// <summary>
        /// Update the vehicle details
        /// </summary>
        /// <param name="vehicleData">vehicle data to update</param>
        /// <returns>True or False</returns>
        [HttpPut]
        public IActionResult UpdateVehicle([FromBody] VehicleViewModel vehicleData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _vehicleService.UpdateVehicle(vehicleData);
                    if (response)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        /// <summary>
        /// Delete the vehicle based on vehicle id
        /// </summary>
        /// <param name="id">vehichle id</param>
        /// <returns>True or False</returns>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteVehicle(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _vehicleService.DeleteVehicle(id);
                    if (response)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
    }
}
