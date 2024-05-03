﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Microsoft.Ajax.Utilities;

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

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegisterVisitors.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SubmitFeedback.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewCommCalandarH.aspx");
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ReqMaintainence.aspx");
        }

        protected void RegVisitor_Click(object sender, EventArgs e)
        {
            string text = TextBox1.Text;
            var cntrllr = (Controller)Session["Controller"];
            if (string.IsNullOrWhiteSpace(TextBox1.Text)==false)
            {
                if (cntrllr.RegisterVisitor(TextBox1.Text.ToString()) == true)
                {
                    Label12.Text = "Register was successful!";
                    Label11.Text = "";
                }
                else
                {
                    Label12.Text = "";
                    Label11.Text = "Register was not successful.";
                }
            }
            else
            {
                Label12.Text = "";
                Label11.Text = "Please fill in all available text boxes.";
            }

        }
    }
}