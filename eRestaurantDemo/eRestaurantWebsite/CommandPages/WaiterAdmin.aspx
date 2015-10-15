<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>

<%@ Register src="../UserControls/MessageUserControl.ascx" tagname="MessageUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <uc1:MessageUserControl ID="MessageUserControl1" runat="server" />
    <br/>
    <h1>Waiter Admin</h1>
    <asp:Label ID="Label1" runat="server" Text="Select Waiter For Update">Select Waiter For Update</asp:Label>
    <asp:DropDownList ID="WaiterList" runat="server" AppendDataBoundItems="True" DataSourceID="ODSWaiters" DataTextField="FirstName" DataValueField="WaiterID">
        <asp:ListItem Value="0">Select Waiter </asp:ListItem>
    </asp:DropDownList>      &nbsp;&nbsp;&nbsp;      <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">FetchWaiter</asp:LinkButton>

    <asp:ObjectDataSource ID="ODSWaiters" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiter_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
     <table style="width: 80%">
        <tr>
            <td>ID</td>
            
            <td><asp:Label ID="WaiterID" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 22px">First Name</td>
            <td style="height: 22px">
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 22px">Last Name</td>
            <td style="height: 22px">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Hired (mm/dd/yyyyy)</td>
            <td>
                <asp:TextBox ID="DateHired" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 22px">Date Released (mm/dd/yyyyy)</td>
            <td style="height: 22px">
                <asp:TextBox ID="DateReleased" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="InsertWaiter" runat="server">LinkButton</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="UpdateWaiter" runat="server">LinkButton</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

