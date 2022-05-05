## Meetup-CRUD-API


Meetup-CRUD-API is an API that works like CRUD app with Bearer authentication.UI built on the basis of Swagger.

- Start the application 
- Register as user or admin
- Login with these credentials 
- Receive your JWT-Token for authentication
- Pass it in the "Authorization" field 
- ✨Magic ✨

## Tech

Meetup API was based on the following technologies 

- [C#] - Programming language
- [Asp.Net Core] - Web framework
- [Web-API] - Application programming interface
- [Indentity] - Is an API that supports user interface (UI) login functionality.
- [Entity Framework] - EF Core is a modern object-database mapper for .NET
- [MS SQL Server] - Relational database management system developed by Microsoft 
- [Swagger] - Simplify API development for users, teams, and enterprises with the Swagger open source and professional toolset

## Installation

Meetup-API requires [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to run.

Download the project from the [GitHub](https://github.com/Goj1ra/Meetup-CRUD-API)

Than you need to create the DB with the EF Core migration. Type into the package manager console
```sh
add-migration initial
update-database
```

And then in the appsettings.json change the connection strings and pass your path to the database
```
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MeetupApp;Trusted_Connection=True;"
  }
```


## License

Artem Starchenko

**Free Software, Hell Yeah!**
