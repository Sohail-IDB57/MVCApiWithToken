## Overview

This ASP.NET application built with .NET Framework 4.7.2. It leverages Entity Framework for data access, Owin for middleware, and OAuth for token-based authentication.

## Features

- **Entity Framework 6.4.4**: ORM for database access.
- **Owin**: Middleware for handling authentication, CORS, and other functionalities.
- **OAuth 2.0**: For token-based authentication.
- **ASP.NET MVC 5.2.9**: For building web applications with the Model-View-Controller pattern.
- **ASP.NET Web API 5.2.9**: For building RESTful services.
- **Bootstrap**: For responsive design and styling.
- **jQuery**: For client-side scripting.

## Getting Started

### Prerequisites

- **.NET Framework 4.7.2**: Ensure you have the .NET Framework 4.7.2 installed on your machine.
- **Visual Studio**: Recommended for development and debugging. Ensure you have Visual Studio 2017 or later.
- **NuGet Package Manager**: For managing project dependencies.

### Installation

1. **Clone the Repository**

  
   git clone https://github.com/yourusername/Exam_MD.git
   

2. **Restore NuGet Packages**

   Open the solution in Visual Studio and restore the NuGet packages:

  
   Tools -> NuGet Package Manager -> Package Manager Console
  

   Run the command:
  
   Update-Package -reinstall
   

3. **Build the Solution**

   In Visual Studio, build the solution to ensure all dependencies are properly set up.

4. **Run the Application**

   Press `F5` or click on the "Start" button in Visual Studio to run the application.

### Configuration

#### OAuth Authentication

The application uses OAuth for token-based authentication. To configure OAuth:

1. **Startup Configuration**: The `Startup` class configures OAuth settings using `OAuthAuthorizationServerOptions` and `OAuthBearerAuthenticationOptions`. These settings are located in `Startup.cs`.

  
   using Microsoft.Owin;
   using Microsoft.Owin.Security.OAuth;
   using Owin;
   using System;
   using System.Threading.Tasks;
   using System.Web.Http;

   [assembly: OwinStartup(typeof(Exam_MD.Startup))]

   namespace Exam_MD
   {
       public class Startup
       {
           public void Configuration(IAppBuilder app)
           {
               app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

               var myProvider = new MyAuthorizationServerProvider();
               OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
               {
                   AllowInsecureHttp = true,
                   TokenEndpointPath = new PathString("/login"),
                   AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                   Provider = myProvider
               };
               app.UseOAuthAuthorizationServer(options);
               app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

               HttpConfiguration config = new HttpConfiguration();
               WebApiConfig.Register(config);
           }
       }
   }
   ```

   - **Token Endpoint Path**: The path for issuing tokens is `/login`.
   - **Token Expiry**: Tokens expire in 1 day.

2. **Authorization Server Provider**: Implement the `MyAuthorizationServerProvider` class to handle token issuance and validation. 

3. **Web API Configuration**: Ensure the Web API is configured correctly in `WebApiConfig`.

#### Database Connection

Configure your database connection string in the `Web.config` file.
<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=.;Initial Catalog=Exam_MD;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>


### Project Structure

- **Controllers**: Contains controller classes for handling HTTP requests.
- **Models**: Contains data models and Entity Framework contexts.
- **Views**: Contains Razor views for rendering HTML.
- **Migrations**: Contains Entity Framework migration files for database schema changes.
- **Scripts**: Contains JavaScript files, including jQuery and Bootstrap scripts.
- **Content**: Contains CSS files and other static content.
- **App_Start**: Contains configuration files for bundling, routing, and Web API.

### Contributing

1. **Fork the Repository**: Create a personal copy of the repository on GitHub.
2. **Create a Branch**: Work on a new feature or bugfix in a separate branch.
3. **Submit a Pull Request**: Once your changes are ready, submit a pull request for review.




