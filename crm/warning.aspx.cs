using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crm
{
    public partial class warning : System.Web.UI.Page
    {
        private string QR = DBConnection.qrWarning;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["uname"] == null)
            {
                Response.Redirect("vhod.aspx");
            }
            else
            {
                QR = DBConnection.qrWarning;
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
            //sdsPPerm.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            //sdsPPerm.DataSourceMode = SqlDataSourceMode.DataReader;


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
            array.Add(lstRole.SelectedIndex + 1);
            procedure.procedure_Execution("warning_Insert", array);
            gvFill(QR);
        }

        private void lbFill()
        {
            Table_Class table_Class = new Table_Class("SELECT [id_tasks], [name_tasks] FROM [CRMBase].[dbo].[tasks]");
            lstRole.DataSource = table_Class.table.DefaultView;
            lstRole.DataValueField = "id_tasks";
            lstRole.DataTextField = "name_tasks";
            lstRole.DataBind();
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
                case ("Название"):
                    e.SortExpression = "[name_warning]";
                    break;
                case ("Начало"):
                    e.SortExpression = "[start_warning]";
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
            tbName.Text = row.Cells[3].Text.ToString();
            lstRole.SelectedIndex = Convert.ToInt32(row.Cells[2].Text.ToString()) - 1;
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAddUser.Rows)
            {
                if (row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text))
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
            string newQr = QR + string.Format(" where [name_warning] like '%{0}%' or [name_task] like '%{0}%'", tbSearch.Text);
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
                    procedure.procedure_Execution("warning_Delete", array);
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
            var s = lstRole.SelectedIndex;
            array.Add(s + 1);
            procedure.procedure_Execution("warning_Update", array);
            gvFill(QR);
        }
    }
}