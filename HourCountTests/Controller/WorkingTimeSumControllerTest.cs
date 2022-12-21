using CrossCutting.DataObjects;
using Newtonsoft.Json;

namespace HourCountTests.Controller;

[TestClass]
public class WorkingTimeSumControllerTest
{
    private readonly HttpClient _client;

    public WorkingTimeSumControllerTest()
    {
        var api = new CustomWorkingTimeApiFactory();
        _client = api.Client;
    }
    
    [TestCleanup]
    public void CleanUp()
    {        
        var database = new Database();
        database.ResetDatabase();
    }
    
    [TestMethod]
    public async Task GetWorkingTimeSums_employeeId1_Returns2Rows()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/working-time-sums?employeeID=1");
        var stringResult = await response.Content.ReadAsStringAsync();
        var workingTimeSums = JsonConvert.DeserializeObject<List<WorkingTimeSum>>(stringResult);
        
        //Assert
        Assert.AreEqual(2,workingTimeSums.Count);
    }

    
}