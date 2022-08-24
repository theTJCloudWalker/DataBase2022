using AirlineTicketing.Common;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using AirlineTicketing.Util;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketing.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller {
    private readonly IUserService _userService;

    public AccountController() {
        _userService = new UserService();
    }

    /// <summary>
    /// 获取用户个人信息
    /// <param name="userName">用户名</param>
    /// </summary>
    /// <returns>成功返回用户个人信息，失败返回错误信息</returns>
    [HttpGet("Profile")]
    public Result UserProfile(string userName) {
        var login = true;
        // 如果已登录，返回当前用户的信息
        if (login) {
            var userByName = _userService.GetUserByName(userName);
            if (userByName.Id == null) {
                return new Result(ResultCode.UserProfileNotFound, userByName);
            }

            return new Result(ResultCode.Success, userByName);
        }

        // 未登录，拒绝访问
        return new Result(ResultCode.UserNotLogin, null);
    }

    /// <summary>
    /// 更新用户名数据
    /// </summary>
    public class UpdateUserNameData {
        public string? UserName { get; set; }
        public string? NewUserName { get; set; }
    }


    /// <summary>
    /// 修改用户名
    /// <param name="userNameData">用户名数据, 包含当前用户名和修改后的用户名</param>
    /// </summary>
    /// <returns></returns>
    [HttpPost("UpdateProfile/Username")]
    public Result UpdateUsername([FromBody] UpdateUserNameData userNameData) {
        var userName = userNameData.UserName;
        var newUserName = userNameData.NewUserName;
        // 检查当前用户是否存在
        var userByName = _userService.GetUserByName(userName!);
        if (userByName.Id == null) {
            return new Result(ResultCode.UsernameNotFound, null);
        }

        // 检查新用户名是否冲突
        if (newUserName!.Equals(userName)) {
            return new Result(ResultCode.NewUsernameConflict, null);
        }

        if (_userService.GetUserByName(newUserName).Id != null) {
            return new Result(ResultCode.NewUsernameExist, null);
        }

        // 检查通过则更新数据
        var newUser = _userService.UpdateUserName(userByName.Name!, newUserName);
        
        return new Result(ResultCode.Success, newUser);
    }

    /// <summary>
    /// 更新密码数据
    /// </summary>
    public class UpdatePasswordData {
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public string? NewPassWord { get; set; }
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="passWordData">新密码数据</param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/Password")]
    public Result UpdatePassword([FromBody] UpdatePasswordData passWordData) {
        var userName = passWordData.UserName;
        var password = passWordData.PassWord;
        var newPassword = passWordData.NewPassWord;
        // 检查当前用户是否存在
        var userByName = _userService.GetUserByName(userName!);
        if (userByName.Id == null) {
            return new Result(ResultCode.UsernameNotFound, null);
        }

        // 检查密码是否重复
        if (password!.Equals(newPassword)) {
            return new Result(ResultCode.NewPasswordConflict, null);
        }

        // 修改密码
        // 构造一个新用户
        var newUser = new User() {
            Id = userByName.Id,
            Name = userByName.Name,
            Password = Password.EncryptPassword(newPassword!),
            PassengerId = userByName.PassengerId,
            PhoneNumber = userByName.PhoneNumber
        };
        // 删除原用户
        if (!_userService.DeleteUserByIds(new object[] {userByName.Id})) {
            throw new Exception("删除用户失败");
        }

        if (!_userService.Add(newUser)) {
            throw new Exception("增加新用户失败");
        }

        return new Result(ResultCode.Success, newUser);
    }


    /// <summary>
    /// 更新手机号数据
    /// </summary>
    public class UpdatePhoneNumberData {
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NewPhoneNumber { get; set; }
    }

    /// <summary>
    /// 修改手机号
    /// </summary>
    /// <param name="phoneNumberData">新电话号码数据</param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/PhoneNumber")]
    public Result UpdatePhoneNumber([FromBody] UpdatePhoneNumberData phoneNumberData) {
        var userName = phoneNumberData.UserName;
        var phoneNumber = phoneNumberData.PhoneNumber;
        var newPhoneNumber = phoneNumberData.NewPhoneNumber;
        // 检查当前用户是否存在
        var userByName = _userService.GetUserByName(userName!);
        if (userByName.Id == null) {
            return new Result(ResultCode.UsernameNotFound, null);
        }

        // 检查电话号码是否重复
        if (phoneNumber!.Equals(newPhoneNumber)) {
            return new Result(ResultCode.NewPhoneNumberConflict, null);
        }

        // 修改密码
        // 构造一个新用户
        var newUser = new User() {
            Id = userByName.Id,
            Name = userByName.Name,
            Password = userByName.Password,
            PassengerId = userByName.PassengerId,
            PhoneNumber = newPhoneNumber
        };
        // 删除原用户
        if (!_userService.DeleteUserByIds(new object[] {userByName.Id})) {
            throw new Exception("删除用户失败");
        }

        if (!_userService.Add(newUser)) {
            throw new Exception("增加新用户失败");
        }

        return new Result(ResultCode.Success, newUser);
    }

    /// <summary>
    /// 更新身份证号数据
    /// </summary>
    public class UpdatePassengerIdData {
        public string? UserName { get; set; }
        public string? PassengerId { get; set; }
        public string? NewPassengerId { get; set; }
    }

    /// <summary>
    /// 修改身份证号
    /// </summary>
    /// <param name="passengerIdData"></param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/PassengerId")]
    public Result UpdatePassengerId([FromBody] UpdatePassengerIdData passengerIdData) {
        var userName = passengerIdData.UserName;
        var passengerId = passengerIdData.PassengerId;
        var newPassengerId = passengerIdData.NewPassengerId;
        // 检查当前用户是否存在
        var userByName = _userService.GetUserByName(userName!);
        if (userByName.Id == null) {
            return new Result(ResultCode.UsernameNotFound, null);
        }

        // 检查身份证号是否重复
        if (passengerId!.Equals(newPassengerId)) {
            return new Result(ResultCode.NewPassengerIdConflict, null);
        }

        // 修改密码
        // 构造一个新用户
        var newUser = new User() {
            Id = userByName.Id,
            Name = userByName.Name,
            Password = userByName.Password,
            PassengerId = newPassengerId,
            PhoneNumber = userByName.PhoneNumber
        };
        // 删除原用户
        if (!_userService.DeleteUserByIds(new object[] {userByName.Id})) {
            throw new Exception("删除用户失败");
        }

        if (!_userService.Add(newUser)) {
            throw new Exception("增加新用户失败");
        }

        return new Result(ResultCode.Success, newUser);
    }
}