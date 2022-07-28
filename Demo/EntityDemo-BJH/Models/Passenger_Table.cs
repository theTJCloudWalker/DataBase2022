using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Passenger_Table")]
    public class Passenger_Table {
        [SugarColumn(IsPrimaryKey = true)]
        public string? User_Id { get; set; }
        [SugarColumn(IsPrimaryKey = true)]
        public string? Passenger_Id { get; set; }
    }
}