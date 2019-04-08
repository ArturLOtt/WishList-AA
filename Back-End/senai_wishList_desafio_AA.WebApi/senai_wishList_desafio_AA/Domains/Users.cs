using System;
using System.Collections.Generic;

namespace senai_wishList_desafio_AA.Domains
{
    public partial class Users
    {
        public Users()
        {
            Wish = new HashSet<Wish>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserSenha { get; set; }

        public ICollection<Wish> Wish { get; set; }
    }
}
