using AirlineTicketing.Common;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static AirlineTicketing.Util.Password;

namespace AirlineTicketing.Controllers
{

    /// <summary>
    /// LuggageController
    /// 行李的查看、添加、修改
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LuggageController : ControllerBase
    {
        private readonly LuggageService _luggageService = new LuggageService();


        /// <summary>
        /// 根据机票Id查看行李，如果存在就返回信息
        /// </summary>
        /// <param name="tid">要查找的行李的机票Id</param>
        /// <returns>返回行李信息</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpGet("GetByTicketId")]
        public Result GetByTicketId(string? tid)
        {
            if (tid == null)
                throw new Exception("输入为空");

            var luggage = _luggageService.GetLuggageByTicketId(tid);
            if (luggage == new Luggage())
            {
                return new Result(ResultCode.Failure, luggage);
            }

            return new Result(ResultCode.Success, luggage);


        }
        
        
        
        
        /// <summary>
        /// 行李添加，如果存在就返回存在的信息
        /// </summary>
        /// <param name="luggageData">要添加的行李信息</param>
        /// <returns>返回行李信息</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpPost("Insert")]
        public Result Insert([FromBody] dynamic luggageData) {
            // POST请求用dynamic接收 反序列化后得到字段数据
            // 如果用RegisterData? 编译检查不通过
            var o = JsonConvert.DeserializeObject(Convert.ToString(luggageData));

            
            var luggageId = o.Id;
            var ticketId = o.ticketId;
            var weight = o.weight;


            // var userName = registerData.userName;
            // var passWord = registerData.passWord;
            // var phoneNumber = registerData.phoneNumber;
            // var passengerId = registerData.passengerId;

            Console.WriteLine(luggageId);
            Console.WriteLine(ticketId);
            Console.WriteLine(weight);


            // 检查输入
            if (weight == null  || ticketId==null) {
                throw new Exception("输入非法");
            }

            // 查重
            var luggageByTicket = _luggageService.GetLuggageByTicketId(ticketId);

            // 未查询到结果，可以添加行李
            if (luggageByTicket.Id == null) {

                //获取一个不重复的行李号
                decimal deId;
                while (true)
                {
                    deId = new Random().Next(1, 9999999) / (decimal)1;
                    var quit = _luggageService.GetLuggageByDecimalId(deId);

                    if (quit == new Luggage())
                    {
                        break;
                    }

                }
                
                // 更新用户
                var newLuggage = new Luggage {
                    Id = deId,
                    Weight=weight,
                    TicketId=ticketId
                };
                return _luggageService.Insert(newLuggage)
                    ? new Result(ResultCode.Success, newLuggage)
                    : new Result(ResultCode.Failure, newLuggage);
            }

            // 查询到结果，返回已注册的状态码
            return new Result(ResultCode.RegisterUserNameExist, luggageByTicket);
        }

        /// <summary>
        /// 行李重量修改
        /// </summary>
        /// <param name="luggageData">要修改为的行李信息</param>
        /// <returns>返回行李信息</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpPost("Update")]
        public Result Update([FromBody] dynamic luggageData)
        {
            
            // POST请求用dynamic接收 反序列化后得到字段数据
            // 如果用RegisterData? 编译检查不通过
            var o = JsonConvert.DeserializeObject(Convert.ToString(luggageData));

            
            var luggageId = o.Id;
            var ticketId = o.ticketId;
            var weight = o.weight;


            // var userName = registerData.userName;
            // var passWord = registerData.passWord;
            // var phoneNumber = registerData.phoneNumber;
            // var passengerId = registerData.passengerId;

            Console.WriteLine(luggageId);
            Console.WriteLine(ticketId);
            Console.WriteLine(weight);


            // 检查输入
            if (weight == null ||  ticketId==null) {
                throw new Exception("输入非法");
            }
            
            
            //行李是否已经存在
            var luggageByTicket = _luggageService.GetLuggageByTicketId(ticketId);

            //行李不存在，无法修改
            if (luggageByTicket.Id == null)
            {
                return new Result(ResultCode.Failure, "行李不存在");
            }
            else
            {
                
                return _luggageService.UpdateWeight(luggageId, weight)
                    ? new Result(ResultCode.Success, "成功")
                    : new Result(ResultCode.Failure, "失败");
                
            }
            
        }
        
        
        
        
    }
    
    
}


// 约定一个格式
public class LuggageData {
    public string Id;
    public string TicketId;
    public decimal Weight;
}