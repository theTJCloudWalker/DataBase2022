using AirlineTicketing.Model;

namespace AirlineTicketing.Dao
{
    
    /// <summary>
    /// Insurance Dao层 接口
    /// </summary>
    public interface IInsurancePolicyDao {

    }

    /// <summary>
    /// Insurance Dao层 接口实现
    /// </summary>
    public class InsurancePolicyDao : Repository<InsurancePolicy>, IInsurancePolicyDao
    {
        
        public InsurancePolicy GetInsurancePolicyById(string? id) {
            var insurancePolicysList = Db.Queryable<InsurancePolicy>().Where(it => it.Id != null && it.Id.Equals(id)).ToList();
            // 不存在该保险，返回空保险
            if (insurancePolicysList.Count == 0) {
                return new InsurancePolicy();
            }
            // 存在则返回第一个结果
            return insurancePolicysList[0];
        }
        
        
    }
    
}