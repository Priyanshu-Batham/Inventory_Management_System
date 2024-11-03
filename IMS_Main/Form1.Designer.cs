namespace IMS_Main
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            controlinventory1 = new Controlinventory();
            controlDashboard1 = new ControlDashboard();
            controlProducts1 = new ControlProducts();
            controlUsers1 = new ControlUsers();
            controlTransactions1 = new ControlTransactions();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 0, 86);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 684);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(9, 255);
            button5.Name = "button5";
            button5.Size = new Size(242, 56);
            button5.TabIndex = 9;
            button5.Text = "Dashboard";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(9, 503);
            button4.Name = "button4";
            button4.Size = new Size(242, 56);
            button4.TabIndex = 8;
            button4.Text = "Transactions";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(9, 441);
            button3.Name = "button3";
            button3.Size = new Size(242, 56);
            button3.TabIndex = 7;
            button3.Text = "Users";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(9, 379);
            button2.Name = "button2";
            button2.Size = new Size(242, 56);
            button2.TabIndex = 6;
            button2.Text = "Products";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(73, 122);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 5;
            label4.Text = "Welcome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(68, 142);
            label3.Name = "label3";
            label3.Size = new Size(127, 33);
            label3.TabIndex = 4;
            label3.Text = "HellGod";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(9, 317);
            button1.Name = "button1";
            button1.Size = new Size(242, 56);
            button1.TabIndex = 0;
            button1.Text = "Inventory";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(259, 78);
            panel3.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(44, 30);
            label2.Name = "label2";
            label2.Size = new Size(162, 33);
            label2.TabIndex = 3;
            label2.Text = "Dashboard";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(453, 22);
            label1.Name = "label1";
            label1.Size = new Size(558, 41);
            label1.TabIndex = 2;
            label1.Text = "Inventory Management System";
            // 
            // controlinventory1
            // 
            controlinventory1.BackColor = Color.FromArgb(255, 192, 192);
            controlinventory1.Location = new Point(265, 78);
            controlinventory1.Name = "controlinventory1";
            controlinventory1.Size = new Size(989, 606);
            controlinventory1.TabIndex = 3;
            // 
            // controlDashboard1
            // 
            controlDashboard1.Location = new Point(265, 78);
            controlDashboard1.Name = "controlDashboard1";
            controlDashboard1.Size = new Size(989, 606);
            controlDashboard1.TabIndex = 4;
            // 
            // controlProducts1
            // 
            controlProducts1.Location = new Point(265, 78);
            controlProducts1.Name = "controlProducts1";
            controlProducts1.Size = new Size(989, 606);
            controlProducts1.TabIndex = 5;
            // 
            // controlUsers1
            // 
            controlUsers1.Location = new Point(265, 78);
            controlUsers1.Name = "controlUsers1";
            controlUsers1.Size = new Size(989, 606);
            controlUsers1.TabIndex = 6;
            // 
            // controlTransactions1
            // 
            controlTransactions1.Location = new Point(265, 66);
            controlTransactions1.Name = "controlTransactions1";
            controlTransactions1.Size = new Size(989, 606);
            controlTransactions1.TabIndex = 7;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 50);
            ClientSize = new Size(1254, 684);
            Controls.Add(controlTransactions1);
            Controls.Add(controlUsers1);
            Controls.Add(controlProducts1);
            Controls.Add(controlDashboard1);
            Controls.Add(controlinventory1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Button button1;
        private Label label2;
        private Button button3;
        private Button button2;
        private Label label4;
        private Label label3;
        private Button button5;
        private Button button4;
        private Controlinventory controlinventory1;
        private ControlDashboard controlDashboard1;
        private ControlProducts controlProducts1;
        private ControlUsers controlUsers1;
        private ControlTransactions controlTransactions1;
    }
}
