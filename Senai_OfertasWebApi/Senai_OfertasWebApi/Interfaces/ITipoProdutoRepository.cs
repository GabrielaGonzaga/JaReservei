using Senai_OfertasWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Interfaces
{
    interface ITipoProdutoRepository
    {

        /// <summary>
        /// Uma lista de TipoProduto
        /// </summary>
        /// <returns>Retorna uma lista de TipoProduto</returns>
        List<TipoProduto> Listar();

        /// <summary>
        /// Cadastra um novo tipo de TipoProduto
        /// </summary>
        void Cadastrar(TipoProduto novoTipoProduto);

        /// <summary>
        /// Atualiza um TipoProduto existente
        /// </summary>
        /// <param name="id">id do TipoProduto que será atualizado</param>
        /// <param name="TipoProdutoAtualizado">Objeto TipoProdutoAtualizado com as novas Informações</param>
        void Atualizar(int id, TipoProduto TipoProdutoAtualizado);

        /// <summary>
        /// Deleta um TipoProduto existente
        /// </summary>
        /// <param name="id">id do TipoProduto que sera deletado</param>
        void Deletar(int id);

    }
}
