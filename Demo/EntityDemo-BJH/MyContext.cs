using SqlSugar;
namespace EntityDemo {
    public class MyContext {
        public const string ConnectionString = "Data Source=150.158.80.33/orclpdb1;User ID=B2052526;Password=123456;";
        public static IConfiguration? Configuration { get; set; }
        public SqlSugarClient Db11;//用来处理事务多表查询和复杂的操作
        public MyContext() {
            Db11 = new SqlSugarClient(new ConnectionConfig() {
                ConnectionString = ConnectionString,
                DbType = DbType.Oracle,
                IsAutoCloseConnection = true
            });
            //Print sql
            Db11.Aop.OnLogExecuting = (sql, pars) => {
                Console.WriteLine(sql + "\r\n" + Db11.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

    }
}
