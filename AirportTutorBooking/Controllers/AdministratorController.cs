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
    public class AdministratorController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IAdministrator _dataRepository;

        public AdministratorController(ILogger<AdministratorsModel> logger, IAdministrator dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(GetList));

            try
            {
                List<AdministratorsModel> administrators = await _dataRepository.GetAllList();

                _logger?.LogInformation("Records have been retrieved successfully.");

                return Ok(administrators);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetList), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddRecord")]
        public async Task<IActionResult> NewAdministrator([FromBody] AdministratorsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(NewAdministrator));

            try
            {
                var administrator = await _dataRepository.CreateRecord(request);

                _logger?.LogInformation("Record have been added successfully.");

                return Ok(administrator);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(NewAdministrator), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] AdministratorsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Login));

            try
            {
                var administrator = await _dataRepository.Login(request);

                _logger?.LogInformation("User succesfully logged in.");

                return Ok(administrator);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(Login), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("Delete")]
        public async Task<IActionResult> SoftDelete([FromBody] AdministratorsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(SoftDelete));

            try
            {
                var administrator = await _dataRepository.DeleteRecord(request);

                _logger?.LogInformation("User succesfully set to inactive.");

                return Ok(administrator);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SoftDelete), ex);
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAdministrator([FromBody] AdministratorsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(UpdateAdministrator));

            try
            {
                var administrator = await _dataRepository.UpdateRecord(request);

                _logger?.LogInformation("Record have been updated successfully.");

                return Ok(administrator);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(UpdateAdministrator), ex);
                return BadRequest(ex);
            }
        }
    }
}