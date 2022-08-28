using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketing.Service
{
    public interface IOrderService
    {
        public bool Add([FromBody] Order data);

        public bool DeleteOrderByIds([FromBody] object[] ids);

        public Order GetOrderById(string? ids);

        public bool Update([FromBody] Order data);

        public List<Order> GetList([FromBody] Order data);
    }

    public class OrderService : IOrderService
    {
        private readonly OrderDao _orderDao = new OrderDao();

        public bool Add([FromBody] Order data){
            return _orderDao.Insert(data);
        }

        public bool DeleteOrderByIds([FromBody] object[] ids){
            return _orderDao.DeleteByIds(ids);
        }

        public Order GetOrderById(string? ids){
            return _orderDao.GetById(ids);
        }

        public bool Update([FromBody] Order data){
            var order = GetOrderById(data.Id);

            return  _orderDao.Update(it => new Order(){
                UserId = data.UserId ?? it.UserId,
                OrderTime = data.OrderTime ?? it.OrderTime,
                Amount = data.Amount ?? it.Amount,
                IsPaid = data.IsPaid ?? it.IsPaid
            },it => it.Id!.Equals(order.Id!));
        }

        public List<Order> GetList([FromBody] Order data){
            return _orderDao.GetList(it => 
                it.Id!.Contains(data.Id ?? it.Id) &&
                it.UserId!.Contains(data.UserId ?? it.UserId) &&
                it.OrderTime!.Equals(data.OrderTime ?? it.OrderTime) &&
                it.Amount!.Equals(data.Amount ?? it.Amount) &&
                it.IsPaid!.Equals(data.IsPaid ?? it.IsPaid)
            );
        }
    }
}