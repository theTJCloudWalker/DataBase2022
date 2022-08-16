using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketing.Service {
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
        private readonly UserDao _userDao = new UserDao();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>用户对象列表</returns>
        public IEnumerable<User> GetUsers() {
            return _userDao.GetList().ToList();
        }

        /// <summary>
        /// 用Id查询用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>用户对象</returns>
        public User GetUserById(string? id) {
            return _userDao.GetById(id);
        }

        /// <summary>
        /// 用主键删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteUserByIds([FromBody] object[] ids) {
            return _userDao.DeleteById(ids);
        }
        
        /// <summary>
        /// 添加 
        /// </summary>
        /// <returns></returns>
        public bool Add([FromBody] User data) {
            return _userDao.Insert(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public bool Update([FromBody] User data) {
            return _userDao.Update(data);
        }

        public IEnumerable<User> GetUserByNames(List<string> names) {
            return _userDao.GetUserByNames(names);
        }

        public User GetUserByName(string name) {
            return _userDao.GetUserByName(name);
        }

        public int GetUserCount() {
            return _userDao.Count(it => it.Id != null);
        }
    }
}