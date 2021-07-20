<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appointmentTasks.aspx.cs" Inherits="crm.performancetasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
     <style type="text/css">
         .bt_Style {
         }
         .gvAddUser {}

         .navcenter {
            text-align: center;
        }
         .btnleft {
            float:left;
        }
         .textbox { 
    background: white; 
    border: 1px double #DDD; 
    border-radius: 5px; 
    box-shadow: 0 0 5px #333; 
    color: #666; 
    outline: none; 
    height:25px; 
    width: 275px; 
  } 
          .block-left {
        width: 15%;
        height: 800px;
        overflow: auto;
          
         }

    .block-center {
        
        width: 85%;
        height: 100%;
        overflow: auto;
        float:right;
    }

    
    </style>
</head>
<body>
      <form id="User" runat="server" style="background-color:white">
        <center>
            <center> 
         <div>
              <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
                  <a class="navbar-brand" href="#">
                   <img src="logoza.ru.png" />

  <a class="navbar-brand navcenter">Введите значение для поиска</a>
  
    <asp:textbox class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" ID="tbSearch" runat="server"/>
      
      <br>
   
  <asp:SqlDataSource ID="sdsEmployee" runat ="server"></asp:SqlDataSource>
                       <asp:SqlDataSource ID="sdsExport" runat ="server"></asp:SqlDataSource>
</nav>
             <br>
             
              <asp:button ID ="btSearch" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Поиск" OnClick="btSearch_Click"></asp:button>
      <asp:button ID ="btFilter" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Фильтр" OnClick="btFilter_Click"></asp:button>
        <asp:button ID ="btCancel" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Отмена" OnClick="btCancel_Click"></asp:button>
        <asp:button ID ="btExport" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Экспорт" OnClick="btExport_Click"></asp:button>
      
             </div>
                <div class="block-center block-2"
                 <center>
                    <br>
                <asp:GridView ID ="gvAddUser" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                    Width ="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered "  style =" border-color: black; background-color: white; "
                OnRowDataBound="gvAddUser_RowDataBound" OnSorting="gvAddUser_Sorting" OnSelectedIndexChanged="gvAddUser_SelectedIndexChanged">
                    <Columns>
                       
                     <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                     <HeaderStyle   CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="33%" />



                </asp:GridView>

                      <asp:GridView ID ="gvExport" runat ="server" 
                    AllowSorting ="true" 
                    CurrentSortField =""
                    CurrentSortDirection ="ASC"
                          Visible="false"
                    Width ="90%"
                   CssClass=" table table-striped table-responsive table-hover table-bordered "  style =" border-color: black; background-color: white; ">
                    <Columns>
                       
                     <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                     <HeaderStyle   CssClass="table table-primary" 
                    BackColor="Black" 
                    HorizontalAlign="Center" 
                    Width="33%" />
                </asp:GridView>
            </center>
            </div>
        </center>
            <br>
        <div style="overflow: unset">
            <div class="block-left block-2">
                
                

              

                
            



                              
                    <br />
                 <br />
                
                
                              
  Сотрудник
  <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="mr-sm-2" Width="280px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>             
  Статус
                 <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="mr-sm-2" Width="280px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>             
  задача
                 <asp:DropDownList ID="DropDownList3" runat="server"  CssClass="mr-sm-2" Width="280px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>             
                
                              
                  <br />
                              
                  <br />
                              
                  <br />
            

                
            

                

                
                <asp:Label ID="lblQuantity" runat="server"
                    Text="Дата" CssClass="font_style"></asp:Label>

                <br />

               
                <asp:TextBox ID="tbName" CssClass="text-center textbox" runat ="server" style="margin-left: 0px"></asp:TextBox>
                <br />


                
                
                <br />
               
                <asp:Button ID="btDelete" runat="server" CssClass="btn btn-primary"
                    Text="Удалить" OnClick="btDelete_Click" />

                <asp:Button ID="btInsert" runat="server" CssClass=" btn btn-primary"
                    Text="Добавить"  Width="100px" OnClick="btInsert_Click" />
               
                <br />
                


                <br />
              <asp:button ID ="Button1" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Назад" Width="90px"></asp:button>

                <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-primary"
                    Text="Изменить" Width="100px" OnClick="btUpdate_Click" />
                <br />

                <br />
                <a href="MainMenu.aspx" class="active">Главная страница</a> 
                <br />
                <br />
                <br />
            </div>
            
               
            </div>
          
           
        
    </form>
</body>
</html>
