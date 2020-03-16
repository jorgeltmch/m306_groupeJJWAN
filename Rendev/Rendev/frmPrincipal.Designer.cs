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
            this.AddMap = new GMap.NET.WindowsForms.GMapControl();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddMap
            // 
            this.AddMap.Bearing = 0F;
            this.AddMap.CanDragMap = true;
            this.AddMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.AddMap.GrayScaleMode = false;
            this.AddMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.AddMap.LevelsKeepInMemmory = 5;
            this.AddMap.Location = new System.Drawing.Point(-2, 2);
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
            this.AddMap.Size = new System.Drawing.Size(746, 403);
            this.AddMap.TabIndex = 2;
            this.AddMap.Zoom = 0D;
            this.AddMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AddMap_MouseDoubleClick);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(644, 369);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(100, 36);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Ajout Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 402);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.AddMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendev";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddEvent;
        private GMap.NET.WindowsForms.GMapControl AddMap;
    }
}

