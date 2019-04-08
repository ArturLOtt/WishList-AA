using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishList_desafio_AA.Repositories
{
    public class WishRepository : IWishRepository
    {
        public void Atualizar(Wish newWish, Wish oldWish)
        {
            using (WishListContext ctx = new WishListContext())
            {
                ctx.Wish.Update(oldWish);
                ctx.SaveChanges();
            }
        }

        public Wish BuscarWishPorId(int WishId)
        {
            using (WishListContext ctx = new WishListContext())
            {
                return ctx.Wish.Find(WishId);
            }
        }

        public void CadastrarWish(Wish wish, int userId)
        {
            using (WishListContext ctx = new WishListContext())
            {
                wish.WishOwnerId = userId;
                wish.WishCreation = DateTime.Now;
                ctx.Wish.Add(wish);
                ctx.SaveChanges();
            }
        }

        public List<Wish> ListarTodos()
        {
            using (WishListContext ctx = new WishListContext())
            {
                return ctx.Wish.ToList();
            }
        }

        public List<Wish> ListarPorUser(int userId)
        {
            using (WishListContext ctx = new WishListContext())
            {
                return ctx.Wish.Where(x => x.WishOwnerId == userId).ToList();
            }
        }
    }
}
