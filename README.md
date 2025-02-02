# coLAB
A documentação completa referente a este trabalho pode ser lida em nossa [wiki](https://github.com/sofialctv/coLAB/wiki/1.-Introdu%C3%A7%C3%A3o).

# Guia de Instalação da aplicação

## Pré-requisitos

Antes de começar, certifique-se de que você tem os seguintes itens instalados em sua máquina:

- [Git](https://git-scm.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

## Clonando o Repositório

1. Abra o terminal ou prompt de comando.
2. Navegue até o diretório onde deseja clonar o repositório.
3. Execute o seguinte comando para clonar o repositório:

```
git clone https://github.com/sofialctv/coLAB
```
4. Navegue até o diretório do projeto:
```
cd coLAB
```

## Configurando o Ambiente

### Configurando o Docker Compose como Projeto de Inicialização

1. Abra o projeto no Visual Studio 2022.
2. No **Solution Explorer**, clique com o botão direito no arquivo `docker-compose.yml`.
3. Selecione **Set as Startup Project** (Definir como Projeto de Inicialização).

## Executando o Projeto

1. Com o Docker Desktop em execução, pressione `F5` no Visual Studio 2022 para iniciar o projeto.
2. O Visual Studio irá construir as imagens Docker e iniciar os contêineres conforme configurado no `docker-compose.yml`.
3. Após a inicialização, o projeto estará disponível no navegador através do endereço `http://localhost:5000` (ou outra porta configurada).

## Considerações Finais

Se você encontrar algum problema durante a configuração ou execução do projeto, verifique se todas as dependências estão corretamente instaladas e configuradas. 