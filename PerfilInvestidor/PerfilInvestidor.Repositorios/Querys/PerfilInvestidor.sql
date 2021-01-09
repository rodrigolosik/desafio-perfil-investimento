CREATE TABLE Usuario
(
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(255) not null,
	Email VARCHAR(255) not null,
	Senha VARCHAR(255) not null
)