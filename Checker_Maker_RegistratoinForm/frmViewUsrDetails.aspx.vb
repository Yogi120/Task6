Imports System.IO

Public Class frmViewUsrDetails
    Inherits System.Web.UI.Page


    Private reader As StreamReader = Nothing
    Private sFilePath As String = Server.MapPath("~/form")
    Private sFileName As String = "Details.txt"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim read As String
            sFilePath = If(sFilePath.EndsWith("/"), sFilePath, sFilePath & "/")
            Dim sFile As String = sFilePath & sFileName
            Dim stable As String = ""

            If File.Exists(sFile) Then
                reader = New StreamReader(sFile)
                If Not reader.EndOfStream Then
                    reader.ReadLine()
                    read = reader.ReadLine()

                    stable += "<table width= 100% border=1px solid>"
                    stable += "<tr>"

                    stable += "<th>" & "Sr no." & "</th>"
                    stable += "<th>" & "Name" & "</th>"
                    stable += "<th>" & "User_id" & "</th>"
                    stable += "<th>" & "Password" & "</th>"
                    stable += "<th>" & "User Type" & "</th>"
                    stable += "<th>" & "Created on" & "</th>"
                    stable += "<th>" & "Details" & "</th>"

                    stable += "</tr>"
                    'divUsers.InnerHtml = stable

                    While Not reader.EndOfStream

                        Dim data As String() = read.Split("|")

                        stable += "<tr>"
                        stable += "<td>" & data(0) & "</td>"
                        stable += "<td>" & data(1) & "</td>"
                        stable += "<td>" & data(2) & "</td>"
                        stable += "<td>" & data(3) & "</td>"
                        stable += "<td>" & data(4) & "</td>"
                        stable += "<td>" & data(5) & "</td>"
                        stable += "<td><input type='button' value='Details' onclick='showDetails(" & data(5) & ")'/></td>"
                        stable += "</tr>"
                        'read = reader.ReadLine()

                    End While
                    divUsers.InnerHtml = stable & "</table>"


                Else
                    divUsers.InnerHtml = "File is empty"
                    'fnJsAlert("File is empty")
                End If

            Else
                'fnJsAlert("File does Not exist")
                divUsers.InnerHtml = "file doesn't exist"
            End If

            'reader.Close()

        Catch ex As Exception
            divUsers.InnerHtml = ex.Message

        End Try

    End Sub

    Private Sub fnJsAlert(ByVal sMsg As String)
        sMsg = sMsg.Replace(vbCrLf, "\n")
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "JS" + Now.Ticks.ToString, "alert('" & sMsg & "');", True)
    End Sub

    'Sub FnFileReader()


    'End Sub


End Class