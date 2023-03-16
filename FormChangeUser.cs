using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            
        }
    }
}
