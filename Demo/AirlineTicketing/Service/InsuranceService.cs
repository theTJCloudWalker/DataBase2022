using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;


namespace AirlineTicketing.Service
{
    
    /// <summary>
    /// Insurance 服务层 接口
    /// </summary>
    public interface IInsuranceService
    {
        public IEnumerable<Insurance> GetInsurances();
        public IEnumerable<InsurancePolicy> GetInsurancePolicys();
        public InsurancePolicy GetInsurancePolicyById(string? id);
        public InsurancePolicy GetInsurancePolicyByTicket(string? id);
        public InsurancePolicy GetInsurancePolicyByOrderIdPassId(string? oid, string? pid);
        public bool DeleteInsurancePolicyById(string? id);

    }


    public class InsuranceService : Repository<InsurancePolicy>,IInsuranceService
    {
        /// <summary>
        /// Dao层 对象
        /// </summary>
        private readonly InsuranceDao _insuranceDao = new InsuranceDao();

        private readonly InsurancePolicyDao _insurancePolicyDao = new InsurancePolicyDao();

        public IEnumerable<Insurance> GetInsurances() {
            return _insuranceDao.GetList().ToList();
        }
        
        public IEnumerable<InsurancePolicy> GetInsurancePolicys() {
            return _insurancePolicyDao.GetList().ToList();
        }

        public InsurancePolicy GetInsurancePolicyById(string? id)
        {

            return _insurancePolicyDao.GetInsurancePolicyById(id);
        }
        
        /// <summary>
        /// 通过机票看保险信息
        /// </summary>
        public InsurancePolicy GetInsurancePolicyByTicket(string? id)
        {
            var ticketList = Db.Queryable<Ticket>().Where(it => it.OrderId!= null && it.OrderId.Equals(id)).ToList();
            var orderId = ticketList[0].OrderId;
            var insurancePoliciyList =Db.Queryable<InsurancePolicy>().Where(it => it.OrderId != null && it.OrderId.Equals(orderId)).ToList();
            // 不存在保险，返回空保险
            if (insurancePoliciyList.Count == 0) {
                return new InsurancePolicy();
            }
            // 存在则返回第一个结果
            return insurancePoliciyList[0];
            
        }
        
        /// <summary>
        /// 通过orderId和passengerId获得保险单信息
        /// </summary>
        public InsurancePolicy GetInsurancePolicyByOrderIdPassId(string? oid, string? pid)
        {
            
            var insurancePoliciyList =Db.Queryable<InsurancePolicy>().Where(it => it.OrderId != null && it.OrderId.Equals(oid)
               && it.PassengerId!=null && it.PassengerId==pid ).ToList();
            // 不存在保险，返回空保险
            if (insurancePoliciyList.Count == 0) {
                return new InsurancePolicy();
            }
            // 存在则返回第一个结果
            return insurancePoliciyList[0];
            
        }



        /// <summary>
        /// 通过保险公司名和保险名获取保险额度
        /// </summary>
        public decimal GetAmountByNames(string? companyName, string? insuranceName)
        {
            
            //根据保险单号查找保险金额
            var insuranceList = Db.Queryable<Insurance>()
                .Where(it => it.CompanyName == companyName
                             && it.InsuranceName == insuranceName).ToList();
            //若无对应的保险，则返回失败
            if (insuranceList.Count == 0)
            {
                return 0;
            }

            return insuranceList[0].Amount??0;

        }

        /// <summary>
        /// 通过订单id和保险价格为订单加钱
        /// </summary>
        public bool AddInsuranceForOrder(string? oid, decimal? amount)
        {
            //TODO
            //未知是否正确
            //此处修改对应的Order信息
            var result1 = Db.Updateable<Order>()
                .SetColumns( it=>it.Amount==it.Amount+amount)
                .Where( q => q.Id == oid).ExecuteCommand();

            return true;

        }
        
        /// <summary>
        /// 通过Id删除保险单信息，还要在订单上去掉对应金额
        /// </summary>
        public bool DeleteInsurancePolicyById(string? id)
        {
            var insurancePolicy =_insurancePolicyDao.GetById(id);
            //不存在该保险，返回失败
            if (insurancePolicy == new InsurancePolicy())
            {
                return false;
            }
            //通过保险单号查订单
            var orderList = Db.Queryable<Order>().Where(it => it.Id != null && it.Id == insurancePolicy.OrderId).ToList();
            //若不存在该对应的订单，返回失败
            if (orderList.Count == 0)
            {
                return false;
            }
            //根据保险单号查找保险金额
            var insuranceList = Db.Queryable<Insurance>()
                .Where(it => it.CompanyName == insurancePolicy.CompanyName
                             && it.InsuranceName == insurancePolicy.InsuranceName).ToList();
            //若无对应的保险，则返回失败
            if (insuranceList.Count == 0)
            {
                return false;
            }
            
            //全部查找成功，开始删除保险单信息和订单金额


            
            //TODO
            //未知是否正确
            //此处修改对应的Order信息
            //把订单号为insurancePolicy.OrderId的Order 替换
            var result1 = Db.Updateable<Order>()
                .SetColumns( it => new Order() 
                    {  Amount = orderList[0].Amount - insuranceList[0].Amount })
                .Where( q => q.Id == insurancePolicy.OrderId).ExecuteCommand();


            return true;
        }
        
        
    }
    
    
}