using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BertholdAPIRest.Models
{
    public class CAUser
    {
        public int Id { get; set; }
        public string FacebookID { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}