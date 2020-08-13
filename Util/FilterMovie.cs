using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Util
{
    public class FilterMovie
    {
        //diretor, nome, gênero e/ou atores
        public string nome { get; set; }
        public string diretor { get; set; }
        public string genero { get; set; }
        public string ator { get; set; }
    }
}
