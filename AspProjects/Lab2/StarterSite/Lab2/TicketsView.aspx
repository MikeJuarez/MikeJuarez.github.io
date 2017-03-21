<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="TicketsView.aspx.cs" Inherits="Lab2_TicketsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <div>    
    <table border="0">
            <tr>
                <td>Filter Tickets:</td>
                <td></td>
            </tr>
            <tr>
                <td>Category:</td>
                <td><asp:DropDownList ID="drpCategory" runat="server" Width="138"></asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnFilter" runat="server" Text="Filter" Height="26px" Width="114px" OnClick="btnSubmitTicket_Click" /></td>
            </tr>
    </table>
    </div>
    <p /><p />
    <table id="table2" border="1" runat="server">        
    </table>
    <asp:Label ID="lblCount" runat="server"></asp:Label>
</asp:Content>

