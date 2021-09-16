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
    public class PjuridicaRepository : IPjuridicaRepository
    {
        JaReserveiContext ctx = new JaReserveiContext();

        public void Atualizar(int id, Pjuridica PjuridicaAtualizada)
        {
            //Busca um Pjuridica através do id
            Pjuridica PjuridicaBuscada = ctx.Pjuridicas.Find(id);

            // Verifica as informações

            if (PjuridicaAtualizada.IdUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.IdUsuario = PjuridicaAtualizada.IdUsuario;
            }

            if (PjuridicaAtualizada.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.Nome = PjuridicaAtualizada.Nome;
            }

            if (PjuridicaAtualizada.EmailEmpresa != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.EmailEmpresa = PjuridicaAtualizada.EmailEmpresa;
            }

            if (PjuridicaAtualizada.NomeEmpresa != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.NomeEmpresa = PjuridicaAtualizada.NomeEmpresa;
            }

            if (PjuridicaAtualizada.Telefone != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.Telefone = PjuridicaAtualizada.Telefone;
            }

            if (PjuridicaAtualizada.Cnpj != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.Cnpj = PjuridicaAtualizada.Cnpj;
            }

            // Atualiza o Pjuridica que foi buscado
            ctx.Pjuridicas.Update(PjuridicaBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Pjuridica BuscarPorId(int id)
        {
            // Retorna o primeiro paciente encontrado para o ID informado
            return ctx.Pjuridicas.FirstOrDefault(u => u.IdPjuridica == id);
        }

        public void Cadastrar(Pjuridica novaPjuridica)
        {
            // Adiciona este novoUsuario
            ctx.Pjuridicas.Add(novaPjuridica);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Remove o tipo de usuário que foi buscado
            ctx.Pjuridicas.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Pjuridica> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários, exceto as senhas
            return ctx.Pjuridicas.ToList();
        }
        public List<Pjuridica> MeusDados(int idUsuario)
        {
            return ctx.Pjuridicas

           .Include(c => c.IdUsuarioNavigation)

           .Where(c => c.IdUsuarioNavigation.IdUsuario == idUsuario)

           .ToList();
        }

        public void AtualizarMeusDados(int idUsuario, Pjuridica PjuridicaAtualizada, Usuario UsuarioAtualizado)
        {
            //Busca um Pjuridica através do id
            Pjuridica PjuridicaBuscada = ctx.Pjuridicas.Find(idUsuario);
            Usuario UsuarioBuscado = ctx.Usuarios.Find(idUsuario);

            // Verifica as informações

            if (UsuarioAtualizado.Email != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
            }

            if (UsuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            if (PjuridicaAtualizada.EmailEmpresa != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.EmailEmpresa = PjuridicaAtualizada.EmailEmpresa;
            }

            if (PjuridicaAtualizada.NomeEmpresa != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.NomeEmpresa = PjuridicaAtualizada.NomeEmpresa;
            }

            if (PjuridicaAtualizada.Telefone != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.Telefone = PjuridicaAtualizada.Telefone;
            }

            if (PjuridicaAtualizada.Cnpj != null)
            {
                // Atribui os novos valores aos campos existentes
                PjuridicaBuscada.Cnpj = PjuridicaAtualizada.Cnpj;
            }

            // Atualiza o Pjuridica que foi buscado



            ctx.Pjuridicas.Update(PjuridicaBuscada);

            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }
    }
}
