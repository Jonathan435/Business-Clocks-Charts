Imports BusinessClocks.ExecutiveClocks

Public Class Form1

    Private carClock As BusinessClocks.ExecutiveClocks.CarClock
    Private goalsClock As GoalsClock
    Private waitClock As WaitClock

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' car clock (with precentage bar)
        carClock = New BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8, True)
        carClock.ShowInnerCutForPerformance = False
        carClock.Create(True)
        Me.Controls.Add(carClock.ClockPanel)
        ' goals clock
        goalsClock = New GoalsClock(200, 200, 0.8)
        goalsClock.Create(True)
        goalsClock.Clock.Location = New Point(0, carClock.ClockPanel.Location.Y + carClock.ClockPanel.Height + 5)
        Me.Controls.Add(goalsClock.Clock)
        ' waitclock
        waitClock = New WaitClock(150, 150, "Loading...")
        waitClock.Clock.Location = New Point(0, goalsClock.Clock.Location.Y + goalsClock.Clock.Height + 5)
        waitClock.LoadFont("ARIAL", 8, FontStyle.Regular)
        waitClock.SetArrayColors(New Color() {Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136) _
                                     , Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204)})
        waitClock.OuterCircleWeight = 8
        waitClock.InnerCircleWeight = 5
        waitClock.Create(True)
        Me.Controls.Add(waitClock.Clock)

        ' version number
        Me.Text = "Version " & BusinessClocks.ExecutiveClocks.GoalsClock.Version.ToString()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        carClock.ShowInnerCutForPerformance = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        carClock.NeedleInnerWeight = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        goalsClock.FontColor = Color.Red
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        goalsClock.ClockFont = New Font("ARIAL", 12, FontStyle.Italic)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        carClock.PercentOfGoals = 0.2
        carClock.RefreshClock(True)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        goalsClock.PercentOfGoals = 0.2
        goalsClock.RefreshClock(True)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        carClock.BarForeColor = Color.Red
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        carClock.BarFont = New Font("ARIAL", 10, FontStyle.Italic)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        carClock.BarBackColor = Color.Orange
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        carClock.BarValueDigitsForeColor = Color.Red
        carClock.BarValueDigitsBackColor = Color.FromArgb(60, 60, 60)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        carClock.BarValueDigitsFont = New Font("DAVID", 10, FontStyle.Strikeout)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        waitClock.WaitText = "other text"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim ar() As Color = {Color.Red, Color.Green, Color.Gray, Color.Orange}
        waitClock.SetArrayColors(ar)
    End Sub
End Class
