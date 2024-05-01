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
            var listofbills=cntrllr.ViewBills();
            if(listofbills.Count != 0)
            {
                for (int i = 0; i < listofbills.Count; i++)
                {
                    ListOfBills.Text = ListOfBills.Text.ToString() + "ID: " + listofbills[i].ToString() + "<br>";
                }
            }
        }

        protected void PayEmAll_Click(object sender, EventArgs e)
        {
            var cntrllr = (Controller)Session["Controller"];
            cntrllr.PayBills();
        }
    }
}