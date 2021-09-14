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
        SenaiOfertasContext ctx = new SenaiOfertasContext();
        public Pjuridica BuscarPorId(int id)
        {
            // Retorna o primeiro usuário encontrado para o ID informado, sem exibir sua senha
            return ctx.Pjuridicas
                .Select(u => new Pjuridica()
                {
                    IdPjuridica = u.IdPjuridica,
                    Email = u.Email
                })
                .FirstOrDefault(u => u.IdPjuridica == id);
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

        public Pjuridica Login(string email, string senha)
        {
            return ctx.Pjuridicas.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
