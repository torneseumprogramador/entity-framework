# Comandos iniciais:
``` bash
  mkdir entity-framework
  cd entity-framework
  dotnet new mvc
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

