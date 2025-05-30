# QuartzEmailJob

Projeto de exemplo em .NET 9.0 que utiliza o **Quartz.NET** para agendar o envio automático de e-mails a cada 30 segundos. As configurações de e-mail são carregadas de forma segura usando **appsettings.json** e **User Secrets**.

---

## 🛠️ Tecnologias Utilizadas

- .NET 9.0
- Quartz.NET (`Quartz`, `Quartz.Extensions.DependencyInjection`)
- SMTP (Gmail)
- Injeção de Dependência (DI)
- `Microsoft.Extensions.Configuration` e `Microsoft.Extensions.Hosting`
- `User Secrets` para gerenciamento seguro da senha do e-mail

---

## 📦 Estrutura do Projeto

```
QuartzEmailJob/
├── Program.cs             # Configuração do agendador e serviços
├── EmailJob.cs            # Lógica do envio de e-mails
├── EmailSettings.cs       # Classe de configuração do e-mail
├── appsettings.json       # Configurações públicas (sem senha)
├── .gitignore             # Ignora secrets e pastas bin/obj
├── README.md              # Este arquivo
```

---

## ⚙️ Configuração

### 1. Clonar o projeto

```bash
git clone https://github.com/fabriciocientistati/QuartzEmailJob.git
cd QuartzEmailJob
```

### 2. Restaurar dependências

```bash
dotnet restore
```

### 3. Configurar User Secrets

```bash
dotnet user-secrets init
dotnet user-secrets set "EmailSettings:Senha" "sua_senha_de_app"
```

> 📌 A senha de aplicativo deve ser gerada em [Minha Conta Google > Segurança > Senhas de app](https://myaccount.google.com/security).

---

### 📝 Configuração do `appsettings.json`

```json
{
  "EmailSettings": {
    "Remetente": "seu-email@gmail.com",
    "Destinatario": "destinatario@email.com"
  }
}
```

> 🔐 **Importante:** Não adicione a senha no `appsettings.json`. Ela é lida de forma segura via `User Secrets`.

---

### ▶️ Executar o Projeto

```bash
dotnet run
```

A aplicação irá disparar um e-mail a cada 30 segundos e registrar no console o resultado.

---

## 🔒 Segurança

- Nenhuma senha é salva ou exposta no código-fonte.
- As credenciais são armazenadas de forma segura no sistema do `User Secrets` do .NET.
- O caminho do arquivo `secrets.json` fica em:

```bash
C:\Users\SeuUsuario\AppData\Roaming\Microsoft\UserSecrets\<UserSecretsId>\secrets.json
```

> ⚠️ Esse arquivo **nunca deve ser compartilhado ou versionado**.

---

## 📤 Deploy

Este projeto é voltado para fins didáticos e uso em ambientes controlados.

Para uso em produção, recomenda-se:

- Substituir o Console por `IHostedService` com logs persistentes.
- Utilizar provedores seguros como:
  - Azure Key Vault
  - AWS Secrets Manager
  - Google Secret Manager
- Adicionar tratamento de falhas e limites de envio por hora/dia.
- Implementar retries e fallback.

---

## 🙋‍♂️ Autor

**Fabrício Pinheiro Monteiro de Souza**  
📧 Email: fabricio.cientistati@gmail.com  
💻 GitHub: [@fabriciocientistati](https://github.com/fabriciocientistati)