using Microsoft.AspNetCore.Mvc;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using AirlineTicketing.Common;

/// <summary>
/// 订单控制器
/// 支付功能
/// 退票功能
/// </summary>
namespace AirlineTicketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// service层接口
        /// </summary>ervice;

        private readonly IOrderService _orderService;

        public OrderController() {
            _orderService = new OrderService();
        }

         /// <summary>
        /// 使用订单号查询订单 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByOrderId")]
        public Result GetOrderById(string? id) {
            var res = _orderService.GetOrderById(id);
            if (res == null) {
                return new Result(ResultCode.QueryFailure, null);
            }
            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 添加订单，生成订单号 
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        public Result Add([FromBody] Order data) {
            var res = _orderService.Add(data);
            if (res == false) {
                return new Result(ResultCode.InsertFailure, null);
            }
            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 用主键取消订单（订单未支付）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("DeleteByIds")]
        public Result DeleteOrderByIds([FromBody] object[] ids) {
            var res = _orderService.DeleteOrderByIds(ids);
            if (res == false) {
                return new Result(ResultCode.DeleteFailure, null);
            }
            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public Result Update([FromBody] Order data) {
            var res = _orderService.Update(data);
            if (res == false) {
                return new Result(ResultCode.UpdateFailure, null);
            }
            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 查找订单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public Result GetList([FromBody] Order data) {
            var res = _orderService.GetList(data);
            if (res == null) {
                return new Result(ResultCode.QueryFailure, null);
            }
            return new Result(ResultCode.Success, res);
        }
    }
}
