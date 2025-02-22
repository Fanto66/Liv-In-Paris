using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace LivinParis
{
    partial class Form1
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.BoutonCheminDFS = new System.Windows.Forms.Button();
            this.TexteCheminDFS = new System.Windows.Forms.Label();
            this.BoutonAfficherGraphe = new System.Windows.Forms.Button();
            this.PanelGraphe = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BoutonCheminDFS
            // 
            this.BoutonCheminDFS.AutoSize = true;
            this.BoutonCheminDFS.Location = new System.Drawing.Point(12, 12);
            this.BoutonCheminDFS.Name = "BoutonCheminDFS";
            this.BoutonCheminDFS.Size = new System.Drawing.Size(147, 26);
            this.BoutonCheminDFS.TabIndex = 0;
            this.BoutonCheminDFS.Text = "Afficher Chemin DFS";
            this.BoutonCheminDFS.UseVisualStyleBackColor = true;
            this.BoutonCheminDFS.Click += new System.EventHandler(this.button1_Click);
            // 
            // TexteCheminDFS
            // 
            this.TexteCheminDFS.AutoSize = true;
            this.TexteCheminDFS.Location = new System.Drawing.Point(12, 41);
            this.TexteCheminDFS.Name = "TexteCheminDFS";
            this.TexteCheminDFS.Size = new System.Drawing.Size(0, 16);
            this.TexteCheminDFS.TabIndex = 1;
            this.TexteCheminDFS.Visible = false;
            // 
            // BoutonAfficherGraphe
            // 
            this.BoutonAfficherGraphe.AutoSize = true;
            this.BoutonAfficherGraphe.Location = new System.Drawing.Point(165, 12);
            this.BoutonAfficherGraphe.Name = "BoutonAfficherGraphe";
            this.BoutonAfficherGraphe.Size = new System.Drawing.Size(147, 26);
            this.BoutonAfficherGraphe.TabIndex = 2;
            this.BoutonAfficherGraphe.Text = "Afficher Graphe";
            this.BoutonAfficherGraphe.UseVisualStyleBackColor = true;
            this.BoutonAfficherGraphe.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PanelGraphe
            // 
            this.PanelGraphe.Location = new System.Drawing.Point(18, 44);
            this.PanelGraphe.Name = "PanelGraphe";
            this.PanelGraphe.Size = new System.Drawing.Size(760, 400);
            this.PanelGraphe.TabIndex = 3;
            this.PanelGraphe.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.PanelGraphe.Visible = false;
            this.PanelGraphe.AutoSize = true;
            this.PanelGraphe.Padding = new Padding(40);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelGraphe);
            this.Controls.Add(this.BoutonAfficherGraphe);
            this.Controls.Add(this.TexteCheminDFS);
            this.Controls.Add(this.BoutonCheminDFS);
            this.Name = "Form1";
            this.Text = "ProjetPSI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new System.Drawing.Size(400, 300); // Set the minimum size here
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button BoutonCheminDFS;
        private System.Windows.Forms.Label TexteCheminDFS;
        private Button BoutonAfficherGraphe;
        private Panel PanelGraphe;
    }
}

