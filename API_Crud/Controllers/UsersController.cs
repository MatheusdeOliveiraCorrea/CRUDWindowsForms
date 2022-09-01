using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Infra.Repositorio;
using Microsoft.AspNetCore.Mvc;
using CrudWindowsForms.Dominio.Validadores;
using System;
using FluentValidation;
using CrudWindowsForms.Dominio.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace API_Crud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IValidator<Usuario> _usuarioValidador;

        public UsersController(IUsuarioRepositorio usuarioRepositorio, IValidator<Usuario> usuarioValidador)
        {

            _usuarioRepositorio = usuarioRepositorio;
            _usuarioValidador = usuarioValidador;
        }

        [HttpGet]
        public IActionResult BuscarTodosUsuarios()
        {
            try
            {
                var todosOsUsuarios = _usuarioRepositorio.ObterTodos();
                return Ok(todosOsUsuarios);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            try
            {
                var usuario = _usuarioRepositorio.ObterPorId(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPatch]
        public IActionResult AtualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var result = _usuarioValidador.Validate(usuario);
                if (result.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    return NoContent();
                }
                return BadRequest(new JsonResult(result.Errors));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var result = _usuarioValidador.Validate(usuario);
                if (result.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    return NoContent();
                }
                return BadRequest(new JsonResult(result.Errors));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _usuarioRepositorio.Deletar(id);
                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("pesquisa/{q}")]
        public List<Usuario> PesquisarNome(string q)
        {
           var query = from pesquisa in _usuarioRepositorio.ObterTodos().ToList()
                       where pesquisa.Nome.Contains(q) || pesquisa.Email.Contains(q)
                       select pesquisa;

           return query.ToList();
        }

    }
}
