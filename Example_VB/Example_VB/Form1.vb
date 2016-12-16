' **********************************
' WRITTEN BY JONATHAN APPLEBAUM ****
' 16-12-2016                    ****
' EMAIL: jonathan88@012.net     ****
' **********************************
Imports BusinessClocks.ExecutiveClocks
Public Class Form1

    Private CarClock As CarClock
    Private GoalsClock As GoalsClock
    Private WaitClock As WaitClock


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Example()
        Button1.Text = "press again"
    End Sub

    Private Sub Example()

        ' form background is changing in order to demonstrate clocks backcolor property
        If Me.BackColor = Color.FromArgb(20, 20, 20) Then
            Me.BackColor = Color.FromArgb(100, 100, 100)
        Else
            Me.BackColor = Color.FromArgb(20, 20, 20)
        End If

        ' use dispose() method dispose objects
        If CarClock IsNot Nothing Then
            CarClock.Dispose()
        End If

        If GoalsClock IsNot Nothing Then
            GoalsClock.Dispose()
        End If

        If WaitClock IsNot Nothing Then
            WaitClock.Dispose()
        End If

        MyCarClock()
        MyGoalsClock()
        MyWaitClock()
    End Sub

    Private Sub MyCarClock()

        CarClock = New BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8, True)
        CarClock.ShowInnerCutForPerformance = False ' when set to true inner the clock will be set with inner cut design
        CarClock.ClockBackGroundColor = Me.BackColor ' set backgroud of the clock
        CarClock.Create(True) ' all properties must be set before Create() is called
        CarClock.ClockPanel.Location = New Point(50, Me.Height / 2)
        Me.Controls.Add(CarClock.ClockPanel)

    End Sub

    Private Sub MyGoalsClock()

        GoalsClock = New GoalsClock(200, 200, 0.75)
        GoalsClock.ClockBackGroundColor = Me.BackColor ' set backgroud of the clock
        GoalsClock.OuterCircleColor = Color.Gray ' change outer circle color 
        GoalsClock.InnerCircleColor = Color.Yellow ' change inner circle color
        GoalsClock.Create(True)
        GoalsClock.Clock.Location = New Point(CarClock.ClockPanel.Location.X + CarClock.ClockPanel.Width + 50, Me.Height / 2)
        Me.Controls.Add(GoalsClock.Clock)

    End Sub

    Private Sub MyWaitClock()

        WaitClock = New WaitClock(150, 150, "Loading...")
        WaitClock.Clock.Location = New Point(GoalsClock.Clock.Location.X + GoalsClock.Clock.Width + 50, (Me.Height / 2) + 25)
        WaitClock.LoadFont("ARIAL", 8, FontStyle.Regular) ' change wait text font
        WaitClock.setArrayColors(New Color() {Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136) _
                                     , Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204)}) ' each spin interval will color the circle according to that array
        WaitClock.OuterCircleWeight = 8 ' change outer circle weight (in PX)
        WaitClock.InnerCircleWeight = 5 ' change inner circle weight (in PX)
        WaitClock.ClockBackGroundColor = Me.BackColor ' set backgroud of the clock
        WaitClock.Create(True)
        Me.Controls.Add(WaitClock.Clock)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Button2.Text = "press again"

        If CarClock IsNot Nothing Then
            CarClock.PercentOfGoals = 0.5 ' change the percent of the clock in order to show new percent before refresing it
            CarClock.RefreshClock(True) ' refresh clock
        End If

        If GoalsClock IsNot Nothing Then
            GoalsClock.PercentOfGoals = 0.5 ' change the percent of the clock in order to show new percent before refresing it
            GoalsClock.InnerCircleColor = Color.Cyan ' change outer circle color 
            GoalsClock.OuterCircleColor = Color.White ' change inner circle color
            GoalsClock.RefreshClock(0.5)
        End If

        If WaitClock IsNot Nothing Then
            WaitClock.setArrayColors(New Color() {Color.Green, Color.Yellow _
                                    , Color.Red, Color.Blue}) ' change colors of spinning intervals
            WaitClock.OuterCircleColor = Color.White
            WaitClock.RefreshClock(True)
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
