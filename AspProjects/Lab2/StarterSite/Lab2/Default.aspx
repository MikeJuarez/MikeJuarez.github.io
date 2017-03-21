<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Lab2_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <asp:Label ID="lblCatAdd" runat="server" Font-Overline="False" Font-Size="Large" Text="Add Category:"></asp:Label>
    <asp:TextBox ID="txtAddCat" runat="server" Width="308px"></asp:TextBox>
    <asp:Button ID="btnAddCat" runat="server" Text="Add Category" Height="26px" OnClick="Button1_Click" Width="115px" />
    <asp:Label ID="lblCatStatus" runat="server"></asp:Label>
    <br /><br /><br />
    <asp:Label ID="lblCurrCat" runat="server" Font-Size="Larger" Text="Current Categories:"></asp:Label>

    <br />
    <asp:ListBox ID="lboCategories" runat="server" Height="207px" Width="204px"></asp:ListBox>

</asp:Content>