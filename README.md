# 🛍️ E-commerce Shop API (.NET Core)

This project is a RESTful Web API for an e-commerce platform built using **ASP.NET Core** and **Entity Framework Core**. It allows for managing products, categories, feedback, and more, forming the backend foundation of a scalable online store.

---


## 📁 Folder Structure

E-commerce-Shop-.Net-Api/  <br>
├── E-commerce Shop Api/<br>
│   ├── Controllers/<br>
│   ├── Models/<br>
│   ├── Data/<br>
│   ├── Program.cs<br>
│   └── appsettings.json <br>
├── E-commerce Shop Api.sln <br>
└── README.md<br>


---

## 🚀 Features

- ✅ Product and category management
- ✅ Feedback system
- ✅ RESTful API design
- ✅ Entity Framework Core with code-first approach
- ✅ Swagger UI documentation
- ✅ SQL Server support
- ✅ Dependency Injection

---

## 🧰 API Endpoints table

| Resource      | Method | Endpoint                 | Description             |
|---------------|--------|--------------------------|-------------------------|
| Products      | GET    | `/api/products`          | Get all products        |
| Products      | POST   | `/api/products`          | Add a new product       |
| Products      | PUT    | `/api/products/{id}`     | Update a product        |
| Products      | DELETE | `/api/products/{id}`     | Delete a product        |
| Productssale  | GET    | `/api/productssale`      | Get all product sales   |
| Productssale  | POST   | `/api/productssale`      | Add a new product sale  |
| Productssale  | PUT    | `/api/productssale/{id}` | Update a product sale   |
| Productssale  | DELETE | `/api/productssale/{id}` | Delete a product sale   |
| Categories    | GET    | `/api/categories`        | Get all categories      |
| Feedback      | POST   | `/api/feedbacks`         | Submit customer feedback|

---

## ⚙️ Installation & Setup

### ✅ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 or Visual Studio Code

### 📦 Steps

1. **Clone the repository**

```bash
git clone https://github.com/abdullah2309/E-commerce-Shop-.Net-Api.git
cd E-commerce-Shop-.Net-Api

