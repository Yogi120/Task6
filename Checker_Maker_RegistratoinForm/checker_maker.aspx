<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="checker_maker.aspx.vb" Inherits="Checker_Maker_RegistratoinForm.checker_maker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
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
                    User_id: <asp:TextBox ID="txtId" runat="server" />
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
        <div style="margin-top:50px" >
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click"  />
        </div>
        
    </form>
</body>
</html>
