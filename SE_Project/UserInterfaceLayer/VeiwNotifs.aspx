﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VeiwNotifs.aspx.cs" Inherits="UserInterfaceLayer.VeiwNotifs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <table  style="background-color:#95d5d7;margin:0 auto;text-align:center;border:8px double;border-radius:5px;border-color:midnightblue;color:darkblue;font-size:1.25vw">
        <tr>
            <th id="Sidebar" style="border:8px double #2386C2; border-radius:5px; width: 221px; height: 546px;" >
                <asp:ImageButton ID="DelH" src="DelHomeownerIcon.png" runat="server" OnClick="DelH_Click"/>
                <br />
                <label>Delete Homeowner<br />
                </label>&nbsp;<br />
                <asp:ImageButton ID="IssueBillsButton" src="IssueBillsIcon.png" runat="server" OnClick="IssueB_Click"/>

                <br />
                <asp:Label ID="Label1" runat="server" Text="Issue Bills"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="NotifsInButton" src="InputNotifsIcon.png" runat="server" OnClick="NotifsIn_Click" />

                <br />
                <asp:Label ID="Label2" runat="server" Text="Broadcast Notifications"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="VeiwNotifsButton" src="VeiwNotifsIcon.png" runat="server" OnClick="VeiwNotifs_Click" />

            </th>
            <th id="Work" style="border:8px double midnightblue; border-radius:5px; width: 991px; height: 546px;">
                <label style="font-size:2.5vw;color:midnightblue;font-family:Arial, Helvetica, sans-serif"><u>Notification Page:</u><br /> </label>
                <br />
                 <br />
                <asp:Label ID="Label3" runat="server" style="font-size:20px"></asp:Label>
               
                
            &nbsp;</th>
        </tr>
    </table>
    </main>
</asp:Content>

