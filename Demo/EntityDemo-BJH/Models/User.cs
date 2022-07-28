using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("USER")]
    public class User {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string? Id { get; set; }
        // [SugarColumn(ColumnName ="NAME")]
        public string? Name { get; set; }
        // [SugarColumn(ColumnName = "PHONE_NUMBER")]
        public string? Phone_Number { get; set; }
        // [SugarColumn(ColumnName = "PASSENGER_ID")]
        public string? Passenger_ID { get; set; }
        // [SugarColumn(ColumnName = "PASSWORD")]
        public string? Password { get; set; }

    }
}
