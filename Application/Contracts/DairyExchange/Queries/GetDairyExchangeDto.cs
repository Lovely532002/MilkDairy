using Domain.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.DairyExchange.Queries
{
    public class GetDairyExchangeDto
    {
        public int Id { get; set; }
        public float Milk { get; set; }
        public float MilkRate { get; set; }
        public string DailyDevision { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
