IF NOT EXISTS(
    SELECT name
    FROM sys.databases
    WHERE name = 'DroneDelivery'
)
    CREATE DATABASE [DroneDelivery]
GO

USE [DroneDelivery]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Drone](
	[Id] [int] NOT NULL,
	[Capacidade] [int] NOT NULL,
	[Velocidade] [int] NOT NULL,
	[Autonomia] [int] NOT NULL,
	[Carga] [int] NOT NULL,
    [Status] [int] NOT NULL
 CONSTRAINT [PK_Drone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Pedido]    Script Date: 22/08/2020 00:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [uniqueidentifier] NOT NULL,
	[Peso] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[DataHora] [datetime] NOT NULL,
    [DistanciaParaOrigem] [float] NOT NULL,
	[StatusPedido] [int] NULL
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Pedido_Drone]    Script Date: 22/08/2020 00:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido_Drone](
	[Pedido_Id] [uniqueidentifier] NOT NULL,
	[Drone_Id] [int] NOT NULL
 CONSTRAINT [PK_Pedido_Drone] PRIMARY KEY CLUSTERED 
(
	[Pedido_Id], [Drone_Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido_Drone]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Drone_Pedido] FOREIGN KEY([Pedido_Id])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Drone] CHECK CONSTRAINT [FK_Pedido_Drone_Pedido]
GO
ALTER TABLE [dbo].[Pedido_Drone]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Drone_Drone] FOREIGN KEY([Drone_Id])
REFERENCES [dbo].[Drone] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Drone] CHECK CONSTRAINT [FK_Pedido_Drone_Drone]
GO

INSERT INTO [Drone] ([Id], [Capacidade], [Velocidade], [Autonomia],	[Carga], [Status])
VALUES
  -- ID, Capacidade KG, Velocidade KM/H, Autonomia min, Carga em %, Status
    (1,  12,            35,              15,            100,        1),
    (2,  7,             25,              35,            50,         1),
    (3,  5,             25,              35,            25,         1),
    (4,  10,            40,              20,            100,        1),
    (5,  8,             60,              25,            100,        1),
    (6,  7,             50,              30,            20,         1),
    (7,  12,            35,              15,            0,          0),
    (8,  7,             25,              35,            5,          0)
GO


INSERT INTO [Pedido] (Id, Peso, Latitude, Longitude, DataHora, DistanciaParaOrigem, StatusPedido)
VALUES
    ('1420207B-08C2-450C-87AF-76107E2377EE',5,-23.5990684,-46.6784195, CONVERT(DATETIME, '23/08/2020 09:06', 103), 2.55364638593945   , 2),
    ('8C626EC5-AA06-423A-9A76-89DF074293E0',5,-23.6990684,-46.6684195, CONVERT(DATETIME, '23/08/2020 09:06', 103),12.4024182185119    , 2),
    ('7CF3A286-5F0F-4937-BEBD-D8B1099A87CE',5,-23.5990684,-46.6684195, CONVERT(DATETIME, '23/08/2020 09:06', 103), 1.72945953901391   , 2),
    ('2683D6B4-C4FB-4680-B8AB-D9936A5CC358',5,-23.5890684,-46.6584195, CONVERT(DATETIME, '23/08/2020 09:05', 103), 0.23215649330868   , 2),
    ('6C1E074A-5864-4168-8E30-5B7A333F802F',5,-23.5880684,-46.6564195, CONVERT(DATETIME, '23/08/2020 09:04', 103), 0                  , 2),
    ('091017F2-AAC7-42EE-AE06-7F33459FD072',5,-23.5898985,-46.65642  , CONVERT(DATETIME, '23/08/2020 09:04', 103), 0.203488045541539  , 2),
    ('DA1E4F7B-1446-4085-8F7E-72306A17EDB0',5,-23.5890785,-46.65762  , CONVERT(DATETIME, '23/08/2020 09:04', 103), 0.16606820161035   , 2),
    ('30D41C99-27F6-4BFB-A90D-10A123515D1D',5,-23.5890785,-46.75642  , CONVERT(DATETIME, '23/08/2020 09:03', 103),10.1905556545044    , 2),
    ('1D2A0E02-6858-4437-BE9A-14CB7EB87475',5,-23.5890785,-46.65642  , CONVERT(DATETIME, '23/08/2020 09:03', 103), 0.112312603076869  , 2),
    ('23713F41-73E6-4418-AB98-BC05410F7B16',5,-23.6080785,-46.75642  , CONVERT(DATETIME, '23/08/2020 09:03', 103),10.4292864585278    , 2),
    ('8AB0083A-B76F-4D31-BED1-18D3E1BA5DA3',5,-23.5880785,-46.65642  , CONVERT(DATETIME, '23/08/2020 09:02', 103), 0.00112323555155982, 2),
    ('87194F04-D55C-4D6A-AC90-F09FE516808E',5,-23.5880684,-46.6564195, CONVERT(DATETIME, '23/08/2020 09:02', 103), 0                  , 2)
GO
