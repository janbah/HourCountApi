using CrossCutting.DataObjects;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController : ControllerBase
{
    private IWorkingTimeManager _workingTimeManager;
    
    public CategoryController(IWorkingTimeManager workingTimeManager)
    {
        _workingTimeManager = workingTimeManager;
    }

    [HttpGet]
    [Route("Category")]
    public IEnumerable<Category> GetCategories()
    {
        return _workingTimeManager.GetCategoryItems();
    }
}