using SqlSugar;

namespace AirlineTicketing.Model {
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("FLIGHT_COMMENT")]
    public class FlightComment {
        /// <summary>
        /// 时间 
        ///</summary>
        [SugarColumn(ColumnName = "TIME", IsPrimaryKey = true)]
        public DateTime? CommentTime { get; set; }

        /// <summary>
        /// 航班号 
        ///</summary>
        [SugarColumn(ColumnName = "FLIGHT_ID", IsPrimaryKey = true)]
        public string? FlightId { get; set; }

        /// <summary>
        /// 用户Id 
        ///</summary>
        [SugarColumn(ColumnName = "USER_ID", IsPrimaryKey = true)]
        public string? UserId { get; set; }

        /// <summary>
        /// 评价星级
        ///</summary>
        [SugarColumn(ColumnName = "COMMENT_LEVEL")]
        public int? CommentLevel { get; set; }

        /// <summary>
        /// 评价的内容
        ///</summary>
        [SugarColumn(ColumnName = "CONTENT")]
        public string? Content { get; set; }
        
    }
}