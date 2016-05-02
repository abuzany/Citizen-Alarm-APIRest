using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRAPIREST.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string FacebookID { get; set; }

        public string Alias { get; set; }

        public string Email { get; set; }

        public DateTime CreationDate { get; set; }
    }
}