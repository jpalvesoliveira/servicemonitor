using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agora.Brokerage.Cadastro.CBLC.Mode.Base;
using Agora.Brokerage.Cadastro.CBLC.Mode.Interfaces;
using Agora.Brokerage.Cadastro.CBLC.Mode.Model;

namespace Agora.Brokerage.Cadastro.CBLC.Core.Servicos
{
    public class ServicoCBLC : ServicoBase<ItemCadastro>, ICBLCService
    {
        public ServicoCBLC(ICBLCRepositorio repo) : base (repo) { }
    }
}
