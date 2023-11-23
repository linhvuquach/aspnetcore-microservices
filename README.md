See the overall picture of implementations on microservices with .net tools on real-world e-commerce microservices project

![image](https://github.com/linhvuquach/aspnetcore-microservices/assets/26388126/ca656ca2-5e18-4770-b94e-196834be49ad)

There is a couple of microservices which implemented e-commerce modules over Catalog, Basket, Discount and Ordering microservices with NoSql (MongoDB, Redis) and relational databases (PostgreSQL, SQL server) with communicating over RabbitMQ Event Driven Communication and using Ocelot API Gateway

# Some concepts

## Simple Data-Driven, CRUD Microservice

![image](https://github.com/linhvuquach/aspnetcore-microservices/assets/26388126/e1a245a6-b36d-4b69-8af9-2936cdb4680e)

# Whats including in this repository

We've implemented below features over the run-aspnetcore-microservices repository

## Catalog microservice which includes:

- ASP.NET Core Web API application
- REST API principles, CRUD operation
- MongoDB db connection and containerization
- Repository pattern implementation
- We use Minimal APIs
- Swagger Open API implementation

## Basket microservice which includes:

- ASP.NET Web API application
- REST API principles, CRUD operations
- Repository pattern implementation
- Redis database connection and containerization
