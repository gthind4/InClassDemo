﻿using System;
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
using System.Data.Entity;
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<WaiterBilling> GetWaiterBillingReport()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from abillrow in context.Bills
                              where abillrow.BillDate.Month == 5
                             orderby abillrow.BillDate, abillrow.Waiter.LastName, abillrow.Waiter.FirstName
                             select new WaiterBilling
                             {
                                 BillDate = abillrow.BillDate.Year+"/"+
                                            abillrow.BillDate.Month+"/"+
                                            abillrow.BillDate.Day,
                                 Name = abillrow.Waiter.LastName + abillrow.Waiter.FirstName,
                                 BillID = abillrow.BillID,
                                 BillTotal = abillrow.Items.Sum(bitem => bitem.Quantity * bitem.SalePrice),
                                 PartySize = abillrow.NumberInParty,
                                 Contact = abillrow.Reservation.CustomerName
                             };
                return results.ToList();
            }
        }
        #endregion

        #region Front Desk
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DateTime GetLastBillDateTime()
        {
            using (var context = new eRestaurantContext())
            {
                var result = context.Bills.Max(x => x.BillDate);
                return result;
            }
        }

        
            [DataObjectMethod(DataObjectMethodType.Select)]
            public List<ReservationCollection> ReservationsByTime(DateTime date)
            {
                using (var context = new eRestaurantContext())
                {
                    var result = (from data in context.Reservations
                                  where data.ReservationDate.Year == date.Year
                                  && data.ReservationDate.Month == date.Month
                                  && data.ReservationDate.Day == date.Day
                                      // && data.ReservationDate.Hour == timeSlot.Hours
                                  && data.ReservationStatus == Reservation.Booked
                                  select new ReservationSummary()
                                  {
                                      ID = data.ReservationID,
                                      Name = data.CustomerName,
                                      Date = data.ReservationDate,
                                      NumberInParty = data.NumberInParty,
                                      Status = data.ReservationStatus,
                                      Event = data.Event.Description,
                                      Contact = data.ContactPhone
                                  }).ToList();

                    //the second part of this method uses the result of first LINQ query.
                    //first linq query.
                    //Linq to Enitity will only execute the query when it deems
                    //necessary for having the results in memory.
                    //to get your query to execute and have the resulting data
                    //inside memory for further use, u can attach the .ToList()
                    // to the previous query.
                    var finalResult = from item in result
                                      orderby item.NumberInParty
                                      group item by item.Date.Hour into itemGroup
                                      select new ReservationCollection()
                                      {
                                          Hour = itemGroup.Key,
                                          Reservations = itemGroup.ToList()
                                      };
                    return finalResult.OrderBy(x => x.Hour).ToList();
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public List<SeatingSummary> SeatingByDateTime(DateTime date, TimeSpan time)
            {
                using (var context = new eRestaurantContext())
                {
                    // Step 1 - Get the table info along with any walk-in bills and reservation bills for the specific time slot
                    var step1 = from data in context.Tables
                                select new
                                {
                                    Table = data.TableNumber,
                                    Seating = data.Capacity,
                                    // This sub-query gets the bills for walk-in customers
                                    WalkIns = from walkIn in data.Bills
                                              where
                                                     walkIn.BillDate.Year == date.Year
                                                  && walkIn.BillDate.Month == date.Month
                                                  && walkIn.BillDate.Day == date.Day
                                                  //&& walkIn.BillDate.TimeOfDay <= time
                                                  && DbFunctions.CreateTime(walkIn.BillDate.Hour,
                                                                            walkIn.BillDate.Minute,
                                                                            walkIn.BillDate.Second )<= time
                                                  && (!walkIn.OrderPaid.HasValue || walkIn.OrderPaid.Value >= time)
                                              //                          && (!walkIn.PaidStatus || walkIn.OrderPaid >= time)
                                              select walkIn,
                                    // This sub-query gets the bills for reservations
                                    Reservations = from booking in data.Reservations
                                                   from reservationParty in booking.Bills
                                                   where
                                                          reservationParty.BillDate.Year == date.Year
                                                       && reservationParty.BillDate.Month == date.Month
                                                       && reservationParty.BillDate.Day == date.Day
                                                       //&& reservationParty.BillDate.TimeOfDay <= time
                                                       && DbFunctions.CreateTime(reservationParty.BillDate.Hour,
                                                                            reservationParty.BillDate.Minute,
                                                                            reservationParty.BillDate.Second )<= time
                                                       && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid.Value >= time)
                                                   //                          && (!reservationParty.PaidStatus || reservationParty.OrderPaid >= time)
                                                   select reservationParty
                                };
                   
                    // Step 2 - Union the walk-in bills and the reservation bills while extracting the relevant bill info
                    // .ToList() helps resolve the "Types in Union or Concat are constructed incompatibly" error
                    var step2 = from data in step1.ToList() // .ToList() forces the first result set to be in memory
                                select new
                                {
                                    Table = data.Table,
                                    Seating = data.Seating,
                                    CommonBilling = from info in data.WalkIns.Union(data.Reservations)
                                                    select new // info
                                                    {
                                                        BillID = info.BillID,
                                                        BillTotal = info.Items.Sum(bi => bi.Quantity * bi.SalePrice),
                                                        Waiter = info.Waiter.FirstName,
                                                        Reservation = info.Reservation
                                                    }
                                };
                   
                    // Step 3 - Get just the first CommonBilling item
                    //         (presumes no overlaps can occur - i.e., two groups at the same table at the same time)
                    var step3 = from data in step2.ToList()
                                select new
                                {
                                    Table = data.Table,
                                    Seating = data.Seating,
                                    Taken = data.CommonBilling.Count() > 0,
                                    // .FirstOrDefault() is effectively "flattening" my collection of 1 item into a 
                                    // single object whose properties I can get in step 4 using the dot (.) operator
                                    CommonBilling = data.CommonBilling.FirstOrDefault()
                                };
                   
                    // Step 4 - Build our intended seating summary info
                    var step4 = from data in step3
                                select new SeatingSummary() // the DTO class to use in my BLL
                                {
                                    Table = data.Table,
                                    Seating = data.Seating,
                                    Taken = data.Taken,
                                    // use a ternary expression to conditionally get the bill id (if it exists)
                                    BillID = data.Taken ?               // if(data.Taken)
                                             data.CommonBilling.BillID  // value to use if true
                                           : (int?)null,               // value to use if false
                                    BillTotal = data.Taken ?
                                                data.CommonBilling.BillTotal : (decimal?)null,
                                    Waiter = data.Taken ? data.CommonBilling.Waiter : (string)null,
                                    ReservationName = data.Taken ?
                                                      (data.CommonBilling.Reservation != null ?
                                                       data.CommonBilling.Reservation.CustomerName : (string)null)
                                                    : (string)null
                                };
                    return step4.ToList();
                }
            }

        public bool IsAvailableSeats(DateTime when)
            {
                return AvailableSeatingByDateTime(DateTime.Parse(when.ToShortDateString()), TimeSpan.Parse(when.ToString())).Count > 0 ? true : false;

            }

        //seating of reservations
        public void SeatCustomer(DateTime when, int reservationId, List<byte> tables, int waiterId)
        {
            var availableSeats = AvailableSeatingByDateTime(when.Date, when.TimeOfDay);
            using (var context = new RestaurantContext())
            {
                List<string> errors = new List<string>();
                // Rule checking:
                // - Reservation must be in Booked status
                // - Table must be available - typically a direct check on the table, but proxied based on the mocked time here
                // - Table must be big enough for the # of customers
                var reservation = context.Reservations.Find(reservationId);
                if (reservation == null)
                    errors.Add("The specified reservation does not exist");
                else if (reservation.ReservationStatus != Reservation.Booked)
                    errors.Add("The reservation's status is not valid for seating. Only booked reservations can be seated.");

                //Is there suficient seats available for the reservation
                var capacity = 0;
                foreach (var tableNumber in tables)
                {
                    if (!availableSeats.Exists(x => x.Table == tableNumber))
                        errors.Add("Table " + tableNumber + " is currently not available");
                    else
                        capacity += availableSeats.Single(x => x.Table == tableNumber).Seating;
                }
                if (capacity < reservation.NumberInParty)
                    errors.Add("Insufficient seating capacity for number of customers. Alternate tables must be used.");
                if (errors.Count > 0)
                    throw new BusinessRuleException("Unable to seat customer", errors);
                // 1) Create a blank bill with assigned waiter
                Bill seatedCustomer = new Bill()
                {
                    BillDate = when,
                    NumberInParty = reservation.NumberInParty,
                    WaiterID = waiterId,
                    ReservationID = reservation.ReservationID
                };
                context.Bills.Add(seatedCustomer);
                // 2) Add the tables for the reservation and change the reservation's status to arrived
                foreach (var tableNumber in tables)
                    reservation.Tables.Add(context.Tables.Single(x => x.TableNumber == tableNumber));
                // 3) update the reservation status to arrived
                reservation.ReservationStatus = Reservation.Arrived;
                var updatable = context.Entry(context.Reservations.Attach(reservation));
                updatable.Property(x => x.ReservationStatus).IsModified = true;
                //updatable.Reference(x=>x.Tables).

                // 4) Save changes
                context.SaveChanges();
            }
            //string message = String.Format("Not yet implemented. Need to seat reservation {0} for waiter {1} at tables {2}", reservationId, waiterId, string.Join(", ", tables));
            //throw new NotImplementedException(message);
        }


            [DataObjectMethod(DataObjectMethodType.Select, false)]
            public List<WaiterOnDuty> ListWaiters()
            {
                using (var context = new eRestaurantContext())
                {
                    var result = from person in context.Waiters
                                 where person.ReleaseDate == null
                                 select new WaiterOnDuty()
                                 {
                                     WaiterId = person.WaiterID,
                                     FullName = person.FirstName + " " + person.LastName
                                 };
                    return result.ToList();
                }
            }
        #endregion
    }//eof class
}//eof namespace
