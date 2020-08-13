using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Domain.Models
{
    public class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
