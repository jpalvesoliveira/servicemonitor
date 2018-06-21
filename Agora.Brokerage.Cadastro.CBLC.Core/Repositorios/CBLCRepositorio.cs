using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agora.Brokerage.Cadastro.CBLC.Mode.Base;
using Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces;
using Agora.Brokerage.Cadastro.CBLC.Mode.Model;

namespace Agora.Brokerage.Cadastro.CBLC.Core.Repositorios
{
    public class CBLCRepositorio : RepositorioBase<ItemCadastro>, ICBLCRepositorio
    {
        private const string ADDCOMMAND = "";
        private const string DELETECOMMAND = "";

        public override void Add(ItemCadastro obj)
        {
            Console.WriteLine("Criando CBLC");
            Thread.Sleep(5000);
            Console.WriteLine("Fim Thread ID");
            //throw new NotImplementedException();
        }

        public override void Delete(ItemCadastro obj)
        {
            throw new NotImplementedException();
        }

        public override ItemCadastro Get(long pCPF)
        {
            throw new NotImplementedException();
        }

        public override IList<ItemCadastro> GetAll()
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
