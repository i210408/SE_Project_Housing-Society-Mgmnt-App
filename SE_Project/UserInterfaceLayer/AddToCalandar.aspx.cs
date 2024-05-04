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

        protected void DelH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DelHomeowner.aspx");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DispatchMaintainence.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Createpoll.aspx");
        }

        protected void AddEvent_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if ((string.IsNullOrWhiteSpace(TextBox1.Text) == true) || (string.IsNullOrWhiteSpace(TextBox2.Text) == true) || (string.IsNullOrWhiteSpace(TextBox3.Text) == true))
            {
                Label11.Text = "";
                Label10.Text = "Please fill all available textboxes.";
            }
            else
            
            {
                int s;
                if (int.TryParse(TextBox3.Text, out s))
                {
                    if (cntrllr.AddEventToCalender(TextBox1.Text, TextBox2.Text, (DateTime.Now).AddDays(s)) == false)
                    {
                        Label11.Text = "";
                        Label10.Text = "There is already an event on " + DateTime.Now.AddDays(Int32.Parse(TextBox3.Text));
                    }
                    else
                    {
                        Label10.Text = "";
                        Label11.Text = "Event successfully added!";
                    }
                }
                else
                {
                    Label11.Text = "";
                    Label10.Text = "Please put an integer number in the Days Till Event textbox.";
                }
            }
        }
        }
}