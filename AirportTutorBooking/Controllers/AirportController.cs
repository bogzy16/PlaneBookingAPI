using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirportTutorBooking.Models;
using AirportTutorBooking.Data;
using AirportTutorBooking.IRepository;
using Microsoft.Extensions.Logging;

namespace AirportTutorBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IAirports _dataRepository;

        public AirportController(ILogger<AirportsModel> logger, IAirports dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAirports()
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(GetAllAirports));

            try
            {
                List<AirportsModel> airports = await _dataRepository.GetAllList();

                _logger?.LogInformation("Records have been retrieved successfully.");

                return Ok(airports);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetAllAirports), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("NewAirport")]
        public async Task<IActionResult> AddAirport([FromBody] AirportsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(AddAirport));

            try
            {
                var airport = await _dataRepository.CreateRecord(request);

                _logger?.LogInformation("Airport succesfully added.");

                return Ok(airport);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(AddAirport), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("GetAirportPlanes")]
        public async Task<IActionResult> GetAirportPlanes([FromBody] AirportsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(GetAirportPlanes));

            try
            {
                var airport = await _dataRepository.GetAirportPlanes(request);

                _logger?.LogInformation("Airport succesfully added.");

                return Ok(airport);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetAirportPlanes), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("Delete")]
        public async Task<IActionResult> SoftDelete([FromBody] AirportsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(SoftDelete));

            try
            {
                var airport = await _dataRepository.DeleteRecord(request);

                _logger?.LogInformation("User succesfully set to inactive.");

                return Ok(airport);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SoftDelete), ex);
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAirport([FromBody] AirportsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(UpdateAirport));

            try
            {
                var airport = await _dataRepository.UpdateRecord(request);

                _logger?.LogInformation("Record have been updated successfully.");

                return Ok(airport);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(UpdateAirport), ex);
                return BadRequest(ex);
            }
        }
    }
}