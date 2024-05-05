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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DispatchMaintainence.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Createpoll.aspx");
        }
        protected void Bill_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(UserBill.Text) == false) && (string.IsNullOrWhiteSpace(AmmtBill.Text) == false) && (string.IsNullOrWhiteSpace(DaysBill.Text) == false) && (string.IsNullOrWhiteSpace(Reason.Text) == false))
            {
                int s = 0;
                if (int.TryParse(AmmtBill.Text.ToString(), out s) == true)
                {
                    if (int.TryParse(DaysBill.Text.ToString(), out s) == true)
                    {
                        var cntrllr = (Controller)Session["Controller"];
                        if (cntrllr.validateUser(UserBill.Text))
                        {
                            string reason = Reason.Text.ToString();
                            decimal v;
                            Decimal.TryParse(AmmtBill.Text.ToString(), out v);
                            Controller.IssueBill(UserBill.Text.ToString(), v, Convert.ToInt32(DaysBill.Text.ToString()), Reason.Text.ToString());
                            Label11.Text = "Bill successfully issued!";
                        }
                        else
                        {
                            Label11.Text = "";
                            WarningL.Text = "Please enter a valid username.";
                        }

                    }
                    else
                    {
                        Label11.Text = "";
                        WarningL.Text = "Write an integer value for the number of days till the bill is due.";
                    }
                }
                else
                {
                    Label11.Text = "";
                    WarningL.Text = "Write an integer value for the ammount.";
                }
            }
            else
            {
                Label11.Text = "";
                WarningL.Text = "Please fill all available textboxes.";
            }

        }

        protected void DelH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DelHomeowner.aspx");

        }
    }
}