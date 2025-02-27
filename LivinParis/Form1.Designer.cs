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

        private void InitializeComponent()
        {
            this.BoutonCheminDFS = new System.Windows.Forms.Button();
            this.TexteCheminDFS = new System.Windows.Forms.Label();
            this.BoutonAfficherGraphe = new System.Windows.Forms.Button();
            this.PanelGraphe = new System.Windows.Forms.Panel();
            this.TableauListeAdj = new System.Windows.Forms.DataGridView();
            this.BoutonListeAdj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableauListeAdj)).BeginInit();
            this.SuspendLayout();
            // 
            // BoutonCheminDFS
            // 
            this.BoutonCheminDFS.AutoSize = true;
            this.BoutonCheminDFS.Location = new System.Drawing.Point(15, 15);
            this.BoutonCheminDFS.Name = "BoutonCheminDFS";
            this.BoutonCheminDFS.Size = new System.Drawing.Size(184, 33);
            this.BoutonCheminDFS.TabIndex = 0;
            this.BoutonCheminDFS.Text = "Afficher Chemin DFS";
            this.BoutonCheminDFS.UseVisualStyleBackColor = true;
            this.BoutonCheminDFS.Click += new System.EventHandler(this.BoutonDFSClick);
            // 
            // TexteCheminDFS
            // 
            this.TexteCheminDFS.AutoSize = true;
            this.TexteCheminDFS.Location = new System.Drawing.Point(15, 63);
            this.TexteCheminDFS.Name = "TexteCheminDFS";
            this.TexteCheminDFS.Size = new System.Drawing.Size(0, 20);
            this.TexteCheminDFS.TabIndex = 1;
            this.TexteCheminDFS.Visible = false;
            // 
            // BoutonAfficherGraphe
            // 
            this.BoutonAfficherGraphe.AutoSize = true;
            this.BoutonAfficherGraphe.Location = new System.Drawing.Point(206, 15);
            this.BoutonAfficherGraphe.Name = "BoutonAfficherGraphe";
            this.BoutonAfficherGraphe.Size = new System.Drawing.Size(184, 33);
            this.BoutonAfficherGraphe.TabIndex = 2;
            this.BoutonAfficherGraphe.Text = "Afficher Graphe";
            this.BoutonAfficherGraphe.UseVisualStyleBackColor = true;
            this.BoutonAfficherGraphe.Click += new System.EventHandler(this.BoutonGrapheClick);
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
            // TableauListeAdj
            // 
            this.TableauListeAdj.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TableauListeAdj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableauListeAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableauListeAdj.Location = new System.Drawing.Point(15, 125);
            this.TableauListeAdj.Name = "TableauListeAdj";
            this.TableauListeAdj.ReadOnly = true;
            this.TableauListeAdj.RowHeadersWidth = 51;
            this.TableauListeAdj.Size = new System.Drawing.Size(300, 188);
            this.TableauListeAdj.TabIndex = 0;
            this.TableauListeAdj.Visible = false;
            this.TableauListeAdj.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.TableauListeAdj.MaximumSize = new System.Drawing.Size(800, 800);
            this.TableauListeAdj.AutoSize = true;

            // 
            // BoutonListeAdj
            // 
            this.BoutonListeAdj.AutoSize = true;
            this.BoutonListeAdj.Location = new System.Drawing.Point(398, 15);
            this.BoutonListeAdj.Name = "BoutonListeAdj";
            this.BoutonListeAdj.Size = new System.Drawing.Size(213, 33);
            this.BoutonListeAdj.TabIndex = 4;
            this.BoutonListeAdj.Text = "Afficher Liste d\'adjacence";
            this.BoutonListeAdj.UseVisualStyleBackColor = true;
            this.BoutonListeAdj.Click += new System.EventHandler(this.BoutonListeAdjClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BoutonListeAdj);
            this.Controls.Add(this.TableauListeAdj);
            this.Controls.Add(this.PanelGraphe);
            this.Controls.Add(this.BoutonAfficherGraphe);
            this.Controls.Add(this.TexteCheminDFS);
            this.Controls.Add(this.BoutonCheminDFS);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form1";
            this.Text = "ProjetPSI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableauListeAdj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Button BoutonCheminDFS;
        private System.Windows.Forms.Label TexteCheminDFS;
        private Button BoutonAfficherGraphe;
        private Panel PanelGraphe;
        private DataGridView TableauListeAdj;
        private Button BoutonListeAdj;
    }
}

