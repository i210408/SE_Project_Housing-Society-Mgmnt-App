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
                for (int i = 0; i < listcalan.Count; i++)
                {
                    Calandarcontents.Text = Calandarcontents.Text.ToString() + listcalan[i].Item3 + " - " + listcalan[i].Item1 + " : " + listcalan[i].Item2 + "<br>";
                }

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
    }
}