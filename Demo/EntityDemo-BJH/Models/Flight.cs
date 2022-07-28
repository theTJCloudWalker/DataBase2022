using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Flight")]
    public class Flight {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? Airlines_Name { get; set; }
        public string? Departure_Airport { get; set; }
        public string? Arrival_Airport { get; set; }
        public string? Departure_Time { get; set; }
        public string? Arrival_Time { get; set; }
    }
}