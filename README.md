# part-3-POE
# RaceDay – Part 3
## ASP.NET Core MVC Web Application

1. Project Overview

RaceDay is a sporting event management web application designed for the South African running, walking and cycling community.

The application allows participants to view sporting events and manage their participation, while organisers can manage events and monitor participant enrolments.

The MVC application communicates with the RaceDay RESTful Web API developed in Part 2. The API handles data operations and communicates with the SQL Server database.

2. Technologies Used

- C#
- ASP.NET Core MVC (.NET 8)
- ASP.NET Core Web API
- SQL Server LocalDB
- HTML and CSS
- Bootstrap
- JavaScript
- Visual Studio
- Docker

 3. Project Structure

The solution contains two main projects:

Part 2
- ASP.NET Core Web API.
- Handles authentication and data operations.
- Communicates with the SQL Server database.
- Provides endpoints for events, categories, enrolments and performance records.

raceDayMVc
- ASP.NET Core MVC web application.
- Provides the user interface.
- Communicates with the Part 2 API using HttpClient.
- Uses session management for authentication and role-based navigation.

4. Main Features
 Authentication
- User registration.
- User login.
- Participant and Organiser roles.
- Session-based authentication.
- Logout functionality.

Participant Features
- Browse sporting events.
- View available events.
- Access a participant dashboard.
- View personal enrolments and performance history where implemented.

 Organiser Features
- Access an organiser dashboard.
- View and manage sporting events.
- Add new events.
- Edit existing events.
- Delete events.
- View participant enrolments.

 Event Management
- Display available sporting events.
- Search events by name.
- Retrieve event information through the API.

 5. Database Connection

The application uses SQL Server LocalDB.

Database name: `raceday`

Database connection used by the Part 2 API:

`(localdb)\api_guide`

The MVC project does not connect directly to the database. All database operations are handled through the Part 2 Web API.

 6. Running the Application

To run the application locally:

1. Open the RaceDay solution in Visual Studio.
2. Start the Part 2 Web API project using its normal HTTPS launch profile.
3. Confirm that the API is running and Swagger is accessible.
4. Start the raceDayMVc project using its normal HTTPS launch profile.
5. Open the MVC application in your browser.

The configured local addresses are:

- API: `https://localhost:7296/`
- MVC: `https://localhost:7014/`

Both projects must be running for the MVC application to retrieve information from the API.

 7. API Communication

The MVC application uses an HttpClient service named `RaceDayAPI` to communicate with the Part 2 API.

The service handles requests such as:

- Retrieving events.
- Adding events.
- Updating events.
- Deleting events.
- User registration and login.
- Retrieving participant enrolments.
- Retrieving performance records.

8. Docker

Docker containerisation is part of the Part 3 requirements.

The project includes Docker configuration files. Docker Desktop is required to build and run the containers.

The application can currently be run locally through Visual Studio without Docker. Full container testing and the final Docker run command remain to be completed.



 10. Conclusion

RaceDay Part 3 extends the RaceDay Web API by providing an ASP.NET Core MVC user interface. It uses session-based authentication, role-specific navigation and API communication to support sporting event management.

The application is designed to provide a simple and accessible platform for participants and organisers.
