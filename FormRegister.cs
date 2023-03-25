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
    public partial class FormRegister : Form
    {

        private ClassDataBase database;

        private bool isClose = true; // Флаг для того, чтобы приложение не закрывалось при закрытии формы
        public FormRegister()
        {
            InitializeComponent();
        }

        private void labelGoToLogForm_Click(object sender, EventArgs e)
        {
            isClose = false;
            this.Close();
            this.Owner.Show();
        }


        private void FormRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose)
            {
                Application.Exit();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //Проверка, что поля не пустые
            if(string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Заполните обязательные поля!");
                return;
            }
            //Проверка, что пароли одинаковые
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Пароли отличаются!");
                return;
            }
            //Проверка, что почта верна
            if (!Regex.IsMatch(textBox6.Text, ".+@.+\\.[a-z]+"))
            {
                MessageBox.Show("Электронная почта не верна!");
                return;
            }
            //Првоерка, что пользователя с данным логином нет
            var res = database.SelectFunctionUsing("auth.\"user\" u where \'" + textBox1.Text.Trim() + "\' = u.login");
            res.Read();
            if (res.HasRows)
            {
                MessageBox.Show("Пользователь с данным логином существует!");
                res.Close();
                return;
            }
            res.Close();

            MessageBox.Show("GOOD");
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        public void SetDB(ClassDataBase _db)
        {
            this.database = _db;
        }

    }
}
