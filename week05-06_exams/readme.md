# Logistics & Shipment Management System — SQL Query Solutions

This repository contains 50 analytical SQL query solutions developed for the `shipped.sqlite` database. The queries focus on customer, driver, vehicle, and shipment operations.

---

## Database Schema

The system consists of four main tables:

| Table | Description | Key Columns |
| :--- | :--- | :--- |
| **`Customer`** | Customer and company information | `CustomerId`, `CompanyName`, `City`, `ContractType`, `Email`, `IsActive` |
| **`Driver`** | Driver and license information | `DriverId`, `FirstName`, `LastName`, `LicenseClass`, `Phone`, `HireDate`, `IsActive` |
| **`Vehicle`** | Fleet vehicles and capacity information | `VehicleId`, `Plate`, `VehicleType`, `CapacityTon` |
| **`Shipment`** | Shipment and delivery records | `ShipmentId`, `CustomerId`, `DriverId`, `VehicleId`, `OriginCity`, `DestCity`, `ShipDate`, `DeliverDate`, `Freight`, `DistanceKm`, `Status` |

---

## Query Topics

The 50 queries are organized into the following categories:

### 1. Basic Projection & Filtering — Queries 1–15
* Column aliases using `AS`
* `DISTINCT` values
* Comparison operators: `=`, `>`, `<`, `>=`, `<=`
* Range filtering with `BETWEEN ... AND ...`
* Sorting with `ORDER BY`

### 2. Pattern Matching & NULL Handling — Queries 16–30
* Pattern matching with `LIKE`
* List filtering with `IN` and `NOT IN`
* Inequality using `!=`
* Missing values using `IS NULL`
* Non-missing values using `IS NOT NULL`

### 3. Grouping & Aggregation — Queries 31–40
* `GROUP BY`
* `COUNT`, `AVG`
* `HAVING`
* Multi-level sorting with `ORDER BY`
* SQLite date functions:
  * `strftime('%Y', date_column)`
  * `strftime('%m', date_column)`

### 4. Joins, Conditional Logic & Set Operations — Queries 41–50
* `INNER JOIN`
* `LEFT JOIN`
* Finding unmatched records using `LEFT JOIN ... WHERE ... IS NULL`
* Conditional logic using `CASE WHEN`
* Combining result sets using `UNION`

---

## SQLite Coding Standards

### Date Handling
SQLite does not provide `YEAR()` or `MONTH()` functions. Date components are extracted using `strftime()`:
```sql
strftime('%Y', ShipDate)
strftime('%m', ShipDate)
```

### String Concatenation
The `||` operator is used to combine text values:
```sql
FirstName || ' ' || LastName
```

### NULL Handling
Missing values are checked explicitly using:
* `IS NULL`
* `IS NOT NULL`

---

## Project Structure

```text
.
├── shipped.sqlite        # SQLite database
├── shipped.sqbpro        # DB Browser for SQLite project file
└── README.md             # Project documentation
```

---

## How to Run

1. Open **DB Browser for SQLite**.
2. Open the `shipped.sqbpro` project file.
3. The database and saved SQL queries will be loaded automatically.
4. Select the query you want to run.
5. Press **F5** or click **Execute SQL**.
6. Review the query results in the output pane.

---

## Requirements

* **SQLite** (3.x or higher)
* **DB Browser for SQLite**
* `shipped.sqlite`
* `shipped.sqbpro`

---

## Project Purpose

This project demonstrates practical SQL skills in a logistics and shipment management environment, including:

* Data filtering
* Data aggregation
* Date-based analysis
* Relational joins
* NULL handling
* Conditional expressions
* Set operations

The project provides a collection of SQL exercises and analytical solutions for working with relational logistics data.