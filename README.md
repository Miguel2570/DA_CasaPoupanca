# DA_CasaPoupanca

Descrição do Projeto

Este projeto consiste no desenvolvimento de um protótipo em C# com Windows Forms, com o objetivo de validar o conceito de uma aplicação de gestão de compras domésticas. A solução pretende apoiar a gestão do orçamento familiar, o planeamento de compras e o controlo detalhado dos artigos adquiridos, previstos e não previstos.

A aplicação será utilizada por membros de um agregado familiar, permitindo que vários utilizadores acedam ao sistema através de autenticação com username e password. Cada utilizador possui acesso apenas aos seus próprios dados, sendo todas as operações registadas e associadas ao utilizador autenticado no momento.

-----------------------------------------------------------------------------------------------------------------------------

Gestão de Utilizadores

O sistema inclui gestão completa de utilizadores (CRUD), sendo obrigatório que o campo username seja único. Todos os utilizadores possuem o mesmo nível de permissões dentro da aplicação.

-----------------------------------------------------------------------------------------------------------------------------

Gestão de Artigos

A aplicação permite a gestão de:
 - Tipos de artigo (CRUD), utilizados para organizar os produtos;
 - Artigos (CRUD), associados a um tipo de artigo específico.
Na criação ou seleção de artigos, o utilizador deve primeiro escolher o tipo de artigo, de forma a facilitar a filtragem dos dados.

----------------------------------------------------------------------------------------------------------------------------

Orçamento

Existe um orçamento mensal único que define o valor máximo disponível para despesas do mês. Este orçamento regista quem o criou e quem o alterou, bem como as respetivas datas de modificação.
Durante a utilização da aplicação, o orçamento disponível vai sendo atualizado em tempo real à medida que os artigos são adicionados ou adquiridos.
Caso o orçamento seja ultrapassado, o sistema apresenta um alerta visível ao utilizador.

----------------------------------------------------------------------------------------------------------------------------

Gestão de Compras

Cada utilizador pode criar listas de compras, sendo registada a data de criação, alteração e o utilizador responsável por cada ação.
Cada compra pode conter:
 - Itens previstos (artigos planeados com quantidade estimada);
 - Itens não previstos (artigos adicionados durante a compra).
Durante a execução de uma compra, o utilizador deve indicar a quantidade adquirida e o preço unitário de cada artigo.
As compras podem ser alteradas apenas enquanto não estiverem fechadas.
Quando um item não previsto é adicionado, este é automaticamente considerado como adquirido.

----------------------------------------------------------------------------------------------------------------------------

Finalização de Compras

Após a conclusão, o utilizador pode fechar a compra, sendo registada a data, hora e utilizador responsável pelo fecho. A partir desse momento, a compra deixa de poder ser alterada.

----------------------------------------------------------------------------------------------------------------------------

Estatísticas

A aplicação inclui um módulo de estatísticas com múltiplas análises, nomeadamente:

 - Comparação mensal entre orçamento definido, total de compras e diferença entre ambos;
 - Percentagem de artigos previstos e não previstos em compras fechadas;
 - Sugestão de orçamento para o mês seguinte com base em meses anteriores;
 - Sugestão de listas de compras com base em padrões de consumo por semana do mês.

----------------------------------------------------------------------------------------------------------------------------

Exportação de Dados

O sistema permite exportar todas as compras fechadas para ficheiro CSV, com separador ponto e vírgula. O ficheiro inclui cabeçalho e os seguintes campos:
Nome da compra, data de criação, data de fecho, nome do artigo, se é previsto ou não previsto, quantidade prevista, quantidade adquirida e preço unitário.

----------------------------------------------------------------------------------------------------------------------------

Persistência de Dados

Toda a informação da aplicação é armazenada numa base de dados relacional SQL Server, garantindo a integridade dos dados. O acesso à base de dados é realizado através do Entity Framework.

----------------------------------------------------------------------------------------------------------------------------

Formulários da Aplicação

A aplicação é composta pelos seguintes formulários obrigatórios:

 - Login
 - Menu principal
 - Gestão de tipos de artigo (CRUD)
 - Gestão de artigos (CRUD)
 - Gestão de orçamento (CRUD)
 - Planeamento de compras
 - Criação/edição de compra
 - Modo de compra (execução da compra)
 - Estatísticas

----------------------------------------------------------------------------------------------------------------------------

Objetivo Final

O objetivo do sistema é permitir uma gestão eficiente das finanças domésticas, fornecendo ferramentas de planeamento, controlo e análise de gastos, de forma a melhorar a organização do orçamento familiar.

----------------------------------------------------------------------------------------------------------------------------


