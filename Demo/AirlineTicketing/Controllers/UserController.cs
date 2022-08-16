using Microsoft.AspNetCore.Mvc;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using AirlineTicketing.Common;
namespace AirlineTicketing.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        /// <summary>
        /// Service层对象
        /// </summary>
        private readonly UserService _userService = new UserService();

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
            if (res == null) {
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
        
        // TODO 旅客信息CRUD
        
        /// <summary>
        /// 添加旅客
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        [HttpPost("Passenger/Add")]
        public Result AddPassenger([FromBody] Passenger passenger) {
            return new Result();
        }
        
        /// <summary>
        /// 更新旅客
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        [HttpPost("Passenger/Update")]
        public Result UpdatePassenger([FromBody] Passenger passenger) {
            return new Result();
        }
        
        /// <summary>
        /// 删除旅客
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        [HttpDelete("Passenger/Delete")]
        public Result DeletePassenger([FromBody] Passenger passenger) {
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
