### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
- [Docker](https://www.docker.com/), 
- [Linux Kernel (Obrigatório caso sistema operacional utilizado seja windows)](https://learn.microsoft.com/pt-br/windows/wsl/install). 
 
Caso não queria rodar pelo Docker, é necessário a utilização do:
- [VS](https://visualstudio.com/) 
- [.Net6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [SqlServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### 🎲 Rodando o projeto com Docker

```
# Clone este repositório
$ git clone <https://github.com/bfeitoza99/UserControlPanel.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd UserControlPanel

# Vá para a pasta que contém o arquivo docker-compose
$ cd backend/UserControlPanel

# Execute o comando
$ docker-compose pull

# Execute o comando (utilize o -d para rodar os containers em modo daemon)
$ docker-compose up -d

# Aguarde 20 segundos após subir os containers
# Tempo pré-configurado para garantir que as migrations e seeds foram executadas com êxito

# O servidor inciará na porta:8080 - acesse <http://localhost:8080>
```

### 🎲 Rodando o projeto com Visual Studio
```
# Clone este repositório
$ git clone <https://github.com/bfeitoza99/UserControlPanel.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd UserControlPanel

# Vá para a pasta api
$ cd backend/UserControlPanel/UserControlPanel.API

# Execute o comando 
$ dotnet run

# Abra outro terminal/cmd acesse a pasta do projeto novamente
$ cd UserControlPanel

# Vá para a pasta presentation
$ cd backend/UserControlPanel/UserControlPanel.Presentation

# Execute o comando 
$ dotnet run

# O front-end inciará na porta:7240 - acesse <http://localhost:7240>
# O backe-end inciará na porta:5002 - acesse <http://localhost:5002>

```
