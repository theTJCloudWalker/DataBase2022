using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Luggage")]
    public class Luggage {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? Passenger_Id { get; set; }
        public string? Ticket_Id { get; set; }
        public double Weight { get; set; }
    }
}