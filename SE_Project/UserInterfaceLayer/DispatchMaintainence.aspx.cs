using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class DispatchMaintainence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listreq = Controller.GetRequests();

            if (listreq.Count!=0)
            {
                reqs.Text = "";
                for (int i = 0; i < listreq.Count; i++)
                {
                    reqs.Text = reqs.Text.ToString() + listreq[i] + "<br>";
                }

            }
            else
            {
                reqs.Text = "There are no Requests posted yet!";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            var listreq = Controller.GetRequests();
            string prob = listreq[0].Split(':')[2];
            string worker;
            if((prob=="leaky pipes")||(prob=="clogged drain")){
                worker = "plumber";
            }
            else if (prob == "faulty wiring"){
                worker = "electrician";
            }
            else if (prob == "wall painting"){
                worker = "painter";
            }
            else
            {
                worker = "general maintenance";
            }
           if(Controller.AssignWorker(prob, worker) == true)
            {
                Label9.Text = "";
                Label10.Text = " The maintainence worker has been dispatched successfully successfully!";
            }
            else
            {
                Label10.Text = "";
                Label9.Text = "The worker was not dispatched successfully.";
            }
        }
    }
}