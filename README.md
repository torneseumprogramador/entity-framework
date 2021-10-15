# Comandos iniciais:
``` bash
  mkdir entity-framework
  cd entity-framework
  dotnet new mvc
  dotnet new sln - Criar solução vazia
  dotnet new classlib --name Entity.Clientes.Domain
  dotnet new classlib --name Entity.Clientes.Data
```

# Comandos git:
``` bash
  git init
  git add .
  git commit -m "Iniciando projeto"
  code .gitignore # gerei o conteúdo para ignorar como (Windows, Linux, Mac, DotnetCore, VisualStudioCore) no link: https://www.toptal.com/developers/gitignore
  Criei o repositório e rodei os comandos
  git remote add origin git@github.com:torneseumprogramador/entity-framework.git
  git branch -M main
  git push -u origin main
```

# Componentes instalados:
``` bash
  dotnet add package Microsoft.EntityFrameworkCore --version 5.0.8
  dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.8
  dotnet add package Pomelo.EntityFrameworkCore.MySql --version 5.0.1
```

# Instalando mysql no servidor
``` SQL
sudo apt install mysql-server
sudo mysql -u root
ALTER USER 'root'@'localhost' IDENTIFIED BY 'root';
CREATE USER 'root'@'127.0.0.1' IDENTIFIED WITH mysql_native_password BY 'root';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'127.0.0.1';
FLUSH PRIVILEGES;
```

# Comandos para migração:
``` bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add ClienteAdd
dotnet ef database update
```

# Instalação do code generator
``` bash
dotnet tool install -g dotnet-aspnet-codegenerator
```

# Gerando o scaffold de clientes
``` bash
dotnet aspnet-codegenerator controller -name ClientesController -m Cliente -dc DbContexto --relativeFolderPath Controllers --useDefaultLayout
```
# Comando para adicionar projetos a solução vazia
``` bash
A partir de uma solução criada digitamos o comando para adicionar a referencia ao csproj dos projetos
  dotnet sln add src/entity-framework.csproj
  dotnet sln add src/EntityClientes/Entity.Clientes.Data/Entity.Clientes.Data.csproj
  dotnet sln add src/EntityPedidos/Entity.Pedidos.Data/Entity.Pedidos.Data.csproj
  dotnet sln add src/EntityProdutos/Entity.Produtos.Data/Entity.Produtos.Data.csproj
 ```

## Comando para adicionar referencia em outros projetos
``` bash
  dotnet add reference ../Entity.Clientes.Domain/Entity.Clientes.Domain.csproj
```

 # Gerando scaffold Contexto e Tabelas
 ## Comando para o contexto Clientes
 ``` bash
  dotnet ef dbcontext scaffold "server=localhost;database=EntityFrameworkComunidade;user=root;password=root" Pomelo.EntityFrameworkCore.MySql -n Entity.Clientes.Domain.Entidades -t clientes -t enderecos -f -c ClienteDbContexto --context-dir Contexto --output-dir ..\Entity.Clientes.Domain\Entidades
```

## Comando para o contexto Pedidos
``` bash
  dotnet ef dbcontext scaffold "server=localhost;database=EntityFrameworkComunidade;user=root;password=root" Pomelo.EntityFrameworkCore.MySql -t pedidos -t enderecos -f -c PedidosDbContexto --context-dir Contexto --output-dir ..\Entity.Pedidos.Domain\Entidades
```

## Comando para o contexto Produtos
``` bash
  dotnet ef dbcontext scaffold "server=localhost;database=EntityFrameworkComunidade;user=root;password=root" Pomelo.EntityFrameworkCore.MySql -t produtos -f -c ProdutosDbContexto --context-dir Contexto --output-dir ..\Entity.Produtos.Domain\Entidades
```

# Geração de scripts via entity
``` bash
    dotnet ef migrations script 0  ContextoCompleto -o Scripts\ContextoCompleto.sql -i
    dotnet ef dbcontext script -o Scripts\ContextoProdutos.sql
```

# Links utéis
``` bash
    Documentação CLI entity-framework-core : https://docs.microsoft.com/pt-br/ef/core/cli/dotnet
```
