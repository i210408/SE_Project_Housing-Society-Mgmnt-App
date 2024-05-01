using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UserInterfaceLayer
{
    public partial class IssueBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DelH_Click(object sender, EventArgs e)
        {
            Response.Redirect("DelHomeowner.aspx");

        }

        protected void IssueB_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("IssueBills.aspx");
        }

        protected void NotifsIn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("NotifsIn.aspx");
        }

        protected void VeiwNotifs_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("VeiwNotifs.aspx");
        }

        protected void ChangePassword_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void CalanadarAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddToCalandar.aspx");
        }

        protected void ViewCommCal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewCommCal.aspx");
        }

        protected void ViewUserData_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewUserData.aspx");
        }
        protected void Bill_Click(object sender, EventArgs e)
        {
            //Check the integer inputs for being integer
            //If any are, alert the warning label
            //Otherwise, send em in, check the db
            int s = 0;
            if(int.TryParse(AmmtBill.Text.ToString(),out s) == true)
            {
                if(int.TryParse(DaysBill.Text.ToString(),out s) == true)
                {
                    string reason = Reason.Text.ToString();
                        decimal v;
                    Decimal.TryParse(AmmtBill.Text.ToString(), out v);
                    Controller.IssueBill(UserBill.Text.ToString(),v, Convert.ToInt32(DaysBill.Text.ToString()), Reason.Text.ToString());
                        Response.Redirect("HomepageA.aspx");
                
            }
                else
                {
                    WarningL.Text = "Write an integer value for the number of days";
                }
            }
            else {
                WarningL.Text = "Write an integer value for the ammount";
            }

        }

        protected void DelH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DelHomeowner.aspx");

        }
    }
}