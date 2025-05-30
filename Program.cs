using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using QuartzEmailJob;

Console.WriteLine("Iniciando agendador de e-mails...");

// Criar host com DI e config
var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddUserSecrets<EmailSettings>(); // <-- Usa secrets com segurança
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<EmailSettings>(context.Configuration.GetSection("EmailSettings"));

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            var jobKey = new JobKey("emailJob");

            q.AddJob<EmailJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("gatilhoEmail")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(30).RepeatForever()));
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    })
    .Build();

await host.RunAsync();
