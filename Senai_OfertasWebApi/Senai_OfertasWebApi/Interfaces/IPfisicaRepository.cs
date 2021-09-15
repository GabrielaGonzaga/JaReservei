using Senai_OfertasWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Interfaces
{
    interface IPfisicaRepository
    {
        /// <summary>
        /// Lista todos os Pfisica
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Pfisica> Listar();

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        Pfisica BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novaPfisica">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(Pfisica novaPfisica);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);


        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="pfisicaAtualizada">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, Pfisica pfisicaAtualizada);

    }
}
