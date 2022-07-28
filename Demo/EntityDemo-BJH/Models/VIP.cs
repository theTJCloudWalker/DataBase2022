using SqlSugar;
namespace EntityDemo.Models {
    [SugarTable("VIP")]
    public class VIP {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string? Id { get; set; }
        public string? UserId { get; set; }

        public int Points { get; set; }
    }
}