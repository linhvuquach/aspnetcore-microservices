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

## Discount microservice which includes:

- ASP.NET Core Web API application
- REST API principles, CRUD operations
- Repository pattern implementation
- PostgreSQL database connection and containerization. We're also use pgAdmin management portal for PostgresSQL database
- Using Dapper for micro-orm implementation to simplify data access and ensure high performance

# Tools

## Container Mangement

Container managewment tools are software solutions that enable the deployment and operation of containrized workdloads. They can be used to mangae containers runing on-premises, in the public cloud, at the edge, or a combination thereof. Some of the popular container management tools are:

1. Amazon Elastic Container Service (Amazon ESC): A fully managed container orchestration service provided by Amazon Web Services. It offers a simple deployment process and allows easy scaling up or down of containerized services

2. Google Kubernetes Engine (GKE): A container orchestration system that automates the deployment, scaling, and management of containerized applications. It is easy to install, has a clear dashboard, and provides great scaling operations and overall great load balancing. It is also provided by the Cloud Native Computing Foundation.

3. Amazon Eslastic Kubernetes Service (Amazon EKS): A popular container management solution, known for its scalability, reliability, and integration with AWS services. Users often appreciate its ease of use and robust features for deploying and managing containerized applications

4. Portainer: A container management tool that makes deploying containers, administering Docker environments, and creating and administering Kubernetes clusters so much easier in a convenient central system

### Container mangement with Portainer

- Open-source
- Managing container-based software application
- Kubernetes, Docker, Docker Swarm, Azure CLI, and edge environments
- Managing environments, deploy applications, monitor app performance and triage problems
