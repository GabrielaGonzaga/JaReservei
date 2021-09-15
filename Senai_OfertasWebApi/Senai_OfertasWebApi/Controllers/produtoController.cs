using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_OfertasWebApi.Domains;
using Senai_OfertasWebApi.Interfaces;
using Senai_OfertasWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_OfertasWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class produtoController : ControllerBase
    {

        private IProdutoRepository _produtoRepository { get; set; }

        public produtoController()
        {
            _produtoRepository = new produtoRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Produto novoProduto)
        {
            try
            {
                _produtoRepository.Cadastrar(novoProduto);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Produto produtoAtualizado)
        {
            try
            {
                _produtoRepository.Atualizar(id, produtoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("meusprodutosfisicos")]
        public IActionResult ListarConsultasP()
        {
            try
            {

                int idPfisica = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);
                int idPjuridica = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_produtoRepository.ListarMeusProdutos(idPfisica, idPjuridica));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }
    }
}
