using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities.POCOs
{
    public class MenuItem
    {
        public String Description { get; set; }
        public decimal Price { get; set; }
        public int? Calories { get; set; }
        public String Comment { get; set; }
    }
}
