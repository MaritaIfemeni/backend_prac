using AutoMapper;
using Moq;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.RepoImplementations;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Domain.src.Shared;

namespace Wepapi.Testing;

public class UnitTest1
{
    private readonly Mock<IUserRepo> _mockUserRepo;
    private readonly IMapper _mapper;

    public UnitTest1()
    {
        _mockUserRepo = new Mock<IUserRepo>();
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<UserDto, User>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public void GetAllUsers()
    {
        // Arrange
        var userService = new UserService(_mockUserRepo.Object, _mapper);
        // Act
        var result = userService.GetAll(new QueryOptions());
        // Assert
        Assert.NotNull(result);
    }

    [Fact]

    public void GetOneUserById()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        User user = new User { Id = userId, FirstName = "John", LastName = "Doe", Email = "email@com", Password = "password", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        _mockUserRepo.Setup(repo => repo.GetOneById(userId.ToString())).Returns(user);
        UserService userService = new UserService(_mockUserRepo.Object, _mapper);

        // Act
        UserDto result = userService.GetOneById(userId.ToString());

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
        Assert.Equal("email@com", result.Email);
    }
}