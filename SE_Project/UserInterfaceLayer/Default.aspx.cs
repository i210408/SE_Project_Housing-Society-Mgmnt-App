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
                    Response.Redirect("About.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            
        }

        protected void SignUpH_Click(object sender, EventArgs e)
        {
            var controller1 = new Controller();
            string Name = NameHS.Text.ToString();
            string Pass = PasswHS.Text.ToString();
            string Email = EmailHS.Text.ToString();
            controller1.SignUp(Name,Pass, Email, "homeowner");

        }

    }
}