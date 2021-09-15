using Senai_OfertasWebApi.Contexts;
using Senai_OfertasWebApi.Domains;
using Senai_OfertasWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Repositories
{
    public class tipoProdutoRepository : ITipoProdutoRepository
    {

        JaReserveiContext ctx = new JaReserveiContext();

        public void Atualizar(int id, TipoProduto TipoProdutoAtualizado)
        {
            TipoProduto tipoprodutoBuscado = ctx.TipoProdutos.Find(id);

            if (TipoProdutoAtualizado != null)
            {
                TipoProdutoAtualizado.NomeTipoProduto = TipoProdutoAtualizado.NomeTipoProduto;
            }

            ctx.TipoProdutos.Update(tipoprodutoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoProduto novoTipoProduto)
        {

            ctx.TipoProdutos.Add(novoTipoProduto);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            TipoProduto TipoProdutoBuscado = ctx.TipoProdutos.Find(id);

            //remove a classe buscada
            ctx.TipoProdutos.Remove(TipoProdutoBuscado);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoProduto> Listar()
        {
            return ctx.TipoProdutos.ToList();
        }
    }
}
