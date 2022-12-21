using CrossCutting.DataObjects;
using Newtonsoft.Json;

namespace HourCountTests.Controller;

[TestClass]
public class CategoryControllerTest
{
    private readonly HttpClient _client;
    private readonly Database _database;

    public CategoryControllerTest()
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
    public async Task GetCategories_ReturnsData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/categories");
        var stringResult = await response.Content.ReadAsStringAsync();
        var categories = JsonConvert.DeserializeObject<List<Category>>(stringResult);
        
        //Assert
        Assert.AreEqual(3,categories.Count);
    }
    

}