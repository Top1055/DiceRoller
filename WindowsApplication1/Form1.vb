Public Class Form1
    Dim x As String
    Dim i As Integer
    Dim num As Integer
    Dim random As Random
    Dim number As Integer
    Dim time
    Dim col
    Dim speed
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Add(TextBox1.Text)
        ListBox2.Items.Add(TextBox1.Text)
        TextBox1.Text = ""
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            ListBox2.Items.Remove(ListBox1.SelectedItem)
        Catch ex As Exception
            MsgBox("please select an item")
        End Try
        x = InputBox("rename", "ITEM", ListBox1.SelectedItem)
        ListBox1.Items.Add(x)
        ListBox2.Items.Add(x)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            ListBox2.Items.Remove(ListBox1.SelectedItem)
        Catch ex As Exception
            MsgBox("please select an item")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        speed = TrackBar1.Value
        Try
            Timer1.Interval = TrackBar1.Value
            ProgressBar1.Maximum = ListBox2.Items.Count
            ProgressBar1.Value = 0
            time = 0
            num = ListBox2.Items.Count
            random = New Random
            number = random.Next(0, num)
            Timer2.Interval = Timer1.Interval
            Timer1.Start()
        Catch ex As Exception
            MsgBox("there's no items in your list")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ListBox2.SelectedIndex = ProgressBar1.Value
            ListBox2.SelectionMode = SelectionMode.One
            TextBox2.Text = ListBox2.SelectedItem
            ProgressBar1.Increment(1)
            If ProgressBar1.Value = ProgressBar1.Maximum Then
                time = time + 1
                ProgressBar1.Value = 0
            End If
            If CheckBox1.Checked = False Then
                Timer1.Interval = Timer1.Interval + 1
            End If

            If time = TrackBar2.Value Then
                Timer1.Stop()
                time = 0
                ProgressBar1.Maximum = number
                ProgressBar1.Value = 0
                Timer2.Interval = Timer1.Interval
                Timer2.Start()
            End If
        Catch ex As Exception
            Timer1.Stop()
            MsgBox("there's no items in your list")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            ListBox2.Items.Remove(ListBox1.SelectedItem)
        Catch ex As Exception
            MsgBox("please select an item")
        End Try
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            ListBox1.Items.Add(TextBox1.Text)
            ListBox2.Items.Add(TextBox1.Text)
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Normal
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        WindowState = FormWindowState.Normal
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ListBox2.SelectedIndex = ProgressBar1.Value
        ListBox2.SelectionMode = SelectionMode.One
        TextBox2.Text = ListBox2.SelectedItem
        ProgressBar1.Increment(1)
        If CheckBox1.Checked = False Then
            Timer2.Interval = Timer2.Interval + 5
        End If
        time = time + 1
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer2.Stop()
            ListBox2.SelectedIndex = number.ToString
            TextBox2.Text = ListBox2.SelectedItem
            If Me.WindowState = FormWindowState.Minimized Then
                NotifyIcon1.BalloonTipTitle = "The rolling is done!"
                NotifyIcon1.BalloonTipText = "<" + TextBox2.Text + "> has been chosen"
                NotifyIcon1.Visible = True
                NotifyIcon1.ShowBalloonTip(3)
            End If
            ProgressBar1.Value = 0
            End If
    End Sub
#Region "colours"

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Black" Then
            Button1.ForeColor = Color.Black
            TextBox2.ForeColor = Color.Black
            Label9.Text = ComboBox1.SelectedItem
            Label9.ForeColor = Color.Black
        End If
        If ComboBox1.SelectedItem = "Blue" Then
            Button1.ForeColor = Color.Blue
            TextBox2.ForeColor = Color.Blue
            Label9.Text = ComboBox1.SelectedItem
            Label9.ForeColor = Color.Blue
        End If
        If ComboBox1.SelectedItem = "Green" Then
            Button1.ForeColor = Color.Green
            TextBox2.ForeColor = Color.Green
            Label9.Text = ComboBox1.SelectedItem
            Label9.ForeColor = Color.Green
        End If
        If ComboBox1.SelectedItem = "Yellow" Then
            Button1.ForeColor = Color.Yellow
            TextBox2.ForeColor = Color.Yellow
            Label9.Text = ComboBox1.SelectedItem
            Label9.ForeColor = Color.Yellow
        End If
        If ComboBox1.SelectedItem = "Red" Then
            Button1.ForeColor = Color.Red
            TextBox2.ForeColor = Color.Red
            Label9.Text = ComboBox1.SelectedItem
            Label9.ForeColor = Color.Red
        End If
        If ComboBox1.SelectedItem = "Purple" Then
            Button1.ForeColor = Color.Purple
            TextBox2.ForeColor = Color.Purple
            Label9.Text = ComboBox1.SelectedItem
            Label9.ForeColor = Color.Purple
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem = "Black" Then
            ListBox1.ForeColor = Color.Black
            Button2.ForeColor = Color.Black
            Button3.ForeColor = Color.Black
            TextBox1.ForeColor = Color.Black
            Label8.Text = ComboBox2.SelectedItem
            Label8.ForeColor = Color.Black
        End If
        If ComboBox2.SelectedItem = "Blue" Then
            ListBox1.ForeColor = Color.Blue
            Button2.ForeColor = Color.Blue
            Button3.ForeColor = Color.Blue
            TextBox1.ForeColor = Color.Blue
            Label8.Text = ComboBox2.SelectedItem
            Label8.ForeColor = Color.Blue
        End If
        If ComboBox2.SelectedItem = "Green" Then
            ListBox1.ForeColor = Color.Green
            Button2.ForeColor = Color.Green
            Button3.ForeColor = Color.Green
            TextBox1.ForeColor = Color.Green
            Label8.Text = ComboBox2.SelectedItem
            Label8.ForeColor = Color.Green
        End If
        If ComboBox2.SelectedItem = "Yellow" Then
            ListBox1.ForeColor = Color.Yellow
            Button2.ForeColor = Color.Yellow
            Button3.ForeColor = Color.Yellow
            TextBox1.ForeColor = Color.Yellow
            Label8.Text = ComboBox2.SelectedItem
            Label8.ForeColor = Color.Yellow
        End If
        If ComboBox2.SelectedItem = "Red" Then
            ListBox1.ForeColor = Color.Red
            Button2.ForeColor = Color.Red
            Button3.ForeColor = Color.Red
            TextBox1.ForeColor = Color.Red
            Label8.Text = ComboBox2.SelectedItem
            Label8.ForeColor = Color.Red
        End If
        If ComboBox2.SelectedItem = "Purple" Then
            ListBox1.ForeColor = Color.Purple
            Button2.ForeColor = Color.Purple
            Button3.ForeColor = Color.Purple
            TextBox1.ForeColor = Color.Purple
            Label8.Text = ComboBox2.SelectedItem
            Label8.ForeColor = Color.Purple
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedItem = "Black" Then
            changeOptionsColour(Color.Black)
        End If

        If ComboBox3.SelectedItem = "Blue" Then
            changeOptionsColour(Color.Blue)
        End If

        If ComboBox3.SelectedItem = "Green" Then
            changeOptionsColour(Color.Green)
        End If

        If ComboBox3.SelectedItem = "Yellow" Then
            changeOptionsColour(Color.Yellow)
        End If

        If ComboBox3.SelectedItem = "Red" Then
            changeOptionsColour(Color.Red)
        End If

        If ComboBox3.SelectedItem = "Purple" Then
            changeOptionsColour(Color.Purple)
        End If
    End Sub

    Public Sub changeOptionsColour(color)

        Label2.ForeColor = color
        Label1.ForeColor = color
        Label3.ForeColor = color
        Label4.ForeColor = color
        Label5.ForeColor = color
        Label6.ForeColor = color
        Label7.Text = ComboBox2.SelectedItem
        Label7.ForeColor = color
        Label11.ForeColor = color
        Label12.ForeColor = color
        Label13.ForeColor = color
        Label10.ForeColor = color

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.SendToBack()
        End If
        If CheckBox2.Checked = False Then
            TextBox2.BringToFront()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        NotifyIcon1.BalloonTipTitle = "Minimized"
        NotifyIcon1.BalloonTipText = "The Roller is now minimized double click to restore"
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(3)
    End Sub


#End Region

End Class
