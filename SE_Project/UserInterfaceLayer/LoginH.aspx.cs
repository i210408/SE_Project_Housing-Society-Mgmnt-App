using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Newtonsoft.Json.Linq;

namespace UserInterfaceLayer
{

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginH_Click(object sender, EventArgs e)
        {
            var controller1 = new Controller();
            string Name = NameH.Text.ToString();
                string Pass = PasswH.Text.ToString();
                if (controller1.Login(Name, Pass) == true)
                {
                this.Session["Username"] = NameH.Text.ToString();
                this.Session["Password"]= PasswH.Text.ToString();
                this.Session["Controller"] = controller1;
                if (Homeowner.Checked == true)
                {
                    Response.Redirect("HomepageA.aspx");
                }
                else if (Admin.Checked == true)
                {
                    Response.Redirect("HomepageA.aspx");
                }
                else
                {
                    WarningLabel.Text = "Choose Admin or Homeowner";
                }
                }
                else
                {
                WarningLabel.Text = "Username/Password Invalid.";
                }
            
        }

        protected void SignUpH_Click(object sender, EventArgs e)
        {
            var controller1 = new Controller();
            string Name = NameHS.Text.ToString();
            string Pass = PasswHS.Text.ToString();
            string Email = EmailHS.Text.ToString();
            Session[0] = NameHS.Text.ToString();
            Session[1] = EmailHS.Text.ToString();
            Session[2] = controller1;
            //Now go to About as the Homepage
            //Needs to be changed as per new signup

        }

    }
}