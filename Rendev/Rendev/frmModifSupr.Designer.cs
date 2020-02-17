namespace Rendev
{
    partial class frmModifSupr
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.rdbModif = new System.Windows.Forms.RadioButton();
            this.rdbSuppr = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxLieu = new System.Windows.Forms.TextBox();
            this.tbxAdresse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(128, 195);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(12, 195);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(85, 30);
            this.btnAnnuler.TabIndex = 1;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // rdbModif
            // 
            this.rdbModif.AutoSize = true;
            this.rdbModif.Checked = true;
            this.rdbModif.Location = new System.Drawing.Point(24, 117);
            this.rdbModif.Name = "rdbModif";
            this.rdbModif.Size = new System.Drawing.Size(62, 17);
            this.rdbModif.TabIndex = 2;
            this.rdbModif.TabStop = true;
            this.rdbModif.Text = "Modifier";
            this.rdbModif.UseVisualStyleBackColor = true;
            // 
            // rdbSuppr
            // 
            this.rdbSuppr.AutoSize = true;
            this.rdbSuppr.Location = new System.Drawing.Point(24, 152);
            this.rdbSuppr.Name = "rdbSuppr";
            this.rdbSuppr.Size = new System.Drawing.Size(72, 17);
            this.rdbSuppr.TabIndex = 3;
            this.rdbSuppr.Text = "Supprimer";
            this.rdbSuppr.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lieu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Adresse :";
            // 
            // tbxLieu
            // 
            this.tbxLieu.Location = new System.Drawing.Point(24, 25);
            this.tbxLieu.Name = "tbxLieu";
            this.tbxLieu.ReadOnly = true;
            this.tbxLieu.Size = new System.Drawing.Size(180, 20);
            this.tbxLieu.TabIndex = 6;
            // 
            // tbxAdresse
            // 
            this.tbxAdresse.Location = new System.Drawing.Point(24, 75);
            this.tbxAdresse.Name = "tbxAdresse";
            this.tbxAdresse.ReadOnly = true;
            this.tbxAdresse.Size = new System.Drawing.Size(180, 20);
            this.tbxAdresse.TabIndex = 7;
            // 
            // frmModifSupr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 237);
            this.Controls.Add(this.tbxAdresse);
            this.Controls.Add(this.tbxLieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbSuppr);
            this.Controls.Add(this.rdbModif);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOk);
            this.Name = "frmModifSupr";
            this.Text = "frmModifSupr";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.RadioButton rdbModif;
        private System.Windows.Forms.RadioButton rdbSuppr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxLieu;
        private System.Windows.Forms.TextBox tbxAdresse;
    }
}