Imports System.IO

Public Class checker_maker
    Inherits System.Web.UI.Page

    Private Name As String = ""
    Private User_id As String = ""
    Private Password As String = ""

    Private Err_msg As String = ""
    Private sFilePath As String = Server.MapPath("~/form")
    Private sFileName As String = "Details.txt"
    Private reader As StreamReader = Nothing
    Private writer As StreamWriter = Nothing

    Private sHeader As String = "Sr No.| Name | User_id | Password | User Type | Created on" & vbCrLf


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Name = Request.Form("txtName")
        User_id = Request.Form("txtId")
        Password = Request.Form("txtPassword")

        Dim Error_Msg As String = ""

        If Name = "" Then
            Error_Msg += "Kindly enter the Name !\n"
        End If

        If User_id = "" Then
            Error_Msg += "Kindly enter the User id !\n"
        End If

        If Password = "" Then
            Error_Msg += "Kindly enter the password !\n"
        End If

        If Error_Msg <> "" Then
            fnJsAlert(Error_Msg)
        Else
            UserDataDetails()
        End If

    End Sub

    Private Function UserDataDetails() As Boolean

        Try
            Dim info As String = Request.Form("btnDetails")
            Dim User_type As String = Request.Form("rdType").ToString
            Name = Request.Form("txtName")
            User_id = Request.Form("txtId")
            Password = Request.Form("txtPassword")
            Dim sData As String = ""
            Dim iSrno As Integer = 1

            sFilePath = If(sFilePath.EndsWith("/"), sFilePath, sFilePath & "/")

            Dim sFile As String = sFilePath & sFileName

            If Not Directory.Exists(sFilePath) Then
                Directory.CreateDirectory(sFilePath)
            End If

            If File.Exists(sFile) Then
                reader = New StreamReader(sFile)
                If Not reader.EndOfStream Then
                    Dim chkhd As Boolean = True
                    Do While Not reader.EndOfStream
                        Dim currLine As String = reader.ReadLine
                        If chkhd = True Then
                            If currLine.Trim <> sHeader.Trim Then
                                sData = sHeader
                            End If
                            chkhd = False
                            Continue Do
                        End If
                        Dim sLineArr() As String = Split(currLine, "|")
                        iSrno += 1

                        If sLineArr(2) = User_id Then
                            fnJsAlert("Entered User_id is already present :(")
                            reader.Close()
                            Return False
                        End If
                    Loop
                End If
                reader.Close()
            Else
                sData = sHeader
            End If

            sData += iSrno & "|" & Name & "|" & User_id & "|" & Password & "|" & User_type & "|" & Now.ToString()

            writer = New StreamWriter(sFilePath & sFileName, True)
            writer.WriteLine(sData)

            If Not writer Is Nothing Then writer.Close()
            Return True

        Catch appex As ApplicationException
            Err_msg = appex.Message
            Return False
        Catch ex As Exception
            Err_msg = ex.Message
            Return False

        Finally
            If Err_msg <> "" Then
                fnJsAlert(Err_msg)
            Else
                fnJsAlert("Data added successfully :)")
            End If

        End Try
    End Function

    Private Sub fnJsAlert(ByVal sMsg As String)
        sMsg = sMsg.Replace(vbCrLf, "\n")
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "JS" + Now.Ticks.ToString, "alert('" & sMsg & "');", True)
    End Sub

End Class