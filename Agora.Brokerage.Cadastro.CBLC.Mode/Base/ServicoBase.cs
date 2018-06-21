using System.Collections.Generic;
using System.Threading.Tasks;
using Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces;

namespace Agora.Brokerage.Cadastro.CBLC.Mode.Base
{
    public class ServicoBase<T> : IServiceBase<T> where T : class
    {
        protected IRepositorioBase<T> _repo;

        public ServicoBase(IRepositorioBase<T> repo)
        {
            _repo = repo;
        }

        public void Add(T obj)
        {
            _repo.Add(obj);
        }

        public void Delete(T obj)
        {
            _repo.Delete(obj);
        }

        public T Get(long pCPF)
        {
            return _repo.Get(pCPF);
        }

        public IList<T> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
