using AirlineTicketing.Common;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketing.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller {
    /// <summary>
    /// 获取用户个人信息
    /// </summary>
    /// <returns>成功返回用户个人信息，失败返回错误信息</returns>
    [HttpGet("Profile")]
    public Result UserProfile() {
        // 如果已登录，返回当前用户的信息

        // 未登录，拒绝访问
        return new Result(ResultCode.UserNotLogin, null);
    }

    // TODO 完成以下的函数

    /// <summary>
    /// 修改用户名
    /// </summary>
    /// <param name="username"></param>
    /// <param name="newName"></param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/Username")]
    public Result UpdateUsername(string username, string newName) {
        return new Result();
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="password"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/Password")]
    public Result UpdatePassword(string password, string newPassword) {
        return new Result();
    }

    /// <summary>
    /// 修改手机号
    /// </summary>
    /// <param name="newPhoneNumber"></param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/PhoneNumber")]
    public Result UpdatePhoneNumber(string newPhoneNumber) {
        return new Result();
    }

    /// <summary>
    /// 修改身份证号
    /// </summary>
    /// <param name="newPassengerId"></param>
    /// <returns></returns>
    [HttpPost("UpdateProfile/PassengerId")]
    public Result UpdatePassengerId(string newPassengerId) {
        return new Result();
    }
}