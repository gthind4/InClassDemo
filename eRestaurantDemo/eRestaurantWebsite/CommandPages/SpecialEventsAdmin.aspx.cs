﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommandPages_SpecialEventsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void checkForException(object sender,ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl1.HandleDataBoundException(e); //MessageUserControl1 is The name of MessageUserControl

    }
}