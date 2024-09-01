🌐 Loja Virtual com Blazor WebAssembly
Bem-vindo ao BlazorShop! Este é um projeto de loja virtual desenvolvido utilizando Blazor WebAssembly e ASP.NET Core, projetado para oferecer uma experiência rica, interativa e responsiva para seus usuários.

🚀 Configuração do Projeto
1. ⚙️ Configuração do appsettings.json
Para iniciar o projeto, configure o arquivo appsettings.json no projeto BlazorShop.Api com as informações do seu banco de dados:


Nota: A chave JWT (Jwt:Key) deve ter pelo menos 32 caracteres.

2. 🗄️ Migrações do Banco de Dados
Para configurar o banco de dados, gere as migrações necessárias para AppDbContext e AppDbContextIdentity:

![image](https://github.com/user-attachments/assets/6e8ab929-d862-4420-8f31-ff35589d31dd)


bash
Copy code
dotnet ef migrations add InitialMigration --context AppDbContext

dotnet ef database update --context AppDbContext


dotnet ef migrations add IdentityMigration --context AppDbContextIdentity

dotnet ef database update --context AppDbContextIdentity


Importante: Certifique-se de que o banco de dados esteja estruturado conforme a imagem abaixo.



3. 🌐 Inicialização dos Projetos API e Web
   
Como o projeto utiliza Blazor WebAssembly, é necessário garantir que tanto a API quanto o projeto Web estejam rodando simultaneamente. Para isso:

Na solução do Visual Studio, vá até as propriedades da solução.
Configure para que BlazorShop.Api e BlazorShop.Web sejam iniciados juntos.


![image](https://github.com/user-attachments/assets/27f6808b-2c4a-40b3-a547-d40d2aefed64)



4. 🔧 Funcionalidades em Andamento
💳 Pagamento: Integração com sistemas de pagamento.

🔒 Gerenciamento de Segurança: Implementação de segurança no gerenciamento de produtos.

📦 Controle de Estoque: Validação e atualização do estoque durante o processo de pagamento.

📄 Licença
Este projeto é licenciado sob os termos da licença MIT.


📫 Contribuindo
Contribuições são bem-vindas! Se você deseja contribuir para este projeto, siga os passos abaixo:

Faça um fork do repositório.

Crie um branch para a sua feature (git checkout -b feature/MinhaFeature).

Commit suas alterações (git commit -m 'Adiciona MinhaFeature').

Push para o branch (git push origin feature/MinhaFeature).

Abra um Pull Request.

🖼️ Screenshots

![image](https://github.com/user-attachments/assets/fb785009-3762-4776-82f5-6b927e94ee12)

![image](https://github.com/user-attachments/assets/7dc66ea5-e614-43aa-8a67-a566e81d113a)

![image](https://github.com/user-attachments/assets/016cf9d8-4532-4b2a-adf4-37554d7ccc70)

![image](https://github.com/user-attachments/assets/ba60f20c-5f0b-4403-9dd9-bc736f6f5873)



✨ Agradecimentos
Agradecemos a todos os colaboradores e usuários por apoiarem o desenvolvimento contínuo do BlazorShop!

Sinta-se à vontade para copiar e colar este conteúdo em seu README.md no GitHub. Espero que esta versão melhore a apresentação do seu projeto e atraia mais colaboradores! 🚀

Este README fornece um guia conciso para configurar e executar o projeto BlazorShop. Fique à vontade para contribuir e melhorar este projeto!



