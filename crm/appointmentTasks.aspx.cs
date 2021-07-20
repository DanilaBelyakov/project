using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace crm
{
    public partial class performancetasks : System.Web.UI.Page
    {
        private string QR = DBConnection.qrappointment_tasks;
        private string QR1 = DBConnection.qrappointment1_tasks;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DBConnection.Role != "Администратор")
            {
                Response.Redirect("MainMenu.aspx");
            }
            if (((string)Session["uname"] == null))
            {
                Response.Redirect("vhod.aspx");
            }
            else
            {
                QR = DBConnection.qrappointment_tasks;
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

        private void gvFill1(string qr)
        {


            sdsExport.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsExport.SelectCommand = qr;
            sdsExport.DataSourceMode = SqlDataSourceMode.DataReader;
            gvExport.DataSource = sdsExport;
            gvExport.DataBind();

        }
        // заполнение выпадающего списка

        public void FillDropLists1()
        {
            //sds1.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            //sds1.DataSourceMode = SqlDataSourceMode.DataReader;


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
            array.Add(DropDownList1.SelectedIndex + 1);
            array.Add(DropDownList2.SelectedIndex + 1);
            array.Add(DropDownList3.SelectedIndex + 1);
            array.Add(tbName.Text);

            //SqlCommand command = new SqlCommand("", DBConnection.connection);
            //command.CommandText = "insert into [dbo].[appoimtment_tasks] ([id_employee], [id_status], [id_task], [date_tasks]) values ('" + (DropDownList1.SelectedIndex + 1).ToString() + "','" + (DropDownList2.SelectedIndex + 1).ToString() + "','" + (DropDownList3.SelectedIndex + 1).ToString() + "','" + tbName.Text + "')";



            //DBConnection.connection.Open();
            //command.ExecuteNonQuery();
            //DBConnection.connection.Close();
            procedure.procedure_Execution("appointment_tasks_insert", array);
            gvFill(QR);
        }

        private void lbFill()
        {
            Table_Class table_Class = new Table_Class("SELECT [id_Employee], CONCAT_WS(' ', [Last_Name_Employee],[Name_Employee]) as 'ФИО' FROM [CRMBase].[dbo].[Employee]");
            DropDownList1.DataSource = table_Class.table.DefaultView;
            DropDownList1.DataValueField = "id_Employee";
            DropDownList1.DataTextField = "ФИО";
            DropDownList1.DataBind();

            Table_Class table_Class1 = new Table_Class("SELECT [id_status], [status_performance_tasks] as 'Статус'  FROM [CRMBase].[dbo].[status_tasks]");
            DropDownList2.DataSource = table_Class1.table.DefaultView;
            DropDownList2.DataValueField = "id_status";
            DropDownList2.DataTextField = "Статус";
            DropDownList2.DataBind();

            Table_Class table_Class3 = new Table_Class("SELECT [id_tasks], [name_tasks] as 'Задача'  FROM [CRMBase].[dbo].[tasks]");
            DropDownList3.DataSource = table_Class3.table.DefaultView;
            DropDownList3.DataValueField = "id_tasks";
            DropDownList3.DataTextField = "Задача";
            DropDownList3.DataBind();
        }

        protected void gvAddUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void gvAddUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Дата"):
                    e.SortExpression = "[date_tasks]";
                    break;
                case ("Статус"):
                    e.SortExpression = "[status_performance_tasks]";
                    break;
                case ("Задача"):
                    e.SortExpression = "[name_tasks]";
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
            DropDownList1.SelectedIndex = Convert.ToInt32(row.Cells[2].Text.ToString()) - 1;
            DropDownList2.SelectedIndex = Convert.ToInt32(row.Cells[3].Text.ToString()) - 1;
            DropDownList3.SelectedIndex = Convert.ToInt32(row.Cells[4].Text.ToString()) - 1;
            tbName.Text = row.Cells[5].Text.ToString();


        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAddUser.Rows)
            {
                if (row.Cells[5].Text.Equals(tbSearch.Text)
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
            string newQr = QR + string.Format(" where [date_tasks] like '%{0}%' or " +
                "[status_performance_tasks] like '%{0}%' or " +
                "[name_tasks] like '%{0}%'", tbSearch.Text);
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
                    procedure.procedure_Execution("appointment_tasks_delete", array);
                    gvFill(QR);

                    break;

            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            Procedure_Class procedure = new Procedure_Class();
            ArrayList array = new ArrayList();
            array.Add(DBConnection.IDrecord);
            array.Add(DropDownList1.SelectedIndex + 1);
            array.Add(DropDownList2.SelectedIndex + 1);
            array.Add(DropDownList3.SelectedIndex + 1);
            array.Add(tbName.Text);
            array.Add(tbName.Text);
            procedure.procedure_Execution("appointment_tasks_update", array);
            gvFill(QR);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btExport_Click(object sender, EventArgs e)
        {
            // выбираем таблицу и источник данных
            GridView gv = new GridView();
            GridView gridView = gvExport;
            DBConnection.connection.Open();
            gv.DataSource = sdsExport;
            DBConnection.connection.Close();
            gvFill1(QR1);





            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            gvExport.AllowPaging = false;
            Response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}