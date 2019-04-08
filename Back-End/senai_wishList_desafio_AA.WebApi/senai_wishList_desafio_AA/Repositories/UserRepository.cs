using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.Interfaces;
using senai_wishList_desafio_AA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishList_desafio_AA.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Users BuscarPorEmailESenha(LoginViewModel login)
        {
            using (WishListContext ctx = new WishListContext())
            {
                return ctx.Users.FirstOrDefault(x => x.UserEmail == login.Email && x.UserSenha == login.Senha);
            }
        }

        public void CadastrarUser(Users usuario)
        {
            using (WishListContext ctx = new WishListContext())
            {
                ctx.Users.Add(usuario);
                ctx.SaveChanges();
            }
        }
        public Users BuscarPorId(int userId)
        {
            using (WishListContext ctx = new WishListContext())
            {
                return ctx.Users.FirstOrDefault(x => x.UserId == userId);
            }
        }
    }
}
