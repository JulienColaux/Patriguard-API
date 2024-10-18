CREATE TABLE [dbo].[Propriete]
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Adresse NVARCHAR(255) NOT NULL,
    Valeur DECIMAL(18, 2) NOT NULL,
    UserId INT NOT NULL, -- Cela fait référence à l'Id dans Locataire
    Description NVARCHAR(MAX),
    FOREIGN KEY (UserId) REFERENCES Locataire(Id) -- Relation avec Locataire
    )
