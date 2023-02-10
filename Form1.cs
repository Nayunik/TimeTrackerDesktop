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
                MessageBox.Show(dataBase.GetMsg);
            }
            else
            {
                MessageBox.Show(dataBase.GetMsg);
            }
        }
    }
}
