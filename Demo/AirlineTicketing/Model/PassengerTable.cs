using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("PASSENGER_TABLE")]
    public class PassengerTable {
        /// <summary>
        /// 用户主码 
        ///</summary>
        [SugarColumn(ColumnName = "USER_ID", IsPrimaryKey = true)]
        public string? UserId { get; set; }

        /// <summary>
        /// 身份证号 
        ///</summary>
        [SugarColumn(ColumnName = "PASSENGER_ID", IsPrimaryKey = true)]
        public string? PassengerId { get; set; }
    }
}