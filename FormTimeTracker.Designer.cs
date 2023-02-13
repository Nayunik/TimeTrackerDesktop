namespace TimeTrackerDesktop
{
    partial class FormTimeTracker
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAutoHideMod = new System.Windows.Forms.Button();
            this.buttonAutoMod = new System.Windows.Forms.Button();
            this.buttonGoToAdminForm = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(201, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 548);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonGoToAdminForm);
            this.panel2.Controls.Add(this.buttonAutoHideMod);
            this.panel2.Controls.Add(this.buttonAutoMod);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 545);
            this.panel2.TabIndex = 9;
            // 
            // buttonAutoHideMod
            // 
            this.buttonAutoHideMod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAutoHideMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAutoHideMod.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAutoHideMod.Location = new System.Drawing.Point(6, 62);
            this.buttonAutoHideMod.Name = "buttonAutoHideMod";
            this.buttonAutoHideMod.Size = new System.Drawing.Size(171, 54);
            this.buttonAutoHideMod.TabIndex = 8;
            this.buttonAutoHideMod.Text = "Автоматический режим (скрытный)";
            this.buttonAutoHideMod.UseVisualStyleBackColor = true;
            // 
            // buttonAutoMod
            // 
            this.buttonAutoMod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAutoMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAutoMod.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAutoMod.Location = new System.Drawing.Point(6, 3);
            this.buttonAutoMod.Name = "buttonAutoMod";
            this.buttonAutoMod.Size = new System.Drawing.Size(171, 53);
            this.buttonAutoMod.TabIndex = 7;
            this.buttonAutoMod.Text = "Автоматический режим";
            this.buttonAutoMod.UseVisualStyleBackColor = true;
            // 
            // buttonGoToAdminForm
            // 
            this.buttonGoToAdminForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoToAdminForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGoToAdminForm.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGoToAdminForm.Location = new System.Drawing.Point(6, 488);
            this.buttonGoToAdminForm.Name = "buttonGoToAdminForm";
            this.buttonGoToAdminForm.Size = new System.Drawing.Size(171, 54);
            this.buttonGoToAdminForm.TabIndex = 9;
            this.buttonGoToAdminForm.Text = "Открыть окно администратора";
            this.buttonGoToAdminForm.UseVisualStyleBackColor = true;
            // 
            // FormTimeTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormTimeTracker";
            this.Text = "Учет времени";
            this.Load += new System.EventHandler(this.FormTimeTracker_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAutoHideMod;
        private System.Windows.Forms.Button buttonAutoMod;
        private System.Windows.Forms.Button buttonGoToAdminForm;
    }
}