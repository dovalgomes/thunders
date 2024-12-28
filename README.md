# 📝 Lista de Tarefas Thunders

Este repositório contém um projeto desenvolvido em **.NET 8**, configurado para execução com **Docker**. O arquivo de configuração `docker-compose.yml` está localizado dentro da pasta **API**.

---

## 🛠️ Requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para clonar e executar o projeto:

1. **Clone o repositório**

   ```bash
   git clone https://github.com/dovalgomes/thunders.git
   ```

2. **Acesse a pasta que contém o arquivo `docker-compose.yml`**

   ```bash
   cd thunders && cd API
   ```

3. **Inicie os serviços usando Docker Compose**

   ```bash
   docker-compose up -d
   ```

4. **Acesse o Swagger para explorar os métodos disponíveis**

   Após alguns segundos, abra o navegador e acesse:
   [http://localhost:8080/swagger/](http://localhost:8080/swagger/)

---

## 🌟 Notas Adicionais

- Certifique-se de que as portas utilizadas no arquivo `docker-compose.yml` (por padrão, **8080**) estejam livres no seu sistema.
- Caso precise parar os serviços, utilize:

   ```bash
   docker-compose down
   ```

Qualquer dúvida ou problema, sinta-se à vontade para abrir uma **Issue** neste repositório! 🚀
