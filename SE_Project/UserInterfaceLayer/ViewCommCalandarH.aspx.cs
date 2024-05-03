using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class ViewCommCalandarH : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listcalan = Controller.ViewCommunityCalendar();

            if (listcalan.Count!= 0)
            {
                Calandarcontents.Text = "";
                for (int i = 0; i < listcalan.Count; i++)
                {
                    Calandarcontents.Text = Calandarcontents.Text.ToString() + listcalan[i].Item3 + " - " + listcalan[i].Item1 + " : " + listcalan[i].Item2 + "<br>";
                }

            }
            else
            {
                Calandarcontents.Text = "There are no events listed for this month!";
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