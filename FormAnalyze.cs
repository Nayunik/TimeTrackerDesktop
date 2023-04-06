using System;
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
            dataGridView1.Refresh();
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

                    int indexX0 = 2;
                    sheet.Cells[1, 1] = "Пользователь";
                    sheet.Cells[1, 2] = "Дата";
                    sheet.Cells[1, 3] = "Приложение";
                    sheet.Cells[1, 4] = "Время работы";
                    for (int i = 0; i < cellUsers.Count; i++)
                    {
                        string userlogin = cellUsers[i].Value.ToString();
                        var resultFunc = database.SelectFunction($"select u.login, t.date, t.description, sum(t.duration) \r\nfrom main.timer t inner join auth.\"user\" u on t.user_id = u.user_id\r\nwhere u.login = '{userlogin}' \r\nand t.\"date\" >= to_date('{textBoxDateStart.Text}', 'yyyy-mm-dd')\r\nand t.\"date\" <= to_date('{textBoxDateEnd.Text}', 'yyyy-mm-dd')\r\n\r\ngroup by u.login, t.date, t.description;");
                        if (resultFunc != null)
                        {

                            while (resultFunc.Read())
                            {
                                sheet.Cells[indexX0, 1] = resultFunc.GetValue(0).ToString();
                                sheet.Cells[indexX0, 2] = resultFunc.GetValue(1).ToString().Split(' ')[0];
                                sheet.Cells[indexX0, 3] = resultFunc.GetValue(2).ToString();
                                sheet.Cells[indexX0, 4] = resultFunc.GetValue(3).ToString();
                                indexX0++;
                            }
                            resultFunc.Close();
                        }

                    }
                    sheet.Columns[1].ColumnWidth = 14;
                    sheet.Columns[2].ColumnWidth = 10;
                    sheet.Columns[3].ColumnWidth = 55;
                    sheet.Columns[4].ColumnWidth = 14;

                    sheet.Cells.Font.Name = "Times New Roman";
                    sheet.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    sheet.Cells.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    Excel.Chart excelchart0 = (Excel.Chart)app.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    excelchart0.Activate();

                    //Изменяем тип диаграммы
                    //app.ActiveChart.ChartType = Excel.XlChartType.xlLineMarkers;

                    //Перемещаем диаграмму на лист 1
                    app.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Пользователь - ПРиложение");
                    //Получаем ссылку на лист 1
                    var excelsheets0 = workBook.Worksheets;
                    sheet = (Excel.Worksheet)excelsheets0.get_Item(1);
                    //Перемещаем диаграмму в нужное место
                    sheet.Shapes.Item(1).IncrementTop(-300);
                    sheet.Shapes.Item(1).IncrementLeft(200);

                    //Задаем размеры диаграммы
                    sheet.Shapes.Item(1).Height = 500;
                    sheet.Shapes.Item(1).Width = 1000;

                    break;
                //Пользователь - День
                case 1:
                    sheet.Name = "Пользователь - Дата";
                    int indexX = 2;
                    sheet.Cells[1, 1] = "Пользователь";
                    sheet.Cells[1, 2] = "Дата";
                    sheet.Cells[1, 3] = "Время работы";
                    for (int i = 0; i < cellUsers.Count; i++)
                    {
                        string userlogin = cellUsers[i].Value.ToString();
                        var resultFunc = database.SelectFunction($"select u.login, t.date, sum(t.duration) \r\nfrom main.timer t inner join auth.\"user\" u on t.user_id = u.user_id\r\nwhere u.login = '{userlogin}' \r\nand t.\"date\" >= to_date('{textBoxDateStart.Text}', 'yyyy-mm-dd')\r\nand t.\"date\" <= to_date('{textBoxDateEnd.Text}', 'yyyy-mm-dd')\r\ngroup by u.login, t.date;");
                        if (resultFunc != null)
                        {
                            
                            while (resultFunc.Read())
                            {
                                sheet.Cells[indexX, 1] = resultFunc.GetValue(0).ToString();
                                sheet.Cells[indexX, 2] = resultFunc.GetValue(1).ToString().Split(' ')[0];
                                sheet.Cells[indexX, 3] = resultFunc.GetValue(2).ToString();
                                indexX++;
                            }
                            resultFunc.Close();
                        }
                        
                    }
                    sheet.Columns[1].ColumnWidth = 14;
                    sheet.Columns[2].ColumnWidth = 10;
                    sheet.Columns[3].ColumnWidth = 14;

                    sheet.Cells.Font.Name = "Times New Roman";
                    sheet.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    sheet.Cells.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    Excel.Chart excelchart = (Excel.Chart)app.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    excelchart.Activate();

                    //Изменяем тип диаграммы
                    //app.ActiveChart.ChartType = Excel.XlChartType.xlLineMarkers;

                    //Перемещаем диаграмму на лист 1
                    app.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Пользователь - Дата");
                    //Получаем ссылку на лист 1
                    var excelsheets = workBook.Worksheets;
                    sheet = (Excel.Worksheet)excelsheets.get_Item(1);
                    //Перемещаем диаграмму в нужное место
                    sheet.Shapes.Item(1).IncrementTop(-300);
                    sheet.Shapes.Item(1).IncrementLeft(-81);
                    
                    //Задаем размеры диаграммы
                    //sheet.Shapes.Item(1).Height = 500;
                    //sheet.Shapes.Item(1).Width = 500;

                    break;
                default:
                    MessageBox.Show("Неизвестный вариант графика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            
            string nameRep = $"Report_{DateTime.Now.ToShortDateString().ToString()}_{DateTime.Now.Hour.ToString()}_{DateTime.Now.Minute.ToString()}_{DateTime.Now.Second.ToString()}.xlsx";
            //Сохранение отчета
            app.Application.ActiveWorkbook.SaveAs(nameRep, Type.Missing,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Завершение работы с excel
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

            //Добавление инфы в БД по созданию отчета
            
            database.ExecuteScript($"\r\n--Добавление инфы об отчете\r\ninsert into main.report (create_user_id, date_formation, reportname)\r\nvalues ( {user.UserId}, to_timestamp('{DateTime.Now}', 'dd.mm.yyyy HH24:MI:SS'), '{nameRep}');");

            MessageBox.Show($"Отчет {nameRep} успешно сформирован!","Успех!", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
