using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        void Add(T obj);
        void Delete(T obj);
        T Get(long pCPF);
        IList<T> GetAll();
    }
}
