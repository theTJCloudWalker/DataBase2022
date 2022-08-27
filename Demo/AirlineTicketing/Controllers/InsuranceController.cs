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
    /// 保险的添加、修改、删除
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly InsuranceService _insuranceService = new InsuranceService();

        /// <summary>
        /// 获取所有保险公司的保险
        /// </summary>
        /// <returns>返回保险信息</returns>
        [HttpGet("Insurance/GetAll")]
        public Result GetInsurances()
        {
            var insuranceList = _insuranceService.GetInsurances();
            return new Result(ResultCode.Success, insuranceList);
        }
        
        /// <summary>
        /// 通过保险单号id查看某人的保险信息
        /// </summary>
        /// <returns>返回保险信息</returns>
        [HttpGet("InsurancePolicy/GetByInsuranceId")]
        public Result GetInsurancePolicyById(string? id)
        {
            var insurancePolicy = _insuranceService.GetInsurancePolicyById(id);
            return new Result(ResultCode.Success, insurancePolicy);
        }
        
        /// <summary>
        /// 通过机票id查看某人的保险信息
        /// </summary>
        /// <returns>返回保险信息</returns>
        [HttpGet("InsurancePolicy/GetByTicketId")]
        public Result GetInsurancePolicyByTicket(string? id)
        {
            var insurancePolicy = _insuranceService.GetInsurancePolicyByTicket(id);
            return new Result(ResultCode.Success, insurancePolicy);
        }
        
        /// <summary>
        /// 通过保险单号id删除某人的保险
        /// </summary>
        /// <returns>返回是否成功</returns>
        [HttpDelete("InsurancePolicy/DeleteById")]
        public Result DeleteInsurancePolicyById(string? id)
        {
            bool delete = _insuranceService.DeleteInsurancePolicyById(id);
            return delete
                ? new Result(ResultCode.Success, id)
                : new Result(ResultCode.Failure, id);
        }
        
        /// <summary>
        /// 为某人添加保险，若已经存在则返回查询到的值
        /// </summary>
        /// <param name="insurancePolicyData">保险数据</param>
        /// <returns>返回保险信息</returns>
        /// <exception cref="Exception">空输入非法</exception>
        [HttpPost("InsurancePolicy/Insert")]
        public Result Insert([FromBody] dynamic insurancePolicyData) {
            // POST请求用dynamic接收 反序列化后得到字段数据
            // 如果用RegisterData? 编译检查不通过
            var o = JsonConvert.DeserializeObject(Convert.ToString(insurancePolicyData));

            var companyName = o.companyName;
            var insuranceName = o.insuranceName;
            var passengerId = o.passengerId;
            var orderId = o.orderId;
            

            Console.WriteLine(companyName);
            Console.WriteLine(insuranceName);
            Console.WriteLine(passengerId);
            Console.WriteLine(orderId);


            // 检查输入
            if (companyName == null || passengerId == null || insuranceName==null || orderId==null) {
                throw new Exception("输入非法");
            }

            //获取保险金额
            var amount = _insuranceService.GetAmountByNames(companyName, insuranceName);
            if(amount==0)
                throw new Exception("该保险不存在");
            
            
            // 查重
            var insuranceByOidPid = _insuranceService.GetInsurancePolicyByOrderIdPassId(orderId, passengerId);
            
            // 未查询到结果，可以添加保险
            if (insuranceByOidPid.Id == null) {
                // 添加id
                var guid = Guid.NewGuid();
                // 更新用户
                var newInsurancePolicy = new InsurancePolicy() {
                    Id = guid.ToString(),
                    PassengerId = passengerId,
                    CompanyName = companyName,
                    InsuranceName = insuranceName,
                    OrderId = orderId
                };
                
                //为订单添加保险
                bool addresult=_insuranceService.AddInsuranceForOrder(orderId, amount);
                if (addresult == false)
                {
                    new Result(ResultCode.Failure, "不存在对应订单");
                }
                
                
                //返回结果
                return _insuranceService.Insert(newInsurancePolicy)
                    ? new Result(ResultCode.Success, newInsurancePolicy)
                    : new Result(ResultCode.Failure, newInsurancePolicy);
            }

            // 查询到结果，返回已经存在的状态码
            return new Result(ResultCode.RegisterUserNameExist, insuranceByOidPid);
        }
        
        
        
        
        
        
    }
    
    
}


// 约定一个格式
public class InsurancePolicyData
{
    public string CompanyName;
    public string InsuranceName;
    public string PassengerId;
    public string OrderId;
}