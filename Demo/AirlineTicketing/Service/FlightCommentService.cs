using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;


namespace AirlineTicketing.Service
{
    
    /// <summary>
    /// FlightComment 服务层 接口
    /// </summary>
    public interface IFlightCommentService
    {
        public IEnumerable<FlightComment> GetFlightCommentsByFlightId(string? id);
        public int GetFlightCommentsCountByFlightId(string? id);
        public bool Add([FromBody] FlightComment data);

    }

    public class FlightCommentService : Repository<FlightComment>, IFlightCommentService
    {
        
        /// <summary>
        /// Dao层 对象
        /// </summary>
        private readonly FlightCommentDao _flightCommentDao = new FlightCommentDao();
        
        
        /// <summary>
        /// 根据航班号返回评价列
        /// </summary>
        public IEnumerable<FlightComment> GetFlightCommentsByFlightId(string? id)
        {
            var flightCommentList = Db.Queryable<FlightComment>().Where(it => it.FlightId != null &&
                                                                              it.FlightId == id).ToList();
            return flightCommentList;

        }
        
        /// <summary>
        /// 根据航班号返回评价的个数
        /// </summary>
        public int GetFlightCommentsCountByFlightId(string? id)
        {
            return _flightCommentDao.Count(it => it.FlightId == id);
        }
        
        /// <summary>
        /// 根据航班号返回平均评价等级(1-5之间)
        /// </summary>
        public int GetFlightCommentsLevelByFlightId(string? id)
        {
            var levelAvg=Db.Queryable<FlightComment>().Where(it=>it.FlightId!=null && it.FlightId==id)
                .Select(a => SqlFunc.AggregateAvg(a.CommentLevel)).ToList();
            if (levelAvg==null) return 5;
            else return levelAvg[0]?? 5;
        }
        

        /// <summary>
        /// 添加 
        /// </summary>
        /// <returns></returns>
        public bool Add([FromBody] FlightComment data) {
            return _flightCommentDao.Insert(data);
        }
        
        
        
        
    }
    
    
    
}