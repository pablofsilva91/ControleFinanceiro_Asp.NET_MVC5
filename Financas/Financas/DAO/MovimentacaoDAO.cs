using Financas.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{

    public class MovimentacaoDAO
    {
        private FinancasContext context;

        public MovimentacaoDAO(FinancasContext context)
        {
            this.context = context;
        }

        public void Adiciona(Movimentacao movimentacao)
        {
            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return context.Movimentacoes.ToList();
        }


        public IList<Movimentacao> BuscaPorUsuario(int? usuarioID)

        {

            return context.Movimentacoes.Where(m => m.UsuarioId == usuarioID).ToList();
        }

        public IList<Movimentacao> Busca(decimal? valorMinimo, decimal? valorMaximo,
                                             DateTime? dataMinima, DateTime? dataMaxima,
                                             Tipo? tipo, int? usuario)
        {
            IQueryable<Movimentacao> resultado = context.Movimentacoes;
            if (valorMinimo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor >= valorMinimo);
            }
            if (valorMaximo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor <= valorMaximo);
            }
            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(m => m.Data >= dataMinima);
            }
            if (dataMaxima.HasValue)
            {
                resultado = resultado.Where(m => m.Data <= dataMaxima);
            }
            if (tipo.HasValue)
            {
                resultado = resultado.Where(m => m.Tipo == tipo);
            }
            if (usuario.HasValue)
            {
                resultado = resultado.Where(m => m.UsuarioId == usuario);
            }
            return resultado.ToList();

        }
    }
}