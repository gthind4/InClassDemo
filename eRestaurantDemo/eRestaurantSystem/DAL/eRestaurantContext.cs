using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using System.Data.Entity;
#endregion
namespace eRestaurantSystem.DAL
{
    //this class should be restricted to access by ONLY
    //the BLL methods.
    //This class should not be accesible outside of the component library

    //this class inherits DbContext class
    internal class eRestaurantContext : DbContext
    {
        public eRestaurantContext()
            : base("name=EatIn")
        { 
            //constructor is used to pass web config string name
        }

        //setup the DbSet MAppings
        //One DbSet for each entity
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        //when overriding on ModelCreating(), it is important to remember to call the base method's implementration before you exit the method

        //The ManyToManyNavigationPropertyConfiguratoin.Map method lets you confiugure the tables and columns used for many to many relationships.
        //It takes ManyToManyNavigationPropertyConfiguratoin instance in which u specify the column names by calling the MapLeftKey, MaptRightKey,
        //and ToTable methods

        //The leftKey is the one specified in the HasMany method
        //The rightKey is the one specified in the WithMany method

        // we have a many to many relationship between reservation and tables
        // a resevation may need many tables
        // atable can have over time many reservations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(x => x.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("TableID");
                    mapping.MapRightKey("ReservationID");
                }
                );
        }
    }
}
