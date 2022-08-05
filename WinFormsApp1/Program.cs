using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
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

            var host = CreateHostBuilder().Build();
            var formTelaPrincipal = host.Services.GetRequiredService<TelaPrincipal>();
            Application.Run(formTelaPrincipal);

        }

        static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
                services.AddTransient<IUsuarioRepositorio, BDUsuario>()
                        .AddTransient<TelaPrincipal>());
    }
}
