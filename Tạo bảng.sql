
/****** Object:  Table [dbo].[tblXeDap]    Script Date: 3/30/2023 1:12:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblXeDap](
	[colMa] [nvarchar](20) NOT NULL,
	[colTen] [nvarchar](50) NOT NULL,
	[colHang] [nvarchar](50) NOT NULL,
	[colXuatXu] [nvarchar](50) NOT NULL,
	[colSoluong] [int] NOT NULL,
	[colGia] [float] NOT NULL,
	[colTien] [float] NOT NULL,
	[colHinhAnh]varbinary(max),
 CONSTRAINT [PK_tblXeDap] PRIMARY KEY CLUSTERED 
(
	[colMa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
