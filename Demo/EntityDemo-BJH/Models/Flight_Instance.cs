using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Flight_Instance")]
    public class Flight_Instance {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? Flight_Id { get; set; }
        public string? Plane_Type { get; set; }
        public int Boarding_Gate { get; set; }
        public double Realtime_Discount { get; set; }
        public DateTime Actual_Departure_Time { get; set; }
        public DateTime Actual_Arrival_Time { get; set; }
    }
}