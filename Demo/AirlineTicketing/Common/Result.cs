using System.ComponentModel;
using System.Reflection;
namespace AirlineTicketing.Common {
    /// <summary>
    /// 后端返回的结果
    /// </summary>
    public class Result {
        public int? code { get; set; }
        public string? msg { get; set; }
        public object? data { get; set; }
        /// <summary>
        /// 传入状态码枚举和返回数据，构造统一的返回类
        /// </summary>
        /// <param name="resultEnum">状态码枚举</param>
        /// <param name="data">后端返回的数据</param>
        public Result(Enum resultEnum, object? data) {
            this.code = Convert.ToInt32(resultEnum);
            this.msg = GetStatusCodeDescription(resultEnum);
            this.data = data;
        }
        /// <summary>
        /// 获取状态码的描述
        /// </summary>
        /// <param name="en">状态码枚举</param>
        /// <returns></returns>
        private static string GetStatusCodeDescription(Enum en) {
            Type type = en.GetType();   //获取类型  
            MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员  
            if (memberInfos != null && memberInfos.Length > 0) {
                DescriptionAttribute[]? attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];   //获取描述特性  
                if (attrs != null && attrs.Length > 0) {
                    return attrs[0].Description;    //返回当前描述
                }
            }
            return en.ToString();
        }
    }

    /// <summary>
    /// 状态码枚举
    /// </summary>
    public enum ResultCode {
        // 通用状态码
        [Description("成功")]
        SUCCESS = 0,
        [Description("失败")]
        FAILURE = 1,

        // 增删改查失败
        [Description("增加失败")]
        INSERT_FAILURE = 2,
        [Description("删除失败")]
        DELETE_FAILURE = 3,
        [Description("修改失败")]
        UPDATE_FAILURE = 4,
        [Description("查询失败")]
        QUERY_FAILURE = 5,

        // 用户登录
        [Description("登录用户不存在")]
        lOGIN_USER_NOT_FOUND = 1000,
        [Description("登录密码不正确")]
        LOGIN_PASSWORD_INCORRECT = 1001
    }
}
