Imports BusinessClocks.ExecutiveClocks
Public Class Form1
    Public CarClock As BusinessClocks.ExecutiveClocks.CarClock
    Public GoalsClock As GoalsClock
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarClock = New BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8, True)
        CarClock.ShowInnerCutForPerformance = False
        CarClock.BarBackColor = Color.Pink
        CarClock.Create(True)
        Me.Controls.Add(CarClock.ClockPanel)

        GoalsClock = New GoalsClock(200, 200, 0.8)
        GoalsClock.Create(True)
        GoalsClock.Clock.Location = New Point(0, CarClock.ClockPanel.Location.Y + CarClock.ClockPanel.Height + 5)
        Me.Controls.Add(GoalsClock.Clock)


        Dim WaitClock As New WaitClock(150, 150, "Loading...")
        WaitClock.Clock.Location = New Point(0, GoalsClock.Clock.Location.Y + GoalsClock.Clock.Height + 5)
        WaitClock.LoadFont("ARIAL", 8, FontStyle.Regular)
        WaitClock.setArrayColors(New Color() {Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136) _
                                     , Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204)})
        WaitClock.OuterCircleWeight = 8
        WaitClock.InnerCircleWeight = 5
        WaitClock.Create(True)
        Me.Controls.Add(WaitClock.Clock)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CarClock.ShowInnerCutForPerformance = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CarClock.NeedleInnerWeight = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GoalsClock.FontColor = Color.Red
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GoalsClock.ClockFont = New Font("ARIAL", 12, FontStyle.Italic)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CarClock.PercentOfGoals = 0.2
        CarClock.RefreshClock(True)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GoalsClock.PercentOfGoals = 0.2
        GoalsClock.RefreshClock(True)
    End Sub
End Class
