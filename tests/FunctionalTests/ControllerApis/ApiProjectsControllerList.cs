﻿//using Nikan.Services.BasicData.WebApi;
//using Xunit;

//namespace Nikan.Services.BasicData.FunctionalTests.ControllerApis;

//[Collection("Sequential")]
//public class ProjectCreate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
//{
//  private readonly HttpClient _client;

//  public ProjectCreate(CustomWebApplicationFactory<WebMarker> factory)
//  {
//    _client = factory.CreateClient();
//  }

//  [Fact]
//  public async Task ReturnsOneProject()
//  {
//    //var result = await _client.GetAndDeserialize<IEnumerable<ProjectDTO>>("/api/projects");

//    //Assert.Single(result);
//    //Assert.Contains(result, i => i.Name == SeedData.TestProject1.Name);
//  }
//}
