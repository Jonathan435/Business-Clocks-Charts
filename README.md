# Speedometer Designed Charts
Welcome to graphic winforms clock charts, an open source code libary.<br/> The main purpose of this project is to provide graphic "clock-like" objects for C# and VB.NET Winforms developers. the libary is primarily design for applications that present calculated data regarding to performance (company sales dashboard for example).<br/>
each clock object has a variety of properties, used for customization, clocks can include animation when refreshed or load.

<img src="http://i.imgur.com/EdsyThw.png"/>
<br/>

<img src="http://i.imgur.com/EgrLU9t.png"/>
<br/>

#### Getting Started

Download the latest version of BusinessClocks.dll to your local computer.
<br/>You can always find the last version in the master branch of the repository.<br/>
Load the .dll to your winforms project using Visual Studio.<br/>

**Instructions to load dll into your project:**<br/>
* Open VS Reference Manager form: right click on your project in the Solution Explorer >> Add >> Reference. 
* Click the "Browse" button and navigate to the dll path and press OK.
* When you do this, by default the DLL is copied and included in the project's output.
<br/>
<img src="https://i.imgur.com/3zbMo8w.png"/>
<br/>

### Basic Usage

* Create a new winforms project with Visual Studio. 
* Reference BusinessClocks.dll (as explained above).
* Add a ```Using```(C#) steatment or ```Imports```(VB.NET) steatment to the namespace ```BusinessClocks.ExecutiveClocks```
in the top of ```Form1``` File.
* Copy & paste the example with your prefered programming language to ```Form1``` class.
* Run and test the example by pressing F5.

**C# Test Example**
```
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

namespace WindowsFormsApplication19
{
    public partial class Form1 : Form
    {

        private BusinessClocks.ExecutiveClocks.CarClock carClock;
        private GoalsClock goalsClock;
        private WaitClock waitClock;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carClock = new BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8F, true);
            carClock.ShowInnerCutForPerformance = false;
            carClock.BarBackColor = Color.Pink;
            carClock.Create(true);
            this.Controls.Add(carClock.ClockPanel);
            goalsClock = new GoalsClock(200, 200, 0.8F);
            goalsClock.Create(true);
            goalsClock.Clock.Location = new Point(0, carClock.ClockPanel.Location.Y + carClock.ClockPanel.Height + 5);
            this.Controls.Add(goalsClock.Clock);
            waitClock = new WaitClock(150, 150, "Loading...");
            waitClock.Clock.Location = new Point(0, goalsClock.Clock.Location.Y + goalsClock.Clock.Height + 5);
            waitClock.LoadFont("ARIAL", 8, FontStyle.Regular);
            waitClock.SetArrayColors(new Color[] { Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136), Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204) });
            waitClock.OuterCircleWeight = 8;
            waitClock.InnerCircleWeight = 5;
            waitClock.Create(true);
            this.Controls.Add(waitClock.Clock);
        }
    }
}

```
**Visual Basic.NET Test Example**

```
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

End Class
```
### Base Class (GoalsClock) Methods and Properties
<img src="https://i.imgur.com/8Jt9v8w.jpg"/>
<br/>

_**Note:** All clocks (WaitClock and CarClock for now) inherit GoalsClock_
<br/><br/>
**Properties:**
* ```Clock:``` Instance of the graphic object that represents the clock, initilized after ```Create()``` had been called.
* ```ClockWidth```: Gets or Sets the clock width.
* ```ClockHeight```: Gets or Sets the clock height.
* ```xPos``` and ```Ypos```: Gets the x or y position of the rectangle that contains the clock.
* ```ClockBackGroundColor```: Gets or sets the clock background color.
* ```FontColor```: Gets or sets the font color of the text  that describes the ```PercentOfGoals``` percentage.
* ```ClockFont```: Gets or sets the font of the text that describes the PercentOfGoals percentage. **Please note:**
1.  _It is recomended not to change ```font``` property because the getter of this property is calling ```LoadFont()``` function in order to calculate the suitable font size and style relative to the clock size using internal elgoritem._
2. _If the clock is too small the text will not appear on screen (not changing the font settings will prevent this issue)._
3. _you can always call ```LoadFont()``` in order to reset the font._ 

* ```InnerCircleColor```: Gets or sets the color of the inner arc.
* ```InnerCircleWeight```: Gets or sets the pixel weight (wideness) of the inner arc.
* ```OuterCircleColor```: Gets or sets the color of the outer arc.
* ```OuterCircleWeight```: Gets or sets the pixel weight (wideness) of the outer arc.
* ```PercentOfGoals```: Gets or sets the the clock value. for example value of 0.1F = 10%, value of 0.5F = 50%,value of 1.1F = 110% etc...
* ```GoalsPercentDecimalValue```: Gets the the clock deciaml value.
* ```Animate```(field): Gets or sets a value indicating whether animation will be activated or not.
* ```AnimationLength```: Gets or sets animation speed (milisec) based on AnimationLength Enumeration: SuperFast = 1, Fast = 4, ModerateFast = 8, Moderate = 15, ModerateSlow = 28, Slow = 50, SuperSlow = 80.
* ```TimerInterval```: Gets or set the ticks interval for the internal timer. recomended value is 4 (default) to expedite refresh time use lower value.

**Methods:**

* ```Create(ByVal AnimateClock As Boolean)```: Initilizing the clock object, must be called after all properties are set (developers please note: this method is Overridable / Virtual).
* ```RefreshClock(ByVal AnimateClock As Boolean)```: Refreshes and redraws the graphics of the clock object, call this method after you change properties (PercentOfGoals, InnerCircleColor for example). Most of the clock properties will call this method when their value is changed. (developers please note: this method is Overridable / Virtual).
* ``` LoadFont()```: Returns the suitable font em size and style relative to the clock size using internal elgoritem.<br/> you can always call ```LoadFont()``` in order to reset the font.<br/> If the clock is to small the text will not be shown inside the clock .
* ```Dispose()```: The method is implements from IDisposable Interface (in mscorlib.dll assembly), when called clock object will be disposed and all [GDI Objects](https://msdn.microsoft.com/en-us/library/ms969928.aspx) will be freed from memory.
### CarClock Class Methods and Properties 
<img src="https://i.imgur.com/m7Uu6JX.jpg"/>
<br/>

**Properties:**

* ```ClockPanel```(field): use to contain inside the ```Clock``` object if text bar is required. **Important:** 
When ```BaseBar = True``` the ```Clock``` object wil be hosted inside ```ClockPanel``` in order to present a bar of performance text underneath the clock.<br/> **Consider that:**
1. _If ```BaseBar = True``` use this control (and not Clock property) to get the clock with the text bar._
2. _If ```BaseBar = False``` never use this property, the result will be ```NullReferenceException``` because it will not be initilized (Please read  issue6 that was oppened by the user [lordofscripts](https://github.com/lordofscripts): https://github.com/Jonathan435/Business-Clocks-Charts/issues/6)._

* ```LowPerformance```: Gets or sets the indication for low performance, this property is binded to **LowPerFormanceColor** property and its value will set the graphical area of the low performance clock with **LowPerFormanceColor** color.
* ```MediumPerformance```: Gets or sets the indication for Medium performance, this property is binded to **MediumPerFormanceColor** property and its value will set the graphical area of the Medium performance clock with **MediumPerFormanceColor** color.
* ```HighPerformance```: Gets or sets the indication for High performance, this property is binded to **HighPerFormanceColor** property and its value will set the graphical area of the High performance clock with **HighPerFormanceColor** color.

* ```HighPerFormanceColor```: Gets or sets the graphical High performance area in the clock with the color that was selected (bindied to ```HighPerFormance``` property).
* ```MediumPerFormanceColor```: Gets or sets the graphical medium performance area in the clock with the color that was selected (binded to ```MediumPerformance``` property).
* ```LowPerFormanceColor```: Gets or sets the graphical low performance area in the clock with the color that was selected (binded to ```LowPerformance``` property).
* ```NeedleBaseColor```: Gets or sets the background color of the needle (clock hand) base.
* ```NeedleBaseWeight```: Gets or sets the pixel weight (thickness) of the needle (clock hand) base.
* ```NeedleOuterColor```: Gets or sets the background color of the outer needle (clock hand) area.
* ```NeedleOuterWeight```: Gets or sets the pixel weight (thickness) of the outer needle (clock hand) area.
* ```NeedleInnerColor```: Gets or sets the background color of the inner needle (clock hand) area.
* ```NeedleInnerWeight```: Gets or sets the pixel weight (thickness) of the inner needle (clock hand) area.
* ```ShowInnerCutForPerformance```: Gets or sets a value indicating whether visual inner cut (slash) that represents performance will be drawn in the middle of the clock border.
* ```InnerCutPreformanceColor```: Gets or sets the color of the visual inner cut (slash) that represents performance in the middle of the clock border.
* ```InnerCutPerformanceWeight```: Gets or sets the weight (thickness) of the inner cut (slash) that represents performance in the middle of the clock border.
* ```BarFont```: Gets or sets the font of the text that describes the PercentOfGoals percentage.
* ```BarBackColor```: Gets or sets the performance bar background color.
* ```BarForeColor```: Gets or sets the performance bar font color.
* ```BarValueDigitsForeColor```: Gets or sets the font color of the bar's max(100%) and min(0%) lables.
* ```BarValueDigitsBackColor```: Gets or sets the background color of the bar's max(100%) and min(0%) lables.
* ```BarValueDigitsFont```: Gets or sets the font of the bar's max(100%) and min(0%) lables.

### WaitClock Class Methods and Properties
<img src="https://i.imgur.com/4Mdudcj.jpg"/>
<br/>

**Properties:** <br/>

* ```waitText```: Gets or sets the text at the middle of the clock. <br/>

**Methods:**<br/>

* ```SetArrayColors(ByVal arrayOfColors() As Color)```: Sets a series of colors that will change after each 360 deg rotation.



### Builet With
The .dll is written in VB.NET. <br/>
You can also use it with C# projects. <br/>
Two identical examples are added, for C# and for VB.NET. <br/>
This is an open source project: [Source Code](https://github.com/Jonathan435/Business-Clocks-Charts/tree/2.1)  
## Versioning:
We use [SemVer](http://semver.org/) for versioning.<br/>
GoalsClock base class has a ```Version``` constant field: use it to check the version number of the libary.

## Writing New BusinessClock Object
This section is still under construction, in a short period of time <br/>
You'll find here explanations and examples for developers who want to take part in the project and write their own clock charts.
## Authors
* **Jonathan Applebaum** - *Initial work* - [Jonathan435](https://github.com/Jonathan435)
<br/>
_______________________________________________________________________________________________________

## Advanced Exmples
<br/>


### Showing the user a ```WaitClock``` object while application is executing long task in the background using threads<br/>

**C# Code Example With Comments:**
```
/*
 **************************************************************************
 * AUTHOR: Jonathan Applebaum                                             *
 * DESCRIPTION: An example that describes how to use WaitClock object     *
 * from another thread in order to execute a long task in the beckground  *
 * DATE: 06/01/2017                                                       *
 * ************************************************************************
*/

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

namespace WindowsFormsApplication19
{
    public partial class Form1 : Form
    {

        private WaitClock waitClock;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // show wait clock on a different thread until LongTask finish executing
            System.Threading.Thread waitThread = new System.Threading.Thread(LoadWaitClock);
            waitThread.Start();
            // start a new thread to execute LongTask() parallel to the waitThread 
            System.Threading.Thread longTaskThread = new System.Threading.Thread(LongTask);
            longTaskThread.Start();

        }

        // put the code of your task that you want to execute in the background in that method
        private void LongTask()
        {
            // loop to represent a long task
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }

            // the "long task" inside the method finished to execute - dispose the wait clock from the GUI
            panel1.Invoke(new Action(waitClock.Dispose));
            // promt to screen
            label1.Invoke(new Action(NotifyTaskHasFinished));
        }

        private void LoadWaitClock()
        {
            // use action delegate to update GUI changes from another thread
            panel1.Invoke(new Action(AddClock));        
        }

        private void AddClock()
        {
            // configure and initilize the clock
            waitClock = new WaitClock(120, 120, "Loading...");
            waitClock.ClockBackGroundColor = Color.White;
            waitClock.FontColor = Color.Black;
            waitClock.Clock.Location = new Point(5, 5);
            waitClock.LoadFont("ARIAL", 8, FontStyle.Regular);
            waitClock.SetArrayColors(new Color[] { Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136), Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204) });
            waitClock.OuterCircleWeight = 8;
            waitClock.InnerCircleWeight = 5;
            waitClock.Create(true);
            this.panel1.Controls.Add(waitClock.Clock);
        }

        private void NotifyTaskHasFinished()
        {
            label1.Text = "LongTask() method has finished";
        }
    }
}

```
**Visual Basic.NET Code Example With Comments:**
```
' **************************************************************************
' * AUTHOR: Jonathan Applebaum                                             *
' * DESCRIPTION: An example that describes how To use WaitClock Object     *
' * from another thread in order to execute a long task in the beckground  *
' * DATE: 06/01/2017                                                       *
' * ************************************************************************
Imports BusinessClocks.ExecutiveClocks
Public Class Form1

    Private waitClock As WaitClock
    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim waitThread As System.Threading.Thread = New System.Threading.Thread(AddressOf LoadWaitClock)
        waitThread.Start()
        Dim longTaskThread As System.Threading.Thread = New System.Threading.Thread(AddressOf LongTask)
        longTaskThread.Start()
    End Sub

    Private Sub LongTask()
        For i As Integer = 0 To 9
            System.Threading.Thread.Sleep(1000)
        Next

        Panel1.Invoke(New Action(AddressOf waitClock.Dispose))
        Label1.Invoke(New Action(AddressOf NotifyTaskHasFinished))
    End Sub

    Private Sub LoadWaitClock()
        Panel1.Invoke(New Action(AddressOf AddClock))
    End Sub

    Private Sub AddClock()
        waitClock = New WaitClock(120, 120, "Loading...")
        waitClock.ClockBackGroundColor = Color.White
        waitClock.FontColor = Color.Black
        waitClock.Clock.Location = New Point(5, 5)
        waitClock.LoadFont("ARIAL", 8, FontStyle.Regular)
        waitClock.SetArrayColors(New Color() {Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136), Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204)})
        waitClock.OuterCircleWeight = 8
        waitClock.InnerCircleWeight = 5
        waitClock.Create(True)
        Me.Panel1.Controls.Add(waitClock.Clock)
    End Sub

    Private Sub NotifyTaskHasFinished()
        Label1.Text = "LongTask() method has finished"
    End Sub

End Class
```

## More Graphical Examples of use<br/>


### Company Sales Dashboard<br/>

<img src="https://i.imgur.com/yB0mXFW.jpg"/>

### Company Operation Dashboard<br/>
<img src="https://i.imgur.com/4GwTajd.jpg"/>
