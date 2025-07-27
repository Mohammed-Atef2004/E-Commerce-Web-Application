# 🛒 E-Commerce Web Application (ASP.NET MVC)

## 📌 Overview

This is a fully functional E-Commerce Web Application developed using **ASP.NET MVC**. The application supports both **Admin** and **Customer** roles and provides full shopping capabilities including product listing, cart management, order placement, and admin product management.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- Role-based login (Admin, Customer)
- Secure registration and login with validations

### 🛍️ Customer Features
- Browse products by category
- Add/remove items to/from shopping cart
- Checkout and place orders
- View order history

### 🛠️ Admin Features
- Manage products (Create, Update, Delete)
- View customer orders and order details
- Manage product categories and inventory

---

## 🧰 Tech Stack

- **ASP.NET MVC 5**
- **Entity Framework** (Code First)
- **SQL Server / LocalDB**
- **Bootstrap 4** for UI design
- **Razor Views**
- **Repository Pattern** for clean architecture
- **LINQ** for querying
- **Identity Framework** for user management

---

## 🗂️ Updated Folder Structure

```
myshop.sln
│
├── myshop.DataAccess/                → Data Access Layer
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Implementation/
│   │   ├── ApplicationUserRepository.cs
│   │   ├── CategoryRepository.cs
│   │   ├── GenericRepository.cs
│   │   ├── OrderDetailRepository.cs
│   │   ├── OrderHeaderRepository.cs
│   │   ├── ProductRepository.cs
│   │   ├── ShoppingCartRepository.cs
│   │   └── UnitOfWork.cs
│   └── Migrations/                   → EF Core migrations
│
├── myshop.Entities/                  → Core Domain Layer
│   ├── Models/
│   │   ├── ApplicationUser.cs
│   │   ├── Category.cs
│   │   ├── ErrorViewModel.cs
│   │   ├── OrderDetail.cs
│   │   ├── OrderHeader.cs
│   │   ├── Product.cs
│   │   └── ShoppingCart.cs
│   ├── Repositories/                → Repository Interfaces
│   │   ├── ICategoryRepository.cs
│   │   ├── IGenericRepository.cs
│   │   ├── IOrderDetailRepository.cs
│   │   ├── IOrderHeaderRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── IShoppingCartRepository.cs
│   │   └── IUnitOfWork.cs
│   └── ViewModels/
│       ├── OrderVM.cs
│       ├── ProductVM.cs
│       └── ShoppingCartVM.cs
│
├── myshop.Utilities/                → Shared utilities (not detailed)
│
├── myshop.Web/                      → ASP.NET Core MVC Frontend
│   ├── wwwroot/                     → Static files (CSS, JS, images)
│   ├── Areas/                       → MVC Areas for identity and admin/customer separation
│   ├── Controllers/
│   │   └── HomeController.cs
│   ├── ViewComponents/
│   │   └── ShoppingCartViewComponent.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Program.cs
│   └── Startup.cs (or equivalent)
```
```
ECommerceApp/
│
├── Controllers/           → MVC Controllers
├── Models/                → Domain and View Models
├── Views/                 → Razor Views (organized by controller)
├── DAL/                   → Data Access Layer (Repositories)
├── Migrations/            → EF Migrations (if applicable)
├── Scripts/               → JS files
├── Content/               → CSS, Images
├── App_Start/             → Config files (e.g., RouteConfig)
└── Web.config             → App settings and connection string
```

---

## ⚙️ Getting Started

### 🧾 Prerequisites
- Visual Studio 2019/2022
- .NET Framework 4.7.2+
- SQL Server or LocalDB

### 🛠️ Installation Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/ecommerce-mvc.git
   ```

2. **Open in Visual Studio**
   - Open `.sln` file in Visual Studio.

3. **Restore NuGet Packages**
   - Go to `Tools` > `NuGet Package Manager` > `Manage NuGet Packages for Solution`.

4. **Database Migration**
   - Open Package Manager Console and run:
     ```bash
     Update-Database
     ```

5. **Run the App**
   - Press `F5` or click `Start` to run the project.

---

## 📸 Screenshots


---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the project
2. Create a new branch
3. Make your changes
4. Submit a Pull Request

---

## 📃 License

This project is licensed under the [MIT License](LICENSE).

---

## 🙋‍♂️ Author

**Mohammed Atef Moselhy**  
[GitHub](https://github.com/Mohammed-Atef2004)

---

## ⭐️ Show Your Support

If you like this project, don’t forget to give it a ⭐ on GitHub and share it with your friends!
