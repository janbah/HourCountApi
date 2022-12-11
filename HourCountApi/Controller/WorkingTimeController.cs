using CrossCutting.DataObjects;
using HourCountApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controllers;

//[ApiController]

//[Route("[controller]")]
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
    
    [HttpGet]
    [Route("WorkingTimeTest")]
    public IEnumerable<WorkingTimeViewModel> GetWorkingTimeTest()
    {
        var workingTimes = _workingTimeManager.GetWorkingTimeTest();
        return _adapter.ToWorkingTimeViewModels(workingTimes);
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