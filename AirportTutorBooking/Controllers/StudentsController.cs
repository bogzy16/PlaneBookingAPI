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
    public class StudentsController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IStudents _dataRepository;

        public StudentsController(ILogger<StudentsModel> logger, IStudents dataRepository)
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
                List<StudentsModel> stuents = await _dataRepository.GetAllList();

                _logger?.LogInformation("Records have been retrieved successfully.");

                return Ok(stuents);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetList), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddRecord")]
        public async Task<IActionResult> NewStudent([FromBody] StudentsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(NewStudent));

            try
            {
                var student = await _dataRepository.CreateRecord(request);

                _logger?.LogInformation("Record have been added successfully.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(NewStudent), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] StudentsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Login));

            try
            {
                var student = await _dataRepository.Login(request);

                _logger?.LogInformation("User succesfully logged in.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(Login), ex);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("SoftDelete")]
        public async Task<IActionResult> SoftDelete([FromBody] StudentsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(SoftDelete));

            try
            {
                var student = await _dataRepository.DeleteRecord(request);

                _logger?.LogInformation("User succesfully set to inactive.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(SoftDelete), ex);
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] StudentsModel request)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Update));

            try
            {
                var student = await _dataRepository.UpdateRecord(request);

                _logger?.LogInformation("Record have been updated successfully.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(Update), ex);
                return BadRequest(ex);
            }
        }
    }
}