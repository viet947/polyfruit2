USE [Xuong_QuanLyTraiCay]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 03/06/2025 4:54:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaChiTiet] [varchar](10) NOT NULL,
	[MaDonHang] [varchar](10) NOT NULL,
	[MaSP] [varchar](10) NOT NULL,
	[MaDVT] [varchar](10) NOT NULL,
	[SoLuong] [decimal](10, 2) NOT NULL,
	[DonGiaBan] [decimal](10, 2) NOT NULL,
	[ThanhTien]  AS ([SoLuong]*[DonGiaBan]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [varchar](10) NOT NULL,
	[MaKhach] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NOT NULL,
	[NgayDatHang] [date] NOT NULL,
	[DiaChiGiaoHang] [nvarchar](255) NOT NULL,
	[MaTrangThai] [varchar](10) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[MaDVT] [varchar](10) NOT NULL,
	[TenDVT] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDVT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhach] [varchar](10) NOT NULL,
	[TenKhach] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[DienThoai] [varchar](20) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[KhachHangThanThiet] [nvarchar](50) NULL,
	[NgayTao] [date] NULL,
	[TrangThai] [bit] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSP] [varchar](10) NOT NULL,
	[TenLoai] [nvarchar](255) NOT NULL,
	[NgayTao] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [varchar](10) NOT NULL,
	[TenNhaCungCap] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[SoDienThoai] [varchar](20) NOT NULL,
	[NgayTao] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](10) NOT NULL,
	[HoTen] [nvarchar](255) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[VaiTro] [bit] NOT NULL,
	[TrangThai] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [varchar](10) NOT NULL,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[MaLoaiSP] [varchar](10) NOT NULL,
	[MaNCC] [varchar](10) NOT NULL,
	[MaDVT] [varchar](10) NOT NULL,
	[DonGiaNhap] [decimal](10, 2) NOT NULL,
	[DonGiaBan] [decimal](10, 2) NOT NULL,
	[SoLuong] [decimal](10, 2) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 03/06/2025 4:54:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[MaTrangThai] [varchar](10) NOT NULL,
	[TenTrangThai] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietDonHang] ([MaChiTiet], [MaDonHang], [MaSP], [MaDVT], [SoLuong], [DonGiaBan]) VALUES (N'CTDH001', N'DH001', N'SP001', N'DVT001', CAST(1.20 AS Decimal(10, 2)), CAST(150000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaChiTiet], [MaDonHang], [MaSP], [MaDVT], [SoLuong], [DonGiaBan]) VALUES (N'CTDH002', N'DH002', N'SP002', N'DVT002', CAST(3.50 AS Decimal(10, 2)), CAST(110000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaChiTiet], [MaDonHang], [MaSP], [MaDVT], [SoLuong], [DonGiaBan]) VALUES (N'CTDH003', N'DH003', N'SP003', N'DVT001', CAST(2.80 AS Decimal(10, 2)), CAST(60000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaChiTiet], [MaDonHang], [MaSP], [MaDVT], [SoLuong], [DonGiaBan]) VALUES (N'CTDH004', N'DH004', N'SP004', N'DVT005', CAST(4.00 AS Decimal(10, 2)), CAST(75000.00 AS Decimal(10, 2)))
INSERT [dbo].[ChiTietDonHang] ([MaChiTiet], [MaDonHang], [MaSP], [MaDVT], [SoLuong], [DonGiaBan]) VALUES (N'CTDH005', N'DH005', N'SP005', N'DVT004', CAST(10.00 AS Decimal(10, 2)), CAST(50000.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[DonHang] ([MaDonHang], [MaKhach], [MaNV], [NgayDatHang], [DiaChiGiaoHang], [MaTrangThai], [GhiChu]) VALUES (N'DH001', N'KH001', N'NV002', CAST(N'2025-05-23' AS Date), N'Quận 1, TP. HCM', N'TT01', NULL)
INSERT [dbo].[DonHang] ([MaDonHang], [MaKhach], [MaNV], [NgayDatHang], [DiaChiGiaoHang], [MaTrangThai], [GhiChu]) VALUES (N'DH002', N'KH002', N'NV004', CAST(N'2025-05-23' AS Date), N'Ninh Kiều, Cần Thơ', N'TT01', NULL)
INSERT [dbo].[DonHang] ([MaDonHang], [MaKhach], [MaNV], [NgayDatHang], [DiaChiGiaoHang], [MaTrangThai], [GhiChu]) VALUES (N'DH003', N'KH003', N'NV002', CAST(N'2025-05-23' AS Date), N'Hải Châu, Đà Nẵng', N'TT03', NULL)
INSERT [dbo].[DonHang] ([MaDonHang], [MaKhach], [MaNV], [NgayDatHang], [DiaChiGiaoHang], [MaTrangThai], [GhiChu]) VALUES (N'DH004', N'KH004', N'NV005', CAST(N'2025-05-23' AS Date), N'TP. Đà Lạt', N'TT02', NULL)
INSERT [dbo].[DonHang] ([MaDonHang], [MaKhach], [MaNV], [NgayDatHang], [DiaChiGiaoHang], [MaTrangThai], [GhiChu]) VALUES (N'DH005', N'KH005', N'NV001', CAST(N'2025-05-23' AS Date), N'Bến Tre', N'TT03', NULL)
GO
INSERT [dbo].[DonViTinh] ([MaDVT], [TenDVT], [MoTa]) VALUES (N'DVT001', N'Kg', N'Cân theo kilogram')
INSERT [dbo].[DonViTinh] ([MaDVT], [TenDVT], [MoTa]) VALUES (N'DVT002', N'Trái', N'Tính theo số lượng quả')
INSERT [dbo].[DonViTinh] ([MaDVT], [TenDVT], [MoTa]) VALUES (N'DVT003', N'Hộp', N'Đóng gói theo hộp')
INSERT [dbo].[DonViTinh] ([MaDVT], [TenDVT], [MoTa]) VALUES (N'DVT004', N'Túi', N'Tính theo túi đóng gói')
INSERT [dbo].[DonViTinh] ([MaDVT], [TenDVT], [MoTa]) VALUES (N'DVT005', N'Chùm', N'Tính theo từng chùm')
GO
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH001', N'Nguyễn Thanh Bình', N'TP. HCM', N'0909123456', N'Nam', N'Có', CAST(N'2025-05-23' AS Date), 1, NULL)
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH002', N'Lê Thị Hoa', N'Cần Thơ', N'0912234567', N'Nữ', N'Không', CAST(N'2025-05-23' AS Date), 1, NULL)
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH003', N'Trần Văn Long', N'Đà Nẵng', N'0923345678', N'Nam', N'Có', CAST(N'2025-05-23' AS Date), 1, NULL)
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH004', N'Phạm Văn Minh', N'Lâm Đồng', N'0934456789', N'Nam', N'Không', CAST(N'2025-05-23' AS Date), 1, NULL)
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH005', N'Hoàng Thu Trang', N'Bến Tre', N'0945567890', N'Nữ', N'Có', CAST(N'2025-05-23' AS Date), 1, NULL)
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH006', N'đa', N'ada', N'222', N'0', N'1', CAST(N'2025-05-30' AS Date), 1, N'dưa')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH007', N'dwa', N'da', N'222', N'1', N'0', CAST(N'2025-05-30' AS Date), 1, N'dwa')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH008', N'dwa', N'da', N'22', N'0', N'1', CAST(N'2025-05-30' AS Date), 0, N'dwa')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH012', N'', N'', N'', N'Nam', N'Có', CAST(N'2025-05-30' AS Date), 0, N'')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH013', N'', N'', N'', N'Nam', N'Có', CAST(N'2025-05-30' AS Date), 0, N'')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH014', N'', N'', N'', N'Nữ', N'Không', CAST(N'2025-05-30' AS Date), 0, N'')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH015', N'', N'', N'', N'Nam', N'Có', CAST(N'2025-05-30' AS Date), 0, N'')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [GioiTinh], [KhachHangThanThiet], [NgayTao], [TrangThai], [GhiChu]) VALUES (N'KH017', N'', N'', N'', N'Nữ', N'Không', CAST(N'2025-05-30' AS Date), 0, N'')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP001', N'Trái cây tươi', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP002', N'Trái cây sấy khô', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP003', N'Nước ép trái cây', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP004', N'Mứt trái cây', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP005', N'Giỏ quà trái cây', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP006', N'dwa', CAST(N'2025-06-02' AS Date), N'vvfdsdfs')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoai], [NgayTao], [GhiChu]) VALUES (N'LSP007', N'Giỏ quà trái cây', CAST(N'2025-05-23' AS Date), N'dwa')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [SoDienThoai], [NgayTao], [GhiChu]) VALUES (N'NCC001', N'Công ty trái cây miền Tây', N'Bến Tre', N'0123456789', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [SoDienThoai], [NgayTao], [GhiChu]) VALUES (N'NCC002', N'Nông sản Đà Lạt', N'Lâm Đồng', N'0987654321', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [SoDienThoai], [NgayTao], [GhiChu]) VALUES (N'NCC003', N'Chợ trái cây Sài Gòn', N'TP. HCM', N'0345678901', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [SoDienThoai], [NgayTao], [GhiChu]) VALUES (N'NCC004', N'Hợp tác xã nông nghiệp', N'Cần Thơ', N'0765432109', CAST(N'2025-05-23' AS Date), NULL)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [SoDienThoai], [NgayTao], [GhiChu]) VALUES (N'NCC005', N'Vườn trái cây Gia Lai', N'Gia Lai', N'0678901234', CAST(N'2025-05-23' AS Date), NULL)
GO
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [Email], [MatKhau], [DiaChi], [VaiTro], [TrangThai]) VALUES (N'NV001', N'Nguyễn Văn An', N'Nam', N'viet', N'1', N'TP. HCM', 1, 1)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [Email], [MatKhau], [DiaChi], [VaiTro], [TrangThai]) VALUES (N'NV002', N'Trần Thị Bình', N'Nữ', N'binhtt@gmail.com', N'abc123', N'Cần Thơ', 0, 1)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [Email], [MatKhau], [DiaChi], [VaiTro], [TrangThai]) VALUES (N'NV003', N'Lê Văn Chung', N'Nam', N'chunglv@gmail.com', N'abc123', N'Lâm Đồng', 0, 1)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [Email], [MatKhau], [DiaChi], [VaiTro], [TrangThai]) VALUES (N'NV004', N'Phạm Thị Duyên', N'Nữ', N'duyenpt@gmail.com', N'abc123', N'Bến Tre', 0, 1)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [Email], [MatKhau], [DiaChi], [VaiTro], [TrangThai]) VALUES (N'NV005', N'Hoàng Văn Tài', N'Nam', N'tannv@gmail.com', N'abc123', N'TP. HCM', 0, 1)
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaLoaiSP], [MaNCC], [MaDVT], [DonGiaNhap], [DonGiaBan], [SoLuong], [TrangThai], [HinhAnh], [GhiChu]) VALUES (N'SP001', N'Sầu riêng Ri6', N'LSP001', N'NCC001', N'DVT001', CAST(120000.00 AS Decimal(10, 2)), CAST(150000.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaLoaiSP], [MaNCC], [MaDVT], [DonGiaNhap], [DonGiaBan], [SoLuong], [TrangThai], [HinhAnh], [GhiChu]) VALUES (N'SP002', N'Xoài Cát Hòa Lộc', N'LSP001', N'NCC002', N'DVT002', CAST(80000.00 AS Decimal(10, 2)), CAST(110000.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaLoaiSP], [MaNCC], [MaDVT], [DonGiaNhap], [DonGiaBan], [SoLuong], [TrangThai], [HinhAnh], [GhiChu]) VALUES (N'SP003', N'Mít Thái', N'LSP001', N'NCC003', N'DVT001', CAST(40000.00 AS Decimal(10, 2)), CAST(60000.00 AS Decimal(10, 2)), CAST(80.00 AS Decimal(10, 2)), 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaLoaiSP], [MaNCC], [MaDVT], [DonGiaNhap], [DonGiaBan], [SoLuong], [TrangThai], [HinhAnh], [GhiChu]) VALUES (N'SP004', N'Nhãn Lồng Hưng Yên', N'LSP002', N'NCC004', N'DVT001', CAST(999.00 AS Decimal(10, 2)), CAST(75000.00 AS Decimal(10, 2)), CAST(60.00 AS Decimal(10, 2)), 1, N'', N'')
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaLoaiSP], [MaNCC], [MaDVT], [DonGiaNhap], [DonGiaBan], [SoLuong], [TrangThai], [HinhAnh], [GhiChu]) VALUES (N'SP005', N'Chôm chôm đỏ', N'LSP001', N'NCC005', N'DVT004', CAST(30000.00 AS Decimal(10, 2)), CAST(50000.00 AS Decimal(10, 2)), CAST(120.00 AS Decimal(10, 2)), 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaLoaiSP], [MaNCC], [MaDVT], [DonGiaNhap], [DonGiaBan], [SoLuong], [TrangThai], [HinhAnh], [GhiChu]) VALUES (N'SP006', N'dwa', N'LSP001', N'NCC002', N'DVT001', CAST(2.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), 1, N'da', N'da')
GO
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai], [MoTa]) VALUES (N'TT01', N'Đang xử lý', N'Đơn hàng đang trong quá trình xử lý')
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai], [MoTa]) VALUES (N'TT02', N'Đã hủy', N'Đơn hàng đã bị hủy')
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai], [MoTa]) VALUES (N'TT03', N'Hoàn tất', N'Đơn hàng đã hoàn thành và giao thành công')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A9D1053411294DFC]    Script Date: 03/06/2025 4:54:37 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT (getdate()) FOR [NgayDatHang]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[LoaiSanPham] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDVT])
REFERENCES [dbo].[DonViTinh] ([MaDVT])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaKhach])
REFERENCES [dbo].[KhachHang] ([MaKhach])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaTrangThai])
REFERENCES [dbo].[TrangThai] ([MaTrangThai])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaDVT])
REFERENCES [dbo].[DonViTinh] ([MaDVT])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaLoaiSP])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
