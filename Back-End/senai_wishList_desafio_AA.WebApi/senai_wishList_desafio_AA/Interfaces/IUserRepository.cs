using senai_wishList_desafio_AA.Domains;
using senai_wishList_desafio_AA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishList_desafio_AA.Interfaces
{
    public interface IUserRepository
    {
        void CadastrarUser(Users usuario);

        Users BuscarPorEmailESenha(LoginViewModel login);

        Users BuscarPorId(int userId);
    }
}
