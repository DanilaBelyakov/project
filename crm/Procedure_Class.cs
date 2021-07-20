using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace crm
{
    public class Procedure_Class
    {
        SqlCommand command = new SqlCommand("", DBConnection.connection);
        /// <summary>
        /// Метод обращения к любой хранимой процедуре Microsoft SQL Server
        /// </summary>
        /// <param name="Procedure_name">Водимое название процедуры из БД</param>
        /// <param name="fileld_value">Не типизированная коллекция значений приложения</param>
        public void procedure_Execution(string Procedure_name,  ArrayList fileld_value)
        {
            //Запрос на вывод списка параметров, конкретной хранимолй процедуры
            //в зависимости от введённого разработчиком названия Stored Procedure
            Table_Class table = new Table_Class(string.Format("select name from sys.parameters " +
                "where " +
                "object_id =" +
                " (select object_id from sys.procedures where name = '{0}')", Procedure_name));
            try
            {
                //Настройка SQLCommand для работы с хранимыми процедурами
                command.CommandType = CommandType.StoredProcedure;
                //Присвоение в текст команды названия хранимой процедуры
                command.CommandText = string.Format("[dbo].[{0}]", Procedure_name);
                //Отчистка параметров
                command.Parameters.Clear();
                for(int i = 0; i<table.table.Rows.Count; i++)
                {
                    var s = fileld_value[i];
                    //Сопоставление значений коллекций в значения параметров
                    command.Parameters.AddWithValue(table.table.Rows[i][0].ToString(),
                        s);
                }
                //Объявление события на перехват сообщений из БД
                DBConnection.connection.InfoMessage += Connection_InfoMessage;
                //Открытие подключения
                DBConnection.connection.Open();
                //Выполнение запроса процедуры
                command.ExecuteNonQuery();
            }
            catch
            {
                
            }
            finally
            {
                //Закрытие подключения
                DBConnection.connection.Close();
            }
        }
        /// <summary>
        /// Обработчик события о получении собщения с сервера БД
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргумет сообщения сервера</param>
        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            ////Вывод сообщения с сервера в диалоговое окно
            //System.Windows.Forms.MessageBox.Show(e.Message,"SupportFCMN");
            ////Снятиек с события обработчика метода
            //DBConnection.connection.InfoMessage -= Connection_InfoMessage;
        }
    }
}
