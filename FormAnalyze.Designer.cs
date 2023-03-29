namespace TimeTrackerDesktop
{
    partial class FormAnalyze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMiddlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxDateEnd = new System.Windows.Forms.TextBox();
            this.textBoxDateStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateReport.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateReport.Location = new System.Drawing.Point(4, 478);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(195, 35);
            this.buttonCreateReport.TabIndex = 7;
            this.buttonCreateReport.Text = "Сформировать отчет";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLogin,
            this.ColumnLastname,
            this.ColumnFirstname,
            this.ColumnMiddlename,
            this.ColumnPhone,
            this.ColumnEmail});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(604, 468);
            this.dataGridView1.TabIndex = 26;
            // 
            // ColumnLogin
            // 
            this.ColumnLogin.HeaderText = "Login";
            this.ColumnLogin.Name = "ColumnLogin";
            this.ColumnLogin.ReadOnly = true;
            this.ColumnLogin.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnLastname
            // 
            this.ColumnLastname.HeaderText = "Фамилия";
            this.ColumnLastname.Name = "ColumnLastname";
            this.ColumnLastname.ReadOnly = true;
            this.ColumnLastname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnFirstname
            // 
            this.ColumnFirstname.HeaderText = "Имя";
            this.ColumnFirstname.Name = "ColumnFirstname";
            this.ColumnFirstname.ReadOnly = true;
            this.ColumnFirstname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnMiddlename
            // 
            this.ColumnMiddlename.HeaderText = "Отчество";
            this.ColumnMiddlename.Name = "ColumnMiddlename";
            this.ColumnMiddlename.ReadOnly = true;
            this.ColumnMiddlename.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnPhone
            // 
            this.ColumnPhone.HeaderText = "Телефон";
            this.ColumnPhone.Name = "ColumnPhone";
            this.ColumnPhone.ReadOnly = true;
            this.ColumnPhone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.HeaderText = "Эл. почта";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.ReadOnly = true;
            this.ColumnEmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.buttonCreateReport);
            this.panel1.Location = new System.Drawing.Point(9, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 519);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.textBoxDateEnd);
            this.panel2.Controls.Add(this.textBoxDateStart);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonClearFilter);
            this.panel2.Location = new System.Drawing.Point(9, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 127);
            this.panel2.TabIndex = 28;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(89, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "Вариант отчета:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(90, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "Дата:";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Пользователь - Приложение",
            "Пользователь - День"});
            this.comboBox1.Location = new System.Drawing.Point(222, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 23);
            this.comboBox1.TabIndex = 33;
            // 
            // textBoxDateEnd
            // 
            this.textBoxDateEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDateEnd.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDateEnd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDateEnd.Location = new System.Drawing.Point(293, 75);
            this.textBoxDateEnd.Multiline = true;
            this.textBoxDateEnd.Name = "textBoxDateEnd";
            this.textBoxDateEnd.Size = new System.Drawing.Size(98, 26);
            this.textBoxDateEnd.TabIndex = 32;
            // 
            // textBoxDateStart
            // 
            this.textBoxDateStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDateStart.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDateStart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDateStart.Location = new System.Drawing.Point(160, 75);
            this.textBoxDateStart.Multiline = true;
            this.textBoxDateStart.Name = "textBoxDateStart";
            this.textBoxDateStart.Size = new System.Drawing.Size(98, 26);
            this.textBoxDateStart.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(259, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "ПО:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(137, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "С:";
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClearFilter.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearFilter.Location = new System.Drawing.Point(406, 43);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(92, 39);
            this.buttonClearFilter.TabIndex = 27;
            this.buttonClearFilter.Text = "Сбросить фильтры";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // FormAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(626, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAnalyze";
            this.Text = "Аналитика";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAnalyze_FormClosed);
            this.Load += new System.EventHandler(this.FormAnalyze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMiddlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDateEnd;
        private System.Windows.Forms.TextBox textBoxDateStart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}