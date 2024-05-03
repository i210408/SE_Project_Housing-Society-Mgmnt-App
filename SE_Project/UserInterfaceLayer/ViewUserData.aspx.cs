using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class ViewUserData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Controller.GetAllResidentData() != null)
            {
                var listresidents = Controller.GetAllResidentData();
                for (int i = 0; i < listresidents.Count; i++)
                {
                    Userdata.Text = Userdata.Text.ToString() +"ID: " + listresidents[i].userId.ToString() + "  Name: " +listresidents[i].username.ToString() + "  Email: " +listresidents[i].email.ToString() + "<br>";
                }

            }
            else
            {
                Userdata.Text = "There is no available Home Owner account data yet!";
            }
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

    }
}