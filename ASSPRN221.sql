CREATE DATABASE [ASSPRN221]
USE [ASSPRN221]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 30/10/2024 21:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 30/10/2024 21:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[total_price] [decimal](10, 2) NULL,
	[status] [varchar](20) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 30/10/2024 21:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 30/10/2024 21:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[description] [text] NULL,
	[category_id] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30/10/2024 21:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[role] [varchar](20) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name], [description], [created_at]) VALUES (1, N'Electronics', N'Electronic gadgets and devices', CAST(N'2024-10-15T15:54:33.857' AS DateTime))
INSERT [dbo].[Category] ([id], [name], [description], [created_at]) VALUES (2, N'Books', N'Books of various genres', CAST(N'2024-10-15T15:54:33.857' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [user_id], [total_price], [status], [created_at]) VALUES (1, 4, CAST(519.98 AS Decimal(10, 2)), N'Pending', CAST(N'2024-10-15T15:55:14.233' AS DateTime))
INSERT [dbo].[Order] ([id], [user_id], [total_price], [status], [created_at]) VALUES (2, 5, CAST(19.99 AS Decimal(10, 2)), N'Completed', CAST(N'2024-10-15T15:55:14.233' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[Order_Product] ([order_id], [product_id], [quantity]) VALUES (1, 1, 1)
INSERT [dbo].[Order_Product] ([order_id], [product_id], [quantity]) VALUES (1, 2, 1)
INSERT [dbo].[Order_Product] ([order_id], [product_id], [quantity]) VALUES (2, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [price], [description], [category_id], [created_at]) VALUES (1, N'Smartphone', CAST(499.99 AS Decimal(10, 2)), N'A high-end smartphone', 1, CAST(N'2024-10-15T15:54:49.437' AS DateTime))
INSERT [dbo].[Product] ([id], [name], [price], [description], [category_id], [created_at]) VALUES (2, N'Laptop', CAST(999.99 AS Decimal(10, 2)), N'A powerful laptop', 1, NULL)
INSERT [dbo].[Product] ([id], [name], [price], [description], [category_id], [created_at]) VALUES (3, N'Science Fiction Book', CAST(40.00 AS Decimal(10, 2)), N'A best-selling science fiction novel', 1, NULL)
INSERT [dbo].[Product] ([id], [name], [price], [description], [category_id], [created_at]) VALUES (5, N'CD Games 11', CAST(19.00 AS Decimal(10, 2)), N'Game CD', 1, NULL)
INSERT [dbo].[Product] ([id], [name], [price], [description], [category_id], [created_at]) VALUES (6, N'S?n ph?m A', CAST(120.00 AS Decimal(10, 2)), N'', 2, CAST(N'2024-10-30T21:18:42.320' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (1, N'admin_user', N'admin@example.com', N'admin_password', N'admin', CAST(N'2024-10-15T15:53:51.310' AS DateTime), CAST(N'2024-10-15T15:53:51.310' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (2, N'manager_user', N'manager@example.com', N'manager_password', N'manager', CAST(N'2024-10-15T15:53:51.310' AS DateTime), CAST(N'2024-10-15T15:53:51.310' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (3, N'staff_user', N'staff@example.com', N'staff_password', N'staff', CAST(N'2024-10-15T15:53:51.310' AS DateTime), CAST(N'2024-10-15T15:53:51.310' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (4, N'customer1', N'customer1@example.com', N'customer1_password', N'customer', CAST(N'2024-10-15T15:53:51.310' AS DateTime), CAST(N'2024-10-15T15:53:51.310' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (5, N'customer2', N'customer2@example.com', N'customer2_password', N'customer', CAST(N'2024-10-15T15:53:51.310' AS DateTime), CAST(N'2024-10-15T15:53:51.310' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (6, N'customer3', N'customer3@example.com', N'customer3_password', N'customer', CAST(N'2024-10-15T15:53:51.310' AS DateTime), CAST(N'2024-10-15T15:53:51.310' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (9, N'test101', N'phamnhatduy08@gmail.com', N'12345678', N'customer', CAST(N'2024-10-30T21:17:41.517' AS DateTime), CAST(N'2024-10-30T21:17:41.517' AS DateTime))
INSERT [dbo].[User] ([id], [username], [email], [password], [role], [created_at], [updated_at]) VALUES (13, N'Test2002', N'phn@gmail.com', N'12356789', N'customer', CAST(N'2024-10-30T21:17:16.720' AS DateTime), CAST(N'2024-10-30T21:17:16.720' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
ON DELETE SET NULL
GO
