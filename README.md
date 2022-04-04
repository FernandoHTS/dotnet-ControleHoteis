# Projeto
O projeto tem como objetivo o cadastro de Hotéis e Quartos, também sendo possível cadastrar fotos para eles.

# Tecnologias, ferramentas e conceitos
.NET 5, SQL Server, Visual Studio 2019 e GIT. Utilizando também alguns conceitos de Clean Architecture e os princípios SOLID. Entre os demais recursos utilizados estão: Identity, EF Core 5, Code First Migrations, Repository Pattern, Mapeamento de entidades com o AutoMapper.

# Build
Após o clone, o clean e build solution, sempre são bem vindos. Depois disso, necessita-se da string de conexão no appsettings.Development.json. Posto isto, atualiza-se o banco (Update-Database).

1. git clone https://github.com/FernandoHTS/dotnet-ControleHoteis.git
2. Clean e Build Solution
3. Ajuste a string de conexão no arquivo appsettings.Development.json (projeto ControleHoteis.Aplicacao)
4. Update-Database -Context ControleHoteisContext (projeto ControleHoteis.Data)
5. Feito! Basta executar o projeto
