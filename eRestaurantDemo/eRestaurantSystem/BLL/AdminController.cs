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
        #region Query Samples

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
        public List<eRestaurantSystem.Entities.POCOs.CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Category.Description, cat.Description
                              select new eRestaurantSystem.Entities.POCOs.CategoryMenuItems
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
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
        public List<eRestaurantSystem.Entities.DTOs.CategoryMenuItems> GetCategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                //remember LINQ does not like using DateTime casting
               

                //Query syntax
                var results = from category in context.MenuCategories
                              orderby category.Description
                              select new eRestaurantSystem.Entities.DTOs.CategoryMenuItems() //DTO
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
         #endregion

        #region CRUD Insert, Update, Delete
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            //input into this method is at the instance level
            using(eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                SpecialEvent added = null;

                //set up the add request for the dbContext
                added = context.SpecialEvents.Add(item);

                //Saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the annotations(validation) on your entity
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update (SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //look up the item instance on the database to determine if the instance exists
                //On delete make sutre u reference the PK
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                //set up the delete request command 
                context.SpecialEvents.Remove(existing);
                //commit the action to happen
                context.SaveChanges();
            }
        }
        #endregion
        #region Waiter CRUD Insert, Update, Delete

        //[DataObjectMethod(DataObjectMethodType.Insert, false)]
        //public void Waiter_Add(Waiter item)
        //{
        //    //input into this method is at the instance level
        //    using (eRestaurantContext context = new eRestaurantContext())
        //    {
        //        //create a pointer variable for the instance type
        //        //set this pointer to null
        //        Waiter added = null;

        //        //set up the add request for the dbContext
        //        added = context.Waiters.Add(item);

        //        //Saving the changes will cause the .Add to execute
        //        //commits the add to the database
        //        //evaluates the annotations(validation) on your entity
        //        context.SaveChanges();
        //    }
        //}

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Waiter_Add(Waiter item)
        {
            //input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type
                //set this pointer to null
                Waiter added = null;

                //set up the add request for the dbContext
                added = context.Waiters.Add(item);

                //Saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the annotations(validation) on your entity
                context.SaveChanges();

                return added.WaiterID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiterByID(int waiterID)
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the SpecialEvents table on sql
                //to do so we will use the DbSet in eRestaurantContext
                //call SpecialEvents (done by mapping)

                //method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();
                //Query syntax
                var results = from item in context.Waiters
                              where item.WaiterID == waiterID
                              orderby item.FirstName, item.LastName
                              select item;

                return results.FirstOrDefault();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiter_List()
        {
            using (var context = new eRestaurantContext())
            {
                var results = from item in context.Waiters
                                orderby item.FirstName, item.LastName
                             select item;

                return results.ToList();
            }
        }

        
        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void Waiter_Update (Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<Waiter>(context.Waiters.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        
        #endregion
    }//eof class
}//eof namespace
