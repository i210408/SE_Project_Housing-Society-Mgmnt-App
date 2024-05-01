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
            if (int.TryParse(TextBox3.Text, out rating) == true)
            {
                if (rating > 0 && rating < 6) {
                cntrllr.InsertFeedback(TextBox1.Text.ToString(), TextBox2.Text.ToString(), rating);
            }
        }
            else
            {
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
    }
}