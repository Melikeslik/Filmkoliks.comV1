namespace Filmkoliks.comV1
{
    partial class OyuncuListesi
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnResimYukle = new System.Windows.Forms.Button();
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCinsiyet = new System.Windows.Forms.PictureBox();
            this.pBResimDetay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCinsiyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBResimDetay)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(797, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 39);
            this.button1.TabIndex = 18;
            this.button1.Text = "SİL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCinsiyet.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCinsiyet.Location = new System.Drawing.Point(410, 88);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(63, 28);
            this.lblCinsiyet.TabIndex = 16;
            this.lblCinsiyet.Text = "label1";
            this.lblCinsiyet.Visible = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblId.Location = new System.Drawing.Point(148, 92);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(73, 31);
            this.lblId.TabIndex = 15;
            this.lblId.Text = "label1";
            this.lblId.Visible = false;
            // 
            // btnResimYukle
            // 
            this.btnResimYukle.BackColor = System.Drawing.Color.RosyBrown;
            this.btnResimYukle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResimYukle.FlatAppearance.BorderSize = 0;
            this.btnResimYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResimYukle.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResimYukle.ForeColor = System.Drawing.Color.White;
            this.btnResimYukle.Location = new System.Drawing.Point(606, 92);
            this.btnResimYukle.Name = "btnResimYukle";
            this.btnResimYukle.Size = new System.Drawing.Size(185, 39);
            this.btnResimYukle.TabIndex = 14;
            this.btnResimYukle.Text = "DETAY";
            this.btnResimYukle.UseVisualStyleBackColor = false;
            this.btnResimYukle.Click += new System.EventHandler(this.btnResimYukle_Click);
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdSoyad.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAdSoyad.Location = new System.Drawing.Point(170, 6);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(73, 31);
            this.lblAdSoyad.TabIndex = 11;
            this.lblAdSoyad.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 136);
            this.panel1.TabIndex = 12;
            // 
            // pbCinsiyet
            // 
            this.pbCinsiyet.Image = global::Filmkoliks.comV1.Properties.Resources.erkek;
            this.pbCinsiyet.Location = new System.Drawing.Point(121, 6);
            this.pbCinsiyet.Name = "pbCinsiyet";
            this.pbCinsiyet.Size = new System.Drawing.Size(31, 41);
            this.pbCinsiyet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCinsiyet.TabIndex = 17;
            this.pbCinsiyet.TabStop = false;
            // 
            // pBResimDetay
            // 
            this.pBResimDetay.Location = new System.Drawing.Point(11, 6);
            this.pBResimDetay.Name = "pBResimDetay";
            this.pBResimDetay.Size = new System.Drawing.Size(104, 120);
            this.pBResimDetay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBResimDetay.TabIndex = 13;
            this.pBResimDetay.TabStop = false;
            // 
            // OyuncuListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbCinsiyet);
            this.Controls.Add(this.lblCinsiyet);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnResimYukle);
            this.Controls.Add(this.pBResimDetay);
            this.Controls.Add(this.lblAdSoyad);
            this.Controls.Add(this.panel1);
            this.Name = "OyuncuListesi";
            this.Size = new System.Drawing.Size(877, 136);
            this.Load += new System.EventHandler(this.OyuncuListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCinsiyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBResimDetay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbCinsiyet;
        private System.Windows.Forms.Label lblCinsiyet;
        public System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnResimYukle;
        public System.Windows.Forms.PictureBox pBResimDetay;
        public System.Windows.Forms.Label lblAdSoyad;
        private System.Windows.Forms.Panel panel1;
    }
}
