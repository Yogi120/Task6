Imports System.IO

Public Class FrmLogin
    Inherits System.Web.UI.Page

    Private reader As StreamReader = Nothing
    Private sFilePath As String = Server.MapPath("~/form")
    Private sFileName As String = "Details.txt"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim userId As String = Request.Form("txtUserid")
            Dim password As String = Request.Form("txtPassword")


            sFilePath = If(sFilePath.EndsWith("/"), sFilePath, sFilePath & "/")
            Dim sFile As String = sFilePath & sFileName

            If File.Exists(sFile) Then
                Dim credentialsFound As Boolean = False
                reader = New StreamReader(sFile)
                If Not reader.EndOfStream Then
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine()
                        Dim parts As String() = line.Split("|"c)


                        If parts(2) = userId Then
                            If parts(3) = password Then
                                credentialsFound = True
                            Else
                                fnJsAlert("Wrong password !!")
                                Return
                            End If
                            Exit While
                        End If

                    End While

                    If credentialsFound Then
                        fnJsAlert("Entered correct credentials :)")
                    Else
                        fnJsAlert("Wrong credentials :(")
                    End If
                Else
                    fnJsAlert("User details file does not exist.")
                End If
            End If
        Catch ex As Exception
            fnJsAlert("An error occurred: " & ex.Message)

        End Try
    End Sub


    Private Sub fnJsAlert(ByVal sMsg As String)
        sMsg = sMsg.Replace(vbCrLf, "\n")
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "JS" + Now.Ticks.ToString, "alert('" & sMsg & "');", True)
    End Sub
End Class