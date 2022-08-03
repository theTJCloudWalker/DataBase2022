using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("PASSENGER")]
    public class Passenger
    {
        /// <summary>
        /// 旅客主码 
        ///</summary>
         [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true   )]
         public string? Id { get; set; }
        /// <summary>
        /// 旅客姓名 
        ///</summary>
         [SugarColumn(ColumnName="NAME"    )]
         public string? Name { get; set; }
        /// <summary>
        /// 电话 
        ///</summary>
         [SugarColumn(ColumnName="PHONE_NUMBER"    )]
         public decimal? PhoneNumber { get; set; }
        /// <summary>
        /// 年龄 
        ///</summary>
         [SugarColumn(ColumnName="AGE"    )]
         public decimal? Age { get; set; }
    }
}
