﻿using System.ComponentModel;

namespace AirlineTicketing.Common {
    /// <summary>
    /// 后端返回的结果
    /// </summary>
    public class Result {
        public int? Code { get; set; }
        public string? Msg { get; set; }
        public object? Data { get; set; }

        public Result() {
            Code = Convert.ToInt32(ResultCode.Uninitialized);
            Msg = "Uninitialized";
            Data = null;
        }

        /// <summary>
        /// 传入状态码枚举和返回数据，构造统一的返回类
        /// </summary>
        /// <param name="resultEnum">状态码枚举</param>
        /// <param name="data">后端返回的数据</param>
        public Result(Enum resultEnum, object? data) {
            Code = Convert.ToInt32(resultEnum);
            Msg = GetStatusCodeDescription(resultEnum);
            Data = data;
        }

        /// <summary>
        /// 获取状态码的描述
        /// </summary>
        /// <param name="en">状态码枚举</param>
        /// <returns></returns>
        private static string GetStatusCodeDescription(Enum en) {
            var type = en.GetType(); //获取类型  
            var memberInfos = type.GetMember(en.ToString()); //获取成员  
            if (memberInfos.Length <= 0) return en.ToString();
            if (memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] {
                    Length: > 0
                } attrs) {
                return attrs[0].Description; //返回当前描述
            }

            return en.ToString();
        }
    }

    /// <summary>
    /// 状态码枚举
    /// </summary>
    public enum ResultCode {
        // 未初始化
        [Description("未初始化")] Uninitialized = -1,

        // 通用状态码
        [Description("成功")] Success = 0,
        [Description("失败")] Failure = 1,

        // 增删改查失败
        [Description("增加失败")] InsertFailure = 2,
        [Description("删除失败")] DeleteFailure = 3,
        [Description("修改失败")] UpdateFailure = 4,
        [Description("查询失败")] QueryFailure = 5,

        // 用户登录
        [Description("登录用户不存在")] LoginUserNotFound = 1000,
        [Description("登录密码不正确")] LoginPasswordIncorrect = 1001,

        // 用户注册
        [Description("用户已注册")] RegisterUserNameExist = 1100,
        [Description("注册用户添加失败")] RegisterUserInsertFailure = 1101,

        // 用户删除
        [Description("删除用户不存在")] CancelUserNotFound = 1200,
        [Description("删除操作失败")] CancelError = 1201,

        // 登录验证
        [Description("用户未登录")] UserNotLogin = 1300,

        // 个人信息管理
        [Description("用户个人信息不存在")] UserProfileNotFound = 1400,
        [Description("用户名不存在")] UsernameNotFound = 1401,
        [Description("新用户名和原用户名一致")] NewUsernameConflict = 1402,
        [Description("新用户名已存在")] NewUsernameExist = 1403,
        [Description("新密码和原密码一致")] NewPasswordConflict = 1404,
        [Description("新电话号码和原电话号码一致")] NewPhoneNumberConflict = 1405,
        [Description("新身份证号和身份证号一致")] NewPassengerIdConflict = 1406,

        //航班信息筛选
        [Description("没有该直飞航班")] DirectFlightNotFound = 121700,
    }
}