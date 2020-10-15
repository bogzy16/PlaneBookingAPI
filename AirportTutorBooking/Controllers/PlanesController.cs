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
    public class PlanesController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IPlanes _dataRepository;

        public PlanesController(ILogger<PlanesModel> logger, IPlanes dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanes()
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(GetAllPlanes));

            try
            {
                var airports = await _dataRepository.GetAllList();

                _logger?.LogInformation("Records have been retrieved successfully.");

                return Ok(airports);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetAllPlanes), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("NewPlane")]
        public async Task<IActionResult> NewPlane([FromBody] PlanesModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(NewPlane));

            try
            {
                var plane = await _dataRepository.CreateRecord(request);

                _logger?.LogInformation("Airport succesfully added.");

                return Ok(plane);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(NewPlane), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromBody] PlanesModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(SoftDelete));

            try
            {
                var plane = await _dataRepository.DeleteRecord(request);

                _logger?.LogInformation("Airport succesfully set to inactive.");

                return Ok(plane);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SoftDelete), ex);
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] PlanesModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Update));

            try
            {
                var plane = await _dataRepository.UpdateRecord(request);

                _logger?.LogInformation("Record have been updated successfully.");

                return Ok(plane);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(Update), ex);
                return BadRequest(ex);
            }
        }
    }
}