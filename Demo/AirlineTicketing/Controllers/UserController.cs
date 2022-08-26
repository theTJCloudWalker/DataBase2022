using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Mvc;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using AirlineTicketing.Common;

namespace AirlineTicketing.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        /// <summary>
        /// Service层接口
        /// </summary>
        private readonly IUserService _userService;

        private readonly IPassengerService _passengerService;

        private readonly IPassengerTableService _passengerTableService;

        public UserController() {
            _userService = new UserService();
            _passengerService = new PassengerService();
            _passengerTableService = new PassengerTableService();
        }

        /// <summary>
        /// 查询所有的用户
        /// </summary>
        /// <returns>用户列表</returns>
        [HttpGet("GetList")]
        public Result GetUsers() {
            var res = _userService.GetUsers();
            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 用Id查询用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>查询到的用户</returns>
        [HttpGet("GetById")]
        public Result GetUserById(string? id) {
            var res = _userService.GetUserById(id);
            if (res.Id == null) {
                return new Result(ResultCode.QueryFailure, null);
            }

            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 用主键删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("DeleteByIds")]
        public Result DeleteUserByIds([FromBody] object[] ids) {
            var res = _userService.DeleteUserByIds(ids);
            if (res == false) {
                return new Result(ResultCode.DeleteFailure, null);
            }

            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        public Result Add([FromBody] User data) {
            var res = _userService.Add(data);
            if (res == false) {
                return new Result(ResultCode.InsertFailure, null);
            }

            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        public Result Update([FromBody] User data) {
            var res = _userService.Update(data);
            if (res == false) {
                return new Result(ResultCode.UpdateFailure, null);
            }

            return new Result(ResultCode.Success, res);
        }

        public class PassengerCrudData {
            public string? UserName { get; set; } // 当前用户
            public Passenger? Passenger { get; set; } // 需添加的旅客
        }


        // TODO 旅客信息CRUD
        /// <summary>
        /// 添加旅客
        /// </summary>
        /// <param name="crudData">添加旅客</param>
        /// <returns></returns>
        [HttpPost("Passenger/Add")]
        public Result AddPassenger([FromBody] PassengerCrudData crudData) {
            // Passenger表添加Passenger
            // PassengerTable表添加UserId和PassengerId
            var userName = crudData.UserName;
            var userByName = _userService.GetUserByName(userName!);
            // 检查用户是否为空
            if (userByName.Id == null) {
                return new Result(ResultCode.UsernameNotFound, userByName);
            }

            // 插入Passenger
            // 先看表中有没有对应的旅客信息，有则返回已存在(身份证号码)
            var passenger = crudData.Passenger;
            if (_passengerService.AddPassenger(passenger!)) {
                // 插入成功后在PassengerTable表
                if (_passengerTableService.AddPassengerToTable(userByName.Id!, passenger!.Id!)) {
                    // 插入成功返回数据
                    return new Result(ResultCode.Success, crudData);
                }
            }

            return new Result(ResultCode.Failure, null);
        }

        /// <summary>
        /// 更新旅客
        /// </summary>  
        /// <param name="passenger"></param>
        /// <returns></returns>
        [HttpPost("Passenger/Update")]
        public Result UpdatePassenger([FromBody] PassengerCrudData passenger) {
            // 更新passenger表 如果更新了PassengerId则需要删除后重新添加
            var userName = passenger.UserName; // 当前用户名
            var p = passenger.Passenger; // 更新后的数据
            var user = _userService.GetUserByName(userName!);
            if (_passengerService.UpdatePassenger(p!)) {
                return new Result(ResultCode.Success, p);
            }

            return new Result(ResultCode.Failure, null);
        }

        /// <summary>
        /// 删除旅客
        /// </summary>
        /// <param name="userName">当前用户名</param>
        /// <param name="passengerId">用户身份证号</param>
        /// <returns></returns>
        [HttpDelete("Passenger/Delete")]
        public Result DeletePassenger(string userName, string passengerId) {
            // 从Passenger表中删除
            return new Result();
        }

        /// <summary>
        /// 查询旅客
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        [HttpGet("Passenger/Get")]
        public Result GetPassenger([FromBody] Passenger passenger) {
            return new Result();
        }
    }
}