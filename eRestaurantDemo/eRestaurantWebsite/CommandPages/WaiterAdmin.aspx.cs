﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL;
using EatIn.UI;
#endregion
public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Initialize the hire date to today
        DateHired.Text = DateTime.Today.ToShortDateString();
    }

    public void GetWaiterInfo()
    {
        //a standard look up sequence
        AdminController sysmgr = new AdminController();
        var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Phone.Text = waiter.Phone;
        Address.Text = waiter.Address;
        DateHired.Text = waiter.HireDate.ToShortDateString();
        if (waiter.ReleaseDate.HasValue)
        {
            DateReleased.Text = waiter.ReleaseDate.ToString();
        }
    }


    protected void FetchWaiter_Click(object sender, EventArgs e)
    {

        if (WaiterList.SelectedIndex == 0)
        {
            MessageUserControl1.ShowInfo("Please select a waiter before clicking fetch Waiter");
        }
        else
        {
            //we will use a TryRun() from MessageUserControl
            //This will capture error messages when/if they happen
            // and properly display in the user control
            //GetWaiterInfo() is your method for accessing BLL and query
            MessageUserControl1.TryRun((ProcessRequest)GetWaiterInfo);
        }
    }
}