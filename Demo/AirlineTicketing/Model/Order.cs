using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("ORDER")]
    public class Order
    {
        /// <summary>
        /// 订单号 
        ///</summary>
         [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true   )]
         public string? Id { get; set; }
        /// <summary>
        /// 用户主码 
        ///</summary>
         [SugarColumn(ColumnName="USER_ID"    )]
         public string? UserId { get; set; }
        /// <summary>
        /// 订单时间戳 
        ///</summary>
         [SugarColumn(ColumnName="ORDER_TIME"    )]
         public DateTime? OrderTime { get; set; }
        /// <summary>
        /// 订单金额 
        ///</summary>
         [SugarColumn(ColumnName="AMOUNT"    )]
         public decimal? Amount { get; set; }
    }
}
