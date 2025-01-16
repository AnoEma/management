
namespace Web.Tests.Services;

public class UserServiceTests
{
    //private readonly Mock<IUserCommandHandler> _mockCommandHandler;
    //private readonly Mock<IGetAllUserQueryHandler> _mockQueryHandler;
    //private readonly UserService _userService;

    //public UserServiceTests()
    //{
    //    _mockCommandHandler = new Mock<IUserCommandHandler>();
    //    _mockQueryHandler = new Mock<IGetAllUserQueryHandler>();
    //    _userService = new UserService(_mockCommandHandler.Object, _mockQueryHandler.Object);
    //}

    //[Fact]
    //public async Task AddUserAsync_ShouldReturnSuccess_WhenCommandSucceeds()
    //{
    //    // Arrange
    //    var user = new UserModel();
    //    var command = UserModel.CreateUserCommand(user);
    //    _mockCommandHandler.Setup(x => x.HandleAsync(command, It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Success());

    //    // Act
    //    var result = await _userService.AddUserAsync(user);

    //    // Assert
    //    Assert.True(result.IsSuccess);
    //}

    //[Fact]
    //public async Task AddUserAsync_ShouldReturnFailure_WhenCommandFails()
    //{
    //    // Arrange
    //    var user = new UserModel();
    //    var command = UserModel.CreateUserCommand(user);
    //    _mockCommandHandler.Setup(x => x.HandleAsync(command, It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Failure("Error"));

    //    // Act
    //    var result = await _userService.AddUserAsync(user);

    //    // Assert
    //    Assert.True(result.IsFailure);
    //    Assert.Equal("Error", result.Error);
    //}

    //[Fact]
    //public async Task DeleteAsync_ShouldReturnSuccess_WhenCommandSucceeds()
    //{
    //    // Arrange
    //    _mockCommandHandler.Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Success());

    //    // Act
    //    var result = await _userService.DeleteAsync(1);

    //    // Assert
    //    Assert.True(result.IsSuccess);
    //}

    //[Fact]
    //public async Task DeleteAsync_ShouldReturnFailure_WhenCommandFails()
    //{
    //    // Arrange
    //    _mockCommandHandler.Setup(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Failure("Error"));

    //    // Act
    //    var result = await _userService.DeleteAsync(1);

    //    // Assert
    //    Assert.True(result.IsFailure);
    //    Assert.Equal("Error", result.Error);
    //}

    //[Fact]
    //public async Task GetUserByIdAsync_ShouldReturnSuccess_WhenQuerySucceeds()
    //{
    //    // Arrange
    //    var userCommand = new UserCommand();
    //    _mockQueryHandler.Setup(x => x.HandleAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Success(userCommand));

    //    // Act
    //    var result = await _userService.GetUserByIdAsync(1);

    //    // Assert
    //    Assert.True(result.IsSuccess);
    //}

    //[Fact]
    //public async Task GetUserByIdAsync_ShouldReturnFailure_WhenQueryFails()
    //{
    //    // Arrange
    //    _mockQueryHandler.Setup(x => x.HandleAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Failure<UserCommand>("Error"));

    //    // Act
    //    var result = await _userService.GetUserByIdAsync(1);

    //    // Assert
    //    Assert.True(result.IsFailure);
    //    Assert.Equal("Error", result.Error);
    //}

    //[Fact]
    //public async Task GetUsersAsync_ShouldReturnSuccess_WhenQuerySucceeds()
    //{
    //    // Arrange
    //    var userQueryList = new List<GetAllUserQuery>();
    //    _mockQueryHandler.Setup(x => x.HandleAsync(It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Success(userQueryList.AsReadOnly()));

    //    // Act
    //    var result = await _userService.GetUsersAsync();

    //    // Assert
    //    Assert.True(result.IsSuccess);
    //}

    //[Fact]
    //public async Task GetUsersAsync_ShouldReturnFailure_WhenQueryFails()
    //{
    //    // Arrange
    //    _mockQueryHandler.Setup(x => x.HandleAsync(It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Failure<IReadOnlyList<GetAllUserQuery>>("Error"));

    //    // Act
    //    var result = await _userService.GetUsersAsync();

    //    // Assert
    //    Assert.True(result.IsFailure);
    //    Assert.Equal("Error", result.Error);
    //}

    //[Fact]
    //public async Task UpdateUserAsync_ShouldReturnSuccess_WhenCommandSucceeds()
    //{
    //    // Arrange
    //    var user = new UserModel();
    //    var command = UserModel.CreateUserCommand(user);
    //    _mockCommandHandler.Setup(x => x.UpdateAsync(command, It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Success());

    //    // Act
    //    var result = await _userService.UpdateUserAsync(user);

    //    // Assert
    //    Assert.True(result.IsSuccess);
    //}

    //[Fact]
    //public async Task UpdateUserAsync_ShouldReturnFailure_WhenCommandFails()
    //{
    //    // Arrange
    //    var user = new UserModel();
    //    var command = UserModel.CreateUserCommand(user);
    //    _mockCommandHandler.Setup(x => x.UpdateAsync(command, It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(Result.Failure("Error"));

    //    // Act
    //    var result = await _userService.UpdateUserAsync(user);

    //    // Assert
    //    Assert.True(result.IsFailure);
    //    Assert.Equal("Error", result.Error);
    //}
}
