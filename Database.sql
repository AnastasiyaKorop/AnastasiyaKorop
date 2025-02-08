USE BiometricAuthDataBase;

CREATE TABLE [dbo].[Clients] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [LastName] NVARCHAR(MAX) NOT NULL,
    [FirstName] NVARCHAR(MAX) NOT NULL,
    [MiddleName] NVARCHAR(MAX),
    [EncryptedDateOfBirth] NVARCHAR(MAX) NOT NULL,
    [Gender] NVARCHAR(MAX) NOT NULL,
    [Address] NVARCHAR(MAX),
    [Phone] NVARCHAR(MAX),
    [Passport] NVARCHAR(MAX),
    [BU] NVARCHAR(MAX)
);

CREATE TABLE [dbo].[Employees] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [EmployeeCode] NVARCHAR(MAX) NOT NULL,
    [PositionCode] NVARCHAR(MAX) NOT NULL,
    [LastName] NVARCHAR(MAX) NOT NULL,
    [FirstName] NVARCHAR(MAX) NOT NULL,
    [MiddleName] NVARCHAR(MAX),
    [EncryptedDateOfBirth] NVARCHAR(MAX) NOT NULL,
    [Phone] NVARCHAR(MAX),
    [Address] NVARCHAR(200),
    [Photo] VARBINARY(MAX)
);

CREATE TABLE [dbo].[Users] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(MAX) NOT NULL,
    [PasswordHash] NVARCHAR(MAX) NOT NULL,
    [Role] NVARCHAR(MAX) NOT NULL
);
CREATE TABLE [dbo].[Faces] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Data] VARBINARY(MAX) NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE [dbo].[FilesKeys] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Key] VARBINARY(MAX) NOT NULL,
    [Vi] VARBINARY(MAX) NOT NULL
);

CREATE TABLE [dbo].[EncodeKeys] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Key] VARBINARY(MAX) NOT NULL,
    [Vi] VARBINARY(MAX) NOT NULL
);

CREATE TABLE [dbo].[ClientEmployeeConnections] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [UserId] INT NOT NULL
);
