using System.Data;
using System.Data.Common;
using System.Net.Http.Json;
using CrossCutting.DataObjects;
using DataStoring.Repositories;
using HourCountApi.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace HourCountTests;

[TestClass]
public class WorkingTimeControllerTest
{
    private  CustomWorkingTimeApiFactory<WorkingTimeController> _api;
    private  HttpClient _client;
    private Database _database = default!;


    public WorkingTimeControllerTest()
    {
        _api = new CustomWorkingTimeApiFactory<WorkingTimeController>();
        _client = _api.Client;
        _database = new Database();
        //_database.ResetDatabase();
    }
    

    [TestCleanup]
    public void CleanUp()
    {
      _database.ResetDatabase();
    }
    

    [TestMethod]
    public async Task GetWorkingTimes_employeeId1_2022_12_14_ReturnsData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/working-times?employeeID=1&SelectedDate=2022-12-14");
        var stringResult = await response.Content.ReadAsStringAsync();
        var workingTimes = JsonConvert.DeserializeObject<List<WorkingTime>>(stringResult);
        
        //Assert
        Assert.AreEqual(3,workingTimes.Count);
    }
    
    [TestMethod]
    public async Task GetWorkingTimes_employeeId0_2022_12_14_ReturnsNoData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/working-times?employeeID=0&SelectedDate=2022-12-14");
        var stringResult = await response.Content.ReadAsStringAsync();
        var workingTimes = JsonConvert.DeserializeObject<List<WorkingTime>>(stringResult);
        
        //Assert
        Assert.AreEqual(0,workingTimes.Count);
    }

    [TestMethod]
    public async Task GetWorkingTime_id_4_ReturnsData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/working-times/4");
        var stringResult = await response.Content.ReadAsStringAsync();
        var workingTime = JsonConvert.DeserializeObject<WorkingTime>(stringResult);
        
        //Assert
        Assert.AreEqual(4, workingTime.Id);
    }
    
    [TestMethod]
    public async Task GetWorkingTime_id_10_ReturnsNoData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/working-times/10");
        var stringResult = await response.Content.ReadAsStringAsync();
        var workingTime = JsonConvert.DeserializeObject<WorkingTime>(stringResult);
        
        //Assert
        Assert.IsNull(workingTime);
    }
    
    [TestMethod]
    public async Task DeleteWorkingTime_WorkingTimeEntryIsDeleted()
    {
        //Arrange
        //Act
        await _client.DeleteAsync("api/working-times/2");

        Database database = new Database();
        var result = database.GetWorkingTimes().Where(w=>w.Id==2).Count();
        
        //Assert
        Assert.AreEqual(0,result);
    }
    
    [TestMethod]
    public async Task InsertWorkingTime_EntryIsInserted()
    {
        //Arrange
        WorkingTimeDto workingTimeDto = new WorkingTimeDto()
        {
            EmployeeId = 1,
            CategoryId = 1,
            Date = new DateTime(2022, 12, 14),
            Comment = "test",
            ProjectId = 2,
            TimeEntry = 7
        };

        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add(nameof(workingTimeDto.EmployeeId),"1");
        dictionary.Add(nameof(workingTimeDto.CategoryId),"1");
        dictionary.Add(nameof(workingTimeDto.Date),"2022-12-14");
        dictionary.Add(nameof(workingTimeDto.Comment),"test");
        dictionary.Add(nameof(workingTimeDto.ProjectId),"2");
        dictionary.Add(nameof(workingTimeDto.TimeEntry),"7");

        var content = new FormUrlEncodedContent(dictionary);
        
        //Act
        //JsonContent jsonContent = new JsonContent(workingTimeDto);
        await _client.PostAsJsonAsync("api/working-times", workingTimeDto );

        Database database = new Database();
        var result = database.GetWorkingTimes().Count();
        
        //Assert
        Assert.AreEqual(5,result);
    }
}