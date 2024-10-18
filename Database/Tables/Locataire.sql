CREATE TABLE [dbo].[Locataire]
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(100) NOT NULL,
    Prenom NVARCHAR(100) NOT NULL,
    Mail NVARCHAR(255),
    Telephone NVARCHAR(20),
    Description NVARCHAR(500)
    )
