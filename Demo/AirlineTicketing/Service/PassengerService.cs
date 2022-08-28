using AirlineTicketing.Dao;
using AirlineTicketing.Model;

namespace AirlineTicketing.Service;

public interface IPassengerService {
    public bool AddPassenger(Passenger passenger);
    public bool UpdatePassenger(Passenger passenger);
}

public class PassengerService : IPassengerService {
    private readonly PassengerDao _passengerDao;

    public PassengerService() {
        _passengerDao = new PassengerDao();
    }

    public bool AddPassenger(Passenger passenger) {
        return _passengerDao.Insert(passenger);
    }

    /// <summary>
    /// 传入身份证号更新数据
    /// </summary>
    /// <param name="passenger"></param>
    /// <returns></returns>
    public bool UpdatePassenger(Passenger passenger) {
        var p = _passengerDao.GetById(passenger.Id);
        // 更新除id外的所有非null属性
        return _passengerDao.Update(p => new Passenger() {
            Age = passenger.Age ?? p.Age,
            Name = passenger.Name ?? p.Name,
            PhoneNumber = passenger.PhoneNumber ?? p.PhoneNumber
        }, it => it.Id!.Equals(p.Id));
    }
}