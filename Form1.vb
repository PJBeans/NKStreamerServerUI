﻿Imports System.IO
Imports System.Net
Imports System.Text

Public Class Form1

    'Window Movement'
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer



    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)
    End Sub


    Private Sub Button1_Click() Handles Button1.Click
        'Save server.cfg, even if at default values'
        Dim reader As New StreamReader("servertmp.cfg")
        Dim writer As New StreamWriter("server.cfg")




        Dim s = reader.ReadToEnd().Replace("thread_num = ", "thread_num = " & TextBox2.Text)
        writer.Write(s)
        writer.Close()
        reader.Close()

        Dim sb = New StringBuilder()
        Dim psi = New ProcessStartInfo() With
    {
            .WorkingDirectory = "",
            .FileName = "NKStreamerServerV2.exe",
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardInput = True,
            .UseShellExecute = False
    }

        Dim installbatOut = New Process()
        installbatOut.StartInfo = psi
        AddHandler installbatOut.OutputDataReceived, Function(sender, args) sb.AppendLine(args.Data)
        installbatOut.Start()
        installbatOut.BeginOutputReadLine()
        installbatOut.WaitForExit(100)
        TextBox1.Text = sb.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Show()
        Button1.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Show()
        Button2.Hide()
        StopServer()
        TextBox1.Text = "Server Stopped"

    End Sub
    Private Sub StopServer()
        Dim proc = Process.GetProcessesByName("NKStreamerServerV2")
        For i As Integer = 0 To proc.Count - 1
            proc(i).Kill()
        Next i

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        StopServer()
        Dim reader As New StreamReader("servertmp.cfg")

        Dim writer As New StreamWriter("server.cfg")



        Dim s = reader.ReadToEnd().Replace("thread_num = " & TextBox2.Text, "thread_num = ")
        writer.Write(s)
        reader.Close()
        writer.Close()
        Me.Close()

    End Sub
    Private Sub ResetThreadCount()
        Dim reader As New StreamReader("servertmp.cfg")

        Dim writer As New StreamWriter("server.cfg")



        Dim s = reader.ReadToEnd().Replace("thread_num = ", "thread_num = 3")
        writer.Write(s)
        reader.Close()
        writer.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GetIPAddress()

        Dim sb = New StringBuilder()
        Dim psi = New ProcessStartInfo() With
    {
            .WorkingDirectory = "",
            .FileName = "ip_tool.bat",
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardInput = True,
            .UseShellExecute = False
    }

        Dim installbatOut = New Process()
        installbatOut.StartInfo = psi
        AddHandler installbatOut.OutputDataReceived, Function(sender, args) sb.AppendLine(args.Data)
        installbatOut.Start()
        installbatOut.BeginOutputReadLine()
        installbatOut.WaitForExit(100)
        Label1.Text = sb.ToString()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        GetIPAddress()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Hide()
        GetIPAddress()

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
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub



    Private Sub RichTextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = "Saved server.cfg, stopped server."

        Dim reader As New StreamReader("servertmp.cfg")
        Dim writer As New StreamWriter("server.cfg")




        Dim s = reader.ReadToEnd().Replace("thread_num = ", "thread_num = " & TextBox2.Text)
        writer.Write(s)
        writer.Close()
        reader.Close()
        StopServer()
        Button1.Show()
        Button2.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ShowAllIPAddressesToolStripMenuItem_Click() Handles ShowAllIPAddressesToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub More_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles More.Opening

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.More.Show(Me.Label6, Me.Label6.PointToClient(Cursor.Position))
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button4_Click_2(sender As Object, e As EventArgs)

        Dim reader As New StreamReader("server.cfg")
        Dim allLines = reader.ReadLine()
        If allLines.StartsWith("thread_num = ") Then
            TextBox2.Text = allLines
        End If

    End Sub
End Class
