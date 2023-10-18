<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmLogin.aspx.vb" Inherits="Checker_Maker_RegistratoinForm.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> User_id
            <asp:TextBox ID="txtUserid" runat="server" />
        </div>
        <div> Password
            <asp:TextBox ID="txtPassword" runat="server" />
        </div>
        <div id="divLogin" runat="server">
            <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click"/>
        </div>
    </form>
</body>
</html>
