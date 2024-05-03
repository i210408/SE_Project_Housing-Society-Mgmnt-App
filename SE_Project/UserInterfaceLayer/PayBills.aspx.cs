using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class PayBills : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListOfBills.Text = "";
            var cntrllr = (Controller)Session["Controller"];
            List<string> listofbills= cntrllr.ViewBills();
            if(listofbills.Count != 0)
            {
                ListOfBills.Text = "";
                for (int i = 0; i < listofbills.Count; i++)
                {
                    ListOfBills.Text = ListOfBills.Text.ToString() + "ID: " + listofbills[i].ToString() + "<br>";
                }
            }
            else
            {
                ListOfBills.Text = "No bills are listed yet!";
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

        protected void PayEmAll_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            if (cntrllr.PayBills() == false)
            {
                Label10.Text = "All bills have already been paid!";
            }
            else
            {
                Label11.Text = "Bills successfully paid!";
            }
        }
    }
}