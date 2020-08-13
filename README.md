# ImdbAPI

API construída em .Net Core

# Autenticação

Foi feita uma autenticação no padrão JWT, com token a ser recebido no formato Bearer. 
Ao testar a API coloquei as funções de cadastro de Usuário e Administrador para retornar o token cadastrado e assim utilizá-los para testar as funções que necessitam de autorização.

# ORM

Entity Framework Core

# Bancos de Dados

SQL Server

# Code First

Assim que o sistema se inicia ele confere se o banco já existe, caso não exista ele cria um banco com as configurações passadas inicialmente pelas classes. 

# Documentação

Swagger utilizado. Para acessar basta ir para o link 'https://localhost:44335/swagger/index.html'

#Paginação

Nas funções com paginação, basta enviar na query a paginação desejada.

Por exemplo: 'https://localhost:44335/api/Filme/listar?PageNumber=2&PageSize=10'

No caso acima, a API irá "pular" os 10 primeiros itens e trazer os próximos 10.
