<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserSearchFile.aspx.vb" Inherits="Checker_Maker_RegistratoinForm.UserSearchFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UserSearchFile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="fileSrh" runat="server">
             <asp:TextBox ID="txtSearch" runat="server" placeholder="File Name .txt"/>
            <asp:Button ID="btnSearch" runat="server" OnClicK="btnSearch_Click" Text="Search" />
        </div>
    </form>
</body>
</html>
