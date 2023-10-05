using CloudCustomer.API.Controllers;
using CloudCustomer.API.Models;
using CloudCustomer.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomer.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
       .Setup(x => x.GetUsers())
       .ReturnsAsync(new List<User>
       {
           new User { Id = 1, Name = "John Doe", Email = "", Address = new Address { City = "London", Street = "Baker Street", PostalCode = "221B", Id = 1 }}
       });

        var sut = new UsersController(mockUsersService.Object);
        

        //Act

        var result = (OkObjectResult)  await sut.GetUsers();

        //Assert

        result.StatusCode.Should().Be(200);
    }
    [Fact]
    public async Task Get_OnSuccess_InvokesUsersService()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(x => x.GetUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController( mockUsersService.Object );


        // act
        var result =  await sut.GetUsers();

        // assert
        mockUsersService.Verify(x => x.GetUsers(), Times.Once);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsUsers()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(x => x.GetUsers())
                .ReturnsAsync(new List<User>
                       {
                           new User { Id = 1, Name = "John Doe", Email = "", Address = new Address { City = "London", Street = "Baker Street", PostalCode = "221B", Id = 1 }}
                       });
        var sut = new UsersController( mockUsersService.Object );
        // act
        var result = (OkObjectResult) await sut.GetUsers();

        // assert

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult) result;
        objectResult.Value.Should().BeOfType<List<User>>();

    }
    [Fact]
    public async Task Get_OnNotFound_Returns404()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(x => x.GetUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act

        var result = (NotFoundResult) await sut.GetUsers();

        // Assert

        result.Should().BeOfType<NotFoundResult>();
    }
}