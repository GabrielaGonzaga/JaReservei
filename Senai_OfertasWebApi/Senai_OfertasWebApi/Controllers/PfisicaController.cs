using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PfisicaController : ControllerBase
    {

        private IPfisicaRepository _pfisicaRepository { get; set; }

        public PfisicaController()
        {
            _pfisicaRepository = new PfisicaRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - ok </returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_pfisicaRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">objeto NovoUsuario que será cadastrado</param>
        /// <returns>um statud code 201- Created</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Pfisica NovoUsuario)

        {
            //faza a chamada para o método 
            _pfisicaRepository.Cadastrar(NovoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pfisica existente
        /// </summary>
        /// <param name="id">ID do pfisica que será atualizado</param>
        /// <param name="PfisicaAtualizada">Objeto pfisicaAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pfisica PfisicaAtualizada)
        {
            // Faz a chamada para o método
            _pfisicaRepository.Atualizar(id, PfisicaAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _pfisicaRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

    }
}
