SET IDENTITY_INSERT [dbo].[obor] ON 

INSERT [dbo].[obor] ([id], [name], [kodUp]) VALUES (1, N'null', N'0')
SET IDENTITY_INSERT [dbo].[obor] OFF
SET IDENTITY_INSERT [dbo].[typZamest] ON 

INSERT [dbo].[typZamest] ([id], [name], [kod]) VALUES (1, N'absolventySs', N'absolventySs')
INSERT [dbo].[typZamest] ([id], [name], [kod]) VALUES (2, N'absolventyVs', N'absolventyVs')
INSERT [dbo].[typZamest] ([id], [name], [kod]) VALUES (3, N'ozp', N'ozp')
INSERT [dbo].[typZamest] ([id], [name], [kod]) VALUES (4, N'bezbar', N'bezbar')
INSERT [dbo].[typZamest] ([id], [name], [kod]) VALUES (5, N'cizince', N'cizince')
INSERT [dbo].[typZamest] ([id], [name], [kod]) VALUES (6, N'azylanty', N'azylanty')
SET IDENTITY_INSERT [dbo].[typZamest] OFF
SET IDENTITY_INSERT [dbo].[pracVztah] ON 

INSERT [dbo].[pracVztah] ([id], [name], [kod]) VALUES (1, N'Plný', N'ppvztahPpPlny')
INSERT [dbo].[pracVztah] ([id], [name], [kod]) VALUES (2, N'Zkrácený', N'ppvztahPpZkrac')
INSERT [dbo].[pracVztah] ([id], [name], [kod]) VALUES (3, N'dpp', N'ppvztahDpp')
INSERT [dbo].[pracVztah] ([id], [name], [kod]) VALUES (4, N'dpc', N'ppvztahDpc')
INSERT [dbo].[pracVztah] ([id], [name], [kod]) VALUES (5, N'Služební poměr', N'ppvztahSp')
SET IDENTITY_INSERT [dbo].[pracVztah] OFF