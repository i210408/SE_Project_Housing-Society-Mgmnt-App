using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Reflection.Emit;

namespace UserInterfaceLayer
{
    public partial class DelHomeowner : System.Web.UI.Page
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

        protected void Delete_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if (string.IsNullOrWhiteSpace(UserDel.Text) == false)
            {
                if (cntrllr.validateUser(UserDel.Text)==true) {
                    var controller = (Controller)Session["Controller"];
                    controller.DeleteHomeowner(UserDel.Text.ToString());
                    Label9.Text = "User Successfully Deleted!";
                    Label8.Text = "";
                }
                else
                {
                    Label9.Text = "";
                    Label8.Text = "Please input a valid Username";
                }
            }
            else
            {
                Label9.Text= "";
                Label8.Text = "Please fill in all available text boxes";
             }
            
        }
    }
    
}