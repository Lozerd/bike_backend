# Getting starting with Bike App backend

This project is simple web API.\
Project is based on ASP.NET framework
Eventually paired with []

# Tools
`C#`
`MySql`
`Entity Framework`
`Swagger`

# Project dependencies
```csharp
Pomelo.EntityFrameworkCore.MySql="6.0.1"  // Database this project is using
Pomelo.EntityFrameworkCore.MySql.Design="1.1.2"  // Constructing database tables, fields
Microsoft.EntityFrameworkCore.Tools.DotNet="2.0.3"  // This package needed for `dotnet ef` command

Swashbuckle.AspNetCore="6.2.3"
Swashbuckle.AspNetCore.Annotations="6.3.1"
Swashbuckle.AspNetCore.SwaggerUI="6.3.1"  // Swagger UI for Controller CRUD Methods
// Api Versioning
Microsoft.AspNetCore.Mvc.Versioning="5.0.0"
Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer="5.0.0"

Microsoft.AspNetCore.Mvc.NewtonsoftJson="6.0.6"
Microsoft.Build.Framework="17.2.0"
Microsoft.EntityFrameworkCore.Design="6.0."
Microsoft.EntityFrameworkCore.Tools="6.0."
Microsoft.VisualStudio.Web.CodeGeneration.Design="6.0.6"
```

# Steps to start project
> Clone this project to local machine `git clone https://github.com/Lozerd/bike_backend.git`

> Change `ConnectionStrings:MySqlContext` in appsettings.Development.json file

# Build the project with
+ Terminal: `dotnet build` \
+ Visual Studio: `right click on solution -> build solution`

# Migrate tables to database
+ Terminal: `dotnet ef database update`
+ Visual Studio: `Tools -> NuGet Manager -> Nuget Console -> update-database`

# Run the project
`dotnet run`

# Licence
```
MIT License

Copyright (c) 2022 Lozerd

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```