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
    
    [TestMethod]
    public async Task GetProjects_Returns_Fair()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/projects");
        var stringResult = await response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(stringResult);
        
        //Assert
        var project = projects[0];
        Assert.IsNotNull(project.Fair);
    }
    
    [TestMethod]
    public async Task GetProjects_Returns_Customer()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/projects");
        var stringResult = await response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(stringResult);
        
        //Assert
        var project = projects[0];
        Assert.IsNotNull(project.Customer);
    }
    
    [TestMethod]
    public async Task GetProjects_Returns_ValidProjectName()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/projects");
        var stringResult = await response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(stringResult);
        
        //Assert
        var project = projects[0];
        Assert.AreEqual("Cust 1-HMI-2022",project.Name);
    }

}