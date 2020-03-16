namespace Rendev
{
    partial class frmAddModif
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxNomEvent = new System.Windows.Forms.TextBox();
            this.tbxDescriptionEvent = new System.Windows.Forms.TextBox();
            this.dtpDateEvent = new System.Windows.Forms.DateTimePicker();
            this.cmbCategoriEvent = new System.Windows.Forms.ComboBox();
            this.tbx = new System.Windows.Forms.TextBox();
            this.btnConfirmEvent = new System.Windows.Forms.Button();
            this.ModifMap = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom Rue :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nom Event :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(602, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Categorie :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(602, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Date :";
            // 
            // tbxNomEvent
            // 
            this.tbxNomEvent.Location = new System.Drawing.Point(605, 28);
            this.tbxNomEvent.Name = "tbxNomEvent";
            this.tbxNomEvent.Size = new System.Drawing.Size(147, 20);
            this.tbxNomEvent.TabIndex = 6;
            // 
            // tbxDescriptionEvent
            // 
            this.tbxDescriptionEvent.Location = new System.Drawing.Point(605, 82);
            this.tbxDescriptionEvent.Multiline = true;
            this.tbxDescriptionEvent.Name = "tbxDescriptionEvent";
            this.tbxDescriptionEvent.Size = new System.Drawing.Size(147, 57);
            this.tbxDescriptionEvent.TabIndex = 7;
            // 
            // dtpDateEvent
            // 
            this.dtpDateEvent.Location = new System.Drawing.Point(605, 288);
            this.dtpDateEvent.Name = "dtpDateEvent";
            this.dtpDateEvent.Size = new System.Drawing.Size(150, 20);
            this.dtpDateEvent.TabIndex = 8;
            // 
            // cmbCategoriEvent
            // 
            this.cmbCategoriEvent.FormattingEnabled = true;
            this.cmbCategoriEvent.Items.AddRange(new object[] {
            "Other"});
            this.cmbCategoriEvent.Location = new System.Drawing.Point(605, 176);
            this.cmbCategoriEvent.Name = "cmbCategoriEvent";
            this.cmbCategoriEvent.Size = new System.Drawing.Size(147, 21);
            this.cmbCategoriEvent.TabIndex = 9;
            this.cmbCategoriEvent.Text = "Choisissez une categorie";
            this.cmbCategoriEvent.SelectedIndexChanged += new System.EventHandler(this.cmbCategoriEvent_SelectedIndexChanged);
            // 
            // tbx
            // 
            this.tbx.Location = new System.Drawing.Point(605, 230);
            this.tbx.Name = "tbx";
            this.tbx.Size = new System.Drawing.Size(147, 20);
            this.tbx.TabIndex = 10;
            // 
            // btnConfirmEvent
            // 
            this.btnConfirmEvent.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmEvent.Location = new System.Drawing.Point(605, 343);
            this.btnConfirmEvent.Name = "btnConfirmEvent";
            this.btnConfirmEvent.Size = new System.Drawing.Size(147, 37);
            this.btnConfirmEvent.TabIndex = 11;
            this.btnConfirmEvent.Text = "Confirm Event";
            this.btnConfirmEvent.UseVisualStyleBackColor = true;
            this.btnConfirmEvent.Click += new System.EventHandler(this.btnConfirmEvent_Click);
            // 
            // ModifMap
            // 
            this.ModifMap.Bearing = 0F;
            this.ModifMap.CanDragMap = true;
            this.ModifMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.ModifMap.GrayScaleMode = false;
            this.ModifMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.ModifMap.LevelsKeepInMemmory = 5;
            this.ModifMap.Location = new System.Drawing.Point(12, 12);
            this.ModifMap.MarkersEnabled = true;
            this.ModifMap.MaxZoom = 18;
            this.ModifMap.MinZoom = 2;
            this.ModifMap.MouseWheelZoomEnabled = true;
            this.ModifMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.ModifMap.Name = "ModifMap";
            this.ModifMap.NegativeMode = false;
            this.ModifMap.PolygonsEnabled = true;
            this.ModifMap.RetryLoadTile = 0;
            this.ModifMap.RoutesEnabled = true;
            this.ModifMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.ModifMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.ModifMap.ShowTileGridLines = false;
            this.ModifMap.Size = new System.Drawing.Size(584, 368);
            this.ModifMap.TabIndex = 12;
            this.ModifMap.Zoom = 0D;
            // 
            // frmAddModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 395);
            this.Controls.Add(this.ModifMap);
            this.Controls.Add(this.btnConfirmEvent);
            this.Controls.Add(this.tbx);
            this.Controls.Add(this.cmbCategoriEvent);
            this.Controls.Add(this.dtpDateEvent);
            this.Controls.Add(this.tbxDescriptionEvent);
            this.Controls.Add(this.tbxNomEvent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAddModif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddModif";
            this.Load += new System.EventHandler(this.frmAddModif_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxNomEvent;
        private System.Windows.Forms.TextBox tbxDescriptionEvent;
        private System.Windows.Forms.DateTimePicker dtpDateEvent;
        private System.Windows.Forms.ComboBox cmbCategoriEvent;
        private System.Windows.Forms.TextBox tbx;
        private System.Windows.Forms.Button btnConfirmEvent;
        private GMap.NET.WindowsForms.GMapControl ModifMap;
    }
}