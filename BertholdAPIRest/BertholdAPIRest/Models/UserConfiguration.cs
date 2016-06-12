using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BertholdAPIRest.Models
{
    public class UserConfiguration
    {
        public int Id { get; set; }
        public string FacebookID { get; set; }
        public double Range { get; set; }
        public bool EnabledNotifications { get; set; }
    }
}