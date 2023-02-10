using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerDesktop.AuthClasses
{
    internal class ClassUserAuht
    {
        private string firstname;
        private string lastname;
        private string middlename;
        private string phone;
        private string email;
        private bool disabled;
        private List<int> roles;

        private string login;
        private string password;

        public ClassUserAuht() { }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public bool Disabled { get => disabled; set => disabled = value; }
        public List<int> Roles { get => roles; set => roles = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }


    }
}
