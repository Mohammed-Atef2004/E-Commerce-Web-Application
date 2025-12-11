# 🛒 MyShop E-Commerce Platform

A comprehensive E-commerce solution built with **ASP.NET Core MVC**, implementing **N-Tier Architecture** principles with complete separation of concerns across multiple layers.

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)

---

## 📋 Table of Contents

- [About The Project](#about-the-project)
- [Architecture Overview](#architecture-overview)
- [ERD Diagram](#EDR-Diagram)
- [Key Features](#key-features)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Screenshots](#screenshots)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 🎯 About The Project

MyShop is a feature-rich e-commerce platform designed to provide a seamless shopping experience. Built with modern web technologies and following industry best practices, this project demonstrates a scalable, maintainable architecture suitable for real-world applications.

### Why This Project?

- ✅ **Clean Architecture** - Clear separation of concerns
- ✅ **Repository Pattern** - Abstracted data access layer
- ✅ **Unit of Work** - Centralized transaction management
- ✅ **Role-Based Access** - Secure admin and customer areas
- ✅ **Payment Integration** - Stripe payment gateway
- ✅ **Responsive Design** - Mobile-friendly interface

---

## 🏗️ Architecture Overview

The project follows a **4-tier layered architecture**:

```
┌─────────────────────────────────────────────┐
│          myshop.Web (Presentation)          │
│         ASP.NET Core MVC / Razor            │
└─────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────┐
│       myshop.Utilities (Cross-Cutting)      │
│      Email, Stripe, Constants, Helpers      │
└─────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────┐
│      myshop.Entities (Domain Layer)         │
│    Models, Interfaces, ViewModels, DTOs     │
└─────────────────────────────────────────────┘
                     ↓
┌─────────────────────────────────────────────┐
│    myshop.DataAccess (Data Access Layer)    │
│  Repositories, UnitOfWork, EF Core Context  │
└─────────────────────────────────────────────┘
```
### 🗂️ ERD Diagram
<img width="952" height="504" alt="image" src="https://github.com/user-attachments/assets/20ab20b0-c844-4271-80d2-2176affcfdda" />


---
### 🗂️ Layer Breakdown

#### **1. myshop.Web** - Presentation Layer
The ASP.NET Core MVC application serving as the user interface.

**Admin Area:**
- `CategoryController.cs` - Manage product categories
- `ProductController.cs` - Product CRUD operations
- `OrderController.cs` - Order management and tracking
- `UserController.cs` - User management and roles
- `DashboardController.cs` - Analytics and reports

**Customer Area:**
- `HomeController.cs` - Product browsing and search
- `CartController.cs` - Shopping cart and checkout

**Identity Area:**
- Authentication pages
- User registration and login

#### **2. myshop.Entities** - Domain Layer
Core business entities and contracts.

**Models:**
- `ApplicationUser.cs` - Extended identity user
- `Category.cs` - Product categories
- `Product.cs` - Product details
- `OrderHeader.cs` - Order information
- `OrderDetail.cs` - Order line items
- `ShoppingCart.cs` - Cart items

**Repository Interfaces:**
- `IGenericRepository.cs` - Base repository contract
- `ICategoryRepository.cs`
- `IProductRepository.cs`
- `IOrderHeaderRepository.cs`
- `IOrderDetailRepository.cs`
- `IShoppingCartRepository.cs`
- `IUnitOfWork.cs` - Transaction management

**ViewModels:**
- `ProductVM.cs` - Product view model with categories
- `ShoppingCartVM.cs` - Cart summary model

#### **3. myshop.DataAccess** - Data Access Layer
Database operations and repository implementations.

**Components:**
- `ApplicationDbContext.cs` - EF Core database context
- `ApplicationUserRepository.cs`
- `CategoryRepository.cs`
- `ProductRepository.cs`
- `OrderHeaderRepository.cs`
- `OrderDetailRepository.cs`
- `ShoppingCartRepository.cs`
- `UnitOfWork.cs` - Centralized data access

**Migrations Folder:**
- Database migration history

#### **4. myshop.Utilities** - Cross-Cutting Concerns
Shared functionality across layers.

- `EmailSender.cs` - Email notification service
- `SD.cs` - Static data and constants
- `StripeData.cs` - Payment configuration

---

## ✨ Key Features

### 🔐 Authentication & Authorization
- User registration and login
- ASP.NET Core Identity integration
- Role-based access control (Admin, Customer)
- Secure password hashing

### 📦 Product Management
- Create, read, update, delete products
- Category organization
- Image upload and management
- Product search and filtering

### 🛍️ Shopping Experience
- Browse products by category
- Add to cart functionality
- Cart management (add, remove, update quantities)
- Order summary and checkout

### 💳 Payment Processing
- Stripe payment gateway integration
- Secure payment handling
- Order confirmation

### 📊 Admin Dashboard
- Sales analytics
- Order management
- User management
- Inventory tracking

### 📧 Notifications
- Email confirmations
- Order status updates

---

## 🛠️ Technologies Used

### Backend
- **Framework:** ASP.NET Core MVC
- **Language:** C# 10
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Authentication:** ASP.NET Core Identity

### Frontend
- **UI Framework:** Bootstrap 5
- **Template Engine:** Razor Views
- **Icons:** Font Awesome
- **JavaScript:** jQuery

### Third-Party Services
- **Payment:** Stripe API
- **Email:** SMTP Integration

### Design Patterns
- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- MVC Pattern

---

## 📁 Project Structure

```
myshop/
│
├── myshop.DataAccess/
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
│   └── Migrations/
│
├── myshop.Entities/
│   ├── Models/
│   │   ├── ApplicationUser.cs
│   │   ├── Category.cs
│   │   ├── OrderDetail.cs
│   │   ├── OrderHeader.cs
│   │   ├── Product.cs
│   │   └── ShoppingCart.cs
│   ├── Repositories/
│   │   ├── IGenericRepository.cs
│   │   ├── ICategoryRepository.cs
│   │   ├── IOrderDetailRepository.cs
│   │   ├── IOrderHeaderRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── IShoppingCartRepository.cs
│   │   └── IUnitOfWork.cs
│   └── ViewModels/
│       ├── ProductVM.cs
│       └── ShoppingCartVM.cs
│
├── myshop.Utilities/
│   ├── EmailSender.cs
│   ├── SD.cs
│   └── StripeData.cs
│
└── myshop.Web/
    ├── Areas/
    │   ├── Admin/
    │   │   ├── Controllers/
    │   │   │   ├── CategoryController.cs
    │   │   │   ├── DashboardController.cs
    │   │   │   ├── OrderController.cs
    │   │   │   ├── ProductController.cs
    │   │   │   └── UserController.cs
    │   │   └── Views/
    │   │       ├── Category/
    │   │       ├── Dashboard/
    │   │       ├── Order/
    │   │       ├── Product/
    │   │       └── User/
    │   ├── Customer/
    │   │   ├── Controllers/
    │   │   │   ├── CartController.cs
    │   │   │   └── HomeController.cs
    │   │   └── Views/
    │   │       ├── Cart/
    │   │       └── Home/
    │   └── Identity/
    │       └── Pages/
    ├── wwwroot/
    │   ├── css/
    │   ├── js/
    │   └── images/
    ├── appsettings.json
    ├── appsettings.Development.json
    └── Program.cs
```

---

## 📸 Screenshots

### Home Page
<img width="747" height="598" alt="image" src="https://github.com/user-attachments/assets/84dbd6fa-99a0-4698-b437-8506e215a6b6" />

### Cart Page
<img width="1349" height="640" alt="image" src="https://github.com/user-attachments/assets/9b59001b-7e32-4ebc-a3a9-561d45841612" />


### Placing Order
<img width="1350" height="632" alt="image" src="https://github.com/user-attachments/assets/c4a6cc0a-6e5b-47e2-8fab-5b2f49fa1c86" />


### Admin Dashboard
<img width="1366" height="645" alt="image" src="https://github.com/user-attachments/assets/42da95c7-c32a-472c-820d-ad6d0e7eb75f" />

### Chopping Cart 
<img width="931" height="606" alt="image" src="https://github.com/user-attachments/assets/1de12715-47ec-426c-9060-ec1d9d1088fb" />

### Integrating with Stripe
<img width="1343" height="621" alt="image" src="https://github.com/user-attachments/assets/71f02501-c03b-4ea0-ac24-5538efb56632" />

### Products Management
<img width="1350" height="641" alt="image" src="https://github.com/user-attachments/assets/1c60c745-63d6-4aed-903e-de907a62d465" />

### Categories Management
<img width="1361" height="641" alt="image" src="https://github.com/user-attachments/assets/8769829c-0595-405e-a586-63fbdde26573" />

### Users Management
<img width="1366" height="641" alt="image" src="https://github.com/user-attachments/assets/c1a8c808-8d54-452e-a4fe-c707848396ba" />


---

## 🚀 Getting Started

### Prerequisites

Before running this project, ensure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (Express/Developer Edition)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [SQL Server Management Studio](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) (Optional)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/myshop-ecommerce.git
   cd myshop-ecommerce
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   
   Open `myshop.Web/appsettings.json` and update the connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=MyShopDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. **Apply database migrations**
   ```bash
   cd myshop.Web
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   
   Open your browser and navigate to: `https://localhost:5001`

---

## ⚙️ Configuration

### Stripe Payment Setup

1. Create a [Stripe account](https://stripe.com/)
2. Get your API keys from the Stripe Dashboard
3. Update `appsettings.json`:
   ```json
   "Stripe": {
     "SecretKey": "your_secret_key",
     "PublishableKey": "your_publishable_key"
   }
   ```

### Email Configuration

Update email settings in `appsettings.json`:
```json
"EmailSettings": {
  "SmtpServer": "smtp.gmail.com",
  "SmtpPort": 587,
  "SenderEmail": "your-email@gmail.com",
  "SenderPassword": "your-app-password"
}
```

### Default Admin Account

After running migrations, seed a default admin account or register and manually assign the Admin role using SQL:

```sql
INSERT INTO AspNetRoles (Id, Name, NormalizedName)
VALUES (NEWID(), 'Admin', 'ADMIN');
```

---

## 💻 Usage

### For Customers

1. **Browse Products** - Navigate through different categories
2. **Add to Cart** - Select products and add them to your shopping cart
3. **Checkout** - Complete your purchase using Stripe payment
4. **Track Orders** - View order history and status

### For Admins

1. **Login** - Access admin area at `/Admin`
2. **Manage Products** - Add, edit, or delete products
3. **Manage Categories** - Organize products into categories
4. **Process Orders** - Update order status and manage shipments
5. **View Dashboard** - Monitor sales and analytics
6. **Manage Users** - Assign roles and manage customer accounts

---

## 🤝 Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📝 License

Distributed under the MIT License. See `LICENSE` for more information.

---

## 📧 Contact

Mohammed Atef : mohammedatef.8224@gmail.com

Linkedin : https://www.linkedin.com/in/mohammed-atef-/

---

## 🙏 Acknowledgments

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Bootstrap](https://getbootstrap.com)
- [Stripe API](https://stripe.com/docs/api)
- [Font Awesome](https://fontawesome.com)

---

<div align="center">
  <p>Made with ❤️ and ☕</p>
  <p>⭐ Star this repo if you find it helpful!</p>
</div>
