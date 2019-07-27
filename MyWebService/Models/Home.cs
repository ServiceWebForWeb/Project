using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebService.Models
{
    public class Home
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ZipCode { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
    }
}
