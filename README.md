A aplicação foi desenvolvida utilizando como o dotnet 4.6.1 como solicitado usando como template o modelo MVC. 
Para banco de dados utilizei o SQL Server juntamente com o Dapper para mapeamento das consutas.
Adicionei no projeto o template AdminLTE para dar um visual melhor e resposividade ao projeto.
O Script para a criação do banco, das tabelas e com uma carga para Carteiras, está dentro do projeto;
Sobre as possíveis melhorias, deixei algumas anotações no código fonte em locais que identifiquei. 
Mas a nível de fluxo, melhoraria/corrigiria as carteiras o fluxo carteiras recomendadas e adicionaria funcionalidades a ela. 
Melhoraria o sistema de autenticação e tratamento de erros. 
Esses são alguns dos pontos que identifico com críticos para dar continuidade ao desenvolvimento da aplicação. 

Instruções de uso: 

1 - Clonar o repositório
2 - Criar o banco de dados utilizando o script localizado no projeto
3 - Alterar a connectionString localizada no Repositorio
4 - Compilar o projeto utilizando o MsBuild do Framework
5 - Adicionar a aplicação ao IIS 
