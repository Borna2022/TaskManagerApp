USE TaskManagerDb;
GO

-- حذف جدول‌ها در صورت وجود (برای تست‌های مکرر)
IF OBJECT_ID('app.Tasks', 'U') IS NOT NULL DROP TABLE app.Tasks;
IF OBJECT_ID('app.Users', 'U') IS NOT NULL DROP TABLE app.Users;
GO

-- جدول کاربران
CREATE TABLE app.Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL,
    Email NVARCHAR(100) NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE()
);
GO

-- جدول وظایف
CREATE TABLE app.Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    IsCompleted BIT DEFAULT 0,
    UserId INT NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES app.Users(Id)
);
GO
