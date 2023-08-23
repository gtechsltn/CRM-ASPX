--------------------      -------------------- 
-------------------- Role -------------------- 
--------------------      --------------------
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Role'))
BEGIN
    DROP TABLE [dbo].[Role]
END

CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
)
GO

SET IDENTITY_INSERT [dbo].[Role] ON

INSERT INTO [dbo].[Role]([Id],[Name]) VALUES (1, N'Admin')
INSERT INTO [dbo].[Role]([Id],[Name]) VALUES (2, N'User')

SET IDENTITY_INSERT [dbo].[Role] OFF

--------------------      -------------------- 
-------------------- User -------------------- 
--------------------      --------------------
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'User'))
BEGIN
    DROP TABLE [dbo].[User]
END

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
)
GO

SET IDENTITY_INSERT [dbo].[User] ON

INSERT INTO [dbo].[User]([Id],[UserName],[Password]) VALUES (1, N'Admin','LMANlCOGRZSajDZOn18GDA==')
INSERT INTO [dbo].[User]([Id],[UserName],[Password]) VALUES (2, N'manh','LMANlCOGRZSajDZOn18GDA==')
INSERT INTO [dbo].[User]([Id],[UserName],[Password]) VALUES (3, N'chien','LMANlCOGRZSajDZOn18GDA==')

SET IDENTITY_INSERT [dbo].[User] OFF

--------------------      -------------------- 
-------------------- UserRole -------------------- 
--------------------      --------------------
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UserRole'))
BEGIN
    DROP TABLE [dbo].[UserRole]
END

CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserId] [int],
	[RoleId] [int],
)
GO

INSERT INTO [dbo].[UserRole]([UserId],[RoleId]) VALUES (1,1)
INSERT INTO [dbo].[UserRole]([UserId],[RoleId]) VALUES (2,2)
INSERT INTO [dbo].[UserRole]([UserId],[RoleId]) VALUES (3,2)


--------------------          -------------------- 
-------------------- Customer -------------------- 
--------------------          --------------------
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Customer'))
BEGIN
    DROP TABLE [dbo].[Customer]
END

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[CCCD] [nvarchar](50) NULL,
	[CMND] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[DoB] [DateTime] NULL,
	[YoB] [Int] NULL,
	[Email] [nvarchar](50) NULL,
	[Email2] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Mobile2] [nvarchar](50) NULL,
	[Gener] [varchar](1) NULL,
	[Facebook] [nvarchar](50) NULL,
	[Facebook2] [nvarchar](50) NULL,
	[Hobbies] [nvarchar](500) NULL,
	[Note] [nvarchar](500) NULL,
)
GO

SET IDENTITY_INSERT [dbo].[Customer] ON

INSERT INTO [dbo].[Customer]([Id],[FirstName],[LastName],[CCCD],[Address],[DoB],[YoB],[Email],[Mobile],[Gener],[Facebook],[Hobbies],[Note]) VALUES (1,N'Mạnh',N'Nguyễn Viết',N'027083000720',N'Tecco Garden, Tứ Hiệp, Thanh Trì, Hà Nội','1983-06-25 15:50:00.000',1983,N'manhng83@gmail.com',N'0982411958','M',N'https://www.facebook.com/manh.nguyenviet.167189',N'Đá bóng, Bóng chuyền hơi',N'Lập trình viên')

SET IDENTITY_INSERT [dbo].[Customer] OFF