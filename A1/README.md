# CSCI5308_Assignments
# Assignment 1

Assignment1 is developed using C# .NET Technology using Visual Studio IDE. This console application accepts input XML path, Output XML path and generates the corresponding XML response in the output path. </br>

## Reference Packages

**DotNet Framework** The application uses .Net Framework 4.6.1

**Unity** NuGet package downloadable from Visual Studio. Employed for Dependency Resolution ( loose coupling ) 

**Visualstudio TestTools UnitTesting** For unit testing purposes.

**Moq** This support library is used to mock methods for implementing unit test cases.


## Folder Structure And Description

* Under A1 folder, FirstAssignment folder consists of first assignment and assignment test projects.</br>
* Under A1 folder, InputFiles folder consist of the different types of input files that could be given to the application. </br>
* IncomingOrder.xml consists of the valid xml that consists of valid attributes. </br>
* IncomingOrder_NotAuthorized.xml consists of invalid dealerid and accesskey attributes.  </br>
* IncomingOrder_validation.xml consists of emoty part number attribute.  </br>
* Each of these files get loaded in the application and validated with hard coded data objects and generate xml response.</br>
* Once the application starts running, input and output file path is mentioned in the terminal and the process is executed.</br>

## Instructions to run the program

* Please start the application.</br>
* In the terminal, please provide input xml and output xml file path. </br>
* Please run the test cases present in FirstAssignmentTest project</br>


## Sources

[1]"Dependency Injection using Unity container - CodeProject", Codeproject.com, 2018. [Online]. Available: https://www.codeproject.com/Articles/988257/Dependency-Injection-using-Unity-container. [Accessed: 01- Jun- 2018].

[2]A. Trainer, "KickStart your Unit Testing using Moq - CodeProject", Codeproject.com, 2018. [Online]. Available: https://www.codeproject.com/Articles/796014/KickStart-your-Unit-Testing-using-Moq. [Accessed: 01- Jun- 2018].
