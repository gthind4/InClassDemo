<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Listview.aspx.cs" Inherits="SamplePages_Listview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>List View Query Display </h1>
    <table align="center" style="width: 70%">
        <tr>
            <td>Special Event Code</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" AppendDataBoundItems="True" DataSourceID="ODSSpecialEvent" DataTextField="Description" DataValueField="EventCode">
                </asp:DropDownList>
                <asp:LinkButton ID="FetchReservations" runat="server" OnClick="FetchReservations_Click">Fetch reservations</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td>
                <asp:ListView ID="ReservationList" runat="server" DataSourceID="ODSReservations">
                    <AlternatingItemTemplate>
                        <tr style="background-color:#FFF8DC;">
                            
                           
                            <td>
                                <asp:Label ID="ReservationIDLabel" runat="server" Text='<%# Eval("ReservationID") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ReservationDateLabel" runat="server" Text='<%# Eval("ReservationDate") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NumberInPartyLabel" runat="server" Text='<%# Eval("NumberInParty") %>' />
                            </td>
                           
                            </td>
                            <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Eval("ContactPhone") %>' />
                          
                            </td>
                            <asp:Label ID="ReservationStatusLabel" runat="server" Text='<%# Eval("ReservationStatus") %>' />
                            <td>
                                <asp:Label ID="EventCodeLabel" runat="server" Text='<%# Eval("EventCode") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EventLabel" runat="server" Text='<%# Eval("Event") %>' />
                            </td>
                            <td>
                                <asp:Label ID="TablesLabel" runat="server" Text='<%# Eval("Tables") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    
                    <EditItemTemplate>
                        <tr style="background-color:#008A8C;color: #FFFFFF;">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                            </td>
                            
                            <td>
                                <asp:TextBox ID="ReservationIDTextBox" runat="server" Text='<%# Bind("ReservationID") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CustomerNameTextBox" runat="server" Text='<%# Bind("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="ReservationDateTextBox" runat="server" Text='<%# Bind("ReservationDate") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="NumberInPartyTextBox" runat="server" Text='<%# Bind("NumberInParty") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' />
                            </td>
                           
                            <td>
                                <asp:TextBox ID="ReservationStatusTextBox" runat="server" Text='<%# Bind("ReservationStatus") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="EventCodeTextBox" runat="server" Text='<%# Bind("EventCode") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="EventTextBox" runat="server" Text='<%# Bind("Event") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="TablesTextBox" runat="server" Text='<%# Bind("Tables") %>' />
                            </td>
                           
                        </tr>
                    </EditItemTemplate>
                    
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
 
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            </td>
                            
                            <td>
                                <asp:TextBox ID="ReservationIDTextBox" runat="server" Text='<%# Bind("ReservationID") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="CustomerNameTextBox" runat="server" Text='<%# Bind("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="ReservationDateTextBox" runat="server" Text='<%# Bind("ReservationDate") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="NumberInPartyTextBox" runat="server" Text='<%# Bind("NumberInParty") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' />
                            </td>
                           
                            <td>
                                <asp:TextBox ID="ReservationStatusTextBox" runat="server" Text='<%# Bind("ReservationStatus") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="EventCodeTextBox" runat="server" Text='<%# Bind("EventCode") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="EventTextBox" runat="server" Text='<%# Bind("Event") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="TablesTextBox" runat="server" Text='<%# Bind("Tables") %>' />
                            </td>
                           
                        </tr>
                    </InsertItemTemplate>
 
                    <ItemTemplate>
                        <tr style="background-color:#DCDCDC;color: #000000;">
                            
                           
                            
                            <td>
                                <asp:Label ID="ReservationIDLabel" runat="server" Text='<%# Eval("ReservationID") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ReservationDateLabel" runat="server" Text='<%# Eval("ReservationDate") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NumberInPartyLabel" runat="server" Text='<%# Eval("NumberInParty") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Eval("ContactPhone") %>' />
                            </td>
                            
                           
                            
                            <td>
                                <asp:Label ID="ReservationStatusLabel" runat="server" Text='<%# Eval("ReservationStatus") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EventCodeLabel" runat="server" Text='<%# Eval("EventCode") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EventLabel" runat="server" Text='<%# Eval("Event") %>' />
                            </td>
                            <td>
                                <asp:Label ID="TablesLabel" runat="server" Text='<%# Eval("Tables") %>' />
                            </td>
                            
                           
                            
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                            
                                            <th runat="server">ReservationID</th>
                                            <th runat="server">CustomerName</th>
                                            <th runat="server">ReservationDate</th>
                                            <th runat="server">NumberInParty</th>
                                            <th runat="server">ContactPhone</th>
                                            
                                            <th runat="server">ReservationStatus</th>
                                            <th runat="server">EventCode</th>
                                            <th runat="server">Event</th>
                                            <th runat="server">Tables</th>
                                            
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder">
                                            
                                            
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    
                    <SelectedItemTemplate>
                        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                            <td>
                                <asp:Label ID="ReservationIDLabel" runat="server" Text='<%# Eval("ReservationID") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ReservationDateLabel" runat="server" Text='<%# Eval("ReservationDate") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NumberInPartyLabel" runat="server" Text='<%# Eval("NumberInParty") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Eval("ContactPhone") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ReservationStatusLabel" runat="server" Text='<%# Eval("ReservationStatus") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EventCodeLabel" runat="server" Text='<%# Eval("EventCode") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EventLabel" runat="server" Text='<%# Eval("Event") %>' />
                            </td>
                            <td>
                                <asp:Label ID="TablesLabel" runat="server" Text='<%# Eval("Tables") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                    
                </asp:ListView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ObjectDataSource ID="ODSSpecialEvent" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ReservationList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 41px"></td>
            <td style="height: 41px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
   
</asp:Content>

