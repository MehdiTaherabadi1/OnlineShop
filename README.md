Online Store Management System

Overview

This project is an Online Store Management System that allows users to place orders, calculate prices (including fixed profits and discounts), and manage order delivery methods. The system is designed with clean architecture principles, efficient code practices, and a layered structure.

Features

The system includes the following features:

Order Management

Register a single order for each customer.

An order can include multiple items.

Validate minimum order price (e.g., no order below 50,000 is acceptable).

Orders can only be placed between specified hours (e.g., 8 AM to 11 PM).

Price Calculation

Add a fixed profit margin to certain product prices.

Apply a percentage-based or fixed-amount discount to orders.

Product Categorization

Normal Products

Fragile Products

Delivery Methods

Standard Shipping

Express Shipping (for fragile products).

Clean Code and Testing

Well-structured architecture.

Comprehensive Unit Tests.

Integration with IConfiguration for flexible configuration management.

Technologies Used

C# (.NET Core)

Entity Framework Core (EF Core)

MSTest / xUnit for Unit Testing

ConfigurationBuilder for configuration management

Clean Code Principles

Domain-Driven Design (DDD) architecture

In-Memory Database for testing

Moq for mocking dependencies

System Architecture

The project follows a layered architecture to ensure separation of concerns:

Domain Layer

Contains core business entities (e.g., Order, Product, Customer, OrderSettings).

Business rules and logic are implemented here.

Application Layer

Contains services and use cases for managing orders and calculating prices.

Infrastructure Layer

Handles data persistence (EF Core), configuration, and delivery methods.

Presentation Layer

Provides endpoints or user interfaces for interaction (if applicable).

Prerequisites

To run and test the project locally, ensure the following are installed:

.NET SDK (6.0 or later)

Visual Studio or Visual Studio Code

Moq (for unit testing and mocking)

How to Run the Project

Follow these steps to set up and run the project:

Clone the Repository

git clone https://github.com/MehdiTaherabadi1/OnlineShop.git
cd OnlineShop

Restore Dependencies

dotnet restore

Run the Project

dotnet run

Run Unit Tests

dotnet test

Configuration

The system uses IConfiguration for configurable settings such as minimum acceptable price and order placement hours. Below is an example configuration:

{
  "OrderSettings": {
    "MinimumAcceptablePrice": "50000",
    "FromOrderPlacement": "8",
    "ToOrderPlacement": "23"
  }
}

Unit Testing

Unit tests have been written for all core features using xUnit and Moq. Key areas covered include:

Order Validation (minimum price, order placement hours)

Price Calculation (fixed profits and discounts)

Delivery Method Handling

Entity and Service Validations

To execute tests:

dotnet test

Example Usage

Order Creation Workflow

A customer places an order with multiple products.

The system validates the order:

Total price meets the minimum requirement.

Order is placed during valid hours.

Fixed profits and discounts are applied.

The system calculates the final price and determines the shipping method.

The order is stored, and a response is sent.

Future Enhancements

Implement a full-fledged API layer.
Add database support (e.g., SQL Server, PostgreSQL).
Improve UI/UX for managing orders and settings.
Add authentication and authorization.
