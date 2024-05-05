<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomepageH.aspx.cs" Inherits="UserInterfaceLayer.HomepageH" %>

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
                <asp:ImageButton ID="ImageButton7" src="Registerfacilitiesicon.png" runat="server" OnClick="ImageButton7_Click" />
                <br />
                <asp:Label ID="Label9" runat="server" Text="Register for Facilities"></asp:Label>

            </th>
            <th id="Work" style="border:8px double #CC5500; border-radius:5px; width: 991px; height: 579px;vertical-align:top">
                <label style="font-size:3vw;color:#F08269;font-family:Arial, Helvetica, sans-serif"><u>Homeowner Account Homepage</u></label>
                <table style="margin:0 auto;text-align:center;">
                    <tr><th style="font-size:20px"><u> User Data: </u></th></tr>
                    <tr><td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td></tr>
                    <tr><td>Locale: DHA-II</td></tr>
                    <tr><td >Status: Current Homeowner</td></tr>
                    <tr><td> </td></tr>
                </table>
                <table style="margin:0 auto;text-align:center">
                    <tr style="font-size:25px"><th ><u> Sidebar Guide: </u></th></tr>
                    
                    <tr><td><label>Pay Bills: Pay Utility of Affiliate Company Bills and Fees online</label></td></tr>
                    <tr><td><label>View Notifications: To view immediate danger notifications, advertisements or outage warnings sent by Admin</label></td></tr>
                    <tr><td><label>Register Visitors: To register the names of visitors a resident has allowed into the society</label></td></tr>
                    <tr><td><label>Submit Feedback: Submit Complaints or Feedback about facilities, mantainence, and the society overall for the Admin users to be aware of</label></td></tr>
                    <tr><td><label>View Community Calendar: To see upcoming events and their date in the community</label></td></tr>
                    <tr><td><label>Request Maintenaince: Request for a maintenance worker to be sent to your home to fix any conceivable home problem</label></td></tr>
                    <tr><td><label>Register for Facilities: An online, hassle-free method for a Homeowner to sign up for facilities offered by the housing society</label></td></tr>
                    <tr><td><label>For futher Questions and Queries, dial 2211</label></td></tr>
                </table>
            </th>
        </tr>
    </table>
    </main>
</asp:Content>
