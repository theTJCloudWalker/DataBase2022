# Airline Ticketing

## 2022-08-03(BJH)

### 1. NuGet需要用到的包

- Swashbuckle.AspNetCore：Swagger UI工具
- **SqlSugarCore**：后端ORM框架
- xunit.core：单元测试框架

### 2. 分层设计

- Common：通用的代码，比如Result类
- Controllers：控制器类，返回值都用Result封装，方便前端路由跳转
- Dao：数据库访问层，实现Repository接口和对应Dao层的接口
- Model：实体
- Service：业务逻辑代码，简单的可以直接调用SimpleClient中的方法
- Util：工具函数

#### 2.1 Common

1. Result类的设计，自定义状态码和状态码的描述，使用静态方法利用反射获取枚举的描述，业务增加的时候再在ResultCode枚举中增加状态码和描述

```c#
/// <summary>
/// 后端返回的结果
/// </summary>
public class Result {
    public int? code { get; set; }
    public string? msg { get; set; }
    public object? data { get; set; }
    /// <summary>
    /// 传入状态码枚举和返回数据，构造统一的返回类
    /// </summary>
    /// <param name="resultEnum">状态码枚举</param>
    /// <param name="data">后端返回的数据</param>
    public Result(Enum resultEnum, object? data) {
        this.code = Convert.ToInt32(resultEnum);
        this.msg = GetStatusCodeDescription(resultEnum);
        this.data = data;
    }
    /// <summary>
    /// 获取状态码的描述
    /// </summary>
    /// <param name="en">状态码枚举</param>
    /// <returns></returns>
    private static string GetStatusCodeDescription(Enum en) {
        Type type = en.GetType();   //获取类型  
        MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员  
        if (memberInfos != null && memberInfos.Length > 0) {
            DescriptionAttribute[]? attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];   //获取描述特性  
            if (attrs != null && attrs.Length > 0) {
                return attrs[0].Description;    //返回当前描述
            }
        }
        return en.ToString();
    }
}

/// <summary>
/// 状态码枚举
/// </summary>
public enum ResultCode {
    // 通用状态码
    [Description("成功")]
    SUCCESS = 0,
    [Description("失败")]
    Failure = -1,

    // 用户登录
    [Description("用户不存在")]
    USER_NOT_FOUND = 1000,
    [Description("密码不正确")]
    PASSWORD_INCORRECT = 1001
}
```

#### 2.2 Controllers

1. Controller前面加上

   ```c#
   [Route("api/[controller]")]
   [ApiController]
   ```

2. 返回值都用Result包装

   ```json
   {
     "code": 0,
     "msg": "成功",
     "data": [
       {
         "id": "1",
         "name": "bjh",
         "phoneNumber": "123456",
         "passengerId": "123456            ",
         "password": "123456                                                          "
       }
     ]
   }
   ```

#### 2.3 Dao

1. Repository类：继承SimpleClient类，主要实现对数据库的访问，配置日志

	```c#
	/// <summary>
	/// SqlSugarScope操作数据库是线程安全的可以单例
	/// </summary>
	public static SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig() {
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
	```

2. Dao层的类都需继承Repository，都使用Repository中的静态字段SqlSugarScope

#### 2.4 Model

1. 举例：User类
	```c#
	/// <summary>
	/// 
	///</summary>
	[SugarTable("USER")]
	public class User
	{
	    /// <summary>
	    /// 用户主码 
	    ///</summary>
	    [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true   )]
	    public string? Id { get; set; }
	    /// <summary>
	    /// 用户姓名 
	    ///</summary>
	    [SugarColumn(ColumnName="NAME"    )]
	    public string? Name { get; set; }
	    /// <summary>
	    /// 电话号码 
	    ///</summary>
	    [SugarColumn(ColumnName="PHONE_NUMBER"    )]
	    public string? PhoneNumber { get; set; }
	    /// <summary>
	    /// 身份证号 
	    ///</summary>
	    [SugarColumn(ColumnName="PASSENGER_ID"    )]
	    public string? PassengerId { get; set; }
	    /// <summary>
	    /// 用户密码(sha256) 
	    ///</summary>
	    [SugarColumn(ColumnName="PASSWORD"    )]
	    public string? Password { get; set; }
	}
	```

#### 2.5 Service

1. 举例：UserService

    ```c#
    /// <summary>
    /// 用户 服务层 接口
    /// </summary>
    public interface IUserService {
    /// <summary>
    /// 获取所有用户
    /// </summary>
    /// <returns>用户List</returns>
    public IEnumerable<User> GetUsers();
    }
    
    
    /// <summary>
    /// 用户 服务层 接口实现
    /// </summary>
    public class UserService : IUserService {
    /// <summary>
    /// Dao层 对象
    /// </summary>
    private readonly UserDao userDao = new UserDao();
    
    /// <summary>
    /// 获取所有用户
    /// </summary>
    /// <returns>用户对象列表</returns>
    public IEnumerable<User> GetUsers() {
    	return userDao.GetList().ToList();
    }
    
    /// <summary>
    /// 用Id查询用户
    /// </summary>
    /// <param name="id">用户Id</param>
    /// <returns>用户对象</returns>
    public User GetUserById(string id) {
    	return userDao.GetById(id);
    }
    }
    ```

#### 2.6 Util

暂无内容，之后添加