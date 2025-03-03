using Moq;
using Xunit;
using Ambev.DeveloperEvaluation.Application.Services.Implementations;
using Ambev.DeveloperEvaluation.Application.Services.Interfaces;
using Ambev.DeveloperEvaluation.Application.Services.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IUserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _mapperMock = new Mock<IMapper>();
        _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
    }

    // Testes de criação de usuário com sucesso
    [Fact]
    public async Task Criar_Usuario_Com_Sucesso()
    {
        var createUserDto = new CreateUserDto { Name = "Leo User", Email = "leo@hotmail.com" };
        var userEntity = new User { Id = System.Guid.NewGuid(), Name = "Leo User", Email = "leo@hotmail.com" };
        var userDto = new UserDto { Id = userEntity.Id, Name = "Leo User", Email = "leo@hotmail.com" };

        _mapperMock.Setup(m => m.Map<User>(createUserDto)).Returns(userEntity);
        _mapperMock.Setup(m => m.Map<UserDto>(userEntity)).Returns(userDto);
        _userRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>())).ReturnsAsync(userEntity);

        var result = await _userService.CreateUserAsync(createUserDto);

        Assert.NotNull(result);
        Assert.Equal("Leo User", result.Name);
        Assert.Equal("leo@hotmail.com", result.Email);
    }

    // Testes de busca de usuário por ID que não existe 
    [Fact]
    public async Task Retornar_Nulo_Quando_Usuario_Nao_Existe()
    {
        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<System.Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((User?)null);

        var result = await _userService.GetUserByIdAsync(System.Guid.NewGuid());

        Assert.Null(result);
    }

    // Testes de exclusão de usuário com sucesso
    [Fact]
    public async Task Excluir_Usuario_Com_Sucesso()
    {
        var userId = Guid.NewGuid();

        _userRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<System.Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var result = await _userService.DeleteUserAsync(userId);

        Assert.True(result);
    }


}
