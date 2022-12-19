using CrossCutting.DataObjects;
using HourCountApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controllers;

[ApiController]

[Route("api/working-times")]
public class WorkingTimeController : ControllerBase
{
    private readonly ILogger<WorkingTimeController> _logger;
    private readonly IWorkingTimeManager _workingTimeManager;
    private readonly WorkingTimeAdapter _adapter;
    
    public WorkingTimeController(ILogger<WorkingTimeController> logger, IWorkingTimeManager workingTimeManager, WorkingTimeAdapter adapter)
    {
        _logger = logger;
        _workingTimeManager = workingTimeManager;
        _adapter = adapter;
    }

    // [HttpGet]
    // [Route("GetAll")]
    // public List<WorkingTime> GetAll()
    // {
    //     return _workingTimeManager.GetAll().ToList();
    // }
    
    [HttpGet]
    [Route("{id}")]
    public WorkingTime GetWorkingTime(int id)
    {
        return _workingTimeManager.GetWorkingTime(id);
    }

    [HttpGet]
    public IEnumerable<WorkingTimeViewModel> GetWorkingTimes(int employeeId, DateTime selectedDate)
    {
        var workingTimes = _workingTimeManager.GetWorkingTimesByDate(selectedDate, employeeId);
        return _adapter.ToWorkingTimeViewModels(workingTimes);
    }

    [HttpPost]
    [Route("WorkingTime")]
    public async Task<ActionResult> InsertWorkingTime(WorkingTimeDto workingTimeDto)
    {
        try
        {
            if (workingTimeDto == null)
            {
                return BadRequest();
            }

            int id = _workingTimeManager.Add(workingTimeDto);
            return CreatedAtAction(nameof(GetWorkingTime), new { id, workingTimeDto });
        }
        
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new workingTime record");
        }
    }

    [HttpPut]
    [Route("WorkingTime")]
    public async Task<ActionResult> UpdateWorkingTime(WorkingTimeDto workingTimeDto)
    {
        try
        {
            if (workingTimeDto == null)
            {
                return BadRequest();
            }
            _workingTimeManager.Update(workingTimeDto);
            return Ok(workingTimeDto);
        }
        
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new workingTime record");
        }
    }

    
    [HttpDelete]
    [Route("{id}")]

    public ActionResult DeleteWorkingTime(int id)
    {
        try
        {
            if (id == null)
            {
                return BadRequest();
            }

            _workingTimeManager.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted, "Deleting workingTime record");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting workingTime record");
        } 
    }
    
    [HttpGet]
    [Route("WorkingTimeSum")]
    public IEnumerable<WorkingTimeSum> GetWorkingTimeSum()
    {
        return this._workingTimeManager.GetWorkingTimeOverView(1);
    }
}