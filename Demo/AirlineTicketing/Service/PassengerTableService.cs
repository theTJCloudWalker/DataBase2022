using AirlineTicketing.Dao;
using AirlineTicketing.Model;

namespace AirlineTicketing.Service;

public interface IPassengerTableService {
    public bool AddPassengerToTable(string userId, string passengerId);
}

public class PassengerTableService : IPassengerTableService {
    private readonly PassengerTableDao _passengerTableDao;

    public PassengerTableService() {
        _passengerTableDao = new PassengerTableDao();
    }

    public bool AddPassengerToTable(string userId, string passengerId) {
        return _passengerTableDao.Insert(new PassengerTable() {
            PassengerId = passengerId,
            UserId = userId
        });
    }
}