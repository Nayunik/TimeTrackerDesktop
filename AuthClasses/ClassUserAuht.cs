using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerDesktop.DataBase;

namespace TimeTrackerDesktop.AuthClasses
{
    internal class ClassUserAuht
    {
        private int userId;
        private string firstname;
        private string lastname;
        private string middlename;
        private string phone;
        private string email;
        private bool disabled;
        private List<int> roles;

        private string login;
        private string password;

        private ClassDataBase dataBase;

        public ClassUserAuht(string login, string password, ClassDataBase dataBase)
        {
            this.dataBase = dataBase;
            this.userId = GetUserId(login, password);
            if (userId != -1)
            {
                this.login = login;
                this.password = password;

                //Необходимо доделать извлечение данных о пользователе при помощи его id, для этого нужно реализовать скрипт по извлечению данных.
            }
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public bool Disabled { get => disabled; set => disabled = value; }
        public List<int> Roles { get => roles; set => roles = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public int UserId { get => userId; set => userId = value; }

        public int GetUserId(string login, string password)
        {
            int result = -1;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) 
            {
                return result;
            }
            else
            {
                var resultFunction = dataBase.FunctionUsing("auth.user_login(\'" + login + "\', \'" + password + "\')");
                resultFunction.Read();
                if (resultFunction != null)
                {
                    result = resultFunction.GetInt32(0);
                    resultFunction.Close();
                    return result;

                }
                else
                {
                    resultFunction.Close();
                    return result;
                }
            }
        }

        public bool UserIsActive(string login, string password)
        {
            bool result = false;

            if (string.IsNullOrEmpty(login))
            {
                return result;
            }
            else
            {
                var resultFunction = dataBase.FunctionUsing("auth.user_is_active(\'" + login + "\', \'" + password + "\')");
                resultFunction.Read();
                if (resultFunction != null)
                {
                    result = resultFunction.GetBoolean(0);
                    resultFunction.Close();
                    return result;

                }
                else
                {
                    resultFunction.Close();
                    return result;
                }
            }
            
        }


    }
}
