# Online Course Management System

## Overview

OnlineCourseSystem is a web application for managing online courses, students, and their registrations. The system provides functionalities for adding, retrieving, updating, and deleting courses and students. It also enables students to register for courses and track their progress.

## Technologies Used

- **.NET 9**
- **ASP.NET Core**
- **Swagger** (API Documentation)
- **Entity Framework Core** (ORM)
- **NUnit** (Unit Testing Framework)

## Libraries

- **Swashbuckle** (Swagger for ASP.NET Core)
- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Design**
- **Microsoft.EntityFrameworkCore.Tools**
- **Microsoft.EntityFrameworkCore.InMemory** (For testing)
- **NUnit**

## Project Structure

The solution is divided into the following layers:

### 1. OnlineCourseSystem (Web Application)

This is the main API project that exposes endpoints for managing courses and students.

#### Controllers:

- **CourseController**
  - `GET /api/course` - Retrieves a list of all available courses.
  - `POST /api/course` - Adds a new course.
  - `GET /api/course/{id}` - Retrieves a course by its ID.
  - `PUT /api/course` - Updates an existing course.
  - `DELETE /api/course/{id}` - Deletes a course.
- **StudentController**
  - `POST /api/student` - Adds a new student.
  - `GET /api/student` - Retrieves a list of all students.
  - `GET /api/student/{id}` - Retrieves a student by ID.
  - `PUT /api/student` - Updates an existing student.
  - `DELETE /api/student/{id}` - Deletes a student.
- **StudentCourseController**
  - `GET /api/studentCourse/{id}` - Retrieves all registered courses for a student.
  - `POST /api/studentCourse/join` - Registers a student to a course.
  - `DELETE /api/studentCourse/leave` - Removes a student's registration from a course.
  - `PUT /api/studentCourse` - Updates a student's progress in a course.

### 2. OnlineCourseSystem.Core (Business Logic Layer)

- **DTO Models**: Course (form, info), Student (form, info), StudentCourse (info).
- **Contracts**: Interfaces for services.
- **Services**:
  - `CourseService`
  - `StudentService`
  - `StudentCourseService`

### 3. OnlineCourseSystem.Infrastructure (Data Access Layer)

- **Repository Pattern**
- **ApplicationDbContext** (Database context using Entity Framework Core)
- **Seed Data**
- **Migrations**
- **Models**: Course, Student, StudentCourse

### 4. OnlineCourseSystem.UnitTests (Unit Testing Layer)

- Unit tests for service classes:
  - `CourseServiceTests`
  - `StudentServiceTests`
  - `StudentCourseServiceTests`

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- SQL Server

### Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/nikolaymihalev/Online-Course-Management-System.git
   ```
2. Set up the database:
   ```sh
   dotnet ef database update
   ```
3. Navigate to the `OnlineCourseSystem` and run the application:
   ```sh
   dotnet run
   ```
4. Access Swagger documentation at:
   ```
   http://localhost:{port}/swagger
   ```

## Running Unit Tests

To execute unit tests, navigate to the `OnlineCourseSystem.UnitTests` directory and run:

```sh
   dotnet test
```
