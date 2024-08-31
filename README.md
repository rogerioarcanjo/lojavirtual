# Loja Virtual - BlazorShop
Bem-vindo ao BlazorShop! Este é um projeto de loja virtual desenvolvido com Blazor WebAssembly e ASP.NET Core, que oferece uma experiência rica e responsiva para seus usuários.

Configuração do Projeto
1. Configuração do appsettings.json
Para iniciar o projeto, é necessário configurar o arquivo appsettings.json no projeto BlazorShop.Api. Atualize a string de conexão com os dados do seu banco de dados:

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=seucaminhobancodedados;Initial Catalog=ShopDBTeste;User ID=seuusuario;Password=seupassword;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
  
  "Jwt": {
    "Key": "YourSuperSecretKeyWith32CharactersOrMore",
    "Issuer": "YourAppNameHere",
    "Audience": "YourAudienceHere"
  },
  
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  
  "AllowedHosts": "*"
}


![image](https://github.com/user-attachments/assets/acb2397c-f22d-4de4-a8b1-3100754d8a7f)

Nota: A chave JWT (Jwt:Key) deve ter pelo menos 32 caracteres.

2. Migrações do Banco de Dados
Para configurar o banco de dados, gere as migrações necessárias para AppDbContext e AppDbContextIdentity:

dotnet ef migrations add InitialMigration --context AppDbContext

dotnet ef database update --context AppDbContext

dotnet ef migrations add IdentityMigration --context AppDbContextIdentity

dotnet ef database update --context AppDbContextIdentity

Importante: Certifique-se de que o banco de dados esteja estruturado conforme a imagem abaixo.

![image](https://github.com/user-attachments/assets/e514cc88-7a39-484b-b4e5-f2399fb85f97)


3. Inicialização dos Projetos API e Web
Como o projeto utiliza Blazor WebAssembly, é necessário garantir que tanto a API quanto o projeto Web estejam rodando simultaneamente. Para isso:

Na solução do Visual Studio, vá até as propriedades da solução.

Configure para que BlazorShop.Api e BlazorShop.Web sejam iniciados juntos.

![image](https://github.com/user-attachments/assets/a0c85bf9-bd7c-418e-8bcf-94fcb6bdce7e)

![image](https://github.com/user-attachments/assets/b95d243c-89ce-416d-ad1a-7803f7502dc7)

4. Funcionalidades em Andamento
Ainda há funcionalidades a serem implementadas, incluindo:

Pagamento: Integração com sistemas de pagamento.

Gerenciamento de Segurança: Implementação de segurança no gerenciamento de produtos.

Controle de Estoque: Validação e atualização do estoque durante o processo de pagamento.


Este README fornece um guia conciso para configurar e executar o projeto BlazorShop. Fique à vontade para contribuir e melhorar este projeto!



