<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserInterfaceLayer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <table>
  <tr>
      <div class="col">
    <th style="text-align:left; height: 368px; width: 313px;">
        <label style="font-size:3vw">Login Here:</label>
        <br />
        <br />
        <label>Name:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
        <asp:TextBox ID="NameH" runat="server"></asp:TextBox>
        <br />
       <label>Password:</label> 
        <asp:TextBox ID="PasswH" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:Button ID="LoginH" runat="server" Text="Login" BorderStyle="Solid" ToolTip="Submit" OnClick="LoginH_Click"/> 
    </div>
    </th>
      <th style="width: 474px">
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
        <asp:Button ID="SignUpH" runat="server" Text="Sign In" BorderStyle="Solid" ToolTip="Submit" OnClick="SignUpH_Click"/> 
    </div>
    </th>
  </tr>
</table>

    </main>

</asp:Content>
