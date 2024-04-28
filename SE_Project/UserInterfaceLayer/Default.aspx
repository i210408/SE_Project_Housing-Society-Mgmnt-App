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
    <th>
        <label>Name:</label>
        <input type="text" runat="server" id="NameH"/>
       <label>Password:</label>
        <input type="password" runat="server" id="PasswH"/>
        <asp:Button ID="LoginH" runat="server" Text="Submit" BorderStyle="Solid" ToolTip="Submit" OnClick="LoginH_Click"/> 
    </th>
    <th>&nbsp;</th>
  </tr>
</table>

    </main>

</asp:Content>
