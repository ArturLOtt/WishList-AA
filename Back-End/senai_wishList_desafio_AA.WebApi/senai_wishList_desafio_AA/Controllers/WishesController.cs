using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.Interfaces;
using senai_wishList_desafio_AA.Repositories;

namespace senai_wishList_desafio_AA.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class WishesController : Controller
    {
        private IWishRepository WishRepository { get; set; }
        private IUserRepository UserRepository { get; set; }
        public WishesController()
        {
            WishRepository = new WishRepository();
            UserRepository = new UserRepository();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Cadastrar(Wish Wish)
        {
            try
            {
                int userId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Users usuarioProcurado = UserRepository.BuscarPorId(userId);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }

                WishRepository.CadastrarWish(Wish, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Wish newWish)
        {
            Wish oldWish = WishRepository.BuscarWishPorId(newWish.WishId);

            if (oldWish == null)
            {
                return NotFound();
            }

            WishRepository.Atualizar(newWish, oldWish);

            return Ok();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                return Ok(WishRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
        [HttpGet("SeusDesejos")]
        [Authorize]
        public IActionResult ListarPorLogado()
        {
            try
            {
                int userId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Users usuarioProcurado = UserRepository.BuscarPorId(userId);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }
                return Ok(WishRepository.ListarPorUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}