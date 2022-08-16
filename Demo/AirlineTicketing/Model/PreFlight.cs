using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("PRE_FLIGHT")]
    public class PreFlight {
        /// <summary>
        /// 航班主码 
        ///</summary>
        [SugarColumn(ColumnName = "FLIGHT_ID", IsPrimaryKey = true)]
        public string? FlightId { get; set; }

        /// <summary>
        /// 前序航班id 
        ///</summary>
        [SugarColumn(ColumnName = "PRE_ID", IsPrimaryKey = true)]
        public string? PreId { get; set; }
    }
}