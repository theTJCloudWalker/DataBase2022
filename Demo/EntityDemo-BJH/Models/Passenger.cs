using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Passenger")]
    public class Passenger {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Phone_Number { get; set; }
        public int Age { get; set; }
    }
}