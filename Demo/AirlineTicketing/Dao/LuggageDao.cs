using AirlineTicketing.Model;


namespace AirlineTicketing.Dao
{
    
    /// <summary>
    /// Luggage Dao层 接口
    /// </summary>
    public interface ILuggageDao
    {
        public Luggage GetLuggageByDecimalId(decimal? id);
        public Luggage GetLuggageByTicketId(string tid);
    }
    
    /// <summary>
    /// Luggage Dao层 接口实现
    /// </summary>
    public class LuggageDao : Repository<Luggage>, ILuggageDao {


        public Luggage GetLuggageByDecimalId(decimal? id) {
            var luggagesList = Db.Queryable<Luggage>().Where(it => it.Id != null && it.Id.Equals(id)).ToList();
            // 不存在该行李，返回空行李
            if (luggagesList.Count == 0) {
                return new Luggage();
            }
            // 存在则返回第一个结果
            return luggagesList[0];
        }
        
        
        public Luggage GetLuggageByTicketId(string? tid ) {
            var luggagesList = Db.Queryable<Luggage>().Where(it => it.TicketId != null && it.TicketId.Equals(tid)).ToList();
            // 不存在该行李，返回空行李
            if (luggagesList.Count == 0) {
                return new Luggage();
            }
            // 存在则返回第一个结果
            return luggagesList[0];
        }
    }
    
    
    
    
    
}
