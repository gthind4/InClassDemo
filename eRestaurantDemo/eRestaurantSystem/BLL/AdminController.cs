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
using eRestaurantSystem.Entities.POCOs; //used for ODS access
#endregion
namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the SpecialEvents table on sql
                //to do so we will use the DbSet in eRestaurantContext
                //call SpecialEvents (done by mapping)

                //method syntax
                return context.SpecialEvents.OrderBy(x => x.Description).ToList();
                //Query syntax
                //var results = from item in context.SpecialEvents
                //              orderby item.Description
                //              select item;
                //return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the SpecialEvents table on sql
                //to do so we will use the DbSet in eRestaurantContext
                //call SpecialEvents (done by mapping)

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();
                //Query syntax
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationByDate> GetReservationsByDate(string ReservationDate)
        {
            using (var context = new eRestaurantContext())
            {
                //remember LINQ does not like using DateTime casting
                int theYear = (DateTime.Parse(ReservationDate)).Year;
                int theMonth = (DateTime.Parse(ReservationDate)).Month;
                int theDay = (DateTime.Parse(ReservationDate)).Day;
            
                //Query syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate() //DTO
                              { 
                                Description =item.Description,
                                Reservations = from row in item.Reservations //collection of navigated rows of ICollection in SpecialEvents
                                                where row.ReservationDate.Year == theYear
                                                    && row.ReservationDate.Month == theMonth
                                                    && row.ReservationDate.Day == theDay
                                                    select new ReservationDetail()
                                                    {
                                                        CustomerName = row.CustomerName,
                                                        ReservationDate = row.ReservationDate,
                                                        NumberInParty = row.NumberInParty,
                                                        ContactPhone = row.ContactPhone,
                                                        ReservationStatus = row.ReservationStatus
                                                    }
                              };
                return results.ToList();
            }

        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> GetCategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                //remember LINQ does not like using DateTime casting
               

                //Query syntax
                var results = from category in context.MenuCategories
                              orderby category.Description
                              select new CategoryMenuItems() //DTO
                              {
                                  Description = category.Description,
                                  MenuItems = from row in category.MenuItems 
                                                 
                                                 select new MenuItem()
                                                 {
                                                     Description = row. Description,
                                                      Price = row.CurrentPrice,
                                                      Calories = row.Calories,
                                                      Comment = row.Comment
                                                 }
                              };
                return results.ToList();
            }

        }
    }
}
