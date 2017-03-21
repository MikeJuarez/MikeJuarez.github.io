<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="TicketsAdded.aspx.cs" Inherits="Lab2_TicketsAdded" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
        
    <div>    
    <table border="0">
            <tr>
                <td>Add Tickets:</td>
                <td></td>
            </tr>
            <tr>
                <td>Title:</td>
                <td><asp:TextBox ID="txtTitle" runat="server" width="138px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Category:</td>
                <td>
                    <asp:DropDownList ID="drpCategory" runat="server" width="138px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>User:</td>
                <td>
                    <asp:DropDownList ID="drpUser" runat="server" width="138px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Description:</td>
                <td><asp:TextBox ID="txtDescription" runat="server" width="344px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmitTicket" runat="server" Text="Submit Ticket" Height="26px" Width="114px" OnClick="btnSubmitTicket_Click" />
                    <asp:Label ID="lblStatusSubmit" runat="server"></asp:Label>
                </td>
            </tr>
    </table>
    </div>

</asp:Content>

