<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table align="center" style="width: 80%">
        <tr>
            <td style="text-align: right">Select Special Event</td>
            <td style="text-align: right">&nbsp;</td>
            <td style="text-align: right">&nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" DataSourceID="ODSspecialEvent" DataTextField="Description" DataValueField="EventCode" AppendDataBoundItems="True">
                    <asp:ListItem Value="z">Select Event </asp:ListItem>
                </asp:DropDownList>
                <asp:LinkButton ID="FetchReservation" runat="server">Fetch Reservation</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSReservations">
                    <AlternatingRowStyle BackColor="Silver" />
                    <Columns>
                        <asp:BoundField DataField="ReservationID" HeaderText="ReservationID" SortExpression="ReservationID" />
                        <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                        <asp:BoundField DataField="ReservationDate" HeaderText="ReservationDate" SortExpression="ReservationDate" />
                        <asp:BoundField DataField="NumberInParty" HeaderText="NumberInParty" SortExpression="NumberInParty" />
                        <asp:BoundField DataField="ContactPhone" HeaderText="ContactPhone" SortExpression="ContactPhone" />
                        <asp:BoundField DataField="ReservationStatus" HeaderText="ReservationStatus" SortExpression="ReservationStatus" />
                        <asp:BoundField DataField="EventCode" HeaderText="EventCode" SortExpression="EventCode" />
                    </Columns>
                    <EmptyDataTemplate>
                        No Data To Display at this time
                    </EmptyDataTemplate>
                    <PagerSettings FirstPageText="Start" Mode="NumericFirstLast" PageButtonCount="5" />
                </asp:GridView>
            </td>
        </tr>
        
        
    </table>
    <asp:ObjectDataSource ID="ODSspecialEvent" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

