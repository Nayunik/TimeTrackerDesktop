using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrackerDesktop
{
    public partial class FormRegister : Form
    {
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

        }
    }
}
