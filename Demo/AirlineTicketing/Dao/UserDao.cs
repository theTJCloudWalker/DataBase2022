using AirlineTicketing.Model;

namespace AirlineTicketing.Dao {
    /// <summary>
    /// 用户 Dao层 接口
    /// </summary>
    public interface IUserDao {
        
    }

    /// <summary>
    /// 用户 Dao层 接口实现
    /// </summary>
    public class UserDao : Repository<User>, IUserDao {

    }
}
