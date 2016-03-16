using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRAPIREST.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AlertType { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}