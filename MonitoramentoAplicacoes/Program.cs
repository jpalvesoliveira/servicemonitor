using System;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces;
using Agora.Brokerage.Cadastro.CBLC.Mode.Model;
using Agora.Brokerage.Cadastro.CBLC.Core.Servicos;
using Agora.Brokerage.Cadastro.CBLC.Core.Repositorios;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MonitoramentoAplicacoes
{
    class Program
    {
        private static ServiceConfigurations _configurations;

        static void Main(string[] args)
        {
            Console.WriteLine("Carregando configurações...");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            _configurations = new ServiceConfigurations();
            new ConfigureFromConfigurationOptions<ServiceConfigurations>(
                configuration.GetSection("ServiceConfigurations"))
                    .Configure(_configurations);


            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<ICBLCRepositorio, CBLCRepositorio>()
            .AddTransient<ICBLCService, ServicoCBLC>()
            .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                       .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            
            IWorker<ItemCadastro> s = new Worker<ItemCadastro>(serviceProvider.GetService<ICBLCService>(), _configurations.Intervalo, logger);

            logger.LogDebug("All done!");
        }
    }
}