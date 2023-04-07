using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
            string script = "";
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
            script += "\r\n\r\ndo $$\r\n declare\r\nv_iduser int8;\r\nbegin\r\n insert into auth.\"user\" (firstname, lastname, middlename, phone, email, login, password) values (\'" + textBox7.Text.Trim() + "\',\'" + textBox8.Text.Trim() + "\', \'" + textBox4.Text.Trim() + "\', \'" + textBox5.Text.Trim() + "\', \'" + textBox6.Text.Trim() + "\', \'" + textBox1.Text.Trim() + "\', \'" + textBox2.Text.Trim() + "\') returning user_id into v_iduser;\r\n";
            script += "\r\ninsert into main.\"user\" (firstname, lastname, middlename, phone, email) values(\'" + textBox7.Text.Trim() + "\',\'" + textBox8.Text.Trim() + "\', \'" + textBox4.Text.Trim() + "\', \'" + textBox5.Text.Trim() + "\', \'" + textBox6.Text.Trim() + "\');";
            script += "\r\ninsert into auth.user_in_role (user_id, role_id) values (v_iduser, 2);";
            script += "\r\ninsert into main.user_in_role (user_id, role_id) values (v_iduser, 2);";
            script += $"\r\ninsert into main.change_log (event_time, user_id, change_user_id, event_type_id, event_object_id)\r\nvalues (to_timestamp('{DateTime.Now}', 'dd.mm.yyyy HH24:MI:SS'), v_iduser, 0, 1, 1);";
            script += "\r\nend;\r\n$$\r\n";
            if (!string.IsNullOrEmpty(script))
            {
                database.ExecuteScript(script);
                MessageBox.Show("Пользователь создан!");
            }
            
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
