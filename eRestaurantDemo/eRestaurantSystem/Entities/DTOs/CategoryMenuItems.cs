using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.Entities.DTOs;
using eRestaurantSystem.Entities.POCOs;
using System.Collections; //used for ODS access
#endregion

namespace eRestaurantSystem.Entities.DTOs
{
    public class CategoryMenuItems
    {
        public String Description {get; set;}
        public IEnumerable MenuItems { get; set; }
    }
}
