using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("USER")]
    public class User
    {
        /// <summary>
        /// 用户主码 
        ///</summary>
         [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true   )]
         public string? Id { get; set; }
        /// <summary>
        /// 用户姓名 
        ///</summary>
         [SugarColumn(ColumnName="NAME"    )]
         public string? Name { get; set; }
        /// <summary>
        /// 电话号码 
        ///</summary>
         [SugarColumn(ColumnName="PHONE_NUMBER"    )]
         public string? PhoneNumber { get; set; }
        /// <summary>
        /// 身份证号 
        ///</summary>
         [SugarColumn(ColumnName="PASSENGER_ID"    )]
         public string? PassengerId { get; set; }
        /// <summary>
        /// 用户密码(sha256) 
        ///</summary>
         [SugarColumn(ColumnName="PASSWORD"    )]
         public string? Password { get; set; }
    }
}
