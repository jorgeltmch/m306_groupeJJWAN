using System;

namespace Rendev
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.AddMap = new GMap.NET.WindowsForms.GMapControl();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(602, 398);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(132, 31);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Ajout Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // AddMap
            // 
            this.AddMap.Bearing = 0F;
            this.AddMap.CanDragMap = true;
            this.AddMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.AddMap.GrayScaleMode = false;
            this.AddMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.AddMap.LevelsKeepInMemmory = 5;
            this.AddMap.Location = new System.Drawing.Point(12, 12);
            this.AddMap.MarkersEnabled = true;
            this.AddMap.MaxZoom = 18;
            this.AddMap.MinZoom = 2;
            this.AddMap.MouseWheelZoomEnabled = true;
            this.AddMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.AddMap.Name = "AddMap";
            this.AddMap.NegativeMode = false;
            this.AddMap.PolygonsEnabled = true;
            this.AddMap.RetryLoadTile = 0;
            this.AddMap.RoutesEnabled = true;
            this.AddMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.AddMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.AddMap.ShowTileGridLines = false;
            this.AddMap.Size = new System.Drawing.Size(722, 380);
            this.AddMap.TabIndex = 2;
            this.AddMap.Zoom = 0D;
            this.AddMap.Load += new System.EventHandler(this.AddMap_Load);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddMap);
            this.Controls.Add(this.btnAddEvent);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendev";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl AddMap;
    }
}

