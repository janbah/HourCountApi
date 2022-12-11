using CrossCutting.DataObjects;
using HourCountApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controllers;

[ApiController]

[Route("api/[controller]")]
public class WorkingTimeController : ControllerBase
{
    private readonly ILogger<WorkingTimeController> _logger;
    private readonly IWorkingTimeManager _workingTimeManager;
    private readonly WorkingTimeAdapter _adapter;

    private Employee martin = new Employee()
    {
        Name = "Martin"
    };

    public WorkingTimeController(ILogger<WorkingTimeController> logger, IWorkingTimeManager workingTimeManager, WorkingTimeAdapter adapter)
    {
        _logger = logger;
        _workingTimeManager = workingTimeManager;
        _adapter = adapter;
    }

    [HttpGet]
    [Route("WorkingTime")]
    public IEnumerable<WorkingTimeViewModel> GetWorkingTime(DateTime selectedDate)
    {
        var workingTimes = _workingTimeManager.GetWorkingTime(selectedDate, martin);
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

            _workingTimeManager.Add(workingTimeDto);

             return StatusCode(StatusCodes.Status201Created, "Created new workingTime Record");
        }
        
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new workingTime record");
        }
    }

    [HttpDelete]
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
    [Route("CurrentWorkingTimes")]
    public IEnumerable<WorkingTimeViewModel> GetCurrentWorkingTime()
    {
        var workingTimes = _workingTimeManager.GetWorkingTime(new DateTime(2022,4,28), martin);
        return _adapter.ToWorkingTimeViewModels(workingTimes);
    }
    
    [HttpGet]
    [Route("WorkingTimeSum")]
    public IEnumerable<WorkingTimeSum> GetWorkingTimeSum()
    {
        return this._workingTimeManager.GetWorkingTimeOverView(martin);
    }
}