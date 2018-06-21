using System;
using System.Collections.Generic;
using System.Text;

namespace Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces
{
    public interface IWorker<T> where T : class
    {
        void Carregar();
        void Processar();
    }
}
