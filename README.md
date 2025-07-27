# Person Web API

This is a simple ASP.NET Core Web API project that provides basic **CRUD (Create, Read, Update, Delete)** operations for managing `Person` entities.


##  Features

- Create a new person
- Retrieve a list of people or a single person by ID
- Update an existing person's details
- Delete a person


##  Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- Follows **Clean Architecture** principles
- Proper use of **Dependency Injection**
- SQL Server
- C#


- ##  Endpoints

| Method | Endpoint           | Description         |
|--------|--------------------|---------------------|
| GET    | `/api/persons`     | Get all persons     |
| GET    | `/api/persons/{id}`| Get person by ID    |
| POST   | `/api/persons`     | Create a new person |
| PUT    | `/api/persons/{id}`| Update a person     |
| DELETE | `/api/persons/{id}`| Delete a person     |
