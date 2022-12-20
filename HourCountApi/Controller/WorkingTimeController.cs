using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;
using HourCountApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controller;

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
    public Task<ActionResult> InsertWorkingTime(WorkingTimeDto workingTimeDto)
    {
        try
        {
            int id = _workingTimeManager.Add(workingTimeDto);
            return Task.FromResult<ActionResult>(CreatedAtAction(nameof(GetWorkingTime), new { id, workingTimeDto }));
        }
        
        catch (Exception)
        {
            return Task.FromResult<ActionResult>(StatusCode(StatusCodes.Status500InternalServerError, "Error creating new workingTime record"));
        }
    }

    [HttpPut]
    public Task<ActionResult> UpdateWorkingTime(WorkingTimeDto workingTimeDto)
    {
        try
        {
            _workingTimeManager.Update(workingTimeDto);
            return Task.FromResult<ActionResult>(Ok(workingTimeDto));
        }
        
        catch (Exception)
        {
            return Task.FromResult<ActionResult>(StatusCode(StatusCodes.Status500InternalServerError, "Error creating new workingTime record"));
        }
    }

    
    [HttpDelete]
    [Route("{id}")]

    public ActionResult DeleteWorkingTime(int id)
    {
        try
        {
            _workingTimeManager.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted, "Deleting workingTime record");
        }
        catch (Exception)
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