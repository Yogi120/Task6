Imports System.IO

Public Class UserSearchFile
    Inherits System.Web.UI.Page


    Private reader As StreamReader = Nothing
    Private sFilePath As String = Server.MapPath("~/form")
    'Private sFileName As String = "Details.txt"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Try

            Dim search As String = Request.Form("txtSearch") & ".txt"
            Dim read As String
            sFilePath = If(sFilePath.EndsWith("/"), sFilePath, sFilePath & "/")
            'Dim sFile As String = sFilePath & sFileName
            Dim files As String() = Directory.GetFiles(sFilePath, "*.txt")

            For Each file As String In files
                Dim fileName As String = Path.GetFileName(file)
                If fileName = search Then
                    reader = New StreamReader(file)
                    read = reader.ReadToEnd()
                    fileSrh.InnerHtml = read
                End If
            Next

            'If search = sFileName Then
            '    If File.Exists(sFile) Then
            '        reader = New StreamReader(sFile)
            '        read = reader.ReadToEnd()
            '        fileSrh.InnerHtml = read

            '    Else
            '        fileSrh.InnerHtml = "The file doesn't exist"
            '    End If

            'End If

            reader.Close()

        Catch ex As Exception
            fileSrh.InnerHtml = "The file doesn't exist: "

        End Try
    End Sub
End Class