# Mini Projeto para realizar um CRUD de Produtos
Neste projeto foram implementadas as seguintes funcionalidades: Cadastrar produto; Atualizar um produto; Remover produto; Listar produtos; Listar um produto específico (pelo ID do produto); Ordenar os produtos por diferentes campos e por ordem crescente ou decrescente; e Listar produtos pelo nome. 

Este projeto foi implementado utilizando o framework .NET 5 e os dados foram persistidos com o Entity Framework no banco de dados Sql Server (db-first).
Neste projeto foi criada uma solução chamada “*ProjetoCrudProdutos*”. 

Esta solução é composta por 4 (quatro) projetos: 1) ProjetoCrudProdutos.API; 2) ProjetoCrudProdutos.Application; 3) ProjetoCrudProdutos.Data; 4) ProjetoCrudProdutos.Domain.

## Projeto “ProjetoCrudProdutos.Domain” 
Possui a classe “*Produto.cs*”, que contém as propriedades do produto, as validações e definições das propriedades automáticas, como definição de data de cadastro e de atualização geradas pelo próprio domínio / modelo. Além disso, o requisito funcional “*O valor do produto não pode ser negativo*” foi tratado nesta classe. 

## Projeto “ProjetoCrudProdutos.Data” 
Possui as pastas “*Contex*t” e “*ScriptDatabase*”. A pasta “*Context*” contém a classe “*ProjetoCrudProdutosContext.cs*” que extende da classe “*DbContext*” do EntityFrameworkCore. O EntityFrameworkCore foi utilizado para realizar a persistência dos dados no Banco de Dados. 

Já a pasta “*ScriptDatabase*” contém o arquivo “*script-bd-ecommerce.sql*”, arquivo que estão os comandos SQL para a criação do banco de dados no SQL Server. ***OBS.:*** Foi utilizado a técnica “***db-first***”, em que primeiramente foi construído o Banco de Dados no SQL Server. Deve-se criar primeiro o banco de dados no SQL Server, antes de testar a solução desenvolvida. 

Neste projeto foram instaladas os seguintes pacotes do NuGet: “*Microsoft.EntityFrameworkCore (5.0.8)*”, “*Microsoft.EntityFrameworkCore.Design (5.0.8)*”, “*Microsoft.EntityFrameworkCore.SqlServer (5.0.8)*” e “*Microsoft.EntityFrameworkCore.Tools (5.0.8)*”. 

## Projeto “ProjetoCrudProdutos.Application” 
Possui as pastas “*Interfaces*” e “*Services*”. A pasta “*Interfaces*” contém a interface “*IProdutoService.cs*” em que declarados os métodos que deverão ser implementados pelas classes que implementar a referida Interface. 

Já a pasta “*Services*” contém o arquivo “*ProdutoService.cs*” que implementa a interface “*IProdutoService.cs*”, acessa os métodos do “*DbContext*” do EntityFrameworkCore do projeto “*ProjetoCrudProdutos.Data*” para a realização da persistência dos dados e consultas dos dados armazenados no Banco de Dados. A pasta “*Services*” contém também o arquivo “*CriaProdutosSingleton.cs*”, classe desenvolvida utilizando o padrão de projeto "*Singleton*" que cria e retorna 5 (cinco) produtos criados previamente para ser inseridos na tabela do banco de dados caso a tabela não tiver nenhum registro cadastrado.

## Projeto “ProjetoCrudProdutos.API” 
Projeto criado utilizando o template “*API Web do ASP.NET Core*” em que foram implementados os métodos disponibilizados pela Web API desenvolvida. Este projeto foi configurada a string de conexão com o banco de dados nos arquivos “*appsettings.json*” e “*appsettings.Development.json*”. No arquivo “*Startup.cs*” foi definido qual banco de dados foi utilizado (Sql Server), qual string de conexão foi usada e foi adicionado ao escopo do projeto o “*ProdutoService*”.

Além disso, este projeto possui a pasta “*Controllers*”, que contém a classe “*ProdutosController.cs*” que implementa a interface “*ControllerBase*”. Nessa classe foram definidas as rotas da APIs que retornam “*ActionResults*”. Essa classe acessa os métodos da classe “*ProdutoService.cs*” do projeto “*ProjetoCrudProdutos.Application*” para a realização dos CRUDs e retorno dos dados das consultas. A Web API desenvolvida foi testada no Swagger e no Postman. 

Para maiores detalhes ou caso tenha alguma dúvida entre em contato: *fernandorroberto@gmail.com* 👍
