using CrossCutting.DataObjects;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controller;

[ApiController]
[Route("api/projects")]

public class ProjectController: ControllerBase
{
    private IWorkingTimeManager _workingTimeManager;

    public ProjectController(IWorkingTimeManager workingTimeManager)
    {
        _workingTimeManager = workingTimeManager;
    }

    [HttpGet]
    public IQueryable<Project> GetProjects()
    {
       return _workingTimeManager.GetProjectItems();
    }
}