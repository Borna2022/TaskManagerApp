-- ایجاد دیتابیس در صورت عدم وجود
IF DB_ID('TaskManagerDb') IS NULL
BEGIN
    CREATE DATABASE TaskManagerDb;
END
GO

USE TaskManagerDb;
GO

-- ایجاد اسکیما اختصاصی برای اپلیکیشن
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'app')
BEGIN
    EXEC('CREATE SCHEMA app AUTHORIZATION dbo;');
END
GO
