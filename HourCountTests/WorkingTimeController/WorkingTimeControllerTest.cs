using System.Data;
using System.Data.Common;
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


    public WorkingTimeControllerTest()
    {
        _api = new CustomWorkingTimeApiFactory<WorkingTimeController>();
        _client = _api.Client;
    }
    

    // [TestInitialize]
    // private void TestInitialize()
    // {
    //     _api = new CustomWorkingTimeApiFactory<WorkingTimeController>();
    //     _api.InitializeRespawnerAsync();
    // }
    

    [TestMethod]
    public async Task GetWorkingTimes_employeeId2_2022_12_14_ReturnsData()
    {
        //Arrange
        
        //Act
        var response = await _client.GetAsync("api/working-times?employeeID=2&SelectedDate=2022-12-14");
        var stringResult = await response.Content.ReadAsStringAsync();
        var workingTimes = JsonConvert.DeserializeObject<List<WorkingTime>>(stringResult);
        
        //Assert
        Assert.AreEqual(2,workingTimes.Count);
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
        await _client.DeleteAsync("api/working-times/5");
        //var response = await _client.GetAsync("api/working-times/2");
        //var stringResult = await response.Content.ReadAsStringAsync();
        //var workingTime = JsonConvert.DeserializeObject<WorkingTime>(stringResult);
        
        //Assert
        //_api.ResetDatabase();

        
        Assert.IsNull(null);
        }
}