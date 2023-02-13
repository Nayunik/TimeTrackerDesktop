﻿using System;
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
    public partial class FormTimeTracker : Form
    {
        private bool buttonIsStart = true;
        private Timer timer = new Timer();
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan time;

        public FormTimeTracker()
        {
            InitializeComponent();
        }

        private void FormTimeTracker_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStartStopTimer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (buttonIsStart)
            {
                buttonStartStopTimer.Text = "Стоп";
                buttonStartStopTimer.BackColor = Color.Tomato;  // Визуальное изменение кнопки
                buttonIsStart = false;

                timer1.Enabled = true;
                startTime= DateTime.Now;
                timer.Start();

            }
            else
            {
                buttonStartStopTimer.Text = "Старт";
                buttonStartStopTimer.BackColor = Color.White;  // Визуальное изменение кнопки
                buttonIsStart = true;
                
                endTime = DateTime.Now;
                timer.Stop();
                time = endTime - startTime;

                labelTime.Text = "00:00:00";
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now - startTime;
            if (time.Hours < 24) 
            {
                labelTime.Text = time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
            }
            else if (time.Hours == 24) // Ограничение в 24 часа, так как данный трекер предназначен для использования на предприятии, где рабочая смена не должна быть больше 24 часов
            {
                timer.Stop();
                time = endTime - startTime;
            }
        }
    }
}