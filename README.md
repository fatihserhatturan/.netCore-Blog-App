
# .netCore-Blog-App

Objective: This project aims to create a web-based blog application where users can create, read, and manage blog posts.

Technologies and Tools:

.NET Core: The foundational platform for the application.
ASP.NET Core: Used to build the web application.
Entity Framework Core: Used for database operations.
SQL Server: Can be used as the database.
AutoMapper: Used for entity and DTO (Data Transfer Object) mapping.
HTML, CSS, and JavaScript: Used to create the user interface.
Bootstrap or other CSS frameworks: Preferred for enhancing the user interface.
NLayer Architecture:
NLayer is an architecture that divides the application into functional layers. The core layers are as follows:

Core Layer: This is where the user interface resides. It can be built using ASP.NET Core MVC or Razor Pages.

Bussiness Layer: This layer manages the business logic and use cases. It accepts user requests, calls relevant services, and performs necessary transformations.

Entitiy Layer: The foundational business logic resides here. It maintains database independence and includes data structures, models, and business rules.

Data-Access Layer: This layer handles database access, communication with external services, and other external resources. It includes components like Entity Framework that create database tables.

Project Structure:

BlogApp.Web: The ASP.NET Core project containing the user interface.
BlogApp.Application: The application layer managing use cases.
BlogApp.Domain: The domain layer containing the core business logic.
BlogApp.Infrastructure: The infrastructure layer handling database access and external services.
Features:

User Registration and Login
Create, Edit, and Delete Blog Posts
Commenting and Reply Functionality
Filtering Posts by Categories and Tags
Search Engine Optimization (SEO)-Friendly URLs
User Profile and Blog Statistics
Authorization and Authentication
Summary:
This project demonstrates a blog application developed using .NET Core and following the principles of the NLayer architecture. Each layer has specific responsibilities, and this approach ensures that the application is scalable, easy to maintain, and testable. The project aims to provide users with a comprehensive experience where they can create, share, and manage their blog posts.


## App İmages :

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/AnaSayfa.png)

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202023-08-23%20190207.png)

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202023-08-23%20190344.png)

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202023-08-23%20190419.png)

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202023-08-23%20190611.png)

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202023-08-23%20190645.png)

![Uygulama Ekran Görüntüsü](https://github.com/fatihserhatturan/.netCore-Blog-App/blob/main/erzo/yazar.png)
  
