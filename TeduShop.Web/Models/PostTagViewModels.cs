using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostTagViewModels
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        public virtual PostViewModels Post { set; get; }

        public virtual TagViewModels Tag { set; get; }
    }
}