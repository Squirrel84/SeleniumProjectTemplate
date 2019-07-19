# SeleniumProjectTemplate
initial startup project for selenium tests

## Quick FAQ
### Frameworks?
.Net Core 2.2
XUnit
Selenium

### Won't Compile
You must select a build configuration (See Step 8)

### No Tests
There are no tests out of the box, you must create your own (See Step 5,6,7)
Inherit from *UITestBase* for easier support
Remember to use the attribute _[Fact]_ or _[Theory]_ for tests to be detected.

### Test Browsers
I have created web drivers for IE, Firefox and Chrome.

## Setup Walkthrough (12 Steps)

### Step 1
After cloning the repo, you can either just use the already created packaged zip (**recommended**) or create a project template from the project. 
Once you have a zip file you can then drop this in the _Visual Studio Template Project Folder_.
Format: ![Step1](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step1_PlaceZippedProject.png)

### Step 2
Start Visual Studio (_visual studio must be restarted to detect changes_)
Select to start a new project and use the search bar to search for "Selenium"
Format: ![Step2](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step2_StartNewProject_LookFor_Selenium.png)

### Step 3
Name your project as usual
Format: ![Step3](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step3_NameNewProject.png)

### Step 4
You will now be presented with a blank project with all the required nuget packages required for Selenium tests.
There is also a skelaton structure setup with base code to instantiate web drivers.
Format: ![Step4](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step4_CheckNugetPackages_InspectBaseClass.png)

### Step 5
To get started, just create a new code file
![Step5](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step5_CreateFirstTest.png)

### Step 6
Naming it as usual
![Step6](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step6_NameFirstTestClass.png)

### Step 7
Then write your first test (_ensure to inherit from *UITestBase*_)
![Step7](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step7_FirstTestCode.png)

### Step 8
Before it will compile, you must select the browser you wish to use.
This is done using *Build Configurations*.
![Step8](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step8_SelectBrowser_BuildConfiguration.png)

### Step 9
Navigate to the Test Explorer, this will list all tests within the project/solution.
![Step9](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step9_Open_TestExplorer.png)

### Step 10
If nothing is showing, ensure you have tagged all your test methods with either _[Fact]_ or _[Theory]_
![Step10](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step10_FindAndRunTests.png)

### Step 11
Run the test and see what happens.
A browser instance should be started by the Selenium framework and test gets executed.
Results of test shown in the test explorer
![Step11](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step11_SeeTestResults.png)

### Step 12
After debugging tests (using the same context menu to run tests), spotted that the text is empty for input control.
Changed to use GetAttribute method of Value and then re-ran the tests.
![Step12](https://github.com/Squirrel84/SeleniumProjectTemplate/blob/master/Setup_Step_Images/Step12_DiagnoseAndResolveTests.png)

#Enjoy
