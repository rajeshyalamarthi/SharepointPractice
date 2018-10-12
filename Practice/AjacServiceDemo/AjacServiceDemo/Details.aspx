<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="AjacServiceDemo.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-left-style: solid;
            border-left-width: 4px;
            border-right: 4px solid #C0C0C0;
            border-top-style: solid;
            border-top-width: 4px;
            border-bottom: 4px solid #C0C0C0;
            background-color: #C0C0C0;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            height: 45px;
        }
        .auto-style4 {
            height: 52px;
        }
        .auto-style5 {
            height: 56px;
        }
        .auto-style6 {
            height: 42px;
            width: 114px;
        }
        .auto-style7 {
            height: 45px;
            width: 114px;
        }
        .auto-style8 {
            height: 52px;
            width: 114px;
        }
        .auto-style9 {
            height: 56px;
            width: 114px;
        }
        .auto-style10 {
            height: 42px;
            width: 249px;
        }
        .auto-style11 {
            height: 45px;
            width: 249px;
        }
        .auto-style12 {
            height: 52px;
            width: 249px;
        }
        .auto-style13 {
            height: 56px;
            width: 249px;
        }
    </style>

 
        <script src="jquery-3.3.1.js"></script>
        <script type="text/javascript"></script>
    <script>
    
  $(document).ready(function () {

    $('#Button1').click(function () {
        var StId = $('#TextBox1').val();
        $.ajax({
            url: 'Details.aspx/GetStudentById',
            type: 'POST',
            contentType: 'application/json',
            data: '{SId: ' + StId + '}',
            dataType: 'json',
          
            success: function (data) {
              
                $('#TextBox2').val(data.Name);
                
                $('#TextBox3').val(data.Gender);
                $('#TextBox4').val(data.Marks);

            },
            error: function (error) {
                alert(error);
            }
        });
    });
});
    </script>

    </head>
    <body>
    <form id="form1" runat="server">

        <div>
            <table class="auto-style1" id="DataTable">
                <tr>
                    <th>StudentId</th>
                    <th>Name</th>
                    <th>Gender</th>
                    <th>Marks</th>
                </tr>
                <tr>
                    <td class="auto-style6">StudentId</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="TextBox1" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <input id="Button1" type="button" value="GetStudent"  /></td>
                </tr>
                <tr>
                    <td class="auto-style7">Name</td>
                    <td class="auto-style11">
                        <asp:TextBox ID="TextBox2" runat="server" Width="206px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style8">Gender</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="TextBox3" runat="server" Width="208px"></asp:TextBox>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style9">Marks</td>
                    <td class="auto-style13">
                        <asp:TextBox ID="TextBox4" runat="server" Width="201px"></asp:TextBox>
                    </td>
                    <td class="auto-style5"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
