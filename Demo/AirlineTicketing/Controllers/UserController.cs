using Microsoft.AspNetCore.Http;
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
        private readonly UserService userService = new UserService();

        /// <summary>
        /// 查询所有的用户
        /// </summary>
        /// <returns>用户列表</returns>
        [HttpPost("GetList")]
        public Result GetUsers() {
            var res = userService.GetUsers();
            if (res == null) {
                return new Result(ResultCode.QUERY_FAILURE, null);
            }
            return new Result(ResultCode.SUCCESS, res);
        }

        /// <summary>
        /// 用Id查询用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>查询到的用户</returns>
        [HttpPost("GetById")]
        public Result GetUserById(string id) {
            var res = userService.GetUserById(id);
            if (res == null) {
                return new Result(ResultCode.QUERY_FAILURE, null);
            }
            return new Result(ResultCode.SUCCESS, res);
        }

        /// <summary>
        /// 用主键删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("DeleteByIds")]
        public Result DeleteUserByIds([FromBody] object[] ids) {
            var res = userService.DeleteUserByIds(ids);
            if (res == false) {
                return new Result(ResultCode.DELETE_FAILURE, null);
            }
            return new Result(ResultCode.SUCCESS, res);
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        public Result Add([FromBody] User data) {
            var res = userService.Add(data);
            if (res == false) {
                return new Result(ResultCode.INSERT_FAILURE, null);
            }
            return new Result(ResultCode.SUCCESS, res);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        public Result Update([FromBody] User data) {
            var res = userService.Update(data);
            if (res == false) {
                return new Result(ResultCode.UPDATE_FAILURE, null);
            }
            return new Result(ResultCode.SUCCESS, res);
        }

    }
}
