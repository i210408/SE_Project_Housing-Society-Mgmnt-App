using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class ChangePassword : System.Web.UI.Page
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if ((string.IsNullOrWhiteSpace(OldPassw.Text) == true) || (string.IsNullOrWhiteSpace(NewPassw.Text) == true))
            {
                errorlabel.Text = "Please fill all of the available textboxes.";
            }
            else
            
            {
                if (cntrllr.ChangePassword(OldPassw.Text, NewPassw.Text) == false)
                {
                    errorlabel.Text = "The old password was entered incorrectly. Please try again.";
                }
                else
                {
                    Label9.Text = "Your Password was changed successfully!";
                }
            }
        }
    }
}