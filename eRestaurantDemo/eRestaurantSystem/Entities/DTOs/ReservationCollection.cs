using eRestaurantSystem.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

#endregion
namespace eRestaurantSystem.Entities.DTOs
{
    public class ReservationCollection
    {
        //data
        public int Hour { get; set; }
        public TimeSpan SeatingTime { get { return new TimeSpan(Hour, 0, 0); } }

        //read only property
        public virtual ICollection<ReservationSummary> Reservations { get; set; }
    }
}
