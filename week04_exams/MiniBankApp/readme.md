# MiniBankApp

**MiniBankApp** is an object-oriented banking simulation developed using C# and .NET Console. The project demonstrates core Object-Oriented Programming (OOP) concepts and SOLID principles through a modular and extensible architecture.

The application supports multiple account types, deposits, withdrawals, account transfers, interest calculations, transaction logging, and business rule validation.

---

## Features

* Multiple bank account types
* Deposit and withdrawal operations
* Account-to-account transfers
* Account-specific withdrawal rules
* Simple and compound interest calculation
* Transaction logging
* Exception handling
* In-memory data storage
* Interface-based and extensible architecture

---

## OOP and SOLID Principles

* **Encapsulation:** Account balances are protected and can only be modified through controlled methods.
* **Inheritance:** Specific account types inherit from the common `Account` base class.
* **Polymorphism:** Account-specific behaviors are handled without explicit type checks.
* **Abstraction:** Core dependencies are defined through interfaces.
* **SRP (Single Responsibility Principle):** Each class is responsible for a specific part of the system.
* **OCP (Open/Closed Principle):** New account types can be added without modifying existing core service logic.
* **DIP (Dependency Inversion Principle):** `BankService` depends on abstractions such as `IRepository` and `ITransactionLogger` rather than concrete implementations.

---

## Project Structure

```text
MiniBankApp/
├── src/
│   ├── Accounts/
│   │   ├── Account.cs
│   │   ├── CheckingAccount.cs
│   │   ├── SavingsAccount.cs
│   │   └── PremiumAccount.cs
│   │
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── ITransactionLogger.cs
│   │   └── IInterestCalculator.cs
│   │
│   ├── Infrastructure/
│   │   ├── InMemoryAccountRepository.cs
│   │   ├── ConsoleTransactionLogger.cs
│   │   ├── SimpleInterestCalculator.cs
│   │   └── CompoundInterestCalculator.cs
│   │
│   └── Services/
│       └── BankService.cs
│
├── Program.cs
├── YANSITMA.md
└── MiniBankApp.csproj
```

---

## Account Types

| Account Type        | Withdrawal Rule                                      | Interest Rate |
| ------------------- | ---------------------------------------------------- | ------------- |
| **CheckingAccount** | Daily withdrawal limit                               | 2%            |
| **SavingsAccount**  | Withdrawals are not allowed before the maturity date | 15%           |
| **PremiumAccount**  | 50,000 TL daily withdrawal limit                     | 5%            |

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

* Account creation
* Deposit operations
* Withdrawal operations
* Daily withdrawal limit validation
* Maturity date validation
* Account-to-account transfers
* Transfer transaction safety
* Polymorphic interest reporting
* Exception handling for invalid account IDs

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
