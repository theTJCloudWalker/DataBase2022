using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace AirlineTicketing.Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("INSURANCE")]
    public class Insurance
    {
        /// <summary>
        /// 保险公司名 
        ///</summary>
         [SugarColumn(ColumnName="COMPANY_NAME" ,IsPrimaryKey = true   )]
         public string? CompanyName { get; set; }
        /// <summary>
        /// 保险产品名 
        ///</summary>
         [SugarColumn(ColumnName="INSURANCE_NAME" ,IsPrimaryKey = true   )]
         public string? InsuranceName { get; set; }
        /// <summary>
        /// 保险价格 
        ///</summary>
         [SugarColumn(ColumnName="AMOUNT"    )]
         public decimal? Amount { get; set; }
        /// <summary>
        /// 保险额 
        ///</summary>
         [SugarColumn(ColumnName="INSURANCE_AMOUNT"    )]
         public decimal? InsuranceAmount { get; set; }
    }
}
