using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("Insurance")]
    public class Insurance {
        [SugarColumn(IsPrimaryKey = true)]
        public string? Company_Name { get; set; }
        [SugarColumn(IsPrimaryKey = true)]
        public string? Insurance_Name { get; set; }
        public double Amount { get; set; }
        public double Insurance_Amout { get; set; }
    }
}
