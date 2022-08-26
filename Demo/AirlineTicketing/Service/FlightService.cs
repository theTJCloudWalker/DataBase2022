using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketing.Service {
    /// <summary>
    /// 航班 服务层 接口
    /// </summary>
    public interface IFlightService {
        /// <summary>
        /// 获取所有航班
        /// </summary>
        /// <returns>航班List</returns>
        public IEnumerable<Flight> GetAllFlights();

        public Flight GetFlightById(string? id);

        public bool DeleteFlightByIds([FromBody] object[] ids);

        public bool Add([FromBody] Flight data);

        public bool Update([FromBody] Flight data);

        public int GetFlightCount();

        public IEnumerable<Flight> GetFlights([FromBody] Flight data);
    }


    /// <summary>
    /// 航班 服务层 接口实现
    /// </summary>
    public class FlightService : IFlightService {
        /// <summary>
        /// Dao层 对象
        /// </summary>
        private readonly FlightDao _flightDao = new FlightDao();

        /// <summary>
        /// 获取所有航班
        /// </summary>
        /// <returns>航班对象列表</returns>
        public IEnumerable<Flight> GetAllFlights() {
            return _flightDao.GetList().ToList();
        }

        public IEnumerable<Flight> GetFlights([FromBody] Flight data) {
            return _flightDao.GetFlights(data);
        }

        /// <summary>
        /// 用Id查询航班
        /// </summary>
        /// <param name="id">航班Id</param>
        /// <returns>航班对象</returns>
        public Flight GetFlightById(string? id) {
            return _flightDao.GetById(id);
        }

        /// <summary>
        /// 用主键删除航班
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteFlightByIds([FromBody] object[] ids) {
            return _flightDao.DeleteById(ids);
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <returns></returns>
        public bool Add([FromBody] Flight data) {
            return _flightDao.Insert(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public bool Update([FromBody] Flight data) {
            return _flightDao.Update(data);
        }

        public int GetFlightCount() {
            return _flightDao.Count(it => it.Id != null);
        }
    }
}