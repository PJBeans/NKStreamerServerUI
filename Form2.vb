﻿Imports System.Text
Public Class Form2
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Form2_Load() Handles MyBase.Load
        ReadTextConfig()
    End Sub
    'Window Movement'
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown


        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top

    End Sub
    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub ReadTextConfig()
        Dim configServer As New IO.StreamReader("C:\Users\phill\Desktop\NKStreamer0.5.8\server" & ".cfg")
        RichTextBox1.Text = configServer.ReadToEnd()
        configServer.Close()
    End Sub
    Private Sub SaveServerConfig()
        Dim configServerSave As New IO.StreamWriter("C:\Users\phill\Desktop\NKStreamer0.5.8\server" & ".cfg")
        configServerSave.Write(RichTextBox1.Text)
        configServerSave.Close()

    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveServerConfig()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class