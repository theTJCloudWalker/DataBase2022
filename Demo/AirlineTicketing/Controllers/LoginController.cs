using AirlineTicketing.Common;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static AirlineTicketing.Util.Password;

namespace AirlineTicketing.Controllers {
    /// <summary>
    /// LoginController
    /// 登录 注册 注销
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {
        private readonly UserService _userService = new UserService();
        
        /// <summary>
        /// 登录数据
        /// </summary>
        public class LoginData {
            public string? UserName { get; set; }
            public string? PassWord { get; set; }
        }

        /// <summary>
        /// 注册数据
        /// </summary>
        public class RegisterData {
            public string? UserName { get; set; }
            public string? PassWord { get; set; }
            public string? PhoneNumber { get; set; }
            public string? PassengerId { get; set; }
        }
        
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerData">用户注册信息</param>
        /// <returns>注册成功返回用户信息，注册失败抛出异常</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpPost("Register")]
        public Result Register([FromBody] RegisterData registerData) {
            // 可行
            // POST请求用dynamic接收 反序列化后得到字段数据

            var userName = registerData.UserName;
            var passWord = registerData.PassWord;
            var phoneNumber = registerData.PhoneNumber;
            var passengerId = registerData.PassengerId;

            // Console.WriteLine(userName);
            // Console.WriteLine(passWord);
            // Console.WriteLine(phoneNumber);
            // Console.WriteLine(passengerId);


            // 检查输入
            if (userName == null || passWord == null || phoneNumber == null || passengerId == null) {
                throw new Exception("输入非法");
            }

            // 用户名查重
            var userByName = _userService.GetUserByName(userName);

            // 未查询到结果，可以注册
            if (userByName.Id == null) {
                // 加密密码
                var res = EncryptPassword(passWord);
                var guid = Guid.NewGuid();
                // 更新用户
                var newUser = new User {
                    Id = guid.ToString(),
                    Name = userName,
                    Password = res,
                    PassengerId = passengerId,
                    PhoneNumber = phoneNumber
                };
                return _userService.Add(newUser)
                    ? new Result(ResultCode.Success, newUser)
                    : new Result(ResultCode.RegisterUserInsertFailure, newUser);
            }

            // 查询到结果，返回已注册的状态码
            return new Result(ResultCode.RegisterUserNameExist, userByName);
        }


        /// <summary>
        /// 用户登录
        /// <param name="loginData">登录信息</param>
        /// </summary>
        /// <returns>登录成功返回用户信息，登录失败返回null</returns>
        [HttpPost("Login")]
        public Result Login([FromBody] LoginData loginData) {
            // TODO 测试前端axios发post请求是否可行
            // 可行
            // var o = JsonConvert.DeserializeObject(Convert.ToString(loginData));
            // string userName = o.userName;
            // string passWord = o.passWord;

            var userName = loginData.UserName;
            var passWord = loginData.PassWord;
            
            Console.WriteLine(userName);
            Console.WriteLine(passWord);
            
            // 用userName查询用户
            var userByName = _userService.GetUserByName(userName);
            // 未查询到用户，提示用户不存在
            if (userByName.Id == null) {
                return new Result(ResultCode.LoginUserNotFound, null);
            }

            // 核对加密后的密码
            var res = EncryptPassword(passWord);
            var actualPassword = userByName.Password;

            // TODO 返回值加入Token和Cookie
            return res.Equals(actualPassword)
                ? new Result(ResultCode.Success, userByName)
                : new Result(ResultCode.LoginPasswordIncorrect, null);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        [HttpDelete("Cancel")]
        public Result Cancel(string userName) {
            // 用userName查询用户
            var userByName = _userService.GetUserByName(userName);
            // 未查询到用户，提示用户不存在
            if (userByName.Id == null) {
                return new Result(ResultCode.CancelUserNotFound, null);
            }

            // 查询到用户则删除
            if (_userService.DeleteUserByIds(new object[] {userByName.Id})) {
                return new Result(ResultCode.Success, userByName);
            }
            
            // 删除错误
            return new Result(ResultCode.CancelError, null);
        }
    }
}

