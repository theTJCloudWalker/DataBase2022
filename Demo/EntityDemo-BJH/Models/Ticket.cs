using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Ticket")]
    public class Ticket {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? Flight_Id { get; set; }
        public string? Instance_Id { get; set; }
        public string? Passenger_Id { get; set; }
        public string? Order_Id { get; set; }
        public string? Seat_Id { get; set; }
        public double Discount { get; set; }
    }
}