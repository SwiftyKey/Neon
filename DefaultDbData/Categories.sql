-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Categories] (
    [Id] int,
    [Title] nvarchar(450),
    [CreatedAt] datetimeoffset,
    [UpdatedAt] datetimeoffset,
    PRIMARY KEY ([Id])
);


INSERT INTO [dbo].[Categories] ([Id],[Title],[CreatedAt],[UpdatedAt]) VALUES (1,'Компьютеры','2024-11-28 12:04:41.6501132','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Categories] ([Id],[Title],[CreatedAt],[UpdatedAt]) VALUES (2,'Ноутбуки','2024-11-28 12:04:53.9674202','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Categories] ([Id],[Title],[CreatedAt],[UpdatedAt]) VALUES (3,'Сканеры','2024-11-28 12:04:59.7253670','0001-01-01 00:00:00.0000000'),(4,'Принтеры','2024-11-28 12:05:07.5812400','0001-01-01 00:00:00.0000000'),(5,'Плоттеры','2024-11-28 12:05:18.2474075','0001-01-01 00:00:00.0000000'),(6,'Микрокомпьютеры','2024-11-28 12:06:00.7395096','0001-01-01 00:00:00.0000000');