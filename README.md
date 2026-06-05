
#  Loan Management System API

A **.NET 10 Web API** for managing customers, loans, and payments with full authentication and role-based authorization using **JWT (JSON Web Tokens)**.

This project demonstrates real-world backend architecture including:
- Clean layered structure (Controllers → Services → Repositories)
- JWT Authentication & Authorization
- Role-based access control (Admin/User)
- Entity Framework Core with SQL Server
- Unit testing (xUnit + Moq)
- Soft Delete support
- Global exception handling
- Swagger API documentation

---

#  Features

##  Authentication & Authorization
- User registration
- User login
- Password hashing using `PasswordHasher`
- JWT token generation
- Role-based authorization:
  - `Admin`
  - `User`
- Protected endpoints using `[Authorize]` and `[Authorize(Roles = "Admin")]`

---

##  Users
- Register new users
- Login users
- Admin seeding on startup

---

##  Customers
- Create customer
- Get customer list
- Get customer by ID
- Update customer
- Soft delete customer (`IsDeleted = true`)
- Admin-only delete operation

---

##  Loans
- Create loan application
- Validate:
  - Customer exists
  - Credit score rules (business logic)
  - Amount range validation
  - Term limits
- Loan status handling (Approved / Rejected)
- Loan schedule generation

---

##  Payments
- Create payments for loans
- Validate:
  - Loan exists
  - Loan is not closed
  - Payment amount > 0
- Payment history tracking

---

##  Testing
- Unit testing with **xUnit**
- Mocking with **Moq**
- Service layer testing (LoanService, CustomerService examples)
- Validation logic testing (exceptions, rejection rules)

---

##  Soft Delete
Instead of physically deleting records:
- `IsDeleted = true`
- Data is preserved in database
- Filtering applied in queries

---

##  Global Exception Handling
- Centralized error handler using middleware
- Consistent API error responses

---

##  API Documentation
- Swagger enabled for API testing
- JWT support integrated (manual token usage if UI button disabled)

---

#  Architecture
Controllers
↓
Services (Business Logic)
↓
Repositories (Data Access Layer)
↓
Entity Framework Core
↓
SQL Server Database


---

# 🧰 Tech Stack

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger / OpenAPI
- xUnit (Testing)
- Moq (Mocking)
- C#

---

#  Authentication Flow

1. Register user
2. Login user
3. Receive JWT token
4. Send token in request header:Authorization:Bearer <your_token>
5. Access protected endpoints

---

#  Role-Based Access

| Role  | Permissions |
|------|------------|
| User | Can create and view data |
| Admin | Full access (delete, manage system data) |

---

# Installation & Setup

## 1. Clone repository

git clone https://github.com/elenekartvelishvili/Loan-Management-System.git
cd Loan-Management-System

2. Configure Database
Update appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=LoanDB;Trusted_Connection=True;"
}
3. Apply migrations
dotnet ef database update
4. Run the project
dotnet run
5. Open Swagger
https://localhost:{port}/swagger
---

##  Default Admin User

Created automatically on startup:

Username: admin
Password: admin123
Role: Admin

---
## Running Tests
dotnet test

---
## Key Endpoints
Auth
POST /api/Auth/register
POST /api/Auth/login
Customers
GET /api/Customer
GET /api/Customer/loans
POST /api/Customer
DELETE /api/customer/{id} (Admin only)
Loans
POST /api/Loans/CreateApplication
GET /api/Loans{id}
Payments
POST /api/Payments

