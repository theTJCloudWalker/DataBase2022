using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using AirlineTicketing.Util;
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

        public User GetUserById(string? id);

        public bool DeleteUserByIds([FromBody] object[] ids);

        public bool Add([FromBody] User data);

        public bool Update([FromBody] User data);

        public IEnumerable<User> GetUserByNames(List<string> names);

        public User GetUserByName(string name);

        public int GetUserCount();

        public User UpdateUserName(string userName, string newUserName);
        public User UpdatePassword(string userName, string newPassword);
        public User UpdatePhoneNumber(string userName, string newPhoneNumber);
        public User UpdatePassengerId(string userName, string newPassengerId);
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
            // id不能修改，用id获取用户
            // 或者用username 不准修改用户名
            var user = GetUserByName(data.Name!);
            if (user.Id == null) {
                throw new Exception("用户不存在");
            }
            // where条件是id一致
            // null值不更新，非null值更新
            return _userDao.Update(it => new User() {
                Amount = data.Amount ?? it.Amount,
                Name = data.Name ?? it.Name,
                PassengerId = data.PassengerId ?? it.PassengerId,
                Password = Password.EncryptPassword(data.Password) ?? it.Password,
                PhoneNumber = data.PhoneNumber ?? it.PhoneNumber
            }, it => it.Name!.Equals(user.Name!));
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

        public User UpdateUserName(string userName, string newUserName) {
            _userDao.Update(user => new User {
                Name = newUserName
            }, user => user.Name!.Equals(userName));
            return _userDao.GetUserByName(newUserName);
        }

        public User UpdatePassword(string userName, string newPassword) {
            _userDao.Update(user => new User {
                Password = Password.EncryptPassword(newPassword)
            }, user => user.Name!.Equals(userName));
            return _userDao.GetUserByName(userName);
        }

        public User UpdatePhoneNumber(string userName, string newPhoneNumber) {
            _userDao.Update(user => new User {
                PhoneNumber = Password.EncryptPassword(newPhoneNumber)
            }, user => user.Name!.Equals(userName));
            return _userDao.GetUserByName(userName);
        }

        public User UpdatePassengerId(string userName, string newPassengerId) {
            _userDao.Update(user => new User {
                PassengerId = Password.EncryptPassword(newPassengerId)
            }, user => user.Name!.Equals(userName));
            return _userDao.GetUserByName(userName);
        }
    }
}