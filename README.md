#Desafio Invillia

Infelizmente não foi possível completar todos os requisitos do desafio, mas, segue código do que foi implementado.

Favor seguir os seguintes passos:

- Criar uma imagem de Banco de Dados SQL Server 2019:
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

- No Console do Gerenciador de Pacotes, rodar um update-database.

- E depois rodar o script em /Resource/CargaDeDadosInicial.sql no banco de dados criado.

- Subir aplicação através do docker (tanto back quando front).
