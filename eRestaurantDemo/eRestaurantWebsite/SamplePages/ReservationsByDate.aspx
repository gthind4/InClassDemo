<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationsByDate.aspx.cs" Inherits="SamplePages_ReservationsByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Reservation By Date (Repeater)</h1>
    <table align="center" style="width: 70%">
        <tr>
            <td align ="right">Enter Reservation By Date&nbsp;<asp:TextBox ID="ReservationDateArg" runat="server" ToolTip="mm/dd/yyyy" Text="01/01/1900"></asp:TextBox></td>
            
            
            <td><asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            
        </tr>
        <tr>
            <td colspan="2">
                <div class="row column-md-12">
                    <asp:Repeater ID="EventReservations" runat="server" DataSourceID="ODSEventRegistration">
                        <ItemTemplate>
                            <h3><%# Eval("Description") %></h3>
                            <asp:Repeater ID="ReservationList" runat="server" DataSource='<%# Eval("Reservations") %>'>
                            <ItemTemplate>
                                <h5>
                                    <%# Eval("CustomerName") %>
                                    <%# Eval("ContactPhone") %>
                                </h5>
                            </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                        </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
    
            <asp:ObjectDataSource ID="ODSEventRegistration" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByDate" TypeName="eRestaurantSystem.BLL.AdminController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ReservationDateArg" Name="ReservationDate" PropertyName="Text" Type="String" />
                </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

