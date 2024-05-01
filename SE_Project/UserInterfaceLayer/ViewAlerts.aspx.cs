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
    public partial class ViewAlerts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Controller.ViewNotifications() != null)
            {
                var listnotifs = Controller.ViewNotifications();
                for (int i = 0; i < listnotifs.Count; i++)
                {
                    Label3.Text = Label3.Text.ToString() + listnotifs[i].notificationDate + "-" + listnotifs[i].notificationText + "<br>";
                }

            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PayBills.aspx");
        }

    }
}