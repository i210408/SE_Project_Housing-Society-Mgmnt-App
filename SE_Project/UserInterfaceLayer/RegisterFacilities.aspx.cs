using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class RegisterFacilities : Page
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
            if (CheckBox1.Checked==true)
            {
                cntrllr.RegisterService("Swimming Pool", "A swimming that is open to members 9-5", 250);
                Label11.Text = "Registration successful!";
            }
            else if (CheckBox2.Checked == true)
            {
                cntrllr.RegisterService("Tennis COurts", "A swimming that is open to members 1-10pm", 200);
                Label11.Text = "Registration successful!";
            }
            else if (CheckBox3.Checked == true)
            {
                cntrllr.RegisterService("Gym", "A gender degregated gym open to members 10am-10pm", 400);
                Label11.Text = "Registration successful!";
            }
            else if (CheckBox4.Checked == true)
            {
                cntrllr.RegisterService("Library", "A swimming that is open to members 24/7", 300);
                Label11.Text = "Registration successful!";
            }
            else
            {
                warning.Text = "Please select a Facility from the checkboxes above"; 
             }
        }
    }
}