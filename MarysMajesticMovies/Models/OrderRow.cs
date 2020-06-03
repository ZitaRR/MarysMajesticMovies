using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies
{
    public class OrderRow
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderLine { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public double PricePerQty { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
