using AirlineTicketing.Model;
using AirlineTicketing.Dao;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketing.Service;

public interface ITicketService
{
    
}

public class TicketService:ITicketService
{
    private readonly TicketDao _ticketDao = new TicketDao();
    
    
}