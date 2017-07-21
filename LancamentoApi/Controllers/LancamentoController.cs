using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LancamentoRepositorio;
using LancamentoRepositorio.Model;

namespace LancamentoApi.Controllers
{
    public class LancamentoController : ApiController
    {

        private LancamentoRepository _lancamentoRepositorio;

        public LancamentoController()
        {
            _lancamentoRepositorio = new LancamentoRepository();
        }

        // Inserindo categoria
        // Deste modo deve se mandar o parâmetro no BODY, usar postman com verbo POST
        public IHttpActionResult Post(Lancamento lancamento)
        {
            _lancamentoRepositorio.Post(lancamento);
            return Ok();
        }

    }


}

