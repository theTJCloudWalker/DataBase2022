using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;


namespace AirlineTicketing.Service
{
    
    /// <summary>
    /// 行李 服务层 接口
    /// </summary>
    public interface ILuggageService
    {

        public Luggage GetLuggageByDecimalId(decimal? id);
        public Luggage GetLuggageByTicketId(string? tId);
        public bool Insert([FromBody] Luggage data);
        

    }

    
    
    
    
    public class LuggageService : ILuggageService
    {

        /// <summary>
        /// Dao层 对象
        /// </summary>
        private readonly LuggageDao _luggageDao = new LuggageDao();
        
        
        
        /// <summary>
        /// 通过id获得行李
        /// </summary>
        /// <returns>行李</returns>
        public Luggage GetLuggageByDecimalId(decimal? id)
        {
            return _luggageDao.GetLuggageByDecimalId(id);
        }
    
        /// <summary>
        /// 通过TicketId获得行李
        /// </summary>
        /// <returns>行李</returns>
        public Luggage GetLuggageByTicketId(string? tId)
        {
            return _luggageDao.GetLuggageByTicketId(tId);
        }

        /// <summary>
        /// 修改重量
        /// </summary>
        /// <returns></returns>
        public bool UpdateWeight(decimal? id, decimal weight)
        {

            return _luggageDao.Update(luggage => new Luggage()
            {
                Weight = weight
            }, luggage => luggage.Id.Equals(id));
            
        }
        
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public bool Insert([FromBody] Luggage data)
        {

            return _luggageDao.Insert(data);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteById(string? id)
        {

            return _luggageDao.DeleteById(id);
        }
        
        
    }
    
    
   
    
    
    
    
    
    
    
    
    
    
    
    
    
}
