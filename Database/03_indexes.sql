USE TaskManagerDb;
GO

-- ایندکس برای بهبود سرعت جستجو بر اساس کاربر
IF NOT EXISTS (
    SELECT * FROM sys.indexes 
    WHERE name = 'IX_Tasks_UserId' AND object_id = OBJECT_ID('app.Tasks')
)
BEGIN
    CREATE NONCLUSTERED INDEX IX_Tasks_UserId
    ON app.Tasks(UserId);
END
GO

-- ایندکس برای جستجوی سریع بر اساس نام کاربری
IF NOT EXISTS (
    SELECT * FROM sys.indexes 
    WHERE name = 'IX_Users_Username' AND object_id = OBJECT_ID('app.Users')
)
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX IX_Users_Username
    ON app.Users(Username);
END
GO
