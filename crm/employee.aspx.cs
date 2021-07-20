using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crm
{
    public partial class employee : System.Web.UI.Page
    {
        private string QR = DBConnection.qremployee;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DBConnection.Role != "Администратор")
            {
                Response.Redirect("MainMenu.aspx");
            }
            if (((string)Session["uname"] == null))
            {
                Response.Redirect("Authorization.aspx");
            }
            else
            {
                QR = DBConnection.qremployee;
                if (!IsPostBack)
                {
                    gvFill(QR);
                    FillDropLists1();
                    FillDropLists2();
                    lbFill();

                }

            }
        }

        private void gvFill(string qr)
        {


            sdsEmployee.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsEmployee.SelectCommand = qr;
            sdsEmployee.DataSourceMode = SqlDataSourceMode.DataReader;
            gvAddUser.DataSource = sdsEmployee;
            gvAddUser.DataBind();

        }
        // заполнение выпадающего списка

        public void FillDropLists1()
        {
            sds1.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sds1.DataSourceMode = SqlDataSourceMode.DataReader;


        }

        public void FillDropLists2()
        {
            //sdsProle.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            //sdsProle.DataSourceMode = SqlDataSourceMode.DataReader;


        }




        protected void btInsert_Click(object sender, EventArgs e)
        {
            Procedure_Class procedure = new Procedure_Class();
            ArrayList array = new ArrayList();
            array.Add(tbName.Text);
            array.Add(tbSurname.Text);
            array.Add(tbBirthday.Text);
            array.Add(tbLogin.Text);
            array.Add(tbPassword.Text);
            array.Add(tbStatus.Text);
            array.Add(lstRole.SelectedIndex + 1);
            procedure.procedure_Execution("employee_insert", array);
            gvFill(QR);
        }

        private void lbFill()
        {
            //Table_Class table_Class = new Table_Class("SELECT [id_possition], [name_possition] FROM [CRMBase].[dbo].[possition_employee]");
            //lstRole.DataSource = table_Class.table.DefaultView;
            //lstRole.DataValueField = "id_possition";
            //lstRole.DataTextField = "name_possition";
            //lstRole.DataBind();
        }

        protected void gvAddUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
        }

        protected void gvAddUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Имя"):
                    e.SortExpression = "[Name_employee]";
                    break;
                case ("Фамилия"):
                    e.SortExpression = "[Last_Name_employee]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[Login_employee]";
                    break;
                case ("Пароль"):
                    e.SortExpression = "[Password_employee]";
                    break;
                case ("Роль"):
                    e.SortExpression = "[Role]";
                    break;
                case ("День рождения"):
                    e.SortExpression = "[birstday_employee]";
                    break;
                case ("Должность"):
                    e.SortExpression = "[name_possition]";
                    break;
            }
            sortGridView(gvAddUser, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        private void sortGridView(GridView gridView,
        GridViewSortEventArgs e,
        out SortDirection sortDirection,
        out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }

        protected void gvAddUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAddUser.SelectedRow;
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
            lstRole.SelectedIndex = Convert.ToInt32(row.Cells[2].Text.ToString()) - 1;
            tbName.Text = row.Cells[3].Text.ToString();
            tbSurname.Text = row.Cells[4].Text.ToString();
            tbBirthday.Text = row.Cells[5].Text.ToString();
            tbLogin.Text = row.Cells[6].Text.ToString();
            tbPassword.Text = row.Cells[7].Text.ToString();
            tbStatus.Text = row.Cells[8].Text.ToString();

        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAddUser.Rows)
            {
                if (row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text)
                    || row.Cells[7].Text.Equals(tbSearch.Text)
                    || row.Cells[8].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + string.Format(" where [Name_employee] like '%{0}%' or " +
                "[Last_Name_employee] like '%{0}%' or " +
                "[Last_Name_employee] like '%{0}%' or " +
                "[birstday_employee] like '%{0}%' or " +
                "[login_employee] like '%{0}%' or " +
                "[password_employee] like '%{0}%' or " +
                "[role] like '%{0}%' or " +
                "[name_possition] like '%{0}%'", tbSearch.Text);
            gvFill(newQr);
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
               "Удалить выбранную запись?",
               "Продажа товара!", System.Windows.Forms.MessageBoxButtons.YesNo,
               System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    Procedure_Class procedure = new Procedure_Class();
                    ArrayList array = new ArrayList();
                    array.Add(DBConnection.IDrecord);
                    procedure.procedure_Execution("employee_delete", array);
                    gvFill(QR);

                    break;

            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            Procedure_Class procedure = new Procedure_Class();
            ArrayList array = new ArrayList();
            array.Add(DBConnection.IDrecord);
            array.Add(tbName.Text);
            array.Add(tbSurname.Text);
            array.Add(tbBirthday.Text);
            array.Add(tbLogin.Text);
            array.Add(tbPassword.Text);
            array.Add(tbStatus.Text);
            array.Add(lstRole.SelectedIndex + 1);
            procedure.procedure_Execution("employee_update", array);
            gvFill(QR);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}