using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crm
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((string)Session["uname"] == null)
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {

                LinkButton7.Text = "Привет, " + (string)Session["uname"];
            }

        }



        protected void btGraphik_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schedule.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("employee.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Otchet.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Role.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleType.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkStatus.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleRed.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Permission.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("vhod.aspx");
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Webform5.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebForm4.aspx");
        }
    }
}