﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ViewAlerts.aspx.cs" Inherits="UserInterfaceLayer.ViewAlerts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <table  style="background-color:#95d5d7;margin:0 auto;text-align:center;border:8px double;border-radius:5px;border-color:midnightblue;color:darkblue;font-size:1.25vw">
        <tr>
            <th id="Sidebar" style="border:8px double #2386C2; border-radius:5px; width: 221px; height: 546px;" >
      <asp:ImageButton ID="ImageButton1" src="PayBillsicon.png" runat="server" OnClick="ImageButton1_Click" />
  <br />
  <asp:Label ID="Label2" runat="server" Text="Pay Bills"></asp:Label>
  <br />
  <br />
  <asp:ImageButton ID="ImageButton2" src="ViewNotifsicon.png" runat="server" />
  <br />
  <asp:Label ID="Label1" runat="server" Text="View Notifications"></asp:Label>
  <br />
  <br />
  <asp:ImageButton ID="ImageButton3" runat="server" />
  <br />
  <asp:Label ID="Label4" runat="server" Text="Register Visitors"></asp:Label>
  <br />
  <br />
  <asp:ImageButton ID="ImageButton4" runat="server" />
  <br />
  <asp:Label ID="Label5" runat="server" Text="Submit Feedback"></asp:Label>
  <br />
  <br />
  <asp:ImageButton ID="ImageButton5" runat="server" />
  <br />
  <asp:Label ID="Label6" runat="server" Text="Lodge Complaints"></asp:Label>
  <br />
  <br />
  <asp:ImageButton ID="ImageButton6" runat="server" />
  <br />
  <asp:Label ID="Label7" runat="server" Text="View Community Calandar"></asp:Label>
  <br />
  <br />
  <asp:ImageMap ID="ImageMap1" runat="server">
  </asp:ImageMap>
  <br />
  <asp:Label ID="Label8" runat="server" Text="Request Maintainence"></asp:Label>
  <br />
  <br />
  <asp:ImageButton ID="ImageButton7" runat="server" />
  <br />
  <asp:Label ID="Label9" runat="server" Text="Register for Facilities"></asp:Label>

</th>
            <th id="Work" style="border:8px double midnightblue; border-radius:5px; width: 991px; height: 546px;">
                <label style="font-size:3vw;color:#F08269;font-family:Arial, Helvetica, sans-serif"><u>Local Alerts Page:</u></label>
                <br />
                 <br />
                <asp:Label ID="Label3" runat="server" style="font-size:20px"></asp:Label>
               
                
            &nbsp;</th>
        </tr>
    </table>
    </main>
</asp:Content>