using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UserInterfaceLayer
{
    public partial class RegisterVisitors : Page
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

        protected void RegVisitor_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            cntrllr.RegisterVisitor(TextBox1.Text.ToString());
        }
    }
}