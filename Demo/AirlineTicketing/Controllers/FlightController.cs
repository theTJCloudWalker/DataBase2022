using Microsoft.AspNetCore.Mvc;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using AirlineTicketing.Common;
using Newtonsoft.Json;

namespace AirlineTicketing.Controllers {
    /// <summary>
    /// FlightController
    /// 筛选查询
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase {
        /// <summary>
        /// Service层接口
        /// </summary>
        private readonly FlightService _flightService;

        public FlightController() {
            _flightService = new FlightService();
        }

        /// <summary>
        /// 注册数据
        /// </summary>
        public class SelectFlightData {
            public string? DepartureAirport { get; set; }
            public string? ArrivalAirport { get; set; }
            public DateTime? DepartureTime { get; set; }
        }

        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <param name="flightData">用户注册信息</param>
        /// <returns>注册成功返回用户信息，注册失败抛出异常</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpPost("Filter")]
        public Result Filter([FromBody] SelectFlightData flightData) {
            var departureAirport = flightData.DepartureAirport;
            var arrivalAirport = flightData.ArrivalAirport;
            var departureTime = flightData.DepartureTime;


            //Console.WriteLine(DepartureAirport);
            //Console.WriteLine(ArrivalAirport);
            //Console.WriteLine(DepartureTime);
            var data = new Flight() {
                DepartureAirport = departureAirport,
                ArrivalAirport = arrivalAirport,
                DepartureTime = departureTime
            };

            // 检查输入
            if (departureAirport == null || arrivalAirport == null || departureTime == null) {
                throw new Exception("输入非法");
            }
 
            var flights = _flightService.GetFlights(data);
            if (flights == null) {
                return new Result(ResultCode.DirectFlightNotFound, flights);
            }

            return new Result(ResultCode.Success, flights);
        }

        /// <summary>
        /// 查询所有的航班
        /// </summary>
        /// <returns>用户列表</returns>
        [HttpGet("GetList")]
        public Result GetAllFlights() {
            var res = _flightService.GetAllFlights();
            return new Result(ResultCode.Success, res);
        }

        /// <summary>
        /// 用Id查询用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>查询到的用户</returns>
        [HttpGet("GetById")]
        public Result GetFlightById(string? id) {
            var res = _flightService.GetFlightById(id);
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
        public Result DeleteFlightByIds([FromBody] object[] ids) {
            var res = _flightService.DeleteFlightByIds(ids);
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
        public Result Add([FromBody] Flight data) {
            var res = _flightService.Add(data);
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
        public Result Update([FromBody] Flight data) {
            var res = _flightService.Update(data);
            if (res == false) {
                return new Result(ResultCode.UpdateFailure, null);
            }

            return new Result(ResultCode.Success, res);
        }


        /// <summary>
        /// 添加航班实例
        /// </summary>
        /// <param name="flightInstance"></param>
        /// <returns></returns>
        [HttpPost("FlightInstance/Add")]
        public Result AddFlightInstancer([FromBody] FlightInstance flightInstance) {
            return new Result();
        }

        /// <summary>
        /// 更新旅客
        /// </summary>
        /// <param name="flightInstance"></param>
        /// <returns></returns>
        [HttpPost("FlightInstance/Update")]
        public Result UpdateFlightInstance([FromBody] FlightInstance flightInstance) {
            return new Result();
        }

        /// <summary>
        /// 删除旅客
        /// </summary>
        /// <param name="flightInstance"></param>
        /// <returns></returns>
        [HttpDelete("FlightInstance/Delete")]
        public Result DeleteFlightInstance([FromBody] FlightInstance flightInstance) {
            return new Result();
        }

        /// <summary>
        /// 查询旅客
        /// </summary>
        /// <param name="flightInstance"></param>
        /// <returns></returns>
        [HttpGet("FlightInstance/Get")]
        public Result GetFlightInstance([FromBody] FlightInstance flightInstance) {
            return new Result();
        }
    }
}