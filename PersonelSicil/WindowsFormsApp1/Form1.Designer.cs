
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblSifreTekrar = new System.Windows.Forms.Label();
            this.txtbAd = new System.Windows.Forms.TextBox();
            this.txtbSifre = new System.Windows.Forms.TextBox();
            this.txtbSifreTekrar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAdHata = new System.Windows.Forms.Label();
            this.lblSifreHata = new System.Windows.Forms.Label();
            this.lblSifreTekrarHata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Bodoni MT Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblBaslik.Location = new System.Drawing.Point(134, 26);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(115, 40);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Login";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAd.Location = new System.Drawing.Point(60, 106);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(101, 20);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "Kullanıcı Adı";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifre.Location = new System.Drawing.Point(60, 194);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(44, 20);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre";
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifreTekrar.Location = new System.Drawing.Point(60, 289);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new System.Drawing.Size(101, 20);
            this.lblSifreTekrar.TabIndex = 1;
            this.lblSifreTekrar.Text = "Şifre Tekrarı";
            // 
            // txtbAd
            // 
            this.txtbAd.Location = new System.Drawing.Point(208, 88);
            this.txtbAd.Multiline = true;
            this.txtbAd.Name = "txtbAd";
            this.txtbAd.Size = new System.Drawing.Size(229, 37);
            this.txtbAd.TabIndex = 1;
            // 
            // txtbSifre
            // 
            this.txtbSifre.Location = new System.Drawing.Point(208, 177);
            this.txtbSifre.Multiline = true;
            this.txtbSifre.Name = "txtbSifre";
            this.txtbSifre.Size = new System.Drawing.Size(229, 37);
            this.txtbSifre.TabIndex = 2;
            // 
            // txtbSifreTekrar
            // 
            this.txtbSifreTekrar.Location = new System.Drawing.Point(208, 272);
            this.txtbSifreTekrar.Multiline = true;
            this.txtbSifreTekrar.Name = "txtbSifreTekrar";
            this.txtbSifreTekrar.Size = new System.Drawing.Size(229, 37);
            this.txtbSifreTekrar.TabIndex = 3;
            this.txtbSifreTekrar.TextChanged += new System.EventHandler(this.txtbSifreTekrar_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(208, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Giriş";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAdHata
            // 
            this.lblAdHata.AutoSize = true;
            this.lblAdHata.BackColor = System.Drawing.SystemColors.Control;
            this.lblAdHata.ForeColor = System.Drawing.Color.Red;
            this.lblAdHata.Location = new System.Drawing.Point(64, 141);
            this.lblAdHata.Name = "lblAdHata";
            this.lblAdHata.Size = new System.Drawing.Size(46, 17);
            this.lblAdHata.TabIndex = 4;
            this.lblAdHata.Text = "label1";
            this.lblAdHata.Visible = false;
            // 
            // lblSifreHata
            // 
            this.lblSifreHata.AutoSize = true;
            this.lblSifreHata.BackColor = System.Drawing.SystemColors.Control;
            this.lblSifreHata.ForeColor = System.Drawing.Color.Red;
            this.lblSifreHata.Location = new System.Drawing.Point(64, 230);
            this.lblSifreHata.Name = "lblSifreHata";
            this.lblSifreHata.Size = new System.Drawing.Size(46, 17);
            this.lblSifreHata.TabIndex = 4;
            this.lblSifreHata.Text = "label1";
            this.lblSifreHata.Visible = false;
            // 
            // lblSifreTekrarHata
            // 
            this.lblSifreTekrarHata.AutoSize = true;
            this.lblSifreTekrarHata.BackColor = System.Drawing.SystemColors.Control;
            this.lblSifreTekrarHata.ForeColor = System.Drawing.Color.Red;
            this.lblSifreTekrarHata.Location = new System.Drawing.Point(64, 324);
            this.lblSifreTekrarHata.Name = "lblSifreTekrarHata";
            this.lblSifreTekrarHata.Size = new System.Drawing.Size(46, 17);
            this.lblSifreTekrarHata.TabIndex = 4;
            this.lblSifreTekrarHata.Text = "label1";
            this.lblSifreTekrarHata.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.lblSifreTekrarHata);
            this.Controls.Add(this.lblSifreHata);
            this.Controls.Add(this.lblAdHata);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbSifreTekrar);
            this.Controls.Add(this.txtbSifre);
            this.Controls.Add(this.txtbAd);
            this.Controls.Add(this.lblSifreTekrar);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblBaslik);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblSifreTekrar;
        private System.Windows.Forms.TextBox txtbAd;
        private System.Windows.Forms.TextBox txtbSifre;
        private System.Windows.Forms.TextBox txtbSifreTekrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAdHata;
        private System.Windows.Forms.Label lblSifreHata;
        private System.Windows.Forms.Label lblSifreTekrarHata;
    }
}

