using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("SEAT_TABLE")]
    public class SeatTable {
        /// <summary>
        /// 航班主码 
        ///</summary>
        [SugarColumn(ColumnName = "FLIGHT_ID", IsPrimaryKey = true)]
        public string? FlightId { get; set; }

        /// <summary>
        /// 航班实例主码 
        ///</summary>
        [SugarColumn(ColumnName = "INSTANCE_ID", IsPrimaryKey = true)]
        public string? InstanceId { get; set; }

        /// <summary>
        /// 座位主码 
        ///</summary>
        [SugarColumn(ColumnName = "SEAT_ID", IsPrimaryKey = true)]
        public string? SeatId { get; set; }

        /// <summary>
        /// 价格 
        ///</summary>
        [SugarColumn(ColumnName = "AMOUNT")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 是否已售 
        ///</summary>
        [SugarColumn(ColumnName = "SOLD")]
        public string? Sold { get; set; }
    }
}