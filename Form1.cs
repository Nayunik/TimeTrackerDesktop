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
    public partial class FormAuth : Form
    {
        ClassDataBase dataBase = new ClassDataBase();
        private string configurationString = "Host = localhost; Port = 5432; Database = TimeTrackerDB; " +
            "Username = postgres; Password = 123456";

        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            ClassUserAuht user = new ClassUserAuht(login, password, dataBase);
            
            if (user.UserId != -1)
            {
                if(user.IsActive)
                {
                    if (user.Roles.Contains(2))
                    {
                        this.Hide();
                        FormTimeTracker formTime = new FormTimeTracker();
                        formTime.SetUser(user);
                        formTime.SetDB(dataBase);
                        formTime.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("У вас нет прав для работы с приложением, обратитесь к администратору приложения!");
                    }
                }
                else
                {
                    MessageBox.Show("Данный пользователь заблокирован, обратитесь к администратору системы!");
                }
            }
            else
            {
                MessageBox.Show("Данного пользователя нет в системе!");
            }
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            if (dataBase.ConnectToDB(configurationString) == null)
            {
                MessageBox.Show(dataBase.GetMsg + "\r\n Проверьте верность данных в строке для подключения к Базе данных!"); 
                Application.Exit(); //Если подключение не состоялось, то необходимо закрыть приложение.
            }
            else
            {
                this.dataBase.ConnectToDB(configurationString);
                MessageBox.Show("Connection is ready!");
            }
        }

        private void labelGoToRegForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister reg = new FormRegister();
            reg.Owner = this;
            reg.SetDB(dataBase);
            reg.ShowDialog();
            
        }
    }
}
