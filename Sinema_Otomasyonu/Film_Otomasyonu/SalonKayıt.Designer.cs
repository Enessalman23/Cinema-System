namespace Film_otomasyonu
{
    partial class SalonKayıt
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
            panel3 = new Panel();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            button4 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.DeepSkyBlue;
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 49);
            panel3.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(733, 0);
            button2.Name = "button2";
            button2.Size = new Size(67, 49);
            button2.TabIndex = 5;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(833, 0);
            button1.Name = "button1";
            button1.Size = new Size(67, 40);
            button1.TabIndex = 1;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DeepSkyBlue;
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 9);
            label2.Name = "label2";
            label2.Size = new Size(110, 28);
            label2.TabIndex = 0;
            label2.Text = "Salon Kayıt";
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.Location = new Point(40, 155);
            button4.Name = "button4";
            button4.Size = new Size(209, 60);
            button4.TabIndex = 17;
            button4.Text = "Kaydet";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(5, 98);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 20;
            label3.Text = "Koltuk Sayısı";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(128, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 23);
            textBox1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 18;
            label1.Text = "Salon Adı";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(28, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 235);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
            comboBox1.Location = new Point(128, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(164, 23);
            comboBox1.TabIndex = 23;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(421, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(379, 399);
            dataGridView1.TabIndex = 24;
            // 
            // SalonKayıt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(750, 350);
            Name = "SalonKayıt";
            StartPosition = FormStartPosition.Manual;
            Text = "SalonKayıt";
            Load += SalonKayıt_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Button button1;
        private Label label2;
        private Button button2;
        private Button button4;
        private Label label3;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
    }
}