using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using FluentMigrator.Runner;
using System.Windows.Forms;
using CrudWindowsForms.Infra.Migracao;
using FluentValidation;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Dominio.Validadores;

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
            var usuarioValidador = host.Services.GetService<IValidator<Usuario>>();

            Application.Run(new TelaPrincipal(usuarioRepositorio, usuarioValidador));
        }

        static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
                services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioLinqToDB>()
                        .AddScoped<LinqToDBConexao>()
                        .AddScoped<IValidator<Usuario>, ValidadorUsuario>());

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
