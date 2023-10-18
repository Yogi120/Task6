Imports System.Web.Configuration
Imports Microsoft.SqlServer.Server
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Public Class RegistrationForm
    Inherits System.Web.UI.Page


    Dim sErrMsg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim bSucess As Boolean = True

            Dim Name As String = Request.Form("txtName")
            Dim Login As String = Request.Form("txtId")
            Dim Password As String = Request.Form("txtPassword")
            Dim UserType As String = Request.Form("rdType").ToString

            Dim iSrno As Integer = 1

            Dim dt As DataTable = Nothing

            If Session("UserDetails") IsNot Nothing Then
                dt = CType(Session("UserDetails"), DataTable)
                iSrno = dt.Rows.Count + 1

                For i = 0 To dt.Rows.Count - 1
                    If Login = dt.Rows(i).Item("Login_id").ToString Then
                        bSucess = False
                        Throw New ApplicationException("User login already exist !")
                    End If
                Next
            Else
                dt = New DataTable
                With dt
                    .Columns.Add("Sr no.")
                    .Columns.Add("Name")
                    .Columns.Add("Login_id")
                    .Columns.Add("Password")
                    .Columns.Add("User Type")
                    .Columns.Add("Created on")
                End With
            End If
            If bSucess Then
                Dim dr As System.Data.DataRow = Nothing

                dr = dt.NewRow

                dr("Sr no.") = iSrno
                dr("Name") = Name
                dr("Login_id") = Login
                dr("Password") = Password
                dr("User Type") = UserType
                dr("Created on") = Now.ToString

                dt.Rows.Add(dr)

                Session("UserDetails") = dt

                grdvw.DataSource = CType(Session("UserDetails"), DataTable)
                grdvw.DataBind()
            End If
        Catch ex As Exception
            sErrMsg = ex.Message
        Finally
            If sErrMsg <> "" Then
                fnJsAlert(sErrMsg)
            End If
        End Try

    End Sub

    Private Sub fnJsAlert(ByVal sMsg As String)
        sMsg = sMsg.Replace(vbCrLf, "\n")
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "JS" + Now.Ticks.ToString, "alert('" & sMsg & "');", True)
    End Sub
End Class