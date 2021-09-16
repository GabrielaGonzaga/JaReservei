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
    public class PfisicaRepository : IPfisicaRepository
    {

        JaReserveiContext ctx = new JaReserveiContext();

        public void Atualizar(int id, Pfisica PfisicaAtualizada)
        {
            //Busca um Pfisica através do id
            Pfisica PfisicaBuscada = ctx.Pfisicas.Find(id);

            // Verifica as informações

            if (PfisicaAtualizada.IdUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                PfisicaBuscada.IdUsuario = PfisicaAtualizada.IdUsuario;
            }

            if (PfisicaAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                PfisicaBuscada.Nome = PfisicaAtualizada.Nome;
            }

            if (PfisicaAtualizada.Telefone != null)
            {
                // Atribui os novos valores aos campos existentes
                PfisicaBuscada.Telefone = PfisicaAtualizada.Telefone;
            }

            if (PfisicaAtualizada.Cpf != null)
            {
                // Atribui os novos valores aos campos existentes
                PfisicaBuscada.Cpf = PfisicaAtualizada.Cpf;
            }

            // Atualiza o Pfisica que foi buscado
            ctx.Pfisicas.Update(PfisicaBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Pfisica BuscarPorId(int id)
        {
            return ctx.Pfisicas.FirstOrDefault(u => u.IdPfisica == id);
        }

        public void Cadastrar(Pfisica novaPfisica)
        {
            // Adiciona este novoPfisica
            ctx.Pfisicas.Add(novaPfisica);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }


        public void Deletar(int id)
        {
            ctx.Pfisicas.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Pfisica> Listar()
        {
            return ctx.Pfisicas.ToList();
        }

        public List<Pfisica> MeusDados(int idUsuario)
        {
            return ctx.Pfisicas

           .Include(c => c.IdUsuarioNavigation)

           .Where(c => c.IdUsuarioNavigation.IdUsuario == idUsuario)

           .ToList();
        }

    }
}
