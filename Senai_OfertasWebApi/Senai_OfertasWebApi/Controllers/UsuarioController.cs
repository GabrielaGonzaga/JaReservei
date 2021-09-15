using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_OfertasWebApi.Domains;
using Senai_OfertasWebApi.Interfaces;
using Senai_OfertasWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Controllers
{
    public class UsuarioController : Controller
    {
        [ApiController]
        public class UsuariosController : ControllerBase
        {
            /// <summary>
            /// Objeto _perfilRepository que irá receber todos os métodos definidos na interface IPerfilRepository
            /// </summary>
            private IUsuarioRepository _usuarioRepository { get; set; }

            /// <summary>
            /// Instancia o objeto _perfilRepository para que haja a referência nos métodos implementadas no repositório PerfilRepository
            /// </summary>
            public UsuariosController()
            {
                _usuarioRepository = new UsuarioRepository();
            }

            /// <summary>
            /// Lista todos os perfis
            /// </summary>
            /// <returns>Uma lista de perfis e um status code 200 - Ok</returns>
            [HttpGet]
            public IActionResult Get()
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_usuarioRepository.Listar());
            }



            /// <summary>
            /// Atualiza um perfil existente
            /// </summary>
            /// <param name="id">ID do perfil que será atualizado</param>
            /// <param name="perfilAtualizado">Objeto perfilAtualizado com as novas informações</param>
            /// <returns>Um status code 204 - No Content</returns>
            [HttpPut("{id}")]
            public IActionResult Put(int id, Usuario perfilAtualizado)
            {
                // Faz a chamada para o método
                _usuarioRepository.Atualizar(id, perfilAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }

            /// <summary>
            /// Busca um perfil através do seu ID
            /// </summary>
            /// <param name="id">ID do perfil que será buscado</param>
            /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
            /// http://localhost:5000/api/estudios/1
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {

                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_usuarioRepository.BuscarPorId(id));
            }


            /// <summary>
            /// Cadastra um novo perfil
            /// </summary>
            /// <param name="novoPerfil">Objeto novoPerfil que será cadastrado</param>
            /// <returns>Um status code 201 - Created</returns>
            [Authorize]
            [HttpPost]
            public IActionResult Post(Usuario novoPerfil)
            {
                // Faz a chamada para o método
                _usuarioRepository.Cadastrar(novoPerfil);

                // Retorna um status code
                return StatusCode(201);
            }

            /// <summary>
            /// Deleta um perfil existente
            /// </summary>
            /// <param name="id">ID do perfil que será deletado</param>
            /// <returns>Um status code 204 - No Content</returns>
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                // Faz a chamada para o método
                _usuarioRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(200);
            }

        }
    }
}
