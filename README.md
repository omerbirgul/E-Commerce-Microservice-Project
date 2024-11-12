# Microservices E-Commerce Project

This project is a comprehensive microservices architecture application developed with **ASP.Net Core 6.0**, featuring various services like **Catalog**, **Basket**, **Order**, **Payment**, **Comment**, **Cargo**, **Discount**, and **Identity Server**.

## Project Overview

- 🚀 The project’s security is managed with **Identity** and **JWT (JSON Web Token)**.
- 🚀 **Ocelot** is used to simplify microservice management and API routing, with **Postman** and **Swagger** utilized for API testing.
- 🚀 Multi-language support is implemented through **Localization**, allowing users to access content in their preferred language.
- 🚀 Cross-platform functionality is enabled with **Docker**, with **Portainer** as the management interface.

## Microservices Overview

- **Basket**: Manages user shopping carts effectively using **Redis**.
- **Cargo**: Manages cargo processes and product tracking with **MySQL**.
- **Comment**: Enables user comments and feedback with **PostgreSQL**.
- **Catalog**: Manages products and listing operations with **MongoDB**, using a mapper for data transformations.
- **IdentityServer**: Provides authentication and authorization using **IdentityServer4** and **OAuth2**.
- **API Gateway**: Manages communication between microservices, handling requests and providing a central access point.

## Technologies Used

### Backend Technologies
- 🧩 ASP.Net Core 6.0 Web App
- 🌐 ASP.Net Web API
- 💾 Dapper
- 🔒 IdentityServer4
- ⚓ RabbitMQ
- 🌀 Ocelot Gateway
- 💳 JSON Web Token

### Database Technologies
- 🗂️ MSSQL
- 🗂️ MongoDB
- 🗂️ Redis
- 🗂️ PostgreSQL

### Infrastructure and Tools
- 🐳 Docker
- 🖥️ DBeaver
- ⚙️ Postman
- 🧾 Swagger
- 🚀 RapidAPI

### Architecture and Design Patterns
- 🏛️ Onion Architecture
- 📋 CQRS Design Pattern
- 🗄️ Mediator Design Pattern
- 🗃️ Repository Design Pattern
