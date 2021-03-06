﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using eRestaurantSystem.BLL;
using eRestaurantSystem.Entities;
using eRestaurantSystem.Entities.POCOs;

#endregion
public partial class UXPages_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ReservationSummaryListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        // Check the command name and add the reservation for the specified seats.
        if (e.CommandName.Equals("Seat"))
        {
            MessageUserControl.TryRun(() =>
            {
                // Get the data
                var reservationId = int.Parse(e.CommandArgument.ToString());
                var selectedItems = new List<byte>();//for multiple table numbers
                foreach (ListItem item in ReservationTableListBox.Items)
                {
                    if (item.Selected)
                        selectedItems.Add(byte.Parse(item.Text.Replace("Table ", "")));
                }
                var when = Mocker.MockDate.Add(Mocker.MockTime);
                // Seat the reservation customer
                var controller = new AdminController();
                controller.SeatCustomer(when, reservationId, selectedItems, int.Parse(WaiterDropDownList.SelectedValue));
                // Refresh the gridview
                SeatingGridView.DataBind();
                ReservationsRepeater.DataBind();
                ReservationTableListBox.DataBind();
            }, "Customer Seated", "Reservation customer has arrived and has been seated");
        }
    }
    protected bool ShowReservationSeating()
    {
        bool showreservations= false;
        //this method will query the database to
        //show any available seats for reservations
        DateTime when = Mocker.MockDate.Add(Mocker.MockTime);
        AdminController sysmgr = new AdminController();
        showreservations = sysmgr.IsAvailableSeats(when);
        return showreservations;
    }
}