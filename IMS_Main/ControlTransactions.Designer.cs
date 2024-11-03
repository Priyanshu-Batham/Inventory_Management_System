namespace IMS_Main
{
    partial class ControlTransactions
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
            label11 = new Label();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            button1 = new Button();
            groupBox3 = new GroupBox();
            maskedTextBox1 = new MaskedTextBox();
            listBox1 = new ListBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            label7 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            groupBox1 = new GroupBox();
            comboBox5 = new ComboBox();
            label9 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            comboBox2 = new ComboBox();
            comboBox4 = new ComboBox();
            label8 = new Label();
            dataGridView1 = new DataGridView();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(13, 0);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 36;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(16, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(959, 253);
            groupBox2.TabIndex = 35;
            groupBox2.TabStop = false;
            groupBox2.Text = "Values";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button1);
            groupBox4.Location = new Point(762, 55);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(118, 162);
            groupBox4.TabIndex = 52;
            groupBox4.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(17, 62);
            button1.Name = "button1";
            button1.Size = new Size(88, 50);
            button1.TabIndex = 49;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(maskedTextBox1);
            groupBox3.Controls.Add(listBox1);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Location = new Point(331, 18);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(338, 223);
            groupBox3.TabIndex = 51;
            groupBox3.TabStop = false;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(125, 38);
            maskedTextBox1.Mask = "00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(59, 23);
            maskedTextBox1.TabIndex = 49;
            maskedTextBox1.ValidatingType = typeof(int);
            maskedTextBox1.TextChanged += maskedTextBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(15, 86);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(309, 79);
            listBox1.TabIndex = 40;
            // 
            // comboBox1
            // 
            comboBox1.ForeColor = Color.Black;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(15, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 32;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(179, 177);
            button2.Name = "button2";
            button2.Size = new Size(88, 32);
            button2.TabIndex = 48;
            button2.Text = "Remove Item";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(44, 18);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 33;
            label1.Text = "Items";
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(55, 177);
            button3.Name = "button3";
            button3.Size = new Size(88, 32);
            button3.TabIndex = 47;
            button3.Text = "Add Item";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(16, 68);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 41;
            label7.Text = "Order List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(126, 18);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 35;
            label2.Text = "Quantity";
            // 
            // textBox2
            // 
            textBox2.ForeColor = Color.Black;
            textBox2.Location = new Point(190, 36);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(64, 23);
            textBox2.TabIndex = 36;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(263, 18);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 39;
            label6.Text = "Total Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(206, 18);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 37;
            label3.Text = "Price";
            // 
            // textBox3
            // 
            textBox3.ForeColor = Color.Black;
            textBox3.Location = new Point(260, 36);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(64, 23);
            textBox3.TabIndex = 38;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox5);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox4);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(112, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(128, 231);
            groupBox1.TabIndex = 50;
            groupBox1.TabStop = false;
            // 
            // comboBox5
            // 
            comboBox5.ForeColor = Color.Black;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(13, 190);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(100, 23);
            comboBox5.TabIndex = 47;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(13, 172);
            label9.Name = "label9";
            label9.Size = new Size(97, 15);
            label9.TabIndex = 46;
            label9.Text = "Assign Employee";
            // 
            // comboBox3
            // 
            comboBox3.ForeColor = Color.Black;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(15, 36);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(100, 23);
            comboBox3.TabIndex = 21;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 16);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 8;
            label4.Text = "type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(14, 66);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 42;
            label5.Text = "Customer";
            // 
            // comboBox2
            // 
            comboBox2.ForeColor = Color.Black;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(14, 84);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(100, 23);
            comboBox2.TabIndex = 43;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox4
            // 
            comboBox4.ForeColor = Color.Black;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(14, 140);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(100, 23);
            comboBox4.TabIndex = 45;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(14, 122);
            label8.Name = "label8";
            label8.Size = new Size(99, 15);
            label8.TabIndex = 44;
            label8.Text = "Shipping Address";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(0, 0, 64);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(128, 290);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(725, 309);
            dataGridView1.TabIndex = 33;
            // 
            // ControlTransactions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            Controls.Add(label11);
            Controls.Add(groupBox2);
            Controls.Add(dataGridView1);
            Name = "ControlTransactions";
            Size = new Size(989, 606);
            Load += ControlTransactions_Load;
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label11;
        private GroupBox groupBox2;
        private ComboBox comboBox3;
        private Label label4;
        private DataGridView dataGridView1;
        private Label label7;
        private ListBox listBox1;
        private Label label6;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox4;
        private Label label8;
        private ComboBox comboBox2;
        private Label label5;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private MaskedTextBox maskedTextBox1;
        private ComboBox comboBox5;
        private Label label9;
    }
}
