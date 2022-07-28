using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Insurance_Policy")]
    public class Insurance_Policy {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? Passenger_Id { get; set; }
        public string? Order_Id { get; set; }
        public string? Company_Name{ get; set; }
        public string? Insurance_Name { get; set; }
    }
}