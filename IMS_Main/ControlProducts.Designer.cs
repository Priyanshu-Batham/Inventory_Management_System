namespace IMS_Main
{
    partial class ControlProducts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox8 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            richTextBox2 = new RichTextBox();
            richTextBox1 = new RichTextBox();
            label11 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(475, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 211);
            groupBox1.TabIndex = 45;
            groupBox1.TabStop = false;
            groupBox1.Text = "Operations";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(37, 46);
            button1.Name = "button1";
            button1.Size = new Size(148, 50);
            button1.TabIndex = 22;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(37, 102);
            button3.Name = "button3";
            button3.Size = new Size(302, 50);
            button3.TabIndex = 24;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(191, 46);
            button2.Name = "button2";
            button2.Size = new Size(148, 50);
            button2.TabIndex = 23;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(38, 83);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 37;
            label6.Text = "Created At";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(38, 127);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 35;
            label7.Text = "Description";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(73, 54);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 33;
            label8.Text = "Title";
            // 
            // textBox8
            // 
            textBox8.ForeColor = Color.Black;
            textBox8.Location = new Point(103, 51);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(84, 25);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 28;
            label1.Text = "Id";
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(103, 22);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 27;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(12, 0, 50);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(21, 0, 86);
            dataGridView1.Location = new Point(234, 294);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(510, 309);
            dataGridView1.TabIndex = 26;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(richTextBox2);
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox8);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(131, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(274, 211);
            groupBox2.TabIndex = 46;
            groupBox2.TabStop = false;
            groupBox2.Text = "Values";
            // 
            // richTextBox2
            // 
            richTextBox2.ForeColor = Color.Black;
            richTextBox2.Location = new Point(103, 80);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(100, 38);
            richTextBox2.TabIndex = 39;
            richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.Location = new Point(103, 124);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(100, 68);
            richTextBox1.TabIndex = 38;
            richTextBox1.Text = "";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(289, 261);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 47;
            // 
            // ControlProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 50);
            Controls.Add(label11);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "ControlProducts";
            Size = new Size(989, 606);
            Load += ControlProducts_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Button button3;
        private Button button2;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox8;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label label11;
    }
}
