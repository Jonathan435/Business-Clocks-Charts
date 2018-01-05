# Speedometer Designed Charts
Welcome to Graphical Winforms Clock Charts libary, the main purpose of this project is to provide graphical clock-like objects that winforms developers can use to builed applications that needs added value to present data (company dashboard for example).
each clock object has a variety of properties, used for customization clocks can include animation when refreshing or loading.

<img src="http://i.imgur.com/EdsyThw.png"/>
<br/>

<img src="http://i.imgur.com/EgrLU9t.png"/>
<br/>

#### Getting Started

Dowonload the last version of BusinessClocks.dll to your local computer.
<br/>you can always find the last version in master branch of the repository.<br/>
load the .dll to your winforms project using Visual Studio.<br/>

**Instructions to load dll into your project:**<br/>
* Open Reference form: right click on your project in the Solution Explorer >> Add >> Reference. 
* Click the "Browse" button and navigate to the dll path and press OK.
* When you do this, by default the DLL is copied and included in the project's output.
<br/>
<img src="https://i.imgur.com/3zbMo8w.png"/>
<br/>

### Basic Usage

* Create a new winforms project with visual studio. 
* Reference BusinessClocks.dll (as explained above).
* Add an Using(C#) steatment or Imports(VB.NET) steatment to the namespace ```BusinessClocks.ExecutiveClocks```
in the top of Form1 File.
* Copy&paste the example with your prefered programming language to Form1 class.
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

        private BusinessClocks.ExecutiveClocks.CarClock CarClock;
        private GoalsClock GoalsClock;
        private WaitClock WaitClock = new WaitClock(150, 150, "Loading...");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarClock = new BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8F, true);
            CarClock.ShowInnerCutForPerformance = false;
            CarClock.BarBackColor = Color.Pink;
            CarClock.Create(true);
            this.Controls.Add(CarClock.ClockPanel);
            GoalsClock = new GoalsClock(200, 200, 0.8F);
            GoalsClock.Create(true);
            GoalsClock.Clock.Location = new Point(0, CarClock.ClockPanel.Location.Y + CarClock.ClockPanel.Height + 5);
            this.Controls.Add(GoalsClock.Clock);
            WaitClock = new WaitClock(150, 150, "Loading...");
            WaitClock.Clock.Location = new Point(0, GoalsClock.Clock.Location.Y + GoalsClock.Clock.Height + 5);
            WaitClock.LoadFont("ARIAL", 8, FontStyle.Regular);
            WaitClock.setArrayColors(new Color[] { Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136), Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204) });
            WaitClock.OuterCircleWeight = 8;
            WaitClock.InnerCircleWeight = 5;
            WaitClock.Create(true);
            this.Controls.Add(WaitClock.Clock);
        }
    }
}

```
**Visual Basic.NET Test Example**

```
Imports BusinessClocks.ExecutiveClocks

Public Class Form1

    Private CarClock As BusinessClocks.ExecutiveClocks.CarClock
    Private GoalsClock As GoalsClock
    Private WaitClock As New WaitClock(150, 150, "Loading...")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' car clock (with precentage bar)
        CarClock = New BusinessClocks.ExecutiveClocks.CarClock(300, 150, 0.8, True)
        CarClock.ShowInnerCutForPerformance = False
        CarClock.BarBackColor = Color.Pink
        CarClock.Create(True)
        Me.Controls.Add(CarClock.ClockPanel)
        ' goals clock
        GoalsClock = New GoalsClock(200, 200, 0.8)
        GoalsClock.Create(True)
        GoalsClock.Clock.Location = New Point(0, CarClock.ClockPanel.Location.Y + CarClock.ClockPanel.Height + 5)
        Me.Controls.Add(GoalsClock.Clock)
        ' waitclock
        WaitClock = New WaitClock(150, 150, "Loading...")
        WaitClock.Clock.Location = New Point(0, GoalsClock.Clock.Location.Y + GoalsClock.Clock.Height + 5)
        WaitClock.LoadFont("ARIAL", 8, FontStyle.Regular)
        WaitClock.setArrayColors(New Color() {Color.FromArgb(0, 100, 100), Color.FromArgb(0, 136, 136) _
                                     , Color.FromArgb(0, 170, 170), Color.FromArgb(0, 204, 204)})
        WaitClock.OuterCircleWeight = 8
        WaitClock.InnerCircleWeight = 5
        WaitClock.Create(True)
        Me.Controls.Add(WaitClock.Clock)
    End Sub

End Class
```
### Base Class (GoalsClock) Methods and Properties
_**Note:** All clocks (WaitClock and CarClock for now) inherits GoalsClock_
<br/><br/>
**Properties:**
* ```Clock:``` UNDER CONSTRACTION...
* ```ClockWidth```: UNDER CONSTRACTION...
* ```ClockHeight```:
* ```xPos``` and ```Ypos```: UNDER CONSTRACTION...
* ```ClockBackGroundColor```: UNDER CONSTRACTION...
* ```FontColor```: UNDER CONSTRACTION...
* ```ClockFont```: UNDER CONSTRACTION...
* ```InnerCircleColor```: UNDER CONSTRACTION...
* ```InnerCircleWeight```: UNDER CONSTRACTION...
* ```OuterCircleColor```: UNDER CONSTRACTION...
* ```OuterCircleWeight```: UNDER CONSTRACTION...
* ```PercentOfGoals```: UNDER CONSTRACTION...
* ```GoalsPercentDecimalValue```: UNDER CONSTRACTION...
* ```AnimationLength```: UNDER CONSTRACTION...
* ```TimerAnimatiom```: UNDER CONSTRACTION...
* ```TimerInterval```: UNDER CONSTRACTION...

**OverLoaded Constructors:**

**Methods:**

* ```Create(ByVal AnimateClock As Boolean)```: UNDER CONSTRACTION... 
* ```RefreshClock(ByVal AnimateClock As Boolean)```: UNDER CONSTRACTION...
* ```Dispose()```: UNDER CONSTRACTION...

### CarClock Class Methods and Properties

**Properties:**
* ```ClockPanel```: UNDER CONSTRACTION...
* ```LowPerformance```: UNDER CONSTRACTION...
* ```MediumPerformance```: UNDER CONSTRACTION...
* ```HighPerformance```: UNDER CONSTRACTION...
* ```HighPerFormanceColor```: UNDER CONSTRACTION...
* ```MediumPerFormanceColor```: UNDER CONSTRACTION...
* ```LowPerFormanceColor```: UNDER CONSTRACTION...
* ```NeedlePanel```: UNDER CONSTRACTION...
* ```NeedleOuterColor```: UNDER CONSTRACTION... 
* ```NeedleWeight```: UNDER CONSTRACTION...
* ```NeedleBaseOuterColor```: UNDER CONSTRACTION...
* ```NeedleBaseWeight```: UNDER CONSTRACTION...
* ```NeedleInnerColor```: UNDER CONSTRACTION...
* ```NeedleInnerWeight```: UNDER CONSTRACTION...
* ```ShowInnerCutForPerformance```: UNDER CONSTRACTION...
* ```InnerCutPreformanceColor```: UNDER CONSTRACTION...
* ```InnerCutPerformanceWeight```: UNDER CONSTRACTION...
* ```BarFont``` (field): UNDER CONSTRACTION... 


**Constructors:**
* ```New(ByVal clockWidth As Int16, ByVal clockHeight As Int16, ByVal GoalsPercent As Single, Optional AddBaseBar As Boolean = False)```: UNDER CONSTRACTION...


### WaitClock Class Methods and Properties
**Properties:**
```waitTex```t: UNDER CONSTRACTION...
**Constructors:**
* ```New(ByVal clockWidth As Int16, ByVal clockHeight As Int16, ByVal waitText As String)```: UNDER CONSTRACTION...
**Methods:**
* ```SetArrayColors(ByVal arrayOfColors() As Color)```: UNDER CONSTRACTION...



### Builet With
The DLL is written in VB.NET. <br/>
you can use it also with C# projects. <br/>
two identical examples are added, for C# and for VB.NET. <br/>

## Versioning:
We use [SemVer](http://semver.org/) for versioning.<br/>
GoalsClock base class has a ```Version``` constant field: use it to check the version number of the libary.

## Writing New BusinessClock Object
UNDER CONSTRACTION...
## Authors
* **Jonathan Applebaum** - *Initial work* - [Jonathan435](https://github.com/Jonathan435)



