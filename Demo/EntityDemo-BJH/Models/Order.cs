using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Order")]
    public class Order {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Id { get; set; }
        public string? User_Id { get; set; }
        public DateTime Order_Time { get; set; }
        public double Amount { get; set; } 
    }
}