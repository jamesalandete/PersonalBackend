USE [DB_doubleV]
GO
/****** Object:  Table [dbo].[auth_users]    Script Date: 13/11/2023 21:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auth_users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Pass] [nvarchar](20) NOT NULL,
	[AddedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_auth_user] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gen_personas]    Script Date: 13/11/2023 21:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gen_personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[TipoIdentificacionId] [int] NOT NULL,
	[NumeroIdentificacion] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Identificacion] [nvarchar](50) NOT NULL,
	[NombreCompleto] [nvarchar](150) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_gen_personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_gen_personas_identificacion] UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_identificaciones]    Script Date: 13/11/2023 21:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_identificaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](10) NOT NULL,
	[Sigla] [nvarchar](5) NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_tipo_identificaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[auth_users] ADD  CONSTRAINT [DF_auth_user_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[auth_users] ADD  CONSTRAINT [DF_auth_user_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
ALTER TABLE [dbo].[gen_personas] ADD  CONSTRAINT [DF_gen_personas_activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[tipo_identificaciones] ADD  CONSTRAINT [DF_tipo_identificaciones_activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[gen_personas]  WITH CHECK ADD  CONSTRAINT [FK_gen_personas_tipo_identificaciones] FOREIGN KEY([TipoIdentificacionId])
REFERENCES [dbo].[tipo_identificaciones] ([Id])
GO
ALTER TABLE [dbo].[gen_personas] CHECK CONSTRAINT [FK_gen_personas_tipo_identificaciones]
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_personas]    Script Date: 13/11/2023 21:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_personas] (
	@id int = null,
	@estado bit = null
) AS BEGIN
	SELECT * FROM gen_personas p
	WHERE p.Id = isnull(@id, p.id) and Activo = isnull(@estado, p.Activo)
END
GO
