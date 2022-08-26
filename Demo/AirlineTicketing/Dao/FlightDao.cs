using AirlineTicketing.Model;

namespace AirlineTicketing.Dao {
    /// <summary>
    /// 航班 Dao层 接口
    /// </summary>
    public interface IFlightDao {
        public IEnumerable<Flight> GetFlights(Flight flightdata);
    }

    /// <summary>
    /// 航班 Dao层 接口实现
    /// </summary>
    public class FlightDao : Repository<Flight>, IFlightDao {
        public IEnumerable<Flight> GetFlights(Flight flightdata) {
            var flights = Db.Queryable<Flight>().Where(it =>
                it.DepartureTime == flightdata.DepartureTime && it.DepartureAirport == flightdata.DepartureAirport &&
                it.ArrivalAirport == flightdata.ArrivalAirport).ToList();
            return flights;
        }
    }
}