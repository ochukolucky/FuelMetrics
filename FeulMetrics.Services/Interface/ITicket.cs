using FuelMetrics.Domain.Dto;
using FuelMetrics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeulMetrics.Services.Interface
{
    public interface ITicket
    {
    
  
        ICollection<PackingTicket> GetAllTicketByDate(DateTime Date);
        Task<string> CreateTicket(CreateTicketDto createTicket);
 
    }
}
