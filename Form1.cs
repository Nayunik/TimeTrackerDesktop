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
            /*ClassUserAuht user = new ClassUserAuht();
            if ()
            {

            }*/
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            if (!dataBase.isConnectToDB(configurationString))
            {
                MessageBox.Show(dataBase.GetMsg + "\r\n Проверьте верность данных в строке для подключения к Базе данных!"); 
                Application.Exit(); //Если подключение не состоялось, то необходимо закрыть приложение. Тестим, делаю изменение))
            }
            else
            {
                MessageBox.Show(dataBase.GetMsg);
            }
        }

        private void labelGoToRegForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister reg = new FormRegister();
            reg.Owner = this;
            reg.ShowDialog();
        }
    }
}
