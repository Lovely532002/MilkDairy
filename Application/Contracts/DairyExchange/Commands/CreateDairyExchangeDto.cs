using Domain.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.DairyExchange.Commands
{
    public class CreateDairyExchangeDto
    {
        public float Milk { get; set; }
        public float MilkRate { get; set; }
        public string DailyDevision { get; set; }
        public int CustomerId { get; set; }
    }
}
