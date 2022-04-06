using FeulMetrics.Services.Interface;
using FuelMetrics.Domain.Dto;
using FuelMetrics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeulMetrics.Services.Implementation
{
    public class TicketRepo : ITicket
    {
        private readonly db_a483f5_usertestContext _context;
        public TicketRepo(db_a483f5_usertestContext context)
        {
            _context = context;
        }

        private static int EntryFee = 2;
        private static int FirstHour = 3;
        private static int OtherHour = 4;
        public async Task<string> CreateTicket(CreateTicketDto createTicket)
        {
            var timespent = CalculateTimeSpent(createTicket.EntryTime, createTicket.ExitTime);
            var amount = CalculateAmount(timespent);

            var ticket = new PackingTicket()
            {
                Name = createTicket.Name,
                EntryTime = createTicket.EntryTime,
                ExitTime = createTicket.ExitTime,
                HoursSpent = timespent,
                AmountToPay = amount,
                Date = DateTime.Now,
            };
            _context.PackingTickets.Add(ticket);
            await _context.SaveChangesAsync();
            return "Ticket Created";
        }
        

        private int CalculateTimeSpent(string EntryTime, string ExitTime)
        {
            //HH:MM
            var entry = EntryTime.Split(":");
            var exit = ExitTime.Split(":");

            int hour = int.Parse(exit[0])-int.Parse(entry[0]);
            int minute = int.Parse(exit[1]) - int.Parse(entry[1]);

            if (minute > 0) { hour++; }
            return hour;
        }

        private int CalculateAmount(int hours)
        {
            //4
            //After 1st hr, 3hrs remaining
            int TotalAmount = EntryFee;

            if (hours > 1)
            {
                //firsthour
                TotalAmount += FirstHour;
                hours = hours - 1;
            }
            TotalAmount += (hours * OtherHour);

            return TotalAmount;
        }


        public ICollection<PackingTicket> GetAllTicketByDate(DateTime Date)
        {

            var allTicks = _context.PackingTickets.Where(x => x.Date.Date == Date).ToList();
            return allTicks;
        }
    }
}

