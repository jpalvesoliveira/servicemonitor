using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces;
using Microsoft.Extensions.Logging;

namespace Agora.Brokerage.Cadastro.CBLC.Core.Servicos
{
    public class Worker<T> : IWorker<T> where T : class, new()
    {
        private IList<T> items;
        private IServiceBase<T> _svc;
        private static Timer _timer;
        private bool processing = false;
        private static object thisLock = new object();
        private int i = 0;
        private ILogger _logger;

        private AutoResetEvent waitHandle = new AutoResetEvent(false);

        public Worker(IServiceBase<T> svc, int period, ILogger logger)
        {
            _svc = svc;
            _timer = new Timer(
                         callback: TimerElapsed,
                         state: null,
                         dueTime: 0,
                         period: period);
            _logger = logger;
            waitHandle.WaitOne();
        }

        public void Carregar()
        {
            i += 1;

            if (Monitor.TryEnter(thisLock))
            {
                try
                {
                    items = _svc.GetAll();
                    items = new List<T>();

                    if (i == 1)
                    {
                        items.Add(new T());
                        items.Add(new T());
                        items.Add(new T());
                        Console.WriteLine("Lista 1");
                    }

                    if (i == 2)
                    {
                        items.Add(new T());
                        items.Add(new T());
                        Console.WriteLine("Lista 2");
                    }

                    if (i == 3)
                    {
                        items.Add(new T());
                        Console.WriteLine("Lista 3");
                    }

                    Processar();
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
            }
        }

        public void Processar()
        {
            try
            {
                var tasks = new List<Task>();
                if (!processing)
                {
                    processing = true;
                    foreach (T item in items)
                    {
                        tasks.Add(Task.Factory.StartNew((() => _svc.Add(item))));
                        _logger.LogTrace($"Criando o CBLC parar o CPF");
                        _logger.LogDebug($"Criando o CBLC parar o CPF");
                    }
                    Task.WaitAll(tasks.ToArray());
                    processing = false;
                }
            }
            catch (Exception)
            {
                processing = false;
            }
        }

        public void TimerElapsed(object state)
        {
            Carregar();
        }
    }
}
