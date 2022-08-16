using SqlSugar;

namespace AirlineTicketing.Dao {
    public class Repository<T> : SimpleClient<T> where T : class, new() {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public Repository(ISqlSugarClient? context = null) : base(context) //注意这里要有默认值等于null
        {
            if (context == null) {
                base.Context = Db;
            }
        }

        /// <summary>
        /// SqlSugarScope操作数据库是线程安全的可以单例
        /// </summary>
        public static readonly SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig() {
                DbType = SqlSugar.DbType.Oracle,
                ConnectionString = @"Data Source=150.158.80.33/orclpdb1;User ID=B2052526;Password=123456;",
                IsAutoCloseConnection = true
            },
            db => {
                // 输出日志
                db.Aop.OnLogExecuting = (s, p) => {
                    Console.WriteLine(s);
                    Console.WriteLine(string.Join(",", p.Select(a => a.ParameterName + ":" + a.Value)));
                };
            });
    }
}