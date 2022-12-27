![Pic](https://github.com/RogerChristopher/tcl_TwinCAT_UnitTestLibrary/blob/main/img/Banner.JPG)

# TwinCAT_UnitTestLibrary

TwinCAT_UnitTestLibrary is a lightweight unit test library for testing TwinCAT3 source code with the following goals:

1. Impose minimum setup cost for a new test.

	A test is defined in a function block that implements I_UnitTestBase. This interface defines a method called RunTest which returns TestCompleted and TestFailed booleans. A base class T_UnitTestBase is provided to allow a test to be defined by extending it. Assert functions are used to determine the correctness of the test, and to output messages to the error window should they fail

2. Runnable Test Suites can be defined containing related tests. 

	A test suite contains a test runner to form a self contained, runnable class. This allows the tests defines in a library to be run either in the library during development, or in the client project during application development. This allows the library to be tested against the  library versions and hardware platform to be used in the application.

3. Tests are run automatically on online-change to provide fast feedback during test-driven development.



To create a test:
* Inherit from a base class
* Create an instance in a test suite
* Execute the test suite somewhere
* Results are posted in the error window of Visual Studio

The library contains unit tests that can be used as examples of how to use the library.

NOTE: Due to restrictions on what can be executed in the FB_Init method by the AuxPlc task, when tests are added to a test suite, online change is not possible so the code must be re-downloaded to the runtime. 
