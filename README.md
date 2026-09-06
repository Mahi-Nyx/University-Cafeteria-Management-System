# University Cafeteria Management System

A desktop-based cafeteria management system developed to organize and manage university cafeteria activities.

## Project Overview

The system digitizes cafeteria activities such as student management, food management, meal ordering, feedback collection, and reporting.

It uses role-based access to provide different functions for Admin, Staff, and Student users.

## User Roles

### Admin
- Manage Students
- Manage Food
- View All Feedback
- View Daily Reports

### Staff
- Manage Meal Orders

### Student
- Submit Feedback
- View Own Report

## Technology Stack

- C#
- Windows Forms
- SQL Server
- ADO.NET
- Stored Procedures
- DataGridView
- Visual Studio

## Main Features

- Secure login
- Role-based access
- Student management
- Food/menu management
- Meal order management
- Duplicate meal prevention
- Student feedback with 1–5 ratings
- Feedback summary and averages
- Daily meal reports
- Student own report

## System Workflow

1. User logs into the system.
2. The system checks the user's role.
3. The appropriate dashboard is displayed.
4. The user performs the permitted activities.
5. Data is stored and retrieved from SQL Server.
6. Reports and feedback can be viewed based on user permissions.

## Database

The main database is:

`AKuUni_IS`

Main tables include:

- Students
- Menu
- MealOrder
- Feedback

Stored procedures are used for important database operations and business rules.

## How to Run

1. Open the project in Visual Studio.
2. Make sure SQL Server is installed.
3. Create the `AKuUni_IS` database.
4. Create the required tables and stored procedures.
5. Update the database connection in `App.config`.
6. Build and run the application.

## Future Improvements

- Web-based version
- Mobile application
- Online payment
- Advanced charts and analytics
- Cloud deployment
- Notification system

## System Preview

### Admin Dashboard
![Admin Dashboard](Screenshots/AdminDashboard.jpg)

### Manage Students
![Manage Students](Screenshots/ManageStudents.jpg)

### Meal Order
![Meal Order](Screenshots/MealOrder.jpg)

### Student Feedback
![Student Feedback](Screenshots/FeedbackForm.jpg)

### Daily Report
![Daily Report](Screenshots/DailyReport.jpg)

## Developer

**Mahi-Nyx**

University Cafeteria Management System developed using C# WinForms and SQL Server.
