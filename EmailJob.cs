using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Quartz;
using QuartzEmailJob;

public class EmailJob : IJob
{
    private readonly EmailSettings _settings;

    public EmailJob(IConfiguration config)
    {
        _settings = config.GetSection("EmailSettings").Get<EmailSettings>()!;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"[JOB] Enviando e-mail em: {DateTime.Now}");

        var remetente = _settings.Remetente;
        var destinatario = _settings.Destinatario;
        var senha = _settings.Senha;

        var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(remetente, senha)
        };

        var mail = new MailMessage(
            remetente,
            destinatario,
            "Tarefa Agendada Quartz",
            "Este e-mail foi enviado automaticamente pelo Quartz.NET"
        );

        try
        {
            await smtp.SendMailAsync(mail);
            Console.WriteLine("[OK] E-mail enviado com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] Falha ao enviar e-mail: {ex.Message}");
        }
    }
}