<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="crm.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title></title>
         <link href="css/bootstrap.css" rel="stylesheet" />
         <script src="Scripts/jquery-3.4.1.slim.min.js"></script>
         <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">

      

         .btleft {
            text-align: left;
            float:left;
        }
        .div {
            background:  	#ded8d8; /* Цвет фона */
            color: #000000; /* Цвет текста */
            /* Чёрная рамка */
            padding: 15px; /* Поля вокруг текста */
            border-radius: 10px;
            width: 70%;
            height: 400px;
        }
         body {
            background: #000 url(font.jpg); /* Фоновый цвет и фоновый рисунок*/
            color: #fff; /*Цвет текста на странице*/
            background-attachment: fixed; /* Фон страницы фиксируется */
            background-repeat: repeat-x; /* Изображение повторяется по горизонтали */
            background-size: 100%;


       
  position: absolute;
  bottom: 0;
  width: 100%;
  /* Set the fixed height of the footer here */
  height: 60px;
  background-color: #f5f5f5;
}

    </style>
</head>
<body>
    
  <form id="form1" runat="server" >
  
      <div>

            <nav class="navbar navbar-expand-lg navbar-light " style="background-color:#e3f2fd">
                <a class="navbar-brand" href="#">
                    <img src="logoza.ru.png" />
                    
                </a>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                    </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav">
                        <li class="nav-item active">
                            <a class="nav-link" href="Tasks.aspx">Задачи</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="employee.aspx">Сотрудники</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="passition.aspx">Должности
                            </a>
                        </li>
                         <li class="nav-item active">
                            <asp:LinkButton class="nav-link" href="warning.aspx" ID="LinkButton4" runat="server">Предупреждения</asp:LinkButton>
                        </li>
                        
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link" ID="LinkButton1" href="appointmenttasks.aspx" runat="server">создание задач</asp:LinkButton>
                        </li>
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link" ID="LinkButton2" href="status.aspx" runat="server">статус</asp:LinkButton>
                        </li>
                          <li class="nav-item active">
                            <asp:LinkButton class="nav-link" ID="LinkButton5" href="Webform5.aspx" runat="server" OnClick="LinkButton5_Click">Загрузка</asp:LinkButton>
                        

                    </ul>
                    <div class="collapse navbar-collapse justify-content-end" id="navbarSupportedConten1t">
                    <ul class="navbar-nav">
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link p-2" ID="LinkButton7" runat="server"></asp:LinkButton>
                            
                        </li>
                       
                        <li class="nav-item active">
                            <asp:LinkButton class="nav-link p-2" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Выйти</asp:LinkButton>
                        </li>
                       
                        
                         
                    </ul>
                        </div>
                </div>
            </nav>
      
     </div>
      <br>
      <br>
      <br>
      <center>
    
             <li><a href="email.aspx">отправка письма</a></li>      
         

          <br>
          <br>

          
          <br>
          <br>
          <br>
          <br>
          <br>
    </div>
          </center>
      
         <div id="footer2" class=" footer container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                      
                    </div>
                </div>
            </div>

        </footer>
        <!-- ./Footer -->
     </form>
    
</body>
     <!-- Footer -->
        <footer>
           
                
           
</html>
