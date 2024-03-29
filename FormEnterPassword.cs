﻿using System;
using System.Windows.Forms;

namespace TimeTrackerDesktop
{
    public partial class FormEnterPassword : Form
    {

        FormTimeTracker _formTimeTracker;
        string _password;
        public bool pasIsCorrect;

        public FormEnterPassword()
        {
            InitializeComponent();
        }

        private void FormEnterPassword_Load(object sender, EventArgs e)
        {
            
        }

        public void SetFormTimeTracker(FormTimeTracker formTimeTracker)
        {
            _formTimeTracker = formTimeTracker;
        }

        public void SetUserPassword(string password)
        {
            _password = password;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == _password)
            {
                _formTimeTracker._tokenSource.Cancel();

                pasIsCorrect = true;
                _formTimeTracker.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введенный пароль неверный, попробуйте снова!");
            }

        }
    }
}
