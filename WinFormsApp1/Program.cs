using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using FluentMigrator.Runner;
using System.Windows.Forms;
using CrudWindowsForms.Infra.Migracao;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            var host = CreateHostBuilder().Build();
            var usuarioRepositorio = host.Services.GetService<IUsuarioRepositorio>();
            Application.Run(new TelaPrincipal(usuarioRepositorio));
        }

        static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
                services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioLinqToDB>());

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(ConstantesDoSql.CONEXAO_STRING)
                    .ScanIn(typeof(AdicionarTabelaDeUsuario).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
