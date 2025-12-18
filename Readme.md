### This project was create in this way: 
- > dotnet new webapp    => ASP.NET Core Web App (Razor Pages)  
-  ASP.NET Core code generator tool (aspnet-codegenerator)
- > dotnet tool install -g dotnet-aspnet-codegenerator
- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-9.0

### Add Using NuGet: Microsoft.VisualStudio.Web.CodeGeneration.Design 

### dotnet aspnet-codegenerator razorpage -m Person -dc AppDbContext -udl -outDir Pages/Persons --referenceScriptLibraries

### for the first section we created a AppDbContext and Person Entity. After that, in program.cs we added in services the datacontext plus connectionstring to database to apply the migracions.
### and finaly we added the nuget to generate the CRUD Pages and operation for the entity Person.

### In the seconde section We are going to create CRUD operation to Cosmos DB.
### Remember to run Azure Cosmos DB Emulator.