# QuartzEmailJob

Projeto de exemplo em .NET 9.0 que utiliza o **Quartz.NET** para agendar o envio automático de e-mails a cada 30 segundos. As configurações de e-mail são carregadas de forma segura usando **appsettings.json** e **User Secrets**.

## 🛠️ Tecnologias Utilizadas

- .NET 9.0
- Quartz.NET (`Quartz`, `Quartz.Extensions.DependencyInjection`, `Quartz.Extensions.Hosting`)
- SMTP (Gmail)
- Injeção de Dependência (DI)
- Microsoft.Extensions.Configuration
- User Secrets para gerenciamento seguro da senha do e-mail

---

## 📦 Estrutura do Projeto

QuartzEmailJob/
├── Program.cs # Configuração do agendador e serviços
├── EmailJob.cs # Lógica do envio de e-mails
├── EmailSettings.cs # Classe de configuração do e-mail
├── appsettings.json # Configurações públicas (sem senha)
├── .gitignore # Ignora secrets e pastas bin/obj
├── README.md # Este arquivo 


## ⚙️ Configuração

### 1. Clonar o projeto

### 2. Restaurar dependências

dotnet restore

### 3. Configurar User Secrets
dotnet user-secrets init

Adicione sua senha de aplicativo do Gmail (gere no Google Conta > Segurança > Senhas de app):
dotnet user-secrets set "EmailSettings:Senha" "sua_senha_de_app"


📝 Configuração do appsettings.json

{
  "EmailSettings": {
    "Remetente": "seu-email@gmail.com",
    "Destinatario": "destinatario@email.com"
  }
}

A senha do e-mail é carregada de forma segura via user-secrets e não deve ser adicionada no appsettings.json.

▶️ Executar o Projeto
dotnet run


🔒 Segurança
A senha de e-mail não é armazenada no código nem no Git.

O projeto usa o sistema de User Secrets do .NET para manter suas credenciais seguras durante o desenvolvimento.

Certifique-se de não compartilhar seu secrets.json.

📤 Deploy
Este projeto é um app de console voltado para estudos e ambientes controlados. Para produção:

Utilize IHostedService com logs persistentes

Configure limites de envio

Proteja variáveis sensíveis com Azure Key Vault, AWS Secrets Manager, etc.

📄 Licença
Este projeto está licenciado sob a MIT License.

🙋‍♂️ Autor
Fabrício Pinheiro Monteiro de Souza
Email: fabricio.cientistati@gmail.com
GitHub: @fabriciocientistati