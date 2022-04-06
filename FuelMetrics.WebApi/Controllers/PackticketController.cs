using FeulMetrics.Services.Interface;
using FuelMetrics.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuelMetrics.WebApi.Controllers
{
    public class PackticketController : Controller
    {

        private readonly ITicket _ticket;

        public PackticketController(ITicket ticket)
        {
            _ticket = ticket;
        }

        [HttpPost]
        [Route("CreateTicket")]
        public IActionResult CreateTicket([FromBody] CreateTicketDto createTicket)
        {
            return Ok( _ticket.CreateTicket(createTicket));
        }
        
        [HttpGet]
        [Route("GetgetAllTickets/{date}")]
        public IActionResult getAllticketsBydate(DateTime date)
        {
            return Ok(_ticket.GetAllTicketByDate(date));
        }
    }
}
