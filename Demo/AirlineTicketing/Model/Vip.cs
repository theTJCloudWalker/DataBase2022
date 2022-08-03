using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("VIP")]
    public class Vip
    {
        /// <summary>
        /// 会员主码 
        ///</summary>
         [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true   )]
         public string? Id { get; set; }
        /// <summary>
        /// 用户主码 
        ///</summary>
         [SugarColumn(ColumnName="USER_ID"    )]
         public string? UserId { get; set; }
        /// <summary>
        /// 积分 
        ///</summary>
         [SugarColumn(ColumnName="POINTS"    )]
         public decimal? Points { get; set; }
    }
}
