using Xunit;

namespace Domain.UnitTests;

public sealed class UserUnitTests
{
    [Fact]
    public void FindUserById_Shoud_Return_UserNotNull()
    {
        var user = User.FindById(new Guid());

        Assert.True(user != null);
    }

    [Fact]
    public void CreateUser_Should_Return_UserNotNull()
    {
        var user = User.Create(
            name: "username",
            email: "username@gmail.com",
            password: "newPassword");

        Assert.Equal("username", user.Name);
        Assert.Equal("username@gmail.com", user.Email);
        Assert.Equal("newPassword", user.Password);
    }

    [Fact]
    public void CreateUser_Should_ReturnError_WhenUsernameIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => User.Create(
            name: "",
            email: "username@gmail.com",
            password: "newPassword"));
    }

    [Fact]
    public void CreateUser_Should_ReturnError_WhenEmailIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => User.Create(
            name: "username",
            email: "",
            password: "newPassword"));
    }

    [Fact]
    public void CreateUser_Should_ReturnError_WhenPasswordIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => User.Create(
            name: "username",
            email: "email@gmail.com",
            password: ""));
    }
}
