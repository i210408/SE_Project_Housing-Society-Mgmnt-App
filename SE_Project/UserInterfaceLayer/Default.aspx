<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserInterfaceLayer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" runat="server" href="~/">Housing Society Application</a>
                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                </div>
        </nav>
    <main>
        <table>
  <tr>
      <div class="col">
    <th style="text-align:left; height: 368px; width: 313px;">
        <label>Name:</label>&nbsp;
        <asp:TextBox ID="NameH" runat="server"></asp:TextBox>
       <label>Password:</label> 
        <asp:TextBox ID="PasswH" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="LoginH" runat="server" Text="Login" BorderStyle="Solid" ToolTip="Submit" OnClick="LoginH_Click"/> 
    </div>
    </th>
      <th style="width: 474px">
          </br>
      </th>
    <th style="text-align:right; height: 368px;">
        <div class="col">
        <label>Name:</label>&nbsp;
            <asp:TextBox ID="NameHS" runat="server"></asp:TextBox>
       <label>Password:</label>
            <asp:TextBox ID="PasswHS" runat="server"></asp:TextBox>
&nbsp;Email:
            <asp:TextBox ID="EmailHS" runat="server"></asp:TextBox>
        <asp:Button ID="SignUpH" runat="server" Text="Sign In" BorderStyle="Solid" ToolTip="Submit" OnClick="SignUpH_Click"/> 
    </div>
    </th>
  </tr>
</table>

    </main>

</asp:Content>
