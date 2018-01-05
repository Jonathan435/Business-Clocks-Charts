Imports BusinessClocks.ExecutiveClocks

Public Class Form1

    Private carClock As BusinessClocks.ExecutiveClocks.CarClock
    Private goalsClock As GoalsClock
    Private waitClock As WaitClock

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' car clock (with precentage bar)
        carClock = New BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8, True)
        carClock.ShowInnerCutForPerformance = False
        carClock.BarBackColor = Color.Pink
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
End Class
