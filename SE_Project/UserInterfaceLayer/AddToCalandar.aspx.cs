using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class AddToCalandar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DelH_Click(object sender, EventArgs e)
        {
            Response.Redirect("DelHomeowner.aspx");

        }

        protected void IssueB_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("IssueBills.aspx");
        }

        protected void NotifsIn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("NotifsIn.aspx");
        }

        protected void VeiwNotifs_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("VeiwNotifs.aspx");
        }

        protected void ChangePassword_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void CalanadarAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddToCalandar.aspx");
        }

        protected void ViewCommCal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewCommCal.aspx");
        }

        protected void ViewUserData_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewUserData.aspx");
        }

        protected void AddEvent_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if(cntrllr.AddEventToCalender(TextBox1.Text, TextBox2.Text, (DateTime.Now).AddDays(Int32.Parse(TextBox3.Text))) == false)
            {
                Label10.Text = "There is already an event on " + DateTime.Now.AddDays(Int32.Parse(TextBox3.Text));
            }
            else
            {
                Response.Redirect("HomepageA.aspx");
            }
        }
    }
}