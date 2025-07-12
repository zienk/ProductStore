# 🛍️ ProductStore - Ứng dụng quản lý sản phẩm

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![WPF](https://img.shields.io/badge/WPF-Windows%20Application-blue)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-9.0-green)](https://docs.microsoft.com/en-us/ef/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-orange)](https://www.microsoft.com/en-us/sql-server)

## 📋 Mô tả dự án

**ProductStore** là một ứng dụng Windows Forms sử dụng WPF (Windows Presentation Foundation) để quản lý sản phẩm và danh mục. Dự án được xây dựng theo kiến trúc N-layer architecture (Kiến trúc đa tầng) với các nguyên tắc thiết kế hiện đại như Repository Pattern, Service Layer và Dependency Injection.

## 🏗️ Kiến trúc dự án

Dự án được tổ chức theo mô hình **N-Layer Architecture** gồm 5 projects chính:

```
📁 ProductStore/
├── 📁 BusinessObjects/          # Data Models & Entities
├── 📁 DataAccessLayer/          # Database Context & DAOs
├── 📁 Repositories/             # Repository Pattern Implementation
├── 📁 Services/                 # Business Logic Layer
└── 📁 WPFApp/                   # Presentation Layer (WPF UI)
```

### 🔧 Chi tiết từng layer:

#### 1. **BusinessObjects Layer**
- **Mục đích**: Chứa các entity models và business objects
- **Công nghệ**: .NET 9.0 Class Library
- **Nội dung**:
  - `AccountMember.cs`: Model cho tài khoản người dùng
  - `Category.cs`: Model cho danh mục sản phẩm
  - `Product.cs`: Model cho sản phẩm

#### 2. **DataAccessLayer (DAL)**
- **Mục đích**: Truy cập và thao tác với cơ sở dữ liệu
- **Công nghệ**: Entity Framework Core 9.0.6 + SQL Server
- **Nội dung**:
  - `MyStoreContext.cs`: Database Context
  - `AccountDAO.cs`: Data Access Object cho Account
  - `CategoryDAO.cs`: Data Access Object cho Category
  - `ProductDAO.cs`: Data Access Object cho Product

#### 3. **Repositories Layer**
- **Mục đích**: Triển khai Repository Pattern
- **Design Pattern**: Repository Pattern với Interface/Implementation
- **Nội dung**:
  - **Interfaces**: `IAccountRepository`, `ICategoryRepository`, `IProductRepository`
  - **Implementations**: `AccountRepository`, `CategoryRepository`, `ProductRepository`

#### 4. **Services Layer**
- **Mục đích**: Chứa business logic và quy tắc nghiệp vụ
- **Design Pattern**: Service Pattern với Dependency Injection
- **Nội dung**:
  - **Interfaces**: `IAccountService`, `ICategoryService`, `IProductService`
  - **Implementations**: `AccountService`, `CategoryService`, `ProductService`

#### 5. **WPFApp (Presentation Layer)**
- **Mục đích**: Giao diện người dùng
- **Công nghệ**: WPF (Windows Presentation Foundation)
- **Nội dung**:
  - `LoginWindow.xaml`: Giao diện đăng nhập
  - `MainWindow.xaml`: Giao diện chính quản lý sản phẩm
  - `appsettings.json`: Cấu hình kết nối database

## 🎯 Tính năng chính

### 🔐 Xác thực và phân quyền
- **Đăng nhập**: Hệ thống xác thực với username/password
- **Phân quyền**: Chỉ Admin (MemberRole = 1) mới có quyền truy cập

### 📦 Quản lý sản phẩm
- ✅ **Xem danh sách**: Hiển thị tất cả sản phẩm trong DataGrid
- ✅ **Thêm sản phẩm**: Tạo sản phẩm mới với thông tin đầy đủ
- ✅ **Cập nhật sản phẩm**: Chỉnh sửa thông tin sản phẩm
- ✅ **Xóa sản phẩm**: Xóa sản phẩm khỏi hệ thống
- ✅ **Quản lý danh mục**: Liên kết sản phẩm với danh mục

### 🎨 Giao diện người dùng
- **Modern UI**: Thiết kế gradient background đẹp mắt
- **Responsive**: Giao diện thân thiện và dễ sử dụng
- **Form Validation**: Kiểm tra dữ liệu đầu vào
- **Error Handling**: Xử lý lỗi thông minh

## 🛠️ Công nghệ sử dụng

| Công nghệ | Phiên bản | Mục đích |
|-----------|-----------|----------|
| .NET | 9.0 | Framework chính |
| WPF | 9.0 | Giao diện người dùng |
| Entity Framework Core | 9.0.6 | ORM for database |
| SQL Server | Latest | Cơ sở dữ liệu |
| C# | 12.0 | Ngôn ngữ lập trình |

## 🗄️ Cấu trúc Database

### Tables:
1. **AccountMember**
   - `MemberID` (Primary Key)
   - `MemberPassword`
   - `FullName`
   - `EmailAddress` (Unique)
   - `MemberRole` (1: Admin, 2: User)

2. **Category**
   - `CategoryID` (Primary Key)
   - `CategoryName`

3. **Product**
   - `ProductID` (Primary Key)
   - `ProductName`
   - `CategoryID` (Foreign Key)
   - `UnitsInStock`
   - `UnitPrice`

## 🚀 Hướng dẫn cài đặt

### Yêu cầu hệ thống:
- ✅ Windows 10/11
- ✅ .NET 9.0 SDK
- ✅ Visual Studio 2022 (hoặc Visual Studio Code)
- ✅ SQL Server (LocalDB/Express/Full)

### Các bước cài đặt:

1. **Clone repository**:
   ```bash
   git clone <repository-url>
   cd ProductStore
   ```

2. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

3. **Cấu hình database**:
   - Cập nhật connection string trong `WPFApp/appsettings.json`
   - Tạo database `MyStore` trong SQL Server
   - Chạy script tạo bảng và seed data

4. **Build solution**:
   ```bash
   dotnet build
   ```

5. **Chạy ứng dụng**:
   ```bash
   cd WPFApp
   dotnet run
   ```

## 🔧 Cấu hình

### Connection String:
```json
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Server=YOUR_SERVER;uid=YOUR_USERNAME;pwd=YOUR_PASSWORD;database=MyStore;TrustServerCertificate=True;"
  }
}
```

### Tài khoản mặc định:
- **Username**: admin
- **Password**: admin123
- **Role**: 1 (Admin)

## 📱 Screenshots

### Login Window
- Giao diện đăng nhập hiện đại với gradient background
- Form validation và error handling

### Main Window
- DataGrid hiển thị danh sách sản phẩm
- Form nhập liệu với ComboBox cho danh mục
- Các nút chức năng: Create, Update, Delete, Close

## 🏛️ Design Patterns được sử dụng

1. **Repository Pattern**: Tách biệt logic truy cập dữ liệu
2. **Service Layer Pattern**: Đóng gói business logic
3. **Dependency Injection**: Quản lý dependencies
4. **Entity Framework Code First**: Mapping object-relational
5. **MVVM Pattern**: Tách biệt UI logic (trong WPF)

## 📦 NuGet Packages

### DataAccessLayer:
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.6)
- `Microsoft.EntityFrameworkCore.Design` (9.0.6)
- `Microsoft.EntityFrameworkCore.Tools` (9.0.6)
- `Microsoft.Extensions.Configuration` (9.0.6)
- `Microsoft.Extensions.Configuration.Json` (9.0.6)

### WPFApp:
- Reference các projects: Services, DataAccessLayer, BusinessObjects

## 🤝 Đóng góp

Mọi đóng góp đều được hoan nghênh! Vui lòng:

1. Fork repository
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📜 License

Dự án này được phát hành dưới MIT License. Xem file [LICENSE](LICENSE) để biết thêm chi tiết.

## 👨‍💻 Tác giả

**Nguyễn Ngọc Viên** - SE182672
- 📧 Email: [zienkdev@gmail.com.com](mailto:zienkdev@gmail.com)
- 🎓 Trường: FPT University
- 📚 Môn học: PRN212 - Lab02

## 🙏 Lời cảm ơn

- FPT University và giảng viên môn PRN212
- Microsoft Documentation
- Entity Framework Core Documentation
- WPF Community

---

⭐ **Nếu dự án này hữu ích, hãy cho một star để ủng hộ!** ⭐