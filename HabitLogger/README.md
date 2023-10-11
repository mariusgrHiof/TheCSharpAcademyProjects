# HabitLogger


Console based CRUD application to track time spent on learning C#.
Developed using C#, .NET and SQLite.


# Given Requirements:
- [x] This is an application where you’ll register one habit.
- [x] This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
- [x] The application should store and retrieve data from a real database
- [x] When the application starts, it should create a sqlite database, if one isn’t present.
- [x] It should also create a table in the database, where the habit will be logged.
- [x] The app should show the user a menu of options.
- [x] The users should be able to insert, delete, update and view their logged habit.
- [x] You should handle all possible errors so that the application never crashes.
- [x] The application should only be terminated when the user inserts 0.
- [x] You can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.

# Features

* SQLite database connection

	- The program uses a SQLite db connection to store and read log information. 
	- Database and table will be created if they do not exist.

* A console based UI where users can navigate by key presses
 

* CRUD DB functions

	- From the main menu users can Create, Read, Update or Delete log entries.




# Challenges
	
- How to set up and structure the project with good code and folder structure/organization.
- how to handle validation and user input.
	
# Lessons Learned
- Before starting to code, plan the project by writing down entities and methods. Create a basic flowchart of how the program flows. 
- Create a new git branch for each new feature. 
- Seperate the code with classes and methods.

# Areas to Improve
- I want to improve the code by reading up on seperation of conerns.
- I Want to learn more about testing, i.e Unit testing. 


# Resources Used
- Google
- Stackoverflow
- Microsoft documentation
