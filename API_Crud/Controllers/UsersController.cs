using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CrudWindowsForms.Infra.Repositorio;
using CrudWindowsForms.Dominio.Modelo;
using System;

namespace API_Crud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static LinqToDBConexao conexao = new LinqToDBConexao();
        public UsuarioRepositorioLinqToDB bancodedados = new UsuarioRepositorioLinqToDB(conexao);

        [HttpGet]
        public IActionResult BuscarTodosUsuarios()
        {
            var todosOsUsuarios = bancodedados.ObterTodos();
            return Ok(todosOsUsuarios);
        }

        [HttpGet("{id}")]
        public Usuario ObterPorId(int id) => bancodedados.ObterPorId(id);

        [HttpPatch]
        public void AtualizarUsuario([FromBody] Usuario usuario) => bancodedados.Atualizar(usuario);

        [HttpPost]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            Console.WriteLine(usuario);
            bancodedados.Adicionar(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => bancodedados.Deletar(id);
    }
}
