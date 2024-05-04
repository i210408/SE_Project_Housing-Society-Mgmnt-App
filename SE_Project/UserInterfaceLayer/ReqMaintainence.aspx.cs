using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UserInterfaceLayer
{
    public partial class ReqMaintainence : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PayBills.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewAlerts.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegisterVisitors.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SubmitFeedback.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewCommCalandarH.aspx");
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ReqMaintainence.aspx");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegisterFacilities.aspx");
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Reservation.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if (string.IsNullOrWhiteSpace(TextBox1.Text) == false)
            {
                if (cntrllr.ReqMaintainence(TextBox1.Text) == true)
                {
                    Label11.Text = "Request Submission was not successful.";
                }
                else
                {
                    Label12.Text = "Request Submission was successful!";
                }
            }
            else
            {
                Label11.Text = "";
                Label12.Text = "Please fill in all available text boxes.";
            }
        }
    }
}