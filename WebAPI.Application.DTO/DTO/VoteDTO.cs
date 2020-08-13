using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Util;

namespace WebAPI.Application.DTO.DTO
{
    public class VoteDTO
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public Rating Rating { get; set; }
        //public MovieDTO Movie { get; set; }
        //public UserDTO User { get; set; }
        public bool Active { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
