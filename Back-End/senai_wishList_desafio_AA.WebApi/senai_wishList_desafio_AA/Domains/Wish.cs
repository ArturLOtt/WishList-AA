using System;
using System.Collections.Generic;

namespace senai_wishList_desafio_AA.Domains
{
    public partial class Wish
    {
        public int WishId { get; set; }
        public string WishDescription { get; set; }
        public DateTime WishCreation { get; set; }
        public int? WishOwnerId { get; set; }

        public Users WishOwner { get; set; }
    }
}
