namespace IMS_Main
{
    partial class LoginForm
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
            groupBox1 = new GroupBox();
            label8 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            button2 = new Button();
            label6 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1230, 648);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(504, 417);
            label8.Name = "label8";
            label8.Size = new Size(195, 23);
            label8.TabIndex = 5;
            label8.Text = "Wrong Credentials";
            label8.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(530, 346);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 4;
            label3.Text = "Fill Text Shown in Image";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(545, 311);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(466, 182);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(744, 43);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(432, 541);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Navy;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(136, 322);
            button2.Name = "button2";
            button2.Size = new Size(160, 43);
            button2.TabIndex = 13;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(184, 237);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 12;
            label6.Text = "Password";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(153, 260);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(132, 23);
            textBox4.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(177, 176);
            label7.Name = "label7";
            label7.Size = new Size(85, 20);
            label7.TabIndex = 10;
            label7.Text = "Username";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(150, 199);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(132, 23);
            textBox5.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(66, 39);
            label2.Name = "label2";
            label2.Size = new Size(312, 44);
            label2.TabIndex = 1;
            label2.Text = "Employee Login";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(34, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(404, 541);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(119, 330);
            button1.Name = "button1";
            button1.Size = new Size(160, 43);
            button1.TabIndex = 8;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(167, 245);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 7;
            label5.Text = "Password";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(136, 268);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(132, 23);
            textBox3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(160, 184);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 5;
            label4.Text = "Username";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(133, 207);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(132, 23);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 39);
            label1.Name = "label1";
            label1.Size = new Size(255, 44);
            label1.TabIndex = 0;
            label1.Text = "Admin Login";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1254, 684);
            Controls.Add(groupBox1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label2;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label label3;
        private Button button2;
        private Label label6;
        private TextBox textBox4;
        private Label label7;
        private TextBox textBox5;
        private Button button1;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label8;
    }
}