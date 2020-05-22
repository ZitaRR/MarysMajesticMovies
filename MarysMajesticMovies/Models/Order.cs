using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        [Required]
        public double Weight { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}
