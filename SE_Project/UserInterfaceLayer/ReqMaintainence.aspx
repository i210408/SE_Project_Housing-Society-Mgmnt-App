<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReqMaintainence.aspx.cs" Inherits="UserInterfaceLayer.ReqMaintainence" %>

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

    <br />
    <br />
    <asp:ImageButton ID="ImageButton9" runat="server" OnClick="ImageButton9_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Reservations"></asp:Label>

</th>
            <th id="Work" style="border:8px double #CC5500; border-radius:5px; width: 991px; height: 579px;vertical-align:top">
                <label style="font-size:3vw;color:#F08269;font-family:Arial, Helvetica, sans-serif"><u>Request Maintainence Worker: </u></label>
                <br />
                <br />
                
                <br />
                <asp:Label ID="Label10" runat="server" Text="Problem: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Request Maintainence" />
                <br />
                <br />
                
                <asp:Label ID="Label11" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label12" runat="server" ForeColor="Green"></asp:Label>
                
                </th>
        </tr>
    </table>
    </main>
</asp:Content>
