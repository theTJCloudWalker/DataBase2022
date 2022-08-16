using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("FLIGHT_INSTANCE")]
    public class FlightInstance {
        /// <summary>
        /// 航班实例主码 
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public string? Id { get; set; }

        /// <summary>
        /// 航班主码 
        ///</summary>
        [SugarColumn(ColumnName = "FLIGHT_ID")]
        public string? FlightId { get; set; }

        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PLANE_TYPE")]
        public string? PlaneType { get; set; }

        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "BOARDING_GATE")]
        public decimal? BoardingGate { get; set; }

        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "REALTIME_DISCOUNT")]
        public string? RealtimeDiscount { get; set; }

        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ACTUAL_DEPARTURE_TIME")]
        public DateTime? ActualDepartureTime { get; set; }

        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ACTUAL_ARRIVAL_TIME")]
        public DateTime? ActualArrivalTime { get; set; }
    }
}