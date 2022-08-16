using AirlineTicketing.Model;

namespace AirlineTicketing.Dao {
    /// <summary>
    /// 用户 Dao层 接口
    /// </summary>
    public interface IUserDao {
        public IEnumerable<User> GetUserByNames(List<string> names);
        public User GetUserByName(string name);
    }

    /// <summary>
    /// 用户 Dao层 接口实现
    /// </summary>
    public class UserDao : Repository<User>, IUserDao {
        public IEnumerable<User> GetUserByNames(List<string> names) {
            var users = Db.Queryable<User>().Where(it => it.Name != null && names.Contains(it.Name)).ToList();
            return users;
        }

        public User GetUserByName(string name) {
            var userList = Db.Queryable<User>().Where(it => it.Name != null && it.Name.Equals(name)).ToList();
            // 不存在该用户，返回空用户
            if (userList.Count == 0) {
                return new User();
            }
            // 存在则返回第一个结果
            return userList[0];
        }
    }
}