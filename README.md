![Pic](https://github.com/RedRockControls/tcl_TwinCAT_UnitTestLibrary/blob/main/img/Banner.JPG)

# TwinCAT_UnitTestLibrary

TwinCAT_UnitTestLibrary is a lightweight unit test library for testing TwinCAT3 source code - 
See [A TwinCAT Unit Test Library](https://www.redrockcontrols.co.uk/?p=809)

 It has been written with the following goals in mind:

1. Minimum setup cost for a new test - a test is defined in a function block that extends T_UnitTestBase by implementing the RunTest method. Assertion methods are used to determine the correctness of the test and to output messages to the error window should they fail

2. Tests are run automatically on online-change to provide fast feedback during test-driven development.
   
3. Tests can be re-run by writing to the Retest flag
         

To create a test:

* Create a function block that inherits from T_UnitTestBase
* Add a RunTest method to perform the required test using assertion methods to verify correct operation
* Execute the unit test somewhere

The following is a recommended template for the RunTest method:


```
METHOD RunTest
IF Retest THEN
    SUPER^.Init(); // this will clear the TestCompleted flag, causing the test to be executed again...
END_IF

IF TestCompleted THEN
    RETURN; // execute no more test code...
END_IF

// Actual test code - for example:
CRC := F_CalculateCrc('Some Text');
AssertEquals_BYTE(Expected:= 16#3F, Actual:= CRC, Message:= 'Calculated CRC is incorrect'); 
TestCompleted := TRUE;
```


Code automatically formatted using

![StweepLogo](https://github.com/RedRockControls/tcl_TwinCAT_UnitTestLibrary/assets/32986382/2181db31-3c1e-449d-b568-c7b0ed50b36d)


