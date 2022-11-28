### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Docker](https://www.docker.com/), [Linux Kernel (caso SO host seja windows)](https://learn.microsoft.com/pt-br/windows/wsl/install). 
Caso não queria rodar pelo Docker, recomendo a utilização do [VS](https://visualstudio.com/), pois foi disponibilizado uma versão compilavél do front-end.

### 🎲 Rodando o projeto com Docker

```
# Acesse a pasta do projeto no terminal/cmd
$ cd UserControlPanel

# Vá para a pasta server
$ cd /backend/UserControlPanel

# Execute o comando
$ docker-compose pull

# Execute o comando (utilize o -d para rodar os containers em modo daemon)
$ docker-compose up -d

# Aguarde 20 segundos após subir os containers (tempo pré-configurado para garantir que as migrations e seeds foram executadas com êxito)

# O servidor inciará na porta:8080 - acesse <http://localhost:8080>
```
