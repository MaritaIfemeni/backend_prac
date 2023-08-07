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


}