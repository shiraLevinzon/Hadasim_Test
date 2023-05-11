# Hadasim Test
Repository for hadasim 3 program
## Project Name: part1.py
Rectangle and Triangle Calculator
This is a Python program that calculates and prints the perimeter and area of a rectangle and the perimeter of a triangle, as well as a triangle built from asterisks according to a specific format. This program does not use any special libraries.

### Getting Started
To run this program, you need to have Python installed on your computer. You can download and install the latest version of Python from the official website: https://www.python.org/downloads/

Once Python is installed, you can download the source code of this program from our GitHub repository.

### Running the Program
Open your terminal or command prompt. Navigate to the directory where you saved the source code using the cd command. Type python main.py to run the program.
Another way: download and install the Python interpreter on your computer.
Run the program and follow the instructions that will be printed in the run window.

## Project Name: Part2

### ServerSide 
ASP.NET WEB CORE API with SQL Server Database
This is a server-side project made in Visual Studio using the ASP.NET WEB CORE API framework in C#. The project includes a SQL Server database and uses the SQLClient package to establish a connection between the application and the database. The project supports HTTP requests sent to different routes.

#### Prerequisites
Visual Studio 2022.
.NET Core 6.0.
SQL Server Management Studio.
SQL Server Database.
#### Getting Started
Clone the repository to your local machine.
Open the project in Visual Studio.
Create a SQL Server database and update the connection string in Controllers > MemberController >constructor to point to your database.
Run the project.
Once the project is running, open your web browser and navigate to http://localhost:7028/swagger. This will open the Swagger UI, where you can test the API endpoints and check the health of the server.

Another way to run: with the help of ClientSide (detailed below).

#### Project Structure
The project follows the standard structure of an ASP.NET WEB CORE API project. The main components are:

Controllers: This folder contains the Member controller class that handle the HTTP requests.

Models: This folder contains the data models- Member and Vaccine that used in the application.

Data: This folder contains the database context and the data access classes.

#### API Endpoints
The project supports the following HTTP requests:

GET /api/member: Returns a list of all members in the database.

GET /api/member/{id}: Returns the details of the member with the specified ID.

POST /api/member: Adds a new member to the database.

GET /api/member/getVaccinesById/{id}: Returns the details of the member vaccines with the specified member ID.

POST /api/member/AddVaccine: Adds a new vaccine to the database.


#### Technologies Used
ASP.NET WEB CORE API
C#
SQL Server
SQLClient package

#### Bonus
In the bonus folder you can find a Windows Form Application project, update the connection string in Form1> Form1_Load to point to your database
After runing Bonus.sln file, a form will be displayed showing the number of patients who were active each day in the last month - displayed as a graph, and how many members of the coffers are not vaccinated at all.

#### Note:
to initialize a date as null, you must fill in the year in the date field to 9999.

### ClientSide
This project is a client-side application that allows users to send HTTP requests. It was built using Visual Studio WPF in C#. The project includes the Member and Vaccine classes, and the code uses HttpClient for sending HTTP requests. It is important to note that this project runs efficiently for normal requests only.

#### Getting Started
To use this application, you will need to have Visual Studio installed on your computer. Once you have Visual Studio installed, you can open the project by opening the solution file (.sln) in Visual Studio.

#### Usage
To use the application, follow these steps:

Open the application in Visual Studio.
Build and run the project.
Maximize the window.

Click the Show Members button see the members list.

To see the list of vaccinations for a certain ID, fill in the text box that appears above and click on the Show Vaccinations button.

To see a member using his ID, fill in the textbox that appears above and click on the Show Member button.

To add a new member, enter data in the text boxes on the lower left and click on the Add Member button.

To insert a new vaccine, enter data into the textboxes in the middle below and click on the Add Vaccine button

#### Note: 
This application was designed to provide a more convenient user interface than the swagger tool and not provide accurate information to find out the various problems.

### Ex 2 part 2
A word file that includes 2 parts - RR document and test document.




# Authors
Shira Levinzon 212829865
# Acknowledgements
I would like to thank Hadasim 3 team.
