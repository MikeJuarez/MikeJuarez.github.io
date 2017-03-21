<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Lab2_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <div>    
    <table border="0">
            <tr>
                <td>Add Users:</td>
                <td></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="txtFName" runat="server" width="138px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Last Name:</td>                
                <td><asp:TextBox ID="txtLName" runat="server" width="138px"></asp:TextBox></td>                
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:TextBox ID="txtEmail" runat="server" width="138px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAddUser" runat="server" Text="Add User" Height="26px" Width="114px" OnClick="btnAddUser_Click" />
                    <asp:Label ID="lblStatusAddUser" runat="server"></asp:Label>
                </td>
            </tr>
    </table>
    </div>

    <p/>
    
    <table id="table2" border="1" runat="server"></table>
    
</asp:Content>

