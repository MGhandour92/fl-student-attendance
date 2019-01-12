namespace Project_8_Attendance
{
    partial class Home
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passTB = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.empRB = new System.Windows.Forms.RadioButton();
            this.stdRB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Heading", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(399, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Attendo";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(508, 222);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(154, 20);
            this.nameTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(406, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(406, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // passTB
            // 
            this.passTB.Location = new System.Drawing.Point(508, 270);
            this.passTB.Name = "passTB";
            this.passTB.Size = new System.Drawing.Size(154, 20);
            this.passTB.TabIndex = 4;
            this.passTB.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.loginBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.loginBtn.ForeColor = System.Drawing.Color.Lavender;
            this.loginBtn.Location = new System.Drawing.Point(699, 330);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 36);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label4.Location = new System.Drawing.Point(440, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Student Attendance management system";
            // 
            // empRB
            // 
            this.empRB.AutoSize = true;
            this.empRB.Checked = true;
            this.empRB.Location = new System.Drawing.Point(410, 330);
            this.empRB.Name = "empRB";
            this.empRB.Size = new System.Drawing.Size(71, 17);
            this.empRB.TabIndex = 7;
            this.empRB.TabStop = true;
            this.empRB.Text = "Employee";
            this.empRB.UseVisualStyleBackColor = true;
            // 
            // stdRB
            // 
            this.stdRB.AutoSize = true;
            this.stdRB.Location = new System.Drawing.Point(410, 354);
            this.stdRB.Name = "stdRB";
            this.stdRB.Size = new System.Drawing.Size(63, 17);
            this.stdRB.TabIndex = 8;
            this.stdRB.Text = "Student";
            this.stdRB.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackgroundImage = global::Project_8_Attendance.Properties.Resources.timeofficeslider;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(850, 456);
            this.Controls.Add(this.stdRB);
            this.Controls.Add(this.empRB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Home";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passTB;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton empRB;
        private System.Windows.Forms.RadioButton stdRB;
    }
}