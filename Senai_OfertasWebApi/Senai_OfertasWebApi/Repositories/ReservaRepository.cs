using Microsoft.EntityFrameworkCore;
using Senai_OfertasWebApi.Contexts;
using Senai_OfertasWebApi.Domains;
using Senai_OfertasWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Repositories
{
    public class ReservaRepository : IReservaRepository
    {

        JaReserveiContext ctx = new JaReserveiContext();

        public void Atualizar(int id, Reserva ReservaAtualizada)
        {
            //Busca um Reserva através do id
            Reserva ReservaBuscada = ctx.Reservas.Find(id);

            // Verifica as informações

            if (ReservaAtualizada.IdUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                ReservaBuscada.IdUsuario = ReservaAtualizada.IdUsuario;
            }

            if (ReservaAtualizada.IdProduto != null)
            {
                // Atribui os novos valores aos campos existentes
                ReservaBuscada.IdProduto = ReservaAtualizada.IdProduto;
            }

            if (ReservaAtualizada.Quantidade != null)
            {
                // Atribui os novos valores aos campos existentes
                ReservaBuscada.Quantidade = ReservaAtualizada.Quantidade;
            }

            if (ReservaAtualizada.PrecoTotal != null)
            {
                // Atribui os novos valores aos campos existentes
                ReservaBuscada.PrecoTotal = ReservaAtualizada.PrecoTotal;
            }
            // Atualiza o Reserva que foi buscado
            ctx.Reservas.Update(ReservaBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Reserva BuscarPorId(int id)
        {
            // Retorna o primeiro paciente encontrado para o ID informado
            return ctx.Reservas.FirstOrDefault(u => u.IdReserva == id);
        }

        public void Cadastrar(Reserva novaReserva)
        {
            // Adiciona este novoUsuario
            ctx.Reservas.Add(novaReserva);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Remove o tipo de usuário que foi buscado
            ctx.Reservas.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Reserva> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de Reservas, exceto as senhas
            return ctx.Reservas.ToList();
        }

        public List<Reserva> MinhasReservas(int idUsuario)
        {
            return ctx.Reservas

           .Include(c => c.IdUsuarioNavigation)

           .Where(c => c.IdUsuarioNavigation.IdUsuario == idUsuario)

           .ToList();
        }
    }
}
