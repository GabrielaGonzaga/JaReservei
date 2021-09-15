using Senai_OfertasWebApi.Contexts;
using Senai_OfertasWebApi.Domains;
using Senai_OfertasWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        JaReserveiContext ctx = new JaReserveiContext();

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            //Busca um Usuariol através do id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica as informações

            if (UsuarioAtualizado.IdTipoUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
            }

            if (UsuarioAtualizado.NomeUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            }

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
            // Atualiza o Usuariol que foi buscado
            ctx.Usuarios.Update(UsuarioBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            // Retorna o primeiro Usuariol encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoUsuariol
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Usuarios.Remove(UsuarioBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            // Retorna o Usuariol encontrado através do e-mail e da senha
            return ctx.Usuarios.FirstOrDefault(l => l.Email == email && l.Senha == senha);
        }
    }
}

