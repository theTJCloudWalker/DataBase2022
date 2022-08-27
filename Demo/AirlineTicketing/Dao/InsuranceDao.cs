using AirlineTicketing.Model;

namespace AirlineTicketing.Dao
{
    
    /// <summary>
    /// Insurance Dao层 接口
    /// </summary>
    public interface IInsuranceDao {

    }

    /// <summary>
    /// Insurance Dao层 接口实现
    /// </summary>
    public class InsuranceDao : Repository<Insurance>, IInsuranceDao
    {

    }
    
}