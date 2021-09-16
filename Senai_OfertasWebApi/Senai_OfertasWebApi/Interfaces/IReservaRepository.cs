using Senai_OfertasWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Interfaces
{
    interface IReservaRepository
    {

        /// <sumamary>
        /// Lista todas os Reservas
        /// </sumamary>
        /// <returns>umaa lista de Reservas</returns>
        List<Reserva> Listar();

        /// <sumamary>
        /// Busca uma Reserva através do ID
        /// </sumamary>
        /// <param name="id">ID do Reserva que será buscada</param>
        /// <returns>uma Reserva buscada</returns>
        Reserva BuscarPorId(int id);

        /// <sumamary>
        /// Cadastra uma nova Reserva
        /// </sumamary>
        /// <param name="novaReserva">Objeto novaReserva que será cadastrado</param>
        void Cadastrar(Reserva novaReserva);

        /// <sumamary>
        /// Deleta uma Reserva existente
        /// </sumamary>
        /// <param name="id">ID do Reserva que será deletado</param>
        void Deletar(int id);


        /// <sumamary>
        /// Atualiza uma Reserva existente
        /// </sumamary>
        /// <param name="id">ID do Reserva que será Atualizada</param>
        /// <param name="ReservaAtualizada">Objeto ReservaAtualizada com as novas informações</param>
        void Atualizar(int id, Reserva ReservaAtualizada);

        /// <summary>
        /// Lista apenas as Reservas do usuário
        /// </summary>
        /// <param name="idUsuario">id da Reserva a ser buscada</param>
        /// <returns>uma Reserva buscada</returns>
        List<Reserva> MinhasReservas(int idUsuario);

    }
}
