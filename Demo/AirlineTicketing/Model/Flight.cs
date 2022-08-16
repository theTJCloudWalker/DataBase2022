using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("FLIGHT")]
    public class Flight {
        /// <summary>
        /// 航班主码 
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public string? Id { get; set; }

        /// <summary>
        /// 航空公司名 
        ///</summary>
        [SugarColumn(ColumnName = "AIRLINES_NAME")]
        public string? AirlinesName { get; set; }

        /// <summary>
        /// 出发机场 
        ///</summary>
        [SugarColumn(ColumnName = "DEPARTURE_AIRPORT")]
        public string? DepartureAirport { get; set; }

        /// <summary>
        /// 到达机场 
        ///</summary>
        [SugarColumn(ColumnName = "ARRIVAL_AIRPORT")]
        public string? ArrivalAirport { get; set; }

        /// <summary>
        /// 计划出发时间 
        ///</summary>
        [SugarColumn(ColumnName = "DEPARTURE_TIME")]
        public DateTime? DepartureTime { get; set; }

        /// <summary>
        /// 计划到达时间 
        ///</summary>
        [SugarColumn(ColumnName = "ARRIVAL_TIME")]
        public DateTime? ArrivalTime { get; set; }
    }
}