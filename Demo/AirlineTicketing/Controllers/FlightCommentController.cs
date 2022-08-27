using AirlineTicketing.Common;
using AirlineTicketing.Model;
using AirlineTicketing.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirlineTicketing.Controllers
{

    
    /// <summary>
    /// FlightCommentController
    /// 航班评价的查看、添加、修改、删除
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightCommentController : ControllerBase
    {
        
        private readonly FlightCommentService _flightCommentService = new FlightCommentService();
        
        /// <summary>
        /// 获取所有某航班的评价
        /// </summary>
        /// <returns>返回航班评价的列表</returns>
        [HttpGet("GetAllByFlightId")]
        public Result GetFlightComments(string? flightId)
        {
            var flightCommentList = _flightCommentService.GetFlightCommentsByFlightId(flightId);
            return new Result(ResultCode.Success, flightCommentList);
        }
        
        /// <summary>
        /// 获取所有某航班的评价个数
        /// </summary>
        /// <returns>返回航班评价的个数</returns>
        [HttpGet("GetCountByFlightId")]
        public Result GetFlightCommentCount(string? flightId)
        {
            var flightCommentList = _flightCommentService.GetFlightCommentsByFlightId(flightId);
            return new Result(ResultCode.Success, flightCommentList.Count());
        }

        /// <summary>
        /// 获取所有某航班的平均评价等级
        /// </summary>
        /// <returns>返回航班评价的平均等级</returns>
        [HttpGet("GetLevelByFlightId")]
        public Result GetFlightCommentLevel(string? flightId)
        {
            var levelAvg = _flightCommentService.GetFlightCommentsLevelByFlightId(flightId);
            return new Result(ResultCode.Success, levelAvg);
        }
        
        
        /// <summary>
        /// 为某航班添加评论，可在多个时间线给出评价
        /// </summary>
        /// <param name="insurancePolicyData">保险数据</param>
        /// <returns>返回保险信息</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpPost("InsertComment")]
        public Result Insert([FromBody] dynamic flightCommentData)
        {
            // POST请求用dynamic接收 反序列化后得到字段数据
            // 如果用RegisterData? 编译检查不通过
            var o = JsonConvert.DeserializeObject(Convert.ToString(flightCommentData));

            var commentTime = o.CommentTime;
            var flightId = o.flightId;
            var userId = o.userId;
            var commentLevel = o.CommentLevel;
            var content = o.content;
            

            Console.WriteLine(commentTime);
            Console.WriteLine(flightId);
            Console.WriteLine(userId);
            Console.WriteLine(commentLevel);
            Console.WriteLine(content);
            
            // 检查输入
            if (flightId == null || userId == null || commentTime==null) {
                throw new Exception("输入非法");
            }
            
            //由于评价时间和用户不可能同时一样，评论不会重复
            
            // 添加评价
            var newFlightComment = new FlightComment() {
                UserId = userId,
                CommentTime=commentTime,
                FlightId=flightId,
                CommentLevel = commentLevel,
                Content = content
            };
            return _flightCommentService.Insert(newFlightComment)
                ? new Result(ResultCode.Success, newFlightComment)
                : new Result(ResultCode.Failure, newFlightComment);

    
        }
        
        
    }
    
}


// 约定一个格式
public class FlightCommentData
{
    public DateTime CommentTime;
    public string FlightId;
    public string UserrId;
    public int CommentLevel;
    public string Content;

}