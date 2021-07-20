using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace crm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkConnection();
        }

        public static bool checkConnection()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex) { return false; }
            finally
            {
                conn.Close();
            }
        }

        protected void btEnter_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.dbEnter(tbLogin.Text, tbPassword.Text);

            switch (DBConnection.ID_employee)
            {
                case (0):
                    tbLogin.BackColor = System.Drawing.Color.Red;
                    tbPassword.BackColor = System.Drawing.Color.Red;

                    lblTitle.Text = "Введён не верный логин или пароль!";
                    tbPassword.Text = "";
                    tbLogin.Text = "";
                    break;
                default:
                    Table_Class table_Class = new Table_Class(DBConnection.qremployee + string.Format("Where [login_employee] = '{0}' and [password_employee] = '{1}'", tbLogin.Text, tbPassword.Text));
                    DBConnection.Role = table_Class.table.Rows[0][7].ToString();
                    var s = DBConnection.Role;
                    Session["uname"] = tbLogin.Text;
                    Response.Redirect("MainMenu.aspx");
                    break;
            }
        }
    }
}