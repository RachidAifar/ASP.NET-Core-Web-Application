# ASP.NET Core Web Application With SQL Server Database
This is a web application built with ASP.NET Core and SQL Server for managing clients. The application allows users to create, read, update, and delete client information.

## Getting Started

### Prerequisites

- .NET Core 3.1 SDK or later
- Visual Studio 2019 or later or Visual Studio Code

### Installation

1. Clone the repository to your local machine:
git clone https://github.com/RachidAifar/ASP.NET-Core-Web-Application.git
2. Open the solution file (`Stor_App.sln`) in Visual Studio or Visual Studio Code.

3. Build the solution to restore NuGet packages:
dotnet build
4. Update the database:
This will create a new database with the name `ClientAppDb` in your local SQL Server instance.

5. Start the application:
dotnet run

the application will start running on `http://localhost:5000` or `https://localhost:5001` (if using HTTPS).

## Features

- CRUD operations for clients
- Search and filter clients by name, email
- Pagination for displaying clients in a table

## Built With

- ASP.NET Core
- Entity Framework Core
- SQL Server

## Contributing

Contributions are always welcome! If you have any suggestions or find any bugs, please create an issue or submit a pull request.





