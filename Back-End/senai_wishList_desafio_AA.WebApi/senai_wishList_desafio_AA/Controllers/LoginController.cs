using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.Interfaces;
using senai_wishList_desafio_AA.Repositories;
using senai_wishList_desafio_AA.ViewModels;

namespace senai_wishList_desafio_AA.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserRepository UserRepository { get; set; }

        public LoginController()
        {
            UserRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Users usuarioBuscado = UserRepository.BuscarPorEmailESenha(login);

                if (usuarioBuscado == null)
                {
                    return NotFound();
                }
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.UserEmail),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.UserId.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wishList_auth-key"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "wishlist.WebApi",
                    //SpMedGroup.WebApi
                    audience: "wishlist.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
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