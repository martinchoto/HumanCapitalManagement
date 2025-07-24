# Human Capital Management

A small‑business HR management web application built with ASP.NET Core MVC and Entity Framework Core.

HumanCapitalManagement is a Blazor Server web application for managing a small company’s HR tasks. It provides interfaces for handling employees and departments, along with authentication and role-based access control (e.g. “Manager” and “HR Admin” roles)

. The app uses an ASP.NET Core backend with Entity Framework Core (SQL Server) for data storage, and integrates ASP.NET Core Identity for user authentication and role management

. In short, it aims to help a company’s HR department administer staff information, departments, and salary records in one place.

Features and Functionality
Employee Management: HR Admins can add, edit, and delete employee records, including their personal details and salary history. Employees can view their personal page (via the Personal page) but cannot access other employees’ data.
Department Management: Managers and HR Admins can create, update, list, and delete departments. Each department can list its assigned employees.
Authentication & Roles: Uses ASP.NET Core Identity with role-based authorization. There are two main roles: HR Admin (can manage all employees and salary records) and Manager (can view and manage their own department’s employees)

. The app enforces these roles on API endpoints and pages via [Authorize] attributes.
Blazor UI: The front-end is built with Razor Components (Blazor Server), providing SPA-like interactivity. Key UI components include login/logout forms, a shared layout with navigation, and pages for Departments, Employees, and HR functions.
Technology Stack
.NET 8 / C#: The project targets .NET 8.0, using modern C# features and the minimal hosting model (see Program.cs)

Blazor Server: UI is implemented with Blazor server-side components (Razor .razor files in the Components folder).
ASP.NET Core Identity: Authentication and authorization are handled by Identity Core with Entity Framework stores.

Entity Framework Core (EF Core) + SQL Server: Data access is via EF Core. The default database provider is SQL Server, configured with a connection string named "DefaultConnection"

Dependency Injection: Follows ASP.NET Core DI conventions. Services like IEmployeeService, IHRService, and RoleService are registered in Program.cs and injected into controllers and components.
REST API: Controllers under Controllers/ (e.g. DepartmentController, HRController) expose JSON APIs for client-side calls (mapped via MapControllers() in Program.cs).
Folder and Code Structure
The project’s files are organized as follows:
HumanCapitalManagement/ – The main project folder.
Components/ – Blazor UI components.
Account/Pages/ – Login (and originally Register) pages for user authentication.
Layout/ – Shared layout components (e.g. MainLayout.razor, NavMenu.razor).
Pages/ – Razor pages for core features:
Departments/ – Pages to add/edit departments and list departments and their employees (AddDepartment.razor, AllDepartments.razor, EditDepartment.razor, Employees.razor, etc.).
Employee/ – Contains Personal.razor for an employee’s personal profile.
HR/ – HR admin pages (AllEmployees.razor, HrAdd.razor, HrEdit.razor) for listing and managing all employees and salaries.
Home.razor – Landing/home page.
App.razor – Application root component.
Controllers/ – API controllers (e.g. DepartmentController.cs, HRController.cs). These use [ApiController] and [Authorize] to enforce role-based access

Data/ – (Likely) contains the EF Core DbContext and entity models (e.g. Employee, Department, SalaryRecord).
DTOs/ – Data Transfer Objects used by controllers and services (AddDepartmentDTO.cs, AddEmployeeDTO.cs, SalaryRecordDTO.cs, etc.).
Services/ – Business logic classes.

Interfaces/ – Service interfaces (e.g. IEmployeeService, IHRService).

Concrete service implementations (e.g. EmployeeService.cs, HRService.cs) that perform data operations via the DbContext.

Other files: Program.cs (application setup), _Imports.razor, CSS files, etc. The .csproj file (project definition) targets .NET 8 and references necessary NuGet packages.


Setup and Installation
Prerequisites:
Install .NET 8.0 SDK.
A SQL Server instance (e.g. localdb or SQL Server Express).
An IDE or editor (Visual Studio 2022/2023 or VS Code recommended).


Clone the repository:
git clone https://github.com/martinchoto/HumanCapitalManagement.git
cd HumanCapitalManagement
Configure the database:
Open appsettings.json (or appsettings.Development.json) in the project and set the "DefaultConnection" string to point to your SQL Server database. For example:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HumanCapitalDB;Trusted_Connection=True;"
}
Build the project:
Using the command line: dotnet build.
Or open the .sln or .csproj in Visual Studio and restore NuGet packages.
Apply Migrations:
The project uses Entity Framework Core for data access. If migrations are not included, create and apply them:
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
This creates the database schema based on the DbContext and entity models.
Seed Roles and Users (Optional):
The app expects roles "HR Admin" and "Manager" as shown in the controllers.


You may need to create these roles (e.g. via a data seeder or Identity console) and assign them to user accounts.
By default, the Register page was removed (see Components/Account), so new users must be added either through a database script or from HR Manager account.

Running Locally
Once running, the Blazor server app will serve UI pages and expose API endpoints under /api/. Use the navigation menu to access features:
Home: Landing page.
Departments: For managing departments (add, list, edit).
HR: (Visible to HR Admin only) for managing all employees and salaries.
Employee Personal: (Visible to authenticated employees) for viewing/editing their own data.
Account: Links for logging in/out.
Backend endpoints (for reference):
GET /api/Department/all – List all departments.
POST /api/Department/create – Create department.
GET /api/Department/employees – Get employees of current user’s department.
PUT /api/Department/update/{id} – Update department.
DELETE /api/Department/delete/{id} – Delete department.
PUT /api/Department/edit/{id} – Get or save edited employee data.
GET /api/HR/all – List all workers (HR Admin).
POST /api/HR/add – Add an employee (HR Admin).
PUT /api/HR/edit/{id} – Edit an employee (HR Admin).
DELETE /api/HR/delete/{id} – Delete an employee (HR Admin).
GET /api/HR/salaries/{employeeId} – Get salary records (HR Admin).
POST /api/HR/salary/add/{employeeId} – Add a salary record (HR Admin).
These endpoints are secured with [Authorize] attributes, enforcing that only users in the specified roles can call them


Database and Migrations
The application uses EF Core to interact with the database. The default connection string is "DefaultConnection", and SQL Server is configured in Program.cs (e.g. options.UseSqlServer(connectionString)). 

If database migrations are not included, you must add them using the EF Core CLI as shown above. After updating the database, the necessary tables (users, roles, employees, departments, salary records, etc.) will be created.
Tip: In development, the app is configured to use the Developer Exception Page and database error pages (UseMigrationsEndPoint) when in a development environment


Authentication and User Roles
Authentication is handled by ASP.NET Core Identity with cookie authentication. The login interface is implemented in the Blazor components under Components/Account/Pages/Login.razor. Upon successful login, the user’s identity and role claims are used throughout the app.
Roles: The code uses two roles, Manager and HR Admin, as seen in the controllers’ [Authorize] attributes


HR Admin can manage all employees, departments, and salaries.
Manager can typically manage their own department’s employees and view department info.
Role setup: The Program.cs registers Identity and calls .AddRoles<IdentityRole>(), so the roles can be created at runtime. You need to uncomment the lines in the DbContext to seed the database.

Contributing and Extending
Coding conventions: The project follows standard ASP.NET Core patterns. Services implement interfaces (e.g. IEmployeeService) and are injected where needed. Feel free to add new services or pages following the existing structure.
Adding features: You can add new pages under Components/Pages and corresponding API endpoints under Controllers. Update the navigation menu (NavMenu.razor) to link to new pages.

Keep UI consistent with Bootstrap (used in the existing pages).
Ensure new code is protected by appropriate [Authorize] roles.
Document any new configuration (e.g. new settings in appsettings.json).
Known Limitations and Notes

Migrations not included: The repository does not include pre-generated EF migrations. You must create and apply migrations to initialize the database.
Email/SMS: Identity’s email confirmation or SMS features are not configured (the IEmailSender is set to a no-op). If account confirmation is needed, additional setup is required.
Error handling: The app currently provides basic validation and returns simple OK/BadRequest responses. More comprehensive error handling and user feedback may be needed for production use.
Scalability: The app is intended as a small-scale HR tool. For large datasets or high concurrency, further optimization (caching, pagination, etc.) may be necessary.

Security: Ensure the application is served over HTTPS. The sample uses local development settings; review Program.cs for production configurations like HSTS.
License
This project is licensed under the MIT License

. Feel free to use and modify the code according to the license terms. This README was generated to help a new developer understand and run the HumanCapitalManagement project. For detailed code behavior, refer to the source files and comments
