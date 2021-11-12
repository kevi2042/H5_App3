using AppProjekt.Models;
using AppProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        //private readonly IMeasurementService _service;

        //public MeasurementController(IMeasurementService service)
        //{
        //    _service = service;
        //}

        ////api/<MeasurementController>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Measurement>>> Get()
        //{
        //    return Ok(await _service.GetMeasurementsAsync());
        //}

        //// api/<MeasurementController>/{id}
        //[HttpGet]
        //public async Task<ActionResult<Measurement>> Get(string id)
        //{
        //    if (string.IsNullOrWhiteSpace(id))
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_service.GetSingleMeasurement(Convert.ToInt32(id)));
        //}

        //// api/<MeasurementController>
        //[HttpPost]
        //public async Task<ActionResult<Measurement>> Post(Measurement measurement)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    await _service.AddMeasurementAsync(measurement);
        //    //    return CreatedAtRoute(nameof(Get), new { id = measurement.entry_id }, measurement);
        //    //}
        //    return BadRequest();
        //}

        //// api/<MeasurementController>/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(string id, [FromBody] Measurement measurement)
        //{
        //    if (measurement == null)
        //    {
        //        return BadRequest();
        //    }

        //    // Exist method still under developing
        //    if (!await _service.Exists(Convert.ToInt32(id)))
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        await _service.UpdateMeasurementAsync(measurement);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }

        //    return NoContent();     // HTTP Status 204
        //}

        //// api/<MeasurementController>/{id}
        //[HttpDelete("id")]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    return null;
        //}
    }
}
