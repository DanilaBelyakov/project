using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace crm
{
    public class Table_Class
    {
        //Глобальный класс виртуальной таблицы
        public DataTable table = new DataTable();
        //Локальная переменная SQLCommand
        private SqlCommand command = new SqlCommand("",DBConnection.connection);
        //Глобальная переменная организации зависимости и прослушивания сервера
        public SqlDependency Dependency = new SqlDependency();
        /// <summary>
        /// Заполение DataTable в зависимости от введённого SQL запроса
        /// </summary>
        /// <param name="SQL_Select_Query">Переменная запроса SQL</param>
        public Table_Class(string SQL_Select_Query)
        {
            command.Notification = null;//Отключение оповещений у команды
            command.CommandText = SQL_Select_Query;//Присвение SQL запроса SQLCommand
            Dependency.AddCommandDependency(command);//Присвоение команды в связку 
            //прослушивания
            try
            {
                //Запуск прослушивания
                SqlDependency.Start(DBConnection.connection.ConnectionString);
                //Открытие подключения
                DBConnection.connection.Open();
                //Записть данных в табличном виде в виртулальную таблицу
                table.Load(command.ExecuteReader());
            }
            catch(Exception ex)
            {
                //Вывод сообщения об ошибке
                //if (ex.Message != "Подключение не было закрыто. Подключение открыто." & ex.Message != "Недопустимая попытка вызвать MetaData при закрытом устройстве чтения.")
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //Закрытие подключения
                DBConnection.connection.Close();
            }
        }
    }
}
