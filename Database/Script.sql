USE [master]
GO
/****** Object:  Database [twancosmetics]    Script Date: 23/12/2022 1:47:15 SA ******/
CREATE DATABASE [twancosmetics]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'twancosmetics', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.HIEUNGUYEN\MSSQL\DATA\twancosmetics.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'twancosmetics_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.HIEUNGUYEN\MSSQL\DATA\twancosmetics_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [twancosmetics] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [twancosmetics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [twancosmetics] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [twancosmetics] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [twancosmetics] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [twancosmetics] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [twancosmetics] SET ARITHABORT OFF 
GO
ALTER DATABASE [twancosmetics] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [twancosmetics] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [twancosmetics] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [twancosmetics] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [twancosmetics] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [twancosmetics] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [twancosmetics] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [twancosmetics] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [twancosmetics] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [twancosmetics] SET  ENABLE_BROKER 
GO
ALTER DATABASE [twancosmetics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [twancosmetics] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [twancosmetics] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [twancosmetics] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [twancosmetics] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [twancosmetics] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [twancosmetics] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [twancosmetics] SET RECOVERY FULL 
GO
ALTER DATABASE [twancosmetics] SET  MULTI_USER 
GO
ALTER DATABASE [twancosmetics] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [twancosmetics] SET DB_CHAINING OFF 
GO
ALTER DATABASE [twancosmetics] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [twancosmetics] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [twancosmetics] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [twancosmetics] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'twancosmetics', N'ON'
GO
ALTER DATABASE [twancosmetics] SET QUERY_STORE = OFF
GO
USE [twancosmetics]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[Region] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[District] [nvarchar](255) NULL,
	[Ward] [nvarchar](255) NULL,
	[Fullname] [nvarchar](255) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[id] [int] IDENTITY(5000,1) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[description] [text] NULL,
	[image_id] [int] NULL,
	[status] [tinyint] NOT NULL,
	[delete_flag] [tinyint] NOT NULL,
	[date_created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id] [int] IDENTITY(2000000,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[modifiled_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetail](
	[cart_id] [int] NOT NULL,
	[inventory_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cart_id] ASC,
	[inventory_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(4000000,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[message] [text] NULL,
	[rate] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[id] [int] IDENTITY(2000000,1) NOT NULL,
	[u_image] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[id] [int] IDENTITY(6000000,1) NOT NULL,
	[variant] [nvarchar](50) NULL,
	[product_id] [int] NOT NULL,
	[quantity] [decimal](18, 0) NOT NULL,
	[price] [float] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_updated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(5000000,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[email] [nvarchar](100) NULL,
	[address] [text] NOT NULL,
	[phone] [nvarchar](10) NULL,
	[total] [decimal](18, 0) NOT NULL,
	[paid] [tinyint] NOT NULL,
	[status] [nvarchar](100) NULL,
	[created_at] [datetime] NOT NULL,
	[id_voucher] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[order_id] [int] NOT NULL,
	[inventory_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[total] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[inventory_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[id] [int] IDENTITY(11000,1) NOT NULL,
	[content] [text] NOT NULL,
	[title] [text] NOT NULL,
	[user_id] [int] NOT NULL,
	[image_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[modifiled_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1000000,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [text] NULL,
	[SKU] [nvarchar](50) NOT NULL,
	[image_id] [int] NULL,
	[brand_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[status] [tinyint] NOT NULL,
	[delete_flag] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(10,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(3000000,1) NOT NULL,
	[fullname] [nvarchar](255) NOT NULL,
	[gender] [bit] NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[phoneNumber] [nvarchar](10) NOT NULL,
	[role_id] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[modifiled_at] [datetime] NOT NULL,
	[image_id] [int] NULL,
	[code] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 23/12/2022 1:47:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[id] [int] IDENTITY(21000,1) NOT NULL,
	[code] [text] NOT NULL,
	[discount_percentage] [decimal](18, 0) NOT NULL,
	[discount_price] [decimal](18, 0) NOT NULL,
	[exp] [datetime] NOT NULL,
	[min_bill] [decimal](18, 0) NOT NULL,
	[remain] [int] NOT NULL,
	[image_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([id], [name], [description], [image_id], [status], [delete_flag], [date_created]) VALUES (5000, N'Cocoon', N' ', NULL, 1, 0, CAST(N'2022-11-06T20:38:27.000' AS DateTime))
INSERT [dbo].[Brand] ([id], [name], [description], [image_id], [status], [delete_flag], [date_created]) VALUES (5001, N'Klairs', N' ', NULL, 1, 0, CAST(N'2022-11-20T11:19:04.497' AS DateTime))
INSERT [dbo].[Brand] ([id], [name], [description], [image_id], [status], [delete_flag], [date_created]) VALUES (5002, N'Simple', N'', NULL, 1, 0, CAST(N'2022-11-20T11:21:05.847' AS DateTime))
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (100, N'Tẩy Trang')
INSERT [dbo].[Category] ([id], [name]) VALUES (101, N'Sữa rửa mặt')
INSERT [dbo].[Category] ([id], [name]) VALUES (102, N'Tẩy tế bào chết')
INSERT [dbo].[Category] ([id], [name]) VALUES (103, N'Mặt nạ')
INSERT [dbo].[Category] ([id], [name]) VALUES (104, N'Tonner')
INSERT [dbo].[Category] ([id], [name]) VALUES (105, N'Xịt khoáng')
INSERT [dbo].[Category] ([id], [name]) VALUES (106, N'Serum')
INSERT [dbo].[Category] ([id], [name]) VALUES (107, N'Lotion')
INSERT [dbo].[Category] ([id], [name]) VALUES (108, N'Kem dưỡng')
INSERT [dbo].[Category] ([id], [name]) VALUES (109, N'Kem chống nắng')
INSERT [dbo].[Category] ([id], [name]) VALUES (110, N'Chăm sóc vùng da mắt')
INSERT [dbo].[Category] ([id], [name]) VALUES (111, N'Combo')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([id], [u_image]) VALUES (2000000, N'../Images/Products/Cocoon/bộ_sản_phẩm_bí_đao-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2000001, N'../Images/Products/Cocoon/bí_đao_mask_100ml-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2001001, N'../Images/Products/Cocoon/Dầu_tẩy_trang_cocoon_hoa_hồng_140ml-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2001002, N'../Images/Products/Cocoon/dung_dịch_chấm_mụn_cocoon-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2001003, N'../Images/Products/Cocoon/gel_rửa_mặt_cocoon_bí_đao_310ml-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2001004, N'../Images/Products/Cocoon/thạch_bí_đao-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2001005, N'../Images/Products/Cocoon/hoa_hồng_mask_cocoon_100ml-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2001006, N'../Images/Products/Cocoon/ntr_cocoon_bí_đao_140ml-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2002001, N'../Images/Products/Klairs/nước_hoa_hồng_không_mùi_klairs-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2002002, N'../Images/Products/Klairs/Nước_Hoa_Hồng_Klairs_Dành_Cho_Da_Nhạy_Cảm_180ml-removebg-preview.png')
INSERT [dbo].[Image] ([id], [u_image]) VALUES (2002003, N'../Images/Products/Simple/Nước_cân_bằng_Simple-removebg-preview.png')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6000007, N'100ml', 1000000, CAST(500 AS Decimal(18, 0)), 295000, CAST(N'2022-11-20T11:50:58.973' AS DateTime), CAST(N'2022-11-20T11:50:58.973' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6000008, N'30ml', 1000000, CAST(500 AS Decimal(18, 0)), 115000, CAST(N'2022-11-20T11:50:58.973' AS DateTime), CAST(N'2022-11-20T11:50:58.973' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001001, N'bộ', 1000001, CAST(500 AS Decimal(18, 0)), 584000, CAST(N'2022-11-22T22:02:17.943' AS DateTime), CAST(N'2022-11-22T22:02:17.943' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001002, N'140ml', 1000002, CAST(500 AS Decimal(18, 0)), 152000, CAST(N'2022-11-27T21:06:01.003' AS DateTime), CAST(N'2022-11-27T21:06:01.003' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001003, N'5ml', 1000003, CAST(500 AS Decimal(18, 0)), 125000, CAST(N'2022-11-27T21:13:05.160' AS DateTime), CAST(N'2022-11-27T21:13:05.160' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001004, N'140ml', 1000004, CAST(500 AS Decimal(18, 0)), 139000, CAST(N'2022-11-27T21:16:15.607' AS DateTime), CAST(N'2022-11-27T21:16:15.607' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001005, N'310ml', 1000004, CAST(500 AS Decimal(18, 0)), 295000, CAST(N'2022-11-27T21:16:15.607' AS DateTime), CAST(N'2022-11-27T21:16:15.607' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001006, N'30ml', 1000005, CAST(500 AS Decimal(18, 0)), 185000, CAST(N'2022-11-27T21:17:32.197' AS DateTime), CAST(N'2022-11-27T21:17:32.197' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001007, N'100ml', 1000005, CAST(500 AS Decimal(18, 0)), 375000, CAST(N'2022-11-27T21:17:57.993' AS DateTime), CAST(N'2022-11-27T21:17:57.993' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001008, N'30ml', 1000006, CAST(500 AS Decimal(18, 0)), 135000, CAST(N'2022-11-27T21:19:16.740' AS DateTime), CAST(N'2022-11-27T21:19:16.740' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001009, N'100ml', 1000006, CAST(500 AS Decimal(18, 0)), 325000, CAST(N'2022-11-27T21:19:43.863' AS DateTime), CAST(N'2022-11-27T21:19:43.863' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001010, N'140ml', 1000007, CAST(500 AS Decimal(18, 0)), 125000, CAST(N'2022-11-27T21:21:31.017' AS DateTime), CAST(N'2022-11-27T21:21:31.017' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6001011, N'500ml', 1000007, CAST(500 AS Decimal(18, 0)), 220000, CAST(N'2022-11-27T21:21:31.017' AS DateTime), CAST(N'2022-11-27T21:21:31.017' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6002002, N'180ml', 1001001, CAST(500 AS Decimal(18, 0)), 269000, CAST(N'2022-12-01T10:26:28.207' AS DateTime), CAST(N'2022-12-01T10:26:28.207' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6002003, N'180ml', 1001002, CAST(500 AS Decimal(18, 0)), 269000, CAST(N'2022-12-01T10:27:01.980' AS DateTime), CAST(N'2022-12-01T10:27:01.980' AS DateTime))
INSERT [dbo].[Inventory] ([id], [variant], [product_id], [quantity], [price], [date_created], [date_updated]) VALUES (6002004, N'50ml', 1001003, CAST(500 AS Decimal(18, 0)), 59000, CAST(N'2022-12-01T10:27:22.020' AS DateTime), CAST(N'2022-12-01T10:27:22.020' AS DateTime))
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [user_id], [name], [email], [address], [phone], [total], [paid], [status], [created_at], [id_voucher]) VALUES (5000000, 3003001, N'Nguyễn Minh Hiếu', N'srg@sdfg', N'adfuhd', N'0983644', CAST(3000000 AS Decimal(18, 0)), 1, N'0', CAST(N'2022-12-20T12:21:48.280' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [user_id], [name], [email], [address], [phone], [total], [paid], [status], [created_at], [id_voucher]) VALUES (5000004, 3003001, N'guyeenx Minh Hieeus', N'sdvjh@fhd', N'agsdfd', N'0392', CAST(1000000 AS Decimal(18, 0)), 1, N'0', CAST(N'2022-01-19T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000000, N'Mặt nạ bí đao', N'', N'test', 2000001, 5000, 103, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000001, N'Combo làm sạch và chăm sóc da dầu mụn Cocoon', N'', N'test1', 2000000, 5000, 111, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000002, N'Dầu tẩy trang hoa hồng', N'', N'test2', 2001001, 5000, 100, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000003, N'Dung dịch chấm mụn bí đao', N'', N'test3', 2001002, 5000, 106, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000004, N'Gel bí đao rửa mặt', N'', N'test5', 2001003, 5000, 103, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000005, N'Thạch hoa hồng dưỡng ẩm Cocoon', N'', N'test6', 2001004, 5000, 103, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000006, N'Mặt nạ hoa hồng', N'', N'test7', 2001005, 5000, 103, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1000007, N'Nước tẩy trang bí đao', N'', N'test8', 2001006, 5000, 100, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1001001, N'Nước hoa hồng không mùi Klairs Supple Preparation Unscented Toner', N'', N'test9', 2002001, 5001, 104, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1001002, N'Nước hoa hồng Klairs Supple Presparation Facial Toner', N'', N'test10', 2002002, 5001, 104, 1, 0)
INSERT [dbo].[Product] ([id], [name], [description], [SKU], [image_id], [brand_id], [category_id], [status], [delete_flag]) VALUES (1001003, N'Nước Hoa Hồng Cân Bằng, Làm Dịu Da Simple Kind To Skin Soothing Facial Toner', N'', N'test11', 2002003, 5002, 104, 1, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (10, N'Admin')
INSERT [dbo].[Role] ([id], [name]) VALUES (11, N'Người dùng')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [fullname], [gender], [email], [phoneNumber], [role_id], [username], [password], [created_at], [modifiled_at], [image_id], [code]) VALUES (3000000, N'Nguyễn Minh Hiếu', 1, N'20521326@gm.uit.edu.vn', N'0328357464', 10, N'admin', N'e89b6e24edf824096b7bf2ac645ad473', CAST(N'2022-11-13T14:08:57.053' AS DateTime), CAST(N'2022-11-13T14:08:57.053' AS DateTime), NULL, NULL)
INSERT [dbo].[User] ([id], [fullname], [gender], [email], [phoneNumber], [role_id], [username], [password], [created_at], [modifiled_at], [image_id], [code]) VALUES (3003001, N'Nguyễn Minh Hiếu', 1, N'hieunguyen31122001@gmail.com', N'0987654326', 11, N'admin1', N'e89b6e24edf824096b7bf2ac645ad473', CAST(N'2022-11-18T19:13:54.500' AS DateTime), CAST(N'2022-11-18T19:13:54.500' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Product__CA1ECF0DB4970A9A]    Script Date: 23/12/2022 1:47:16 SA ******/
ALTER TABLE [dbo].[Product] ADD UNIQUE NONCLUSTERED 
(
	[SKU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__4849DA01A0F43549]    Script Date: 23/12/2022 1:47:16 SA ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[phoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__AB6E6164297780FC]    Script Date: 23/12/2022 1:47:16 SA ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__F3DBC572596272CE]    Script Date: 23/12/2022 1:47:16 SA ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT (NULL) FOR [description]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT ((0)) FOR [delete_flag]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT (getdate()) FOR [date_created]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT (getdate()) FOR [date_created]
GO
ALTER TABLE [dbo].[Inventory] ADD  DEFAULT (getdate()) FOR [date_updated]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Post] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Post] ADD  DEFAULT (getdate()) FOR [modifiled_at]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (NULL) FOR [description]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [modifiled_at]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [Fk_Address_User] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [Fk_Address_User]
GO
ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [Fk_Brand_Image] FOREIGN KEY([image_id])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [Fk_Brand_Image]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_User]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Cart] FOREIGN KEY([cart_id])
REFERENCES [dbo].[Cart] ([id])
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Cart]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Inventory] FOREIGN KEY([inventory_id])
REFERENCES [dbo].[Inventory] ([id])
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Inventory]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Product]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [Fk_Inventory_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [Fk_Inventory_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [Fk_Order_Voucher] FOREIGN KEY([id_voucher])
REFERENCES [dbo].[Voucher] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [Fk_Order_Voucher]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Image] FOREIGN KEY([image_id])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Image]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Fk_Product_Brand] FOREIGN KEY([brand_id])
REFERENCES [dbo].[Brand] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Fk_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Fk_Product_Image] FOREIGN KEY([image_id])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Fk_Product_Image]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [Fk_User_Image] FOREIGN KEY([image_id])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [Fk_User_Image]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Voucher_Image] FOREIGN KEY([image_id])
REFERENCES [dbo].[Image] ([id])
GO
ALTER TABLE [dbo].[Voucher] CHECK CONSTRAINT [FK_Voucher_Image]
GO
USE [master]
GO
ALTER DATABASE [twancosmetics] SET  READ_WRITE 
GO
