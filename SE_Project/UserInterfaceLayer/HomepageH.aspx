<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomepageH.aspx.cs" Inherits="UserInterfaceLayer.HomepageH" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <table  style="background-color:powderblue;margin:0 auto;text-align:center;border:8px double;border-radius:5px;border-color:#fd7702;color:darkblue;font-size:1.25vw">
        <tr>
            <th id="Sidebar" style="color:#F08269;border:8px double #2386C2; border-radius:5px; width: 221px;" >
                <label>Sidebar</label>

            </th>
            <th id="Work" style="border:8px double; border-radius:5px; width: 991px;border-color:#CC5500">
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
