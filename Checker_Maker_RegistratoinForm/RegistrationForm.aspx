
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrationForm.aspx.vb" Inherits="Checker_Maker_RegistratoinForm.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <h1 style="text-align:center; margin-bottom:50px"  >
            Registration Form
        </h1>
        <table>
            <tr>
                <th  >
                    Name: <asp:TextBox ID="txtName" placeholder="Enter full name"  runat="server"/>
                </th>
            </tr>
            <tr>
                <th >
                    Login_id: <asp:TextBox ID="txtId" runat="server" />
                </th>
            </tr>
            <tr>
                <th >
                    Password: <asp:TextBox ID="txtPassword" runat="server" />
                </th>
            </tr>
            <tr >
                <th > User type:
                    <asp:RadioButton GroupName="rdType" value="Checker" runat="server" checked="true" />Checker
                    <asp:RadioButton GroupName="rdType" value="Maker" runat="server" /> Maker
                </th>
            </tr>
            
        </table>
        <div style="margin-top:30px; margin-bottom:30px" >
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="Button1_Click"  />
            <a target="_self" href="/LoginPg.aspx">Login</a>
        </div>
        <asp:GridView ID="grdvw" runat="server" />
    </form>
</body>
</html>
