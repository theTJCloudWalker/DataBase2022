using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("INSURANCE_POLICY")]
    public class InsurancePolicy
    {
        /// <summary>
        /// 主码 
        ///</summary>
         [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true   )]
         public string? Id { get; set; }
        /// <summary>
        /// 身份证号 
        ///</summary>
         [SugarColumn(ColumnName="PASSENGER_ID"    )]
         public string? PassengerId { get; set; }
        /// <summary>
        /// 订单号 
        ///</summary>
         [SugarColumn(ColumnName="ORDER_ID"    )]
         public string? OrderId { get; set; }
        /// <summary>
        /// 保险公司名 
        ///</summary>
         [SugarColumn(ColumnName="COMPANY_NAME"    )]
         public string? CompanyName { get; set; }
        /// <summary>
        /// 保险产品名 
        ///</summary>
         [SugarColumn(ColumnName="INSURANCE_NAME"    )]
         public string? InsuranceName { get; set; }
    }
}
