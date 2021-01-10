CREATE TABLE Usuarios (
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(255) not null,
	Email VARCHAR(255) not null,
	Senha VARCHAR(255) not null,
	TipoPerfil INT null
);

CREATE TABLE UsuariosRespostas (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	UsuarioId INT NOT NULL,
	RespostaId INT NOT NULL
);

CREATE TABLE Carteiras (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Composicao VARCHAR(255) NOT NULL,
	Rentabilidade VARCHAR(20) NOT NULL,
	Descricao VARCHAR(255) NULL,
	PerfilRecomendado VARCHAR(20) NOT NULL
);

INSERT INTO Carteiras
(Composicao, Rentabilidade, Descricao, PerfilRecomendado)
Values
('100% P�s Fixado', '17,2%', 'Precavido', 'Conservador')
('5% Infla��o, 5% Multimercado, 55% Renda Vari�vel, 35% Renda Vari�vel Global','10.04%','Destemido','Agressivo')
('55% P�s Fixado, 10% Infla��o, 2.50% Renda Fixa Global, 25% Multimercado, 2,50% Renda Vari�vel, 5% Renda Vari�vel Global','6.97%','Defensivo','Moderado')