﻿using System;
using System.Windows.Forms;
using TimeTrackerDesktop.AuthClasses;
using TimeTrackerDesktop.DataBase;

namespace TimeTrackerDesktop
{
    public partial class FormAdmin : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            UsersUpdateInfo();
        }

        public void UsersUpdateInfo ()
        {
            dataGridView1.Rows.Clear();
            var resultFunc = database.SelectFunctionUsing("auth.get_users()");
            
            while (resultFunc.Read())
            {
                dataGridView1.Rows.Add(resultFunc.GetValue(0).ToString().Split(' ')[0], resultFunc.GetValue(1), resultFunc.GetValue(2), resultFunc.GetValue(3), resultFunc.GetValue(4), resultFunc.GetValue(5));
                 
                if (!resultFunc.IsDBNull(6) && resultFunc.GetBoolean(6))
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count-1].DefaultCellStyle.BackColor = System.Drawing.Color.Red;

                }
            }
            resultFunc.Close();
        }
        public void SetUser(ClassUserAuht _user)
        {
            this.user = _user;
        }
        public void SetDB(ClassDataBase _db)
        {
            this.database = _db;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string selectedLogin = dataGridView1.SelectedCells[0].Value.ToString();
            ClassUserAuht selectedUser = new ClassUserAuht(selectedLogin, database);
            FormChangeUser formChangeUser = new FormChangeUser();
            formChangeUser.SetUser(selectedUser);
            formChangeUser.SetDB(database);
            formChangeUser.SetAdminForm(this);
            formChangeUser.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                buttonChange.Enabled = true;
                buttonBlockUser.Enabled = true;

                string selectedLogin = dataGridView1.SelectedCells[0].Value.ToString();
                ClassUserAuht selectedUser = new ClassUserAuht(selectedLogin, database);
                if (!selectedUser.IsActive)
                {
                    buttonBlockUser.Text = "Разблокировать";
                }
                else
                {
                    buttonBlockUser.Text = "Блокировать";
                }
            }
            else
            {
                buttonChange.Enabled = false;
                buttonBlockUser.Enabled = false;
            }
        }

        private void buttonBlockUser_Click(object sender, EventArgs e)
        {
            string selectedLogin = dataGridView1.SelectedCells[0].Value.ToString();
            ClassUserAuht selectedUser = new ClassUserAuht(selectedLogin, database);

            if (!selectedUser.IsActive)
            {
                database.ExecuteScript("select auth.block_user(" + selectedUser.UserId + ",false);");
                buttonBlockUser.Text = "Блокировать";
            }
            else
            {
                database.ExecuteScript("select auth.block_user(" + selectedUser.UserId + ",true);");
                buttonBlockUser.Text = "Разблокировать";
                
            }

            UsersUpdateInfo();
        }

        
    }
}
