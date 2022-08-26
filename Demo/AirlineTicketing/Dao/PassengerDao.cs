using AirlineTicketing.Model;

namespace AirlineTicketing.Dao;

public interface IPassengerDao {
}

public class PassengerDao : Repository<Passenger>, IPassengerDao {
    
}