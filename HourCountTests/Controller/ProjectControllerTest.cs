using CrossCutting.DataObjects;
using Newtonsoft.Json;

namespace HourCountTests.Controller;

[TestClass]
public class ProjectControllerTest
{
    private readonly HttpClient _client;
    private readonly Database _database;

    public ProjectControllerTest()
    {
        var api = new CustomWorkingTimeApiFactory();
        _client = api.Client;
        _database = new Database();
    }
    

    [TestCleanup]
    public void CleanUp()
    {
      _database.ResetDatabase();
    }
    

    [TestMethod]
    public async Task GetProjects_ReturnsData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/projects");
        var stringResult = await response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(stringResult);
        
        //Assert
        Assert.AreEqual(2,projects.Count);
    }
    

}