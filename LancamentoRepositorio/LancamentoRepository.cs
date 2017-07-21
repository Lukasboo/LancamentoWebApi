using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LancamentoRepositorio.Model;

namespace LancamentoRepositorio
{
    public class LancamentoRepository
    {
        private readonly DatabaseConnection _connect;
        public LancamentoRepository()
        {
            _connect = new DatabaseConnection();
        }

        public List<Lancamento> Buscar()
        {
            var lancamento = new List<Lancamento>();

            _connect.ExecutarProcedure("GKSSP_SelLancamentos");

            using (var leitor = _connect.ExecuteReader())
            {
                while (leitor.Read())
                {
                    lancamento.Add(new Lancamento
                    {
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        IdLancamento = leitor.GetInt32(leitor.GetOrdinal("IdLancamento")),
                        DataEvento = leitor.GetDateTime(leitor.GetOrdinal("IdDataEvento")),
                        Descricao = leitor.GetString(leitor.GetOrdinal("Descricao")),
                        Valor = leitor.GetDecimal(leitor.GetOrdinal("Valor"))
                        /*IdCategoria = leitor.GetInt32(leitor.GetOrdinal("IdCategoria"))
                        IdAcao = leitor.GetInt32(leitor.GetOrdinal("IdAcao"))
                        IdConta = leitor.GetInt32(leitor.GetOrdinal("IdConta"))
                        FG_Pago = leitor.GetInt32(leitor.GetOrdinal("FG_Pago"))
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),*/
                    });
                }
            }

            return lancamento;
        }

        public Lancamento Get(int id)
        {
            _connect.ExecutarProcedure("GKSSP_SelLancamento");
            _connect.AddParametro("@IdLancamento", id);
            using (var leitor = _connect.ExecuteReader())
                if (leitor.Read())
                    return new Lancamento
                    {
                        DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
                        IdLancamento = leitor.GetInt32(leitor.GetOrdinal("IdLancamento")),
                        DataEvento = leitor.GetDateTime(leitor.GetOrdinal("IdDataEvento")),
                        Descricao = leitor.GetString(leitor.GetOrdinal("Descricao")),
                        Valor = leitor.GetDecimal(leitor.GetOrdinal("Valor"))
                    };

            return null;
        }

        public void Post(Lancamento lancamento)
        {
            /*DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("DataCadastro")),
            IdLancamento = leitor.GetInt32(leitor.GetOrdinal("IdLancamento")),
            DataEvento = leitor.GetDateTime(leitor.GetOrdinal("IdDataEvento")),
            Descricao = leitor.GetString(leitor.GetOrdinal("Descricao")),
            Valor = leitor.GetDecimal(leitor.GetOrdinal("Valor"))*/
            
            _connect.ExecutarProcedure("GKSSP_InsLancamento");
            _connect.AddParametro("@DataEvento", lancamento.DataEvento);
            //_connect.AddParametro("@DataCadastro", lancamento.DataCadastro);
            _connect.AddParametro("@Descricao", lancamento.Descricao);
            _connect.AddParametro("@IdCategoria", lancamento.IdCategoria);
            _connect.AddParametro("@IdAcao", lancamento.IdAcao);
            _connect.AddParametro("@IdConta", lancamento.IdConta);
            _connect.AddParametro("@Valor", lancamento.Valor);
            _connect.ExecutarSemRetorno();
        }

        public void Put(Lancamento lancamento)
        {
            /*_connect.ExecutarProcedure("GKSSP_UpdLancamento");
            _connect.AddParametro("@IdCategoria", lancamento.IdLancamento);
            _connect.AddParametro("@Nome", lancamento.Nome);
            _connect.ExecutarSemRetorno();*/
        }

        public void Delete(int idLancamentoAntiga, int idLancamentoNova)
        {
            /*_connect.ExecutarProcedure("GKSSP_DelCategoria");
            _connect.AddParametro("@IdLancamentoAnt", idLancamentoNova);
            _connect.AddParametro("@IdLancamentoNova", idLancamentoNova);
            _connect.ExecutarSemRetorno();*/
        }
    }
}

