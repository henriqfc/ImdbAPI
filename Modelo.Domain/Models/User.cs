using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Domain.Models
{
    [Table("User")]
    public class User : Base
    {
        public string Login { get; set; }
        
        [StringLength(100)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
    }
}
