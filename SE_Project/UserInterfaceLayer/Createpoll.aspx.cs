using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class Createpoll : System.Web.UI.Page
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

        protected void DelH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DelHomeowner.aspx");

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(TextBox1.Text) == true) || ((string.IsNullOrWhiteSpace(TextBox1.Text) == true)) || ((string.IsNullOrWhiteSpace(TextBox1.Text) == true)) || ((string.IsNullOrWhiteSpace(TextBox1.Text) == true)) || ((string.IsNullOrWhiteSpace(TextBox1.Text) == true)))
            {
                Label14.Text = "Please fill all of the provided text boxes.";
                Label15.Text = "";
            }
            else
            {
                int s;
                if (Int32.TryParse(TextBox2.Text, out s) == true)
                {
                    string[] options = { TextBox5.Text, TextBox4.Text, TextBox3.Text };
                    Controller.CreatePoll(TextBox1.Text, (DateTime.Now), (DateTime.Now).AddDays(Int32.Parse(TextBox2.Text)), options);
                    Label15.Text = "Poll create successfully!";
                    Label14.Text = "";
                }
                else
                {
                    Label14.Text = "Please fill the Days Textbox with an integer number.";
                    Label15.Text = "";
                }
                }
        }
    }
}