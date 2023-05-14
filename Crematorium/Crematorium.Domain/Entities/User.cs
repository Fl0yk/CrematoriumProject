using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Domain.Entities
{
    public class User : Entity
    {
        public string Surname { get; set; } = "";

        public string MailAdress { get; set; } = "";

        public string NumPassport { get; set; } = "";

        public List<Order> Orders { get; set; } = new();

        public Role UserRole { get; set; } = Role.NoName;
    }

    public enum Role
    {
        Admin,
        Employee,
        Customer,
        NoName
    }

}
