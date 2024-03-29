﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TimeTrackerDesktop.AuthClasses;
using TimeTrackerDesktop.DataBase;

namespace TimeTrackerDesktop
{
    public partial class FormChangeUser : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;
        private FormAdmin adminForm;

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

        public void SetAdminForm (FormAdmin adminForm)
        {
            this.adminForm = adminForm;
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxEmail.Clear();
            textBoxLastname.Clear();
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
            string script = "";
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
            else if (checkedListBox1.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Выбертие хотя бы одну роль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        //Изменение пользователя и пароля!
                        database.ExecuteScript("select auth.change_user_info0(\'" + textBoxName.Text.Trim() + "\',\'" + textBoxLastname.Text.Trim() + "\', \'" + textBoxMiddlename.Text.Trim() + "\', \'" + textBoxPhone.Text.Trim() + "\', \'" + textBoxEmail.Text.Trim() + "\', \'" + textBoxPassword1.Text.Trim() + "\', " + user.UserId.ToString() + ");");
                    }
                    else
                    {
                        //Изменение только пользователя
                        database.ExecuteScript("select auth.change_user_info1(\'" + textBoxName.Text.Trim() + "\', \'" + textBoxLastname.Text.Trim() + "\', \'" + textBoxMiddlename.Text.Trim() + "\', \'" + textBoxPhone.Text.Trim() + "\', \'" + textBoxEmail.Text.Trim() + "\', " + user.UserId.ToString() + ");");

                    }
                    var o = checkedListBox1.GetItemChecked(0);
                    database.ExecuteScript("select auth.change_user_in_roles(" + checkedListBox1.GetItemChecked(0) + ", " + checkedListBox1.GetItemChecked(1) + ", " + checkedListBox1.GetItemChecked(2) + ", false, " + user.UserId.ToString() + ")");
                    database.ExecuteScript($"insert into main.change_log (event_time, user_id, change_user_id, event_type_id, event_object_id)\r\nvalues (to_timestamp('{DateTime.Now}', 'dd.mm.yyyy HH24:MI:SS'), {user.UserId}, {adminForm.user.UserId}, 2, 1);");
                }
                adminForm.UsersUpdateInfo();

            }


        }
    }
}
