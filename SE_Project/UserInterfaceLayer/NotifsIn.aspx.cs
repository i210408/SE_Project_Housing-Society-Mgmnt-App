﻿using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterfaceLayer
{
    public partial class NotifsIn : System.Web.UI.Page
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

        protected void Bcast_Click(object sender, EventArgs e)
        {
            var controller = (Controller)Session["Controller"];
            controller.BroadcastNotifications(NotifsInput.Text.ToString());
            Response.Redirect("HomepageA.aspx");
        }
    }
}