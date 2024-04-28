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
            string Name = NameH.Value.ToString();
                string Pass = PasswH.Value.ToString();
                if (controller1.Login(Name, Pass) == true)
                {
                    Response.Redirect("About.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            
        }
    }
}