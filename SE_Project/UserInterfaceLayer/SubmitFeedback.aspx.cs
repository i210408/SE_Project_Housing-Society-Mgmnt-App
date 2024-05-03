using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class SubmitFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fdback_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            int rating;
            if ((string.IsNullOrWhiteSpace(TextBox1.Text) == true) || (string.IsNullOrWhiteSpace(TextBox2.Text) == true) || (string.IsNullOrWhiteSpace(TextBox3.Text) == true))
            {
                    Label13.Text = "";
                    warninglabel.Text = "Please fill in all available text boxes";
            }
            else
            if (int.TryParse(TextBox3.Text, out rating) == true)
            {
                if (rating > 0 && rating < 6)
                {
                    cntrllr.InsertFeedback(TextBox1.Text.ToString(), TextBox2.Text.ToString(), rating);
                    Label13.Text = "Feedback submission successful!";
                    warninglabel.Text = "";
                }
            }
            else
            {
                Label13.Text = "";
                warninglabel.Text = "Please enter a number between 1 and 5 for Rating";
            }
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
    }
}