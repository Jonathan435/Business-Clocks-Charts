using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessClocks.ExecutiveClocks;

namespace Example_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private CarClock CarClock;
        private GoalsClock GoalsClock;
        private WaitClock WaitClock;



        private void Example()
        {
            // form background is changing in order to demonstrate clocks backcolor property
            if (this.BackColor == Color.FromArgb(20, 20, 20))
            {
                this.BackColor = Color.FromArgb(100, 100, 100);
            }
            else
            {
                this.BackColor = Color.FromArgb(20, 20, 20);
            }

            // use dispose() method dispose objects
            if (CarClock != null)
            {
                CarClock.Dispose();
            }

            if (GoalsClock != null)
            {
                GoalsClock.Dispose();
            }

            if (WaitClock != null)
            {
                WaitClock.Dispose();
            }

            MyCarClock();
            MyGoalsClock();
            MyWaitClock();
        }


        private void MyCarClock()
        {
            CarClock = new BusinessClocks.ExecutiveClocks.CarClock(300, 150, (float)0.8, true);
            CarClock.ShowInnerCutForPerformance = false;
            // when set to true inner the clock will be set with inner cut design
            CarClock.ClockBackGroundColor = this.BackColor;
            // set backgroud of the clock
            CarClock.Create(true);
            // all properties must be set before Create() is called
            CarClock.ClockPanel.Location = new Point(50, this.Height / 2);
            this.Controls.Add(CarClock.ClockPanel);

        }


        private void MyGoalsClock()
        {
            GoalsClock = new GoalsClock(200, 200, (float)0.75);
            GoalsClock.ClockBackGroundColor = this.BackColor;
            // set backgroud of the clock
            GoalsClock.OuterCircleColor = Color.Gray;
            // change outer circle color 
            GoalsClock.InnerCircleColor = Color.Yellow;
            // change inner circle color
            GoalsClock.Create(true);
            GoalsClock.Clock.Location = new Point(CarClock.ClockPanel.Location.X + CarClock.ClockPanel.Width + 50, this.Height / 2);
            this.Controls.Add(GoalsClock.Clock);

        }


        private void MyWaitClock()
        {
            WaitClock = new WaitClock(150, 150, "Loading...");
            WaitClock.Clock.Location = new Point(GoalsClock.Clock.Location.X + GoalsClock.Clock.Width + 50, (this.Height / 2) + 25);
            WaitClock.LoadFont("ARIAL", 8, FontStyle.Regular);
            // change wait text font
            WaitClock.setArrayColors(new Color[] {
            Color.FromArgb(0, 100, 100),
            Color.FromArgb(0, 136, 136),
            Color.FromArgb(0, 170, 170),
            Color.FromArgb(0, 204, 204)
        });
            // each spin interval will color the circle according to that array
            WaitClock.OuterCircleWeight = 8;
            // change outer circle weight (in PX)
            WaitClock.InnerCircleWeight = 5;
            // change inner circle weight (in PX)
            WaitClock.ClockBackGroundColor = this.BackColor;
            // set backgroud of the clock
            WaitClock.Create(true);
            this.Controls.Add(WaitClock.Clock);

        }
  

        private void button1_Click_1(object sender, EventArgs e)
        {
            Example();
            button1.Text = "press again";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            button2.Text = "press again";

            if (CarClock != null)
            {
                CarClock.PercentOfGoals = (float)0.5;
                // change the percent of the clock in order to show new percent before refresing it
                CarClock.RefreshClock(true);
                // refresh clock
            }

            if (GoalsClock != null)
            {
                GoalsClock.PercentOfGoals = (float)0.5;
                // change the percent of the clock in order to show new percent before refresing it
                GoalsClock.InnerCircleColor = Color.Cyan;
                // change outer circle color 
                GoalsClock.OuterCircleColor = Color.White;
                // change inner circle color
                GoalsClock.RefreshClock(true);
            }

            if (WaitClock != null)
            {
                WaitClock.setArrayColors(new Color[] {
                Color.Green,
                Color.Yellow,
                Color.Red,
                Color.Blue
            });
                // change colors of spinning intervals
                WaitClock.OuterCircleColor = Color.White;
                WaitClock.RefreshClock(true);
            }
        }
    }
}



//https://www.youtube.com/watch?v=Ijfypw7qJgg&t=264s