using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebService.Models
{
    public class SingUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string HomePhone { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
        public string Number { get; set; }

        public SingUp()
        {

        }

        public SingUp(int id, string name, string email, string cpf, string cnpj, string homePhone, string phone, string username, string password, string zipCode, string number)
        {
            Id = id;
            Name = name;
            Email = email;
            CPF = cpf;
            CNPJ = cnpj;
            HomePhone = homePhone;
            Phone = phone;
            Username = username;
            Password = password;
            ZipCode = zipCode;
            Number = number;
        }
    }
}
