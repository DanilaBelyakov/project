<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email.aspx.cs" Inherits="crm.email" %>

<!DOCTYPE html>


<head>
    </style>
    <body style="background : #000 url(font.jpg);
    ;
</body>

<label class="txtLabel">ФИО</label>
    <form id="form1" runat="server">
       
<asp:TextBox ID="tbTitle" runat="server" placeholder=" ФИО Сотрудника" MaxLength="50"></asp:TextBox>

     <br>
            <br>

    <label class="txtLabel">Комментарий </label>
        <br>
            <br>
    
<asp:TextBox ID="tbMessage" runat="server" placeholder="оставить комментарий " MaxLength="100"></asp:TextBox>

     <br>
            <br>


    <label class="txtLabel">Электронная почта </label>
    <br>
            <br>

<asp:TextBox ID="tbEmail" runat="server" placeholder="укажите почту" MaxLength="50"></asp:TextBox>
    <br>
            <br>
         <asp:Button ID = "btInsert" runat ="server" Text ="Отправить" OnClick="btInsert_Click"  />
        <br>
        <a href="MainMenu.aspx" class="active">Главная страница</a> 
         </form>

                  



</body>
</html>

