using SqlSugar;
namespace EntityDemo.Models
{
    [SugarTable("Seat_Table")]
    public class Seat_Table
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Flight_Id { get; set; }
        public string? Instance_Id { get; set; }
        public string? Seat_Id { get; set; }
        public double Amount{ get; set; }
        public bool Sold{get;set;}
    }
}