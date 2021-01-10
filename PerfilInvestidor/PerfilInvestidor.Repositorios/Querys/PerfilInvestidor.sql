CREATE TABLE Usuarios (
	Id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(255) not null,
	Email VARCHAR(255) not null,
	Senha VARCHAR(255) not null,
	TipoPerfil INT null
);

CREATE TABLE Perguntas (
	Id INT IDENTITY PRIMARY KEY,
	Texto VARCHAR(255) NOT NULL,
);

CREATE TABLE Respostas (
	Id INT IDENTITY PRIMARY KEY,
	Texto VARCHAR(255) NOT NULL,
	Valor INT NOT NULL,
	PerguntaId INT FOREIGN KEY REFERENCES Perguntas(Id)
);

CREATE TABLE UsuariosRespostas (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	UsuarioId INT NOT NULL,
	RespostaId INT NOT NULL
)

-- PERGUNTA 1
INSERT INTO Perguntas (Texto) VALUES ('Qual faixa de valor correspondente aos seus rendimentos mensais?');
INSERT INTO Respostas (Texto, Valor, PerguntaId) VALUES
('At� R$ 5.000,00', 0, 1),
('De R$ 5.000,00 at�  R$ 30.000,00', 5, 1),
('Acima de R$ 30.000,00', 10, 1);

-- PERGUNTA 2
INSERT INTO Perguntas (Texto) VALUES ('Qual das op��es abaixo melhor representa seu conhecimento do mercado financeiro?');
INSERT INTO Respostas (Texto, Valor, PerguntaId) VALUES
('N�o conclu� o ensino superior e minha experi�ncia profissional n�o possui rela��o com o mercado financeiro.', 0, 2),
('Conclu� o ensino superior, por�m minha experi�ncia profissional n�o possui rela��o com o mercado financeiro.', 2, 2),
('Apesar de n�o ter conclu�do o ensino superior, minha experi�ncia profissional aprimorou meus conhecimentos sobre o mercado financeiro.', 6, 2),
('Conclu� o ensino superior e minha experi�ncia profissional aprimorou meus conhecimentos sobre o mercado financeiro.', 8, 2);

-- PERGUNTA 3
INSERT INTO Perguntas (Texto) VALUES ('Seus investimentos representam que percentual do total do seu patrim�nio?');
INSERT INTO Respostas (Texto, Valor, PerguntaId) VALUES
('At� 25%', 2, 3),
('Entre 26% e 50%', 6, 3),
('Mais de 51%', 10, 3);

-- PERGUNTA 4
INSERT INTO Perguntas (Texto) VALUES ('Em quais produtos financeiros voc� investiu nos �ltimos 24 meses?');
INSERT INTO Respostas (Texto, Valor, PerguntaId) VALUES
('Somente Poupan�a, t�tulos p�blicos e outros produtos de Renda Fixa.', 2, 4),
('Al�m dos produtos da alternativa acima, produtos de Renda Vari�vel (fundos de a��es, a��es e similares).', 6, 4),
('Al�m dos produtos acima, mercado futuro e outros derivativos.', 8, 4),
('N�o investi no per�odo.', 10, 4);

-- PERGUNTA 5
INSERT INTO Perguntas (Texto) VALUES ('Qual o volume investido em produtos financeiros nos �ltimos 24 meses?');
INSERT INTO Respostas (Texto, Valor, PerguntaId) VALUES
('At� R$ 100.000,00', 2, 5),
('Entre R$ 100.000,00 e R$ 500.000,00', 6, 5),
('Acima de R$ 500.000,00', 8, 5),
('N�o investi no per�odo.', 0, 5);
