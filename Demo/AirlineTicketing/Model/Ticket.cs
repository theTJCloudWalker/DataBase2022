using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("TICKET")]
    public class Ticket {
        /// <summary>
        /// 机票主码 
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public string? Id { get; set; }

        /// <summary>
        /// 航班主码 
        ///</summary>
        [SugarColumn(ColumnName = "FLIGHT_ID")]
        public string? FlightId { get; set; }

        /// <summary>
        /// 航班实例主码 
        ///</summary>
        [SugarColumn(ColumnName = "INSTANCE_ID")]
        public string? InstanceId { get; set; }

        /// <summary>
        /// 身份证号 
        ///</summary>
        [SugarColumn(ColumnName = "PASSENGER_ID")]
        public string? PassengerId { get; set; }

        /// <summary>
        /// 订单主码 
        ///</summary>
        [SugarColumn(ColumnName = "ORDER_ID")]
        public string? OrderId { get; set; }

        /// <summary>
        /// 座位主码 
        ///</summary>
        [SugarColumn(ColumnName = "SEAT_ID")]
        public string? SeatId { get; set; }

        /// <summary>
        /// 折扣 
        ///</summary>
        [SugarColumn(ColumnName = "DISCOUNT")]
        public decimal? Discount { get; set; }
    }
}