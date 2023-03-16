using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTrackerDesktop.AuthClasses;
using TimeTrackerDesktop.DataBase;

namespace TimeTrackerDesktop
{
    public partial class FormChangeUser : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;

        public FormChangeUser()
        {
            InitializeComponent();
        }

        private void FormChangeUser_Load(object sender, EventArgs e)
        {
            textBoxEmail.Text = user.Email;
            textBoxLastname.Text = user.Lastname;
            textBoxLogin.Text = user.Login;
            textBoxMiddlename.Text = user.Middlename;
            textBoxName.Text = user.Firstname;
            textBoxPhone.Text = user.Phone;

            foreach (var role in user.Roles)
            {
                switch (role) 
                {
                    case 1:
                        checkedListBox1.SetItemChecked(0, true);
                        break;
                    case 2:
                        checkedListBox1.SetItemChecked(1, true);
                        break;
                    case 3:
                        checkedListBox1.SetItemChecked(2, true);
                        break;
                    case 4:
                        checkedListBox1.SetItemChecked(3, true);
                        break;
                }
            }
            
        }
        public void SetUser(ClassUserAuht _user)
        {
            this.user = _user;
        }
        public void SetDB(ClassDataBase _db)
        {
            this.database = _db;
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxEmail.Clear();
            textBoxLastname.Clear();
            textBoxLogin.Clear();
            textBoxMiddlename.Clear();
            textBoxName.Clear();
            textBoxPhone.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++) 
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните адрес почты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxLastname.Text))
            {
                MessageBox.Show("Заполните фамилию!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxMiddlename.Text))
            {
                MessageBox.Show("Заполните отчество!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните имя!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                MessageBox.Show("Заполните телефон!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, ".+@.+\\.[a-z]+"))
            {
                MessageBox.Show("Неверная информация о почте!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                if (textBoxPassword1.Text != textBoxPassword2.Text)
                {
                    MessageBox.Show("Пароли отличаются!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBoxPassword1.Text) && !string.IsNullOrEmpty(textBoxPassword2.Text))
                    {
                        //Необходимо изменение пользователя и пароля!
                    }
                    else
                    {
                        //Необходимо изменение только пользователя
                    }
                    
                }
                
            }


        }
    }
}
