using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class Reservation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = Session["Username"].ToString();
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
        protected void AddEvent_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if ((string.IsNullOrWhiteSpace(TextBox1.Text) == true) || (string.IsNullOrWhiteSpace(TextBox2.Text) == true) || (string.IsNullOrWhiteSpace(TextBox3.Text) == true))
            {
                Label11.Text = "";
                Label12.Text = "Please fill all available textboxes.";
            }
            else

            {
                int s;
                if (int.TryParse(TextBox3.Text, out s))
                {
                    if (cntrllr.AddEventToCalender("(Reservation)" + TextBox1.Text, TextBox2.Text, (DateTime.Now).AddDays(s)) == false)
                    {
                        Label12.Text = "";
                        Label11.Text = "There is already an event on " + DateTime.Now.AddDays(Int32.Parse(TextBox3.Text));
                    }
                    else
                    {
                        Label11.Text = "";
                        Label12.Text = "Reservation successfully added!";
                    }
                }
                else
                {
                    Label12.Text = "";
                    Label11.Text = "Please put an integer number in the Days Till Event textbox.";
                }
            }
        }
    }
}