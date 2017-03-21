<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
     <link href="StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table>
  <tr>    
    <th>
        Name:<br />
        <asp:TextBox ID="txtName" runat="server" Width="180px" CssClass="tb_with_border"></asp:TextBox>
        <br />
        <asp:Label ID="lblName" runat="server" CssClass="err" ForeColor="Red"></asp:Label>
        <p />
        Event Date:<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <asp:Label ID="lblCalendar" runat="server" CssClass="err" ForeColor="Red"></asp:Label>
        <p />
        Dietary Requirements:<br />
        <asp:RadioButtonList ID="rdoDietary" runat="server"></asp:RadioButtonList>
        <br />
        <asp:Button ID="btnRegistration" runat="server" Text="Add Registration" Width="138px" OnClick="btnRegistration_Click" />           
    </th>

    <th>
        Registrations:<br />
        <asp:ListBox ID="lboRegistrations" runat="server" Height="115px" Width="330px" OnSelectedIndexChanged="lboRegistrations_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox><br />
        <asp:Button ID="btnCancelReg" runat="server" Text="Cancel Registration" OnClick="Button1_Click" Width="154px" Enabled="False" />
    </th>
    <th>
        Canceled Registrations:<br />
        <asp:ListBox ID="lboCancRegistrations" runat="server" Height="115px" Width="330px" AutoPostBack="True"></asp:ListBox>
    </th>
  </tr>
</table>   
</asp:Content>