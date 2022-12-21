using CrossCutting.DataObjects;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controller;


[ApiController]
[Route("api/working-time-sums")]

public class WorkingTimeSumController
{
    private readonly ILogger<WorkingTimeController> _logger;
    private readonly IWorkingTimeManager _workingTimeManager;

    public WorkingTimeSumController(ILogger<WorkingTimeController> logger, IWorkingTimeManager workingTimeManager)
    {
        _logger = logger;
        _workingTimeManager = workingTimeManager;
    }
    
    public IEnumerable<WorkingTimeSum> GetWorkingTimeSums(int employeeId)
    {
        var workingTimeSums = _workingTimeManager.GetWorkingTimeSums(employeeId);
        return workingTimeSums;
    }

    
    
    
}