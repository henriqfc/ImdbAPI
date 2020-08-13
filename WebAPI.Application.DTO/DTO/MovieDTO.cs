using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPI.Application.DTO.DTO
{
    public class MovieDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public ICollection<VoteDTO> Votes { get; set; }

        public double? Media { get {
                if (Votes == null || Votes.Count == 0)
                {
                    return null;
                } else
                {
                    return Votes.Sum(v => (int)v.Rating) / Votes.Count;
                }
            }
        }
        public bool Active { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
