using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWeb.Models
{
    public class Gizmo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime IntroducedDate { get; set; }
        public int Quantity { get; set; }
    }
}