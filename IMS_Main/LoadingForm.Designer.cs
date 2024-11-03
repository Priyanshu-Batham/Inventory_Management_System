namespace IMS_Main
{
    partial class LoadingForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 48F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(268, 119);
            label1.Name = "label1";
            label1.Size = new Size(750, 77);
            label1.TabIndex = 0;
            label1.Text = "Inventory Management";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 48F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(501, 210);
            label2.Name = "label2";
            label2.Size = new Size(257, 77);
            label2.TabIndex = 1;
            label2.Text = "System";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(2, 511);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1252, 23);
            progressBar1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(48, 470);
            label3.Name = "label3";
            label3.Size = new Size(174, 38);
            label3.TabIndex = 3;
            label3.Text = "Loading...";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(778, 291);
            label4.Name = "label4";
            label4.Size = new Size(208, 33);
            label4.TabIndex = 4;
            label4.Text = "-by Priyanshu";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1254, 638);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}