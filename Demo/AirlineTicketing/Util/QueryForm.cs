namespace AirlineTicketing.Util;

public enum Cabin
{
    FIRST_CLASS,
    BUSSINESS_CLASS,
    ECONOMY_CLASS,
    ALL
}

//搜索表单
public class QueryForm
{
    public string destination;
    public string depart;

    //舱位
    public Cabin cabin;

    //时间区间
    public DateTime startTime;
    public DateTime endTime; 
    
    public QueryForm()
    {
        
    }
}