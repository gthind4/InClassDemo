 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addition1 Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required(ErrorMessage = "A is Required (Only One Character)")]
        [StringLength(40)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Range(1,16,ErrorMessage="Party size is limited to 1-16")]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required, StringLength(1,MinimumLength=1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }

        //Navigation Properties
        public virtual SpecialEvent Event { get; set; }

        //the reservation table is a many to many relationship to Tables table
        // The SQL reservation table resolves this problem
        //However reservation table holds only a compound primary key
        //We will not create a ReservationsTable entity in our project but 
        // handle via navigation mapping
        //Therefore we will place a ICollection properties in this entity refering to the Tables table.
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
