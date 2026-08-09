# CampusLibraryApp

**CampusLibraryApp** is an object-oriented campus library simulation developed using C# and .NET Console. The project demonstrates core Object-Oriented Programming (OOP) concepts and SOLID principles through a modular and extensible architecture.

The application manages books, library members, borrowing and returning operations, loan renewals, stock management, and late fee calculations based on member types.

---

## Features

* Multiple library member types
* Book and stock management
* Borrow and return operations
* Member-specific borrowing limits
* Member-specific loan periods
* Loan renewal functionality
* Late fee calculation
* Transaction logging
* Exception handling
* In-memory data storage
* Interface-based and extensible architecture

---

## OOP and SOLID Principles

* **Encapsulation:** Book stock and member borrowing counts are protected and can only be modified through controlled methods.
* **Inheritance:** Specific member types inherit from the common `Member` base class.
* **Polymorphism:** Member-specific borrowing limits, loan periods, and late fee rules are handled without explicit type checks.
* **Abstraction:** Core dependencies are defined through interfaces.
* **SRP (Single Responsibility Principle):** Each class is responsible for a specific part of the system.
* **OCP (Open/Closed Principle):** New member types can be added without modifying existing core service logic.
* **DIP (Dependency Inversion Principle):** `LibraryService` depends on abstractions such as `IRepository`, `ILoanLogger`, and `ILateFeeCalculator` rather than concrete implementations.

---

## Project Structure

```text
CampusLibraryApp/
├── src/
│   ├── Catalog/
│   │   └── Book.cs
│   │
│   ├── Members/
│   │   ├── Member.cs
│   │   ├── StudentMember.cs
│   │   ├── AcademicMember.cs
│   │   └── GuestMember.cs
│   │
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── ILoanLogger.cs
│   │   └── ILateFeeCalculator.cs
│   │
│   ├── Infrastructure/
│   │   ├── InMemoryMemberRepository.cs
│   │   ├── InMemoryBookRepository.cs
│   │   ├── ConsoleLoanLogger.cs
│   │   ├── StandardFeeCalculator.cs
│   │   └── GracePeriodFeeCalculator.cs
│   │
│   └── Services/
│       └── LibraryService.cs
│
├── Program.cs
├── YANSITMA.md
└── CampusLibraryApp.csproj
```

---

## Member Types

| Member Type        | Borrowing Limit | Loan Period |  Late Fee |
| ------------------ | --------------: | ----------: | --------: |
| **StudentMember**  |         3 books |     14 days |  5 TL/day |
| **AcademicMember** |        10 books |     30 days |  2 TL/day |
| **GuestMember**    |          1 book |      7 days | 10 TL/day |

---

## Installation and Usage

The project requires **.NET SDK 6.0 or later**.

### Build the project

```bash
dotnet build
```

### Run the application

```bash
dotnet run
```

---

## Tested Scenarios

The following scenarios are demonstrated in `Program.cs`:

* Member and book registration
* Successful book borrowing
* Borrowing limit validation
* Book stock validation
* Loan renewal
* Prevention of multiple renewals for the same loan
* Late return and polymorphic late fee calculation
* Exception handling for invalid member IDs

---

## Technologies

* C#
* .NET 6.0+
* Object-Oriented Programming
* SOLID Principles
* Repository Pattern
* Strategy Pattern

---

## Documentation

For a detailed explanation of the architectural decisions, OOP/SOLID principles, and design evaluation, see:

**`YANSITMA.md`**
