using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelMetrics.Domain.Dto
{
    public class CreateTicketDto
    {
        public string Name { get; set; }
        public string EntryTime { get; set; }
        public string ExitTime { get; set; }
    }
}
