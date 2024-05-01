﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterFacilities.aspx.cs" Inherits="UserInterfaceLayer.RegisterFacilities" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <table  style="background-color:powderblue;margin:0 auto;text-align:center;border:8px double;border-radius:5px;border-color:#fd7702;color:darkblue;font-size:1.25vw">
        <tr>
            <th id="Sidebar" style="color:#F08269;border:8px double #2386C2; border-radius:5px; width: 221px; height: 579px;" >
                <asp:ImageButton ID="ImageButton1" src="PayBillsicon.png" runat="server" OnClick="ImageButton1_Click" />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Pay Bills"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton2" src="ViewNotifsicon.png" runat="server" OnClick="ImageButton2_Click" />
                <br />
                <asp:Label ID="Label3" runat="server" Text="View Notifications"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton3" src="registervisitorsicon.png" runat="server" OnClick="ImageButton3_Click" />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Register Visitors"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton4" src="submitfeedbackicon.png" runat="server" OnClick="ImageButton4_Click" />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Submit Feedback"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton6" src="viewcommcalandarhicon.png" runat="server" OnClick="ImageButton6_Click" />
                <br />
                <asp:Label ID="Label7" runat="server" Text="View Community Calandar"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton8" src="remaintainenceicon.png" runat="server" OnClick="ImageButton8_Click">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Request Maintainence"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton7" src="Registerfacilitiesicon.png" runat="server" />
                <br />
                <asp:Label ID="Label9" runat="server" Text="Register for Facilities"></asp:Label>

            </th>
            <th id="Work" style="border:8px double #CC5500; border-radius:5px; width: 991px; height: 579px;">
                <label style="font-size:3vw;color:#F08269;font-family:Arial, Helvetica, sans-serif"><u>Homeowner Account Homepage</u></label>
                <table style="margin:0 auto;text-align:center;">
                    <tr><th style="font-size:20px"><u> User Data: </u></th></tr>
                    <tr><td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td></tr>
                    <tr><td>Locale: DHA-II</td></tr>
                    <tr><td >Status: Current Homeowner</td></tr>
                </table>
                <table style="margin:0 auto;text-align:center">
                    <tr><th style="font-size:20px"><u> Sidebar Guide: </u></th></tr>
                    <tr><td><label>For futher Questions and Queries, dial 2211</label></td></tr>
                </table>
            </th>
        </tr>
    </table>
    </main>
</asp:Content>
