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
using Excel = Microsoft.Office.Interop.Excel;

namespace TimeTrackerDesktop
{
    public partial class FormAnalyze : Form
    {
        private ClassUserAuht user;
        private ClassDataBase database;

        public FormAnalyze()
        {
            InitializeComponent();
        }

        private void FormAnalyze_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var resultFunc = database.SelectFunctionUsing("auth.get_users()");

            while (resultFunc.Read())
            {
                dataGridView1.Rows.Add(resultFunc.GetValue(0).ToString().Split(' ')[0], resultFunc.GetValue(1), resultFunc.GetValue(2), resultFunc.GetValue(3), resultFunc.GetValue(4), resultFunc.GetValue(5));

                if (!resultFunc.IsDBNull(6) && resultFunc.GetBoolean(6))
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Red;

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

        private void FormAnalyze_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            textBoxDateEnd.Text = string.Empty;
            textBoxDateStart.Text = string.Empty;
        }

        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите вариант отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDateStart.Text) || string.IsNullOrEmpty(textBoxDateEnd.Text))
            {
                MessageBox.Show("Заполните фильтр даты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView1.CurrentCell.ColumnIndex != 0)
            {
                MessageBox.Show("Выберите логин(ы) интересующих пользователей в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Данных таймера
            var cellUsers = dataGridView1.SelectedCells;

            Excel.Application app = new Excel.Application
            {
                //Количество листов в рабочей книге
                SheetsInNewWorkbook = 1
            };
            //Добавить рабочую книгу
            Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
            //Отключить отображение окон с сообщениями
            app.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);

            switch (comboBox1.SelectedIndex)
            {
                //Пользователь - Приложение
                case 0:
                    sheet.Name = "Пользователь - Приложение";

                    /*for (int i = 0; i < users.Length; i++)
                    {
                        sheet.Cells[1, i] = users[i].ToString();
                    }*/
                    break;
                //Пользователь - День
                case 1:
                    sheet.Name = "Пользователь - Дата";
                    int indexX = 1;
                    for (int i = 0; i < cellUsers.Count; i++)
                    {
                        string userlogin = cellUsers[i].Value.ToString();
                        var resultFunc = database.SelectFunction($"select u.login, t.date, sum(t.duration) \r\nfrom main.timer t inner join auth.\"user\" u on t.user_id = u.user_id\r\nwhere u.login = '{userlogin}' \r\nand t.\"date\" >= to_date('{textBoxDateStart.Text}', 'yyyy-mm-dd')\r\nand t.\"date\" <= to_date('{textBoxDateEnd.Text}', 'yyyy-mm-dd')\r\ngroup by u.login, t.date;");
                        if (resultFunc != null)
                        {
                            
                            while (resultFunc.Read())
                            {
                                sheet.Cells[indexX, 1] = resultFunc.GetValue(0).ToString();
                                sheet.Cells[indexX, 2] = resultFunc.GetValue(1).ToString();
                                sheet.Cells[indexX, 3] = resultFunc.GetValue(2).ToString();
                                indexX++;
                            }
                            resultFunc.Close();
                        }
                        
                    }
                    break;
            }
            
            string nameRep = $"Report_{DateTime.Now.ToShortDateString().ToString()}_{DateTime.Now.Hour.ToString()}_{DateTime.Now.Minute.ToString()}_{DateTime.Now.Second.ToString()}.xlsx";
            //Сохранение отчета
            app.Application.ActiveWorkbook.SaveAs(nameRep, Type.Missing,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Завершение работы с excel
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

            MessageBox.Show($"Отчет {nameRep} успешно сформирован!","Успех!", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
