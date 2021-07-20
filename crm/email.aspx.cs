using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            EmailClass emailClass = new EmailClass("Шикарин Олег ", "Проверьте дату начала задачи", "danilabelyakov241@gmail.com"); // отправка сообщения 

        }
    }
}