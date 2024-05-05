using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> feedback = Controller.ViewFeedback();
            if (feedback.Count!=0)
            {
                feedbacktext.Text = "";
                for (int i = 0; i < feedback.Count; i++)
                {
                    feedbacktext.Text = feedbacktext.Text.ToString() + feedback[i] +"<br>";
                }

            }
            else
            {
                feedbacktext.Text = "There is no available feedback to view yet!";
            }
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
    }
}