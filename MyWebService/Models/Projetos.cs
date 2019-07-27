using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebService.Models
{
    public class Projetos
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Projetos()
        {

        }

        public Projetos(string description)
        {
            Description = description;
        }
    }
}
