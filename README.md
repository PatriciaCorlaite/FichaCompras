📋 FichaCompras  
Um sistema simples em ASP.NET Core MVC para cadastro de solicitações de compra de materiais.  
Ele permite adicionar, listar, editar, visualizar detalhes e excluir solicitações de forma prática.  

🚀 Funcionalidades  
✅ Adicionar solicitações de compra  
✅ Listar solicitações cadastradas  
✅ Editar informações da solicitação  
✅ Visualizar detalhes da solicitação  
✅ Excluir solicitações  

🛠️ Tecnologias Utilizadas  
- C#  
- .NET Core (ASP.NET Core MVC)  
- Entity Framework Core (InMemory Database para testes)  
- Bootstrap (para layout básico)  

💻 Como Executar o Programa  

1. Clone o repositório (caso esteja no GitHub):  

```bash
git clone https://github.com/SEU-USUARIO/FichaCompras.git
Abra o projeto no Visual Studio.

Restaure os pacotes NuGet (caso necessário):

bash
Copiar código
dotnet restore
Execute o programa:

bash
Copiar código
dotnet run
Abra no navegador:

arduino
Copiar código
https://localhost:5001
🛠️ Estrutura do Código

O projeto segue o padrão MVC (Model-View-Controller):

Model → Classe Solicitacao.cs (representa os dados da solicitação).

Controller → SolicitacaoController.cs (controla as ações e rotas do sistema).

Views → Páginas Razor (Index.cshtml, Create.cshtml, Edit.cshtml, Details.cshtml, Delete.cshtml).

Data → AppDbContext.cs e SolicitacaoRepository.cs (responsáveis pelo acesso e persistência de dados).

Business → SolicitacaoService.cs (regras de negócio).

📌 Exemplo de Uso

Página inicial (Index) → lista todas as solicitações cadastradas.

Clique em Nova Solicitação → insira os dados:

makefile
Copiar código
Material: Papel A4
Quantidade: 10
Data: 01/10/2025
Solicitação cadastrada com sucesso!

Na tela de listagem, é possível Visualizar Detalhes, Editar ou Excluir a solicitação.
