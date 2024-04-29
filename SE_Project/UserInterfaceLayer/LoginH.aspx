<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginH.aspx.cs" Inherits="UserInterfaceLayer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
  <tr>
      <div class="col">
    <th style="text-align:left; height: 368px; width: 408px;">
        <label style="font-size:3vw">Login Here:</label>
        <br />
        <br />
        <label>Name:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
        <asp:TextBox ID="NameH" runat="server"></asp:TextBox>
        <br />
       <label>Password:</label> 
        <asp:TextBox ID="PasswH" runat="server"></asp:TextBox>
        <br />
        <asp:CheckBox ID="Homeowner" runat="server" />
        <asp:Label ID="Homeownerlabel" runat="server" Text="Login as Homeowner"></asp:Label>
        <br />
        <asp:CheckBox ID="Admin" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Login as Admin"></asp:Label>
        <br />
&nbsp;<asp:Button ID="LoginH" runat="server" Text="Login" BorderStyle="Solid" ToolTip="Submit" OnClick="LoginH_Click"/> 
    </div>
        <br />
        <asp:Label ID="WarningLabel" runat="server" ForeColor="Red"></asp:Label>
    </th>
      <th style="width: 325px">
          </br>
      </th>
    <th style="text-align:right; height: 368px;">
                <label style="font-size:3vw">Register Here:</label>

        <div class="col">
        <label>Name:</label>&nbsp;
            <asp:TextBox ID="NameHS" runat="server"></asp:TextBox>
            <br />
       <label>Password:</label>
            <asp:TextBox ID="PasswHS" runat="server"></asp:TextBox>
            <br />
&nbsp;Email:
            <asp:TextBox ID="EmailHS" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="Homeowner0" runat="server" />
            <asp:Label ID="Homeownerlabel0" runat="server" Text="Sign Up as Homeowner"></asp:Label>
            <br />
            <asp:CheckBox ID="Admin0" runat="server" />
            <asp:Label ID="Label2" runat="server" Text="Sign Up as Admin"></asp:Label>
            <br />
        <asp:Button ID="SignUpH" runat="server" Text="Sign In" BorderStyle="Solid" ToolTip="Submit" OnClick="SignUpH_Click"/> 
            <br />
            <asp:Label ID="WarningLabel2" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </th>
  </tr>
</table>

    </main>

</asp:Content>
