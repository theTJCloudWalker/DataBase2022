using AirlineTicketing.Model;

namespace AirlineTicketing.Dao
{
    /// <summary>
    /// 用户 Dao层 接口
    /// </summary>
    public interface IOrderDao
    {
        public IEnumerable<Order> GetOrderById(List<string> ids);
        public Order GetOrderById(string id);
        
    }

    /// <summary>
    /// 用户 Dao层 接口实现
    /// </summary>
    public class OrderDao : Repository<Order>, IOrderDao
    {
        public IEnumerable<Order> GetOrderById(List<string> ids){
            var orders = Db.Queryable<Order>().Where(it => it.Id != null && ids.Contains(it.Id)).ToList();
            return orders;
        }

        public Order GetOrderById(string id){
            var orderList = Db.Queryable<Order>().Where(it => it.Id != null && it.Id.Equals(id)).ToList();
            // 不存在该用户，返回空用户
            if (orderList.Count == 0) {
                return new Order();
            }
            // 存在则返回第一个结果
            return orderList[0];
        }
    }
}