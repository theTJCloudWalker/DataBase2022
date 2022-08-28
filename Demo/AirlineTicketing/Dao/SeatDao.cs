using AirlineTicketing.Model;
using AirlineTicketing.Util;

namespace AirlineTicketing.Dao
{

    public interface ISeatDao
    {
        public IEnumerable<SeatTable> GetSeatsByInstanceId(string instanceId);

        public void UpdateSold(string seatId,string stauts);

    }                                                   
    
    
    public class SeatDao : Repository<SeatTable>, ISeatDao
    {
        public IEnumerable<SeatTable> GetSeatsByInstanceId(string instanceId) {
            var seats = Db.Queryable<SeatTable>().Where(it => it.InstanceId == instanceId && it.Sold=="0").ToList();
            return seats;
        }

        public void UpdateSold(string seatId,string stauts)
        {
            var result =  Db.Updateable<SeatTable>().SetColumns(it => it.Sold == stauts)
                .Where(it => it.SeatId == seatId);

        }
        
    }
    

}