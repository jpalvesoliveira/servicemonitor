using System.Collections.Generic;
using System.Threading.Tasks;
using Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces;

namespace Agora.Brokerage.Cadastro.CBLC.Mode.Base
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public abstract void Add(T obj);

        public abstract void Delete(T obj);

        public abstract T Get(long pCPF);

        public abstract IList<T> GetAll();
    }
}
