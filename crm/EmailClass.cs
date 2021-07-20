using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace crm
{
    class EmailClass
    { 


        public bool Sended;
        /// <summary>
        /// Класс для отправки электронных писем по средствам smtp-сервера
        /// </summary>
        /// <param name="subject">Тема письма</param>
        /// <param name="Text">Текст письма</param>
        /// <param name="Email">Адрес почты</param>
        public EmailClass(string subject, string Text, string Email)
        {
            //отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("danilabelyakov231@gmail.com", "CRM");
            // кому отправляем
            MailAddress to = new MailAddress(Email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = subject;
            // текст письма
            m.Body = "<h2>" + Text + "</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("danilabelyakov231@gmail.com", "Danila554678dan");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
                Sended = true;
            }
            catch
            {
                MessageBox.Show("Ошибка, сообщение не отправлено!");
                Sended = false;
            }

        }
    }
}

    