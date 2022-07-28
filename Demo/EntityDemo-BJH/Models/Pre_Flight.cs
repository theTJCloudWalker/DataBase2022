using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Pre_Flight")]
    public class Pre_Flight {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Flight_Id { get; set; }
        [SugarColumn(IsPrimaryKey = true)]
        public string? Pre_Id { get; set; }
    }
}