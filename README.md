# desafio
Desafio Pessoa Desenvolvedora .Net na empresa ESIG

Descrição do projeto

Este projeto foi desenvolvido como parte do processo seletivo da ESIG Group, conforme orientações do desafio prático. A aplicação foi construída utilizando ASP.NET WebForms, com integração a banco de dados Oracle 21c para persistência e processamento de dados.

Funcionalidades implementadas
- Listagem de Pessoas

  - Tela com listagem das pessoas, seus cargos e respectivos salários calculados (salário bruto, descontos e salário líquido).

- Cálculo dos Salários

  - Implementado botão para calcular/recalcular salários.

  - Cálculo realizado via Stored Procedure no banco de dados, preenchendo a tabela pessoa_salario.

- Processamento assíncrono

  - O cálculo dos salários é executado de forma assíncrona, evitando bloqueios na interface da aplicação.

- CRUD de Pessoas

  - Funcionalidade para adicionar, editar e remover pessoas.

- Sistema de Login

  - Implementado controle de usuário e autenticação.

  - Apenas usuários cadastrados podem acessar a aplicação.

  Instruções para execução local

- Configurar banco de dados Oracle:

  - Importar as tabelas pessoa, cargo, vencimentos, cargo_vencimentos conforme planilha enviada.

  - Criar a tabela pessoa_salario conforme especificado.
  - Criar as tabelas
    - [tabelas.txt](https://github.com/user-attachments/files/20434121/tabelas.txt)
  - Criar a procedures.
    - [procedures desafio.txt](https://github.com/user-attachments/files/20434088/procedures.desafio.txt)

- Configurar aplicação:

  - Configurar a string de conexão com o banco Oracle no arquivo Web.config.
