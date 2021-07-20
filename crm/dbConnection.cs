using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;
using System.Net;


namespace crm
{
    public class DBConnection
    {
        public static string connectionString = @"Data Source=LAPTOP-U17GVN71\PRAKTIKA;Initial Catalog=CRMBase;Integrated Security=True;" +
            @"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            @"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //public static string connectionString = "Data Source = VASYAN-PC\\INO_SERVER; Initial Catalog = CRMBase; Persist Security Info = true; User ID = sa; Password = 123456789";

        //
        public static SqlConnection connection = new SqlConnection(connectionString);
        //public static SqlConnection connection = new SqlConnection("Data Source = VASYAN-PC\\MYSERVER; " +
        //        " Initial Catalog = CRMBase; Persist Security Info = true;" +
        //        " User ID = sa; Password = \"123456789\"");
        public DataTable dtemployee = new DataTable("employee");
            public DataTable dtpossition_employee = new DataTable("possition_employee");
            public DataTable dtwarning = new DataTable("warning");
            public DataTable dtappointment_tasks = new DataTable("Appointment_Tasks");
            public DataTable dttasks = new DataTable("tasks");
            public DataTable dtstatus_tasks = new DataTable("Status_tasks");


        public static string qrStatus_tasks = "SELECT " +
        "[ID_Status], " +
        "[status_performance_tasks] as 'Статус выполняемой задачи' " +
        "FROM [dbo].[status_tasks]  ",



       qremployee = "SELECT [ID_employee], [dbo].[Employee].[id_possition],[name_employee] as 'Имя',  [last_name_employee] as 'Фамилия',    " +
        " [birstday_employee]  as 'День рождения',  [login_employee]  as 'Логин'," +
        "  [password_employee]  as 'Пароль',  [Role]  as 'Роль', " +
        " [name_possition] as 'Должность' " +
        " FROM [dbo].[Employee]    " +
        " INNER JOIN [dbo].[possition_employee] ON [dbo].[possition_employee].[id_possition] = [dbo].[employee].[id_possition] ",

       qrpossition_employee = "SELECT " +
        "[ID_possition], " +
        "[name_possition] as 'Название', " +
        "[status_possition] as 'Статус'" +
        "FROM [dbo].[possition_employee]  ",

          qrappointment1_tasks = " SELECT     [date_tasks] as 'Дата', " +
          "CONCAT_WS(' ', [Last_Name_Employee],[Name_Employee]) as 'ФИО', " +
          "[status_performance_tasks] as 'Статус', [name_tasks] as 'Задача'   " +
             "  FROM [dbo].[appointment_tasks] " +
           "   INNER JOIN [dbo].[employee] ON [dbo].[employee].[ID_employee] = [dbo].[appointment_tasks].[ID_employee]  " +
         "     INNER JOIN [dbo].[status_tasks] ON [dbo].[status_tasks].[ID_status] = [dbo].[appointment_tasks].[ID_status]   " +
          "    INNER JOIN [dbo].[tasks] ON [dbo].[tasks].[ID_tasks] = [dbo].[appointment_tasks].[ID_task]  " ,





           qrappointment_tasks = " SELECT     [ID_appointment]," +
        "      [dbo].[appointment_tasks].[id_employee]  , " +
            "  [dbo].[appointment_tasks].[id_status] ,  " +
             " [id_task] , [date_tasks] as 'Дата', " +
              "CONCAT_WS(' ', [Last_Name_Employee],[Name_Employee]) as 'ФИО', " +
              "[status_performance_tasks] as 'Статус', [name_tasks] as 'Задача'  " +
            "  FROM [dbo].[appointment_tasks] " +
           "   INNER JOIN [dbo].[employee] ON [dbo].[employee].[ID_employee] = [dbo].[appointment_tasks].[ID_employee]  " +
         "     INNER JOIN [dbo].[status_tasks] ON [dbo].[status_tasks].[ID_status] = [dbo].[appointment_tasks].[ID_status]   " +
          "    INNER JOIN [dbo].[tasks] ON [dbo].[tasks].[ID_tasks] = [dbo].[appointment_tasks].[ID_task]  ",

           qrTasks = "SELECT " +
             "[ID_tasks], " +
             "[Name_tasks] as 'Название', " +
             "[start_tasks] as 'Начало'," +
             "[end_tasks] as 'Конец' " +

             "FROM [dbo].[Tasks]  ",


           qrWarning = "SELECT[ID_Warning], [dbo].[warning].[id_tasks],   [coment_task] as 'Комментарий',   [name_tasks] as 'Задача'    FROM[dbo].[warning] INNER JOIN[dbo].[tasks] ON[dbo].[warning].[id_tasks] = [dbo].[tasks].[id_tasks] ";

            private SqlCommand command = new SqlCommand("", connection);
            public static Int32 IDrecord, ID_employee;
            public static string Role;
            public void dbEnter(string login, string password)
            {
                command.CommandText = "SELECT [ID_employee] FROM [dbo].[employee]" +
                    "where [Login_employee] = '" + login + "' and [Password_employee] = '" +
                    password + "'";
                connection.Open();
                ID_employee = Convert.ToInt32(command.ExecuteScalar().ToString());
                connection.Close();
            }

            private void dtFill(DataTable table, string query)
            {
                command.CommandText = query;
                connection.Open();
                table.Load(command.ExecuteReader());
                connection.Close();
            }

            public Int32 Authorization(string User_Login, string User_Password)
            {
                Int32 ID_record = 0;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select [dbo].[employee]('"
                    + User_Login + "','" + User_Password + "')";
                DBConnection.connection.Open();
                ID_record = Convert.ToInt32(command.ExecuteScalar().ToString());
                DBConnection.connection.Close();
                return (ID_record);
            }
        }
 }
