<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddToCalandar.aspx.cs" Inherits="UserInterfaceLayer.AddToCalandar" %>
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

    <br />
    <asp:Label ID="Label3" runat="server" Text="Veiw Notifications"></asp:Label>

    <br />
    <br />
    <asp:ImageButton ID="ChangePassw" src="ChangePasswordIcon.png" runat="server" OnClick="ChangePassword_Click"/>
    <br />
    <label>Change Password</label><br />
    <br />
    <asp:ImageButton ID="CalanadarAdd" src="InsertToCalanderIcon.png" runat="server" OnClick="CalanadarAdd_Click" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Add To Community Calander"></asp:Label>
    <br />
    <br />
    <asp:ImageButton ID="ViewCommCal" src="ViewCommCalIcon.png" runat="server" OnClick="ViewCommCal_Click" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="View Community Calandar"></asp:Label>
    <br />
    <br />
    <asp:ImageButton ID="ViewUserData" src="VeiwUserDataIcon.png" runat="server" OnClick="ViewUserData_Click" />
    <br />
    <asp:Label ID="Label6" runat="server" Text="View All User Data"></asp:Label>
    <br />
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" src="VeiwFeedbackicon.png" OnClick="ImageButton1_Click" />
    <br />
    <asp:Label ID="Label12" runat="server" Text="View Feedback"></asp:Label>
    <br />
    <br />
    <asp:ImageButton ID="ImageButton2" runat="server" src="dispatchworkersicon.png" OnClick="ImageButton2_Click" />
    <br />
    <asp:Label ID="Label13" runat="server" Text="Dispatch Maintainenece Workers"></asp:Label>
    <br />
    <br />
    <asp:ImageButton ID="ImageButton3" src="createpollicon.png" runat="server" OnClick="ImageButton3_Click" />
    <br />
    <asp:Label ID="Label14" runat="server" Text="Create Poll"></asp:Label>
    <br />
</th>
            <th id="Work" style="border:8px double midnightblue; border-radius:5px; width: 991px; height: 546px;vertical-align:top">
                <label style="font-size:3vw;color:midnightblue;font-family:Arial, Helvetica, sans-serif"><u>Add to Calander</u></label>
                <br />
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Event Title: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Event Description: "></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Days Till Event: "></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="AddEvent" runat="server" OnClick="AddEvent_Click" Text="Add Event" />
                <br />
                <br />
                <br />
                <asp:Label ID="Label10" runat="server" Style="color:red"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label11" runat="server" ForeColor="Green"></asp:Label>
            </th>
        </tr>
    </table>
    </main>
</asp:Content>

