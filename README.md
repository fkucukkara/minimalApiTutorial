# Minimal API Workshop

## Overview
This project is a **.NET 9 Minimal API** built as part of a workshop to demonstrate advanced concepts in API development using the latest features of C# and .NET 9. The focus is on applying modern architectural patterns and practices while leveraging a variety of tools and frameworks.

## Features

### **Major Features**
- **C# .NET 9**: Leverages the latest features of .NET 9 for efficient and robust development.
- **CQRS (Command Query Responsibility Segregation)**: Implements separation of read and write operations for scalability and maintainability.
- **MediatR**: Facilitates in-process messaging for decoupling and implementing CQRS patterns.
- **Entity Framework Core**: Simplifies database access and management.
- **Generic Repository Pattern**: Provides reusable and efficient data access methods.
- **OOP (Object-Oriented Programming)**: Demonstrates robust design and implementation of object-oriented principles.
- **SOLID Principles**: Adheres to SOLID design principles for maintainable and scalable code.
- **Clean Code**: Focuses on writing readable, maintainable, and extensible code.

### **Minor Features**
- **Centralized Package Management**: Ensures consistent package versions across projects using `Directory.Packages.props`.
- **Centralized Exception Management**: Implements a unified approach to handling exceptions and improving debugging.

## Testing and Automation
- **xUnit**: Provides a robust testing framework for unit and integration tests.
- **Autofixture**: Simplifies test data generation for effective and clean testing.

## Prerequisites
- .NET 9 SDK
- SQL Server
- Visual Studio 2022 or a compatible IDE

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/minimal-api-workshop.git
   ```

2. Navigate to the project directory:
   ```bash
   cd minimal-api-workshop
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Apply migrations and update the database:
   ```bash
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

## License
[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

This project is licensed under the MIT License. See the [`LICENSE`](LICENSE) file for details.