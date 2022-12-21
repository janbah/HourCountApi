using CrossCutting.DataObjects;
using Microsoft.AspNetCore.Mvc;
using WorkingTimeManagement;

namespace HourCountApi.Controller;

[ApiController]
[Route("api/categories")]

public class CategoryController : ControllerBase
{
    private IWorkingTimeManager _workingTimeManager;
    
    public CategoryController(IWorkingTimeManager workingTimeManager)
    {
        _workingTimeManager = workingTimeManager;
    }

    [HttpGet]
    public IEnumerable<Category> GetCategories()
    {
        return _workingTimeManager.GetCategoryItems();
    }
}