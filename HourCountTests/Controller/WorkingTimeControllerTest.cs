using System.Net.Http.Json;
using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;
using Newtonsoft.Json;

namespace HourCountTests.Controller;

[TestClass]
public class WorkingTimeControllerTest
{
    private readonly HttpClient _client;

    public WorkingTimeControllerTest()
    {
        var api = new CustomWorkingTimeApiFactory();
        _client = api.Client;
    }
    

    [TestCleanup]
    public void CleanUp()
    {
        Database database = new Database();
        database.ResetDatabase();
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
        var content = await response.Content.ReadAsStringAsync();
        
        //Assert
        Assert.IsTrue(content.Contains("working-time data with id 10 not found"));
    }
    
    [TestMethod]
    public async Task DeleteWorkingTime_WorkingTimeEntryIsDeleted()
    {
        //Arrange
        //Act
        await _client.DeleteAsync("api/working-times/2");

        Database database = new Database();
        var result = database.GetWorkingTimes().Count(w => w.Id==2);
        
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

        //Act
        await _client.PostAsJsonAsync("api/working-times", workingTimeDto );

        //Assert
        Database database = new Database();
        var result = database.GetWorkingTimes().Count();
        Assert.AreEqual(5,result);
    }
    
    [TestMethod]
    public async Task InsertDecimalEntry4Point5_EntryIsStoredCorrectly()
    {
        //Arrange
        WorkingTimeDto workingTimeDto = new WorkingTimeDto()
        {
            EmployeeId = 1,
            CategoryId = 1,
            Date = new DateTime(2022, 12, 14),
            Comment = "test",
            ProjectId = 2,
            TimeEntry = 4.5
        };

        //Act
        await _client.PostAsJsonAsync("api/working-times", workingTimeDto );

        //Assert
        var database = new Database();
        var result = database.GetWorkingTimes().Last();
        Assert.AreEqual((decimal)4.5,result.TimeEntry);
    }

    
    [TestMethod]
    public async Task UpdateWorkingTime_EntryIsUpdated()
    {
        //Arrange
        WorkingTimeDto workingTimeDto = new WorkingTimeDto()
        {
            Id = 1,
            EmployeeId = 2,
            CategoryId = 2,
            Date = new DateTime(),
            Comment = "update",
            ProjectId = 2,
            TimeEntry = 4
        };

        //Act
        await _client.PutAsJsonAsync("api/working-times", workingTimeDto );

        //Assert
        var database = new Database();
        var result = database.GetWorkingTimes().First(wt => wt.Id == 1);
        Assert.AreEqual(2,result.Employee.Id);
        Assert.AreEqual(2,result.Category.Id);
        Assert.AreEqual(2,result.Project.Id);
        Assert.AreEqual("update",result.Comment);
        Assert.AreEqual(4,result.TimeEntry);
    }
}