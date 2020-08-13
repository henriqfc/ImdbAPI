using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Domain.Models
{
    [Table("Movie")]
    public class Movie : Base
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
