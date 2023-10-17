# CodingTracker


Console based CRUD application to track time spent on coding.
Developed using C#, .NET and SQLite.


# Given Requirements:
- [x] To show the data on the console, you should use the "ConsoleTableExt" library.
- [x] You're required to have separate classes in different files (ex. UserInput.cs, Validation.cs, CodingController.cs)
- [x] You should tell the user the specific format you want the date and time to be logged and not allow any other format.
- [x] You'll need to create a configuration file that you'll contain your database path and connection strings.
- [x] You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration
- [x] The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.
- [x] The user should be able to input the start and end times manually.
- [x] When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.


# Features

* SQLite database connection

	- The program uses a SQLite db connection to store and read log information.
	- Database and table will be created if they do not exist.

* A console based UI where users can navigate by key presses
 

* CRUD DB functions

	- From the main menu users can Create, Read, Update or Delete log entries.




# Challenges
	
- How to set up and structure the project with good code and folder structure/organization.
- How to handle validation and user input.
- How to handle datetime format.
	
# Lessons Learned
- Before starting to code, plan the project by writing down entities and methods. Create a basic flowchart of how the program flows. 
- Create a new git branch for each new feature. 
- Seperate the code with classes and methods.
- Create a seperate playground project to play around with new code.

# Areas to Improve
- I want to improve the code by reading up on seperation of conerns.
- I Want to learn more about testing, i.e Unit testing. 


# Resources Used
- Google
- Stackoverflow
- Microsoft documentation
