using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.Interfaces;
using senai_wishList_desafio_AA.Repositories;

namespace senai_wishList_desafio_AA.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository UserRepository { get; set; }
        public UsersController()
        {
            UserRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult CadastrarUser(Users usuario)
        {
            try
            {
                UserRepository.CadastrarUser(usuario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}