Public Class LoginPg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        'Session("UserDetails") = "UserDetails"

        Dim userId As String = Request.Form("txtUserid")
        Dim Password As String = Request.Form("txtPassword")

        Dim dt As DataTable = CType(Session("UserDetails"), System.Data.DataTable)

        Dim bValid As Boolean = False

        For i = 0 To dt.Rows.Count - 1
            If userId = dt.Rows(i).Item("Login_id").ToString AndAlso Password = dt.Rows(i).Item("Password").ToString Then
                bValid = True
            End If
        Next

        If bValid Then
            fnJsAlert("Correct credentials !")
        Else
            fnJsAlert("InCorrect credentials !")
        End If

    End Sub

    Private Sub fnJsAlert(ByVal sMsg As String)
        sMsg = sMsg.Replace(vbCrLf, "\n")
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "JS" + Now.Ticks.ToString, "alert('" & sMsg & "');", True)
    End Sub
End Class