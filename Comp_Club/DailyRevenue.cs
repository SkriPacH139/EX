using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comp_Club
{
    public class DailyRevenue
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Revenue { get; set; }         
    }
}
