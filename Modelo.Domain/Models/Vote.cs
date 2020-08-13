using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebAPI.Util;

namespace Modelo.Domain.Models
{
    [Table("Vote")]
    public class Vote : Base
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public Rating Rating { get; set; }

        //[ForeignKey("MovieId")]
        //public virtual Movie Movie { get; set; }

        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }
    }
}
