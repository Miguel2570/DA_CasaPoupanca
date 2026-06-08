# 🏠 CasaPoupança

Sistema de gestão doméstica desenvolvido em **C# Windows Forms**, utilizando arquitetura **MVC**, para controlo de orçamentos, planeamento de compras e análise de despesas.

---

# 📋 Índice

- Sobre o Projeto
- Credenciais de Acesso
- Funcionalidades
- Estrutura do Projeto
- Formulários da Aplicação
- Base de Dados
- Regras de Negócio
- Proteções Implementadas
- Tecnologias Utilizadas
- Instalação e Execução
- Autores
- Licença

---

# 📖 Sobre o Projeto

O **CasaPoupança** é uma aplicação desktop que permite gerir:

- Utilizadores
- Tipos de Artigo
- Artigos
- Orçamentos Mensais
- Planeamento de Compras
- Execução de Compras
- Estatísticas
- Exportação de Dados CSV

O sistema segue o padrão **MVC (Model-View-Controller)** garantindo uma separação clara entre interface, lógica de negócio e acesso a dados.

---

# 🔑 Credenciais de Acesso

No primeiro acesso não existem utilizadores registados.

## Primeiro Login

1. Abrir a aplicação.
2. Clicar em **Registar**.
3. Criar um utilizador com um username único.
4. Efetuar login com as credenciais criadas.

---

# 🚀 Funcionalidades

## 👤 Gestão de Utilizadores

- CRUD completo de utilizadores
- Username único obrigatório
- Password encriptada com SHA256
- Todos os utilizadores possuem o mesmo nível de permissões

---

## 📦 Gestão de Tipos de Artigo

- CRUD de tipos de artigo
- Listagem de todos os tipos
- Validação de nomes duplicados

---

## 🛒 Gestão de Artigos

- CRUD de artigos
- Associação a um tipo de artigo
- Filtro por tipo de artigo
- Registo de preço unitário

---

## 💰 Orçamento Mensal

- Um único orçamento por mês/ano
- CRUD de orçamentos
- Registo do utilizador criador
- Registo do utilizador que alterou
- Cálculo automático do total gasto

### Estados do Orçamento

| Estado | Cor |
|----------|----------|
| Orçamento disponível | 🟢 Verde |
| Orçamento ultrapassado | 🔴 Vermelho |

---

## 📋 Planeamento de Compras

- Criação de listas de compras
- Adição de itens previstos
- Definição de quantidades previstas
- Filtro por estado:
  - Todas
  - Abertas
  - Fechadas
- Visualização detalhada das compras
- Separação entre itens previstos e não previstos

---

## 🏪 Modo Compra (Execução)

- Visualização dos itens previstos
- Registo da quantidade adquirida
- Registo do preço unitário real
- Adição de itens não previstos
- Atualização automática dos gastos
- Consulta do orçamento disponível em tempo real
- Alerta visual quando o orçamento é ultrapassado
- Registo automático da data de fecho
- Registo do utilizador responsável

---

## 📊 Estatísticas

### Resumo Mensal

- Orçamento definido
- Total gasto
- Diferença entre orçamento e despesa

### Compras Fechadas

- Percentagem de itens previstos
- Percentagem de itens não previstos

### Sugestões

#### Sugestão de Orçamento

Calculada pela média dos últimos 3 meses.

#### Sugestão de Lista de Compras

Baseada nas compras efetuadas na mesma semana dos meses anteriores.

---

## 📄 Exportação CSV

Permite exportar:

- Compras fechadas
- Resumo mensal
- Estatísticas
- Listas de compras
- Utilizadores
- Artigos
- Orçamentos

Características:

- Separador `;`
- Cabeçalhos incluídos
- Compatível com Microsoft Excel

---

# 🏗️ Estrutura do Projeto

```text
CasaPoupanca/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── ArtigoController.cs
│   ├── CompraController.cs
│   ├── ModoCompraController.cs
│   ├── OrcamentoController.cs
│   ├── PlaneamentoComprasController.cs
│   └── EstatisticasController.cs
│
├── Models/
│   ├── Artigo.cs
│   ├── Compra.cs
│   ├── ConfigDB.cs
│   ├── Estatisticas.cs
│   ├── ItemCompra.cs
│   ├── Orcamento.cs
│   ├── Session.cs
│   ├── TipoArtigo.cs
│   └── Utilizador.cs
│
├── Views /
│   ├── FormLogin.cs
│   ├── FormPrincipal.cs
│   ├── FormTipoArtigo.cs
│   ├── FormArtigo.cs
│   ├── FormOrcamento.cs
│   ├── FormCompra.cs
│   ├── FormModoCompra.cs
│   ├── FormPlaneamentoCompras.cs
│   ├── FormEstatisticas.cs
│   ├── FormExportarCSV.cs
│   ├── FormUtilizadores.cs
│   ├── FormProfile.cs
│   └── FormItemNaoPrevisto.cs
│
├── .gitignore
├── App.config
└── Program.cs
```

---

# 🖥️ Formulários da Aplicação

| Código | Formulário | Ficheiro | Descrição |
|----------|----------|----------|----------|
| a | Register | FormRegister.cs | Autenticação |
| b | Login | FormLogin.cs | Autenticação |
| c | Principal | FormPrincipal.cs | Menu principal |
| d | Tipos de Artigo | FormTipoArtigo.cs | CRUD tipos de artigo |
| e | Artigos | FormArtigo.cs | CRUD artigos |
| f | Orçamentos | FormOrcamento.cs | CRUD orçamentos |
| g | Planeamento | FormPlaneamentoCompras.cs | Listagem de compras |
| h | Criar/Editar Compra | FormCompra.cs | Planeamento |
| i | Modo Compra | FormModoCompra.cs | Execução |
| j | Estatísticas | FormEstatisticas.cs | Estatísticas |
| k | Exportar CSV | FormExportarCSV.cs | Exportação |
| l | Utilizadores | FormUtilizadores.cs | Gestão utilizadores |
| m | Perfil | FormProfile.cs | Perfil |
| n | Item Não Previsto | FormItemNaoPrevisto.cs | Artigos extra |

---

# 🗄️ Base de Dados

## Tabelas

### Utilizadores

- Id
- Username
- Nome
- Password (SHA256)
- DataRegisto

### TiposArtigo

- Id
- Nome

### Artigos

- Id
- Nome
- TipoArtigoId
- PrecoUnitario

### Orcamentos

- Id
- Mes
- Ano
- Valor
- CriadoPorId
- AlteradoPorId
- DataCriacao
- DataAlteracao

### Compras

- Id
- Nome
- DataCriacao
- DataAlteracao
- IsFechada
- DataFecho
- CriadoPorId
- AlteradoPorId
- FechadaPorId

### ItensCompra

- Id
- CompraId
- ArtigoId
- QuantidadePrevista
- QuantidadeAdquirida
- PrecoUnitario
- IsPrevisto
- Observacao

---

## Relações

- Artigo → TipoArtigo (N:1)
- ItemCompra → Compra (N:1)
- ItemCompra → Artigo (N:1)
- Compra → Utilizador (N:1)
- Orcamento → Utilizador (N:1)

---

# 📐 Regras de Negócio

- Cada utilizador visualiza apenas os seus dados.
- Compras fechadas não podem ser alteradas.
- Existe apenas um orçamento por mês e ano.
- Username único no sistema.
- Itens não previstos entram automaticamente como adquiridos.
- Passwords armazenadas utilizando SHA256.
- Todas as operações registam utilizador e data.

---

# 🛡️ Proteções Implementadas

- Validação de campos obrigatórios
- Tratamento de exceções com try-catch
- Mensagens de erro informativas
- Confirmação antes de eliminar registos
- Verificação de duplicados
- Proteção contra edição de compras fechadas
- Alertas visuais de orçamento
- Controlo de integridade dos dados

---

# 🛠️ Tecnologias Utilizadas

- C#
- .NET Framework
- Windows Forms
- Entity Framework
- SQL Server / LocalDB
- MVC
- SHA256

---

# ▶️ Instalação e Execução

## Requisitos

- Visual Studio 2022 ou superior
- SQL Server LocalDB
- .NET Framework compatível com o projeto

## Execução

```bash
git clone https://github.com/Miguel2570/DA_CasaPoupanca
```

1. Abrir a solução no Visual Studio.
2. Configurar a Connection String no `App.config`.
3. Executar o projeto.

---

# 👨‍🎓 Autores

**[Miguel da Costa Tobias]** — Nº [2241574]

**[Nome Completo Estudante 2]** — Nº [XXXXXX]

**[Nome Completo Estudante 3]** — Nº [XXXXXX]

**Curso:** Técnico Superior Profissional de Programação de Sistemas de Informação

**Unidade Curricular:** Desenvolvimento de Aplicações

**Ano Letivo:** 2025/2026

**Data de Entrega:** 09 de Junho de 2026

---

# 📜 Licença

Projeto desenvolvido exclusivamente para fins académicos no âmbito da Unidade Curricular de Desenvolvimento de Aplicações.

---

# 📝 Observações

- Implementação baseada no padrão MVC.
- Os Controllers são responsáveis pela lógica de negócio e acesso a dados.
- As Views comunicam apenas com os Controllers.
- A sessão do utilizador mantém-se ativa durante toda a execução da aplicação.
- O sistema foi desenvolvido com foco na gestão doméstica e controlo orçamental.