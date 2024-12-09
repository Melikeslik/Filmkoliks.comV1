namespace Filmkoliks.comV1
{
    partial class FrmFilmDetay
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pBResim = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFilmAdi = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTur = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblOzellikler = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblOyuncular = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblYonetmen = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblDurum = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblVizyonTarihi = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblPuan = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblDetay = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBResim)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 40);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(994, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "[FİLM DETAY EKRANI]";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.pBResim);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox9.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox9.Location = new System.Drawing.Point(9, 46);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox9.Size = new System.Drawing.Size(262, 335);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "FİLM AFİŞİ";
            // 
            // pBResim
            // 
            this.pBResim.Image = global::Filmkoliks.comV1.Properties.Resources.noGorsel;
            this.pBResim.Location = new System.Drawing.Point(7, 36);
            this.pBResim.Name = "pBResim";
            this.pBResim.Size = new System.Drawing.Size(248, 289);
            this.pBResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBResim.TabIndex = 8;
            this.pBResim.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFilmAdi);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(277, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(240, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FİLM ADI";
            // 
            // lblFilmAdi
            // 
            this.lblFilmAdi.ForeColor = System.Drawing.Color.Black;
            this.lblFilmAdi.Location = new System.Drawing.Point(14, 35);
            this.lblFilmAdi.Name = "lblFilmAdi";
            this.lblFilmAdi.Size = new System.Drawing.Size(219, 62);
            this.lblFilmAdi.TabIndex = 0;
            this.lblFilmAdi.Text = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTur);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(531, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(240, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FİLM TÜRÜ";
            // 
            // lblTur
            // 
            this.lblTur.ForeColor = System.Drawing.Color.Black;
            this.lblTur.Location = new System.Drawing.Point(14, 40);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(214, 57);
            this.lblTur.TabIndex = 0;
            this.lblTur.Text = "label3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblOzellikler);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox4.Location = new System.Drawing.Point(277, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox4.Size = new System.Drawing.Size(750, 112);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FİLM ÖZELLİKLERİ";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // lblOzellikler
            // 
            this.lblOzellikler.ForeColor = System.Drawing.Color.Black;
            this.lblOzellikler.Location = new System.Drawing.Point(14, 40);
            this.lblOzellikler.Name = "lblOzellikler";
            this.lblOzellikler.Size = new System.Drawing.Size(726, 69);
            this.lblOzellikler.TabIndex = 0;
            this.lblOzellikler.Text = "label5";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblOyuncular);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox5.Location = new System.Drawing.Point(531, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox5.Size = new System.Drawing.Size(240, 100);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "FİLM OYUNCULARI";
            // 
            // lblOyuncular
            // 
            this.lblOyuncular.ForeColor = System.Drawing.Color.Black;
            this.lblOyuncular.Location = new System.Drawing.Point(14, 40);
            this.lblOyuncular.Name = "lblOyuncular";
            this.lblOyuncular.Size = new System.Drawing.Size(214, 57);
            this.lblOyuncular.TabIndex = 0;
            this.lblOyuncular.Text = "label6";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblYonetmen);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox6.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox6.Location = new System.Drawing.Point(277, 163);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox6.Size = new System.Drawing.Size(240, 100);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "FİLM YÖNETMENİ";
            // 
            // lblYonetmen
            // 
            this.lblYonetmen.ForeColor = System.Drawing.Color.Black;
            this.lblYonetmen.Location = new System.Drawing.Point(13, 40);
            this.lblYonetmen.Name = "lblYonetmen";
            this.lblYonetmen.Size = new System.Drawing.Size(214, 57);
            this.lblYonetmen.TabIndex = 0;
            this.lblYonetmen.Text = "label7";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblDurum);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox7.Location = new System.Drawing.Point(9, 516);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox7.Size = new System.Drawing.Size(1018, 71);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "FİLM DURUM";
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.ForeColor = System.Drawing.Color.Black;
            this.lblDurum.Location = new System.Drawing.Point(14, 23);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(994, 43);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "label8";
            this.lblDurum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblVizyonTarihi);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox8.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox8.Location = new System.Drawing.Point(787, 163);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox8.Size = new System.Drawing.Size(240, 100);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "FİLM VİZYON TARİHİ";
            // 
            // lblVizyonTarihi
            // 
            this.lblVizyonTarihi.ForeColor = System.Drawing.Color.Black;
            this.lblVizyonTarihi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVizyonTarihi.Location = new System.Drawing.Point(14, 40);
            this.lblVizyonTarihi.Name = "lblVizyonTarihi";
            this.lblVizyonTarihi.Size = new System.Drawing.Size(214, 57);
            this.lblVizyonTarihi.TabIndex = 0;
            this.lblVizyonTarihi.Text = "label9";
            this.lblVizyonTarihi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblPuan);
            this.groupBox10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox10.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox10.Location = new System.Drawing.Point(787, 46);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox10.Size = new System.Drawing.Size(240, 100);
            this.groupBox10.TabIndex = 20;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "FİLM PUANI";
            // 
            // lblPuan
            // 
            this.lblPuan.ForeColor = System.Drawing.Color.Black;
            this.lblPuan.Location = new System.Drawing.Point(14, 36);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(214, 61);
            this.lblPuan.TabIndex = 0;
            this.lblPuan.Text = "label10";
            this.lblPuan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lblDetay);
            this.groupBox11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox11.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox11.Location = new System.Drawing.Point(12, 390);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox11.Size = new System.Drawing.Size(1015, 120);
            this.groupBox11.TabIndex = 23;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "FİLM DETAYI";
            // 
            // lblDetay
            // 
            this.lblDetay.ForeColor = System.Drawing.Color.Black;
            this.lblDetay.Location = new System.Drawing.Point(10, 40);
            this.lblDetay.Name = "lblDetay";
            this.lblDetay.Size = new System.Drawing.Size(995, 70);
            this.lblDetay.TabIndex = 0;
            this.lblDetay.Text = "label11";
            // 
            // FrmFilmDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1035, 774);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(400, 80);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmFilmDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmFilmDetay";
            this.Load += new System.EventHandler(this.FrmFilmDetay_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBResim)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.PictureBox pBResim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFilmAdi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTur;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblOzellikler;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblOyuncular;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblYonetmen;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblVizyonTarihi;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lblDetay;
    }
}