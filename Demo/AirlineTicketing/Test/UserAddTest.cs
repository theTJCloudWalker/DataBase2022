using System.Security.Cryptography;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using Xunit;
using Xunit.Abstractions;

namespace AirlineTicketing.Test;

public class UserAddTest {
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly UserService _userService = new UserService();

    public UserAddTest(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void UserAdd() {
        var currentCount = _userService.GetUserCount();
        var testCount = 500;
        for (var i = currentCount; i < testCount + currentCount; i++) {
            var userName = "test";
            var passWord = "password";
            var phoneNumber = "178xxxxxxxx";
            var passengerId = "500103xxxxxxxxxxxx";
            var guid = Guid.NewGuid();
            var md5 = MD5.Create();
            var sha256 = SHA256.Create();
            // 
            userName += i;
            passWord += i;
            // 
            var newUser = new User() {
                Id = guid.ToString(),
                Name = userName,
                Password = Convert.ToHexString(sha256.ComputeHash(System.Text.Encoding.Unicode.GetBytes(passWord))),
                PhoneNumber = phoneNumber,
                PassengerId = passengerId
            };
            _userService.Add(newUser);
        }
    }

    [Fact]
    public void PassWordMatchTest() {
        var testName = "test109";
        var passWord = "password109";
        // 使用userName查询出该用户
        var userByName = _userService.GetUserByName(testName);
        var res =
            Convert.ToHexString(SHA256.Create().ComputeHash(System.Text.Encoding.Unicode.GetBytes(passWord)));
        _testOutputHelper.WriteLine($"res = {res}, res.length = {res.Length}");
        if (userByName.Password != null)
            _testOutputHelper.WriteLine(
                $"password = {userByName.Password}, password.length = {userByName.Password.Length}");
        Assert.Equal(userByName.Password, res);
    }
}