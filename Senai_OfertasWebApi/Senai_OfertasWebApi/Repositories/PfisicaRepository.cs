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

        SenaiOfertasContext ctx = new SenaiOfertasContext();

        public Pfisica BuscarPorId(int id)
        {
            // Retorna o primeiro usuário encontrado para o ID informado, sem exibir sua senha
            return ctx.Pfisicas
                .Select(u => new Pfisica()
                {
                    IdPfisica = u.IdPfisica,
                    Email = u.Email
                })
                .FirstOrDefault(u => u.IdPfisica == id);
        }

        public void Cadastrar(Pfisica novoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Pfisicas.Add(novoUsuario);

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

        public Pfisica Login(string email, string senha)
        {
            return ctx.Pfisicas.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
