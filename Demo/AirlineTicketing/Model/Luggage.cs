using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("LUGGAGE")]
    public class Luggage
    {
        /// <summary>
        /// 行李主码 
        ///</summary>
         [SugarColumn(ColumnName="ID"    )]
         public decimal? Id { get; set; }
        /// <summary>
        /// 身份证号 
        ///</summary>
         [SugarColumn(ColumnName="PASSENGER_ID"    )]
         public string? PassengerId { get; set; }
        /// <summary>
        /// 机票主码 
        ///</summary>
         [SugarColumn(ColumnName="TICKET_ID"    )]
         public string? TicketId { get; set; }
        /// <summary>
        /// 行李重量 
        ///</summary>
         [SugarColumn(ColumnName="WEIGHT"    )]
         public decimal? Weight { get; set; }
    }
}
