using Senai_OfertasWebApi.Contexts;
using Senai_OfertasWebApi.Domains;
using Senai_OfertasWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Repositories
{
    public class produtoRepository : IProdutoRepository
    {

        SenaiOfertasContext ctx = new SenaiOfertasContext();

        public void Atualizar(int id, Produto produtoAtualizado)
        {
            Produto produtoBuscado = ctx.Produtos.Find(id);

            if (produtoAtualizado != null)
            {
                produtoAtualizado.NomeProduto = produtoAtualizado.NomeProduto;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Quantidade = produtoAtualizado.Quantidade;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Descricao = produtoAtualizado.Descricao;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.LinkProduto = produtoAtualizado.LinkProduto;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.ImagemProduto = produtoAtualizado.ImagemProduto;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.Preco = produtoAtualizado.Preco;
            }

            if (produtoAtualizado != null)
            {
                produtoBuscado.IdTipoProduto = produtoAtualizado.IdTipoProduto;
            }

            ctx.Produtos.Update(produtoBuscado);

            ctx.SaveChanges();

        }

        public Produto BuscarPorId(int id)  
        {
            return ctx.Produtos
                .Select(s => new Produto()
                {
                    IdProduto = s.IdProduto,
                    NomeProduto = s.NomeProduto,
                    Quantidade = s.Quantidade,
                    Preco = s.Preco,
                    LinkProduto = s.LinkProduto,
                    ImagemProduto = s.ImagemProduto,
                    IdTipoProduto = s.IdTipoProduto

                })
                .FirstOrDefault(s => s.IdProduto == id);
        }

        public void Cadastrar(Produto novoProduto)
        {
            ctx.Produtos.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Produtos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return ctx.Produtos.ToList();
        }
    }
}
