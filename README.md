![Pic](https://github.com/RedRockControls/tcl_TwinCAT_UnitTestLibrary/blob/main/img/Banner.JPG)

# TwinCAT_UnitTestLibrary

TwinCAT_UnitTestLibrary is a lightweight unit test library for testing TwinCAT3 source code - 
See [A TwinCAT Unit Test Library](https://www.redrockcontrols.co.uk/?p=809)


 It has been written with the following goals in mind:

1. Minimum setup cost for a new test.

	A test is defined in a function block that implements I_UnitTestBase. This interface defines a method called RunTest which returns TestCompleted and TestFailed booleans. A base class T_UnitTestBase is provided to allow a test to be defined by extending it. Assert functions are used to determine the correctness of the test, and to output messages to the error window should they fail

2. Runnable Test Suites can be defined containing related tests. 

	A test suite contains a test runner to form a self contained, runnable class. This allows the tests defines in a library to be run either in the library during development, or in the client project during application development. This enables the tests to be run against the library versions and hardware platform to be used in the application.

3. Tests are run automatically on online-change to provide fast feedback during test-driven development.



To create a test:
* Create a unit test function block that inherits from T_UnitTestBase
* Create a test suite function block that will contain the test(s) and test runner
* Add an instance ot T_TestRunner to the test suite
* Add an instance of the unit test function block to the test suite
* Call TestRunner() in the body of the test suite
* Execute the test suite somewhere

The library contains unit tests that can be used as examples of how to use the library.

NOTE: Due to an apparent bug in how nested function blocks are initialised, when tests are added to a test suite, online change is not possible so the code must be re-downloaded to the runtime. 
