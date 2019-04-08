using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishList_desafio_AA.Interfaces
{
    public interface IWishRepository
    {
        void CadastrarWish(Wish wish, int userId);
        void Atualizar(Wish newWish, Wish oldWish);
        Wish BuscarWishPorId(int WishId);
        List<Wish> ListarTodos();
        List<Wish> ListarPorUser(int userId);
    }
}
