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
            this.TexteProp = new System.Windows.Forms.Label();
            this.TexteCheminBFS = new System.Windows.Forms.Label();
            this.BoutonAfficherGraphe = new System.Windows.Forms.Button();
            this.PanelGraphe = new System.Windows.Forms.Panel();
            this.TableauListeAdj = new System.Windows.Forms.DataGridView();
            this.BoutonListeAdj = new System.Windows.Forms.Button();
            this.BoutonCheminBFS = new System.Windows.Forms.Button();
            this.BoutonProp = new System.Windows.Forms.Button();
            this.BoutonMat = new System.Windows.Forms.Button();
            this.dataGridViewMatAdjacence = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatAdjacence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableauListeAdj)).BeginInit();
            this.SuspendLayout();
            // 
            // BoutonCheminDFS
            // 
            this.BoutonCheminDFS.AutoSize = true;
            this.BoutonCheminDFS.Location = new System.Drawing.Point(11, 12);
            this.BoutonCheminDFS.Margin = new System.Windows.Forms.Padding(2);
            this.BoutonCheminDFS.Name = "BoutonCheminDFS";
            this.BoutonCheminDFS.Size = new System.Drawing.Size(138, 27);
            this.BoutonCheminDFS.TabIndex = 0;
            this.BoutonCheminDFS.Text = "Afficher Chemin DFS";
            this.BoutonCheminDFS.UseVisualStyleBackColor = true;
            this.BoutonCheminDFS.Click += new System.EventHandler(this.BoutonDFSClick);
            // 
            // TexteCheminDFS
            // 
            this.TexteCheminDFS.AutoSize = true;
            this.TexteCheminDFS.Location = new System.Drawing.Point(11, 51);
            this.TexteCheminDFS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TexteCheminDFS.Name = "TexteCheminDFS";
            this.TexteCheminDFS.Size = new System.Drawing.Size(0, 13);
            this.TexteCheminDFS.TabIndex = 1;
            this.TexteCheminDFS.Visible = false;
            // 
            // TexteProp
            // 
            this.TexteProp.AutoSize = true;
            this.TexteProp.Location = new System.Drawing.Point(15, 63);
            this.TexteProp.Name = "TexteProp";
            this.TexteProp.Size = new System.Drawing.Size(0, 13);
            this.TexteProp.TabIndex = 1;
            this.TexteProp.Visible = false;
            // 
            // TexteCheminBFS
            // 
            this.TexteCheminBFS.AutoSize = true;
            this.TexteCheminBFS.Location = new System.Drawing.Point(15, 63);
            this.TexteCheminBFS.Name = "TexteCheminBFS";
            this.TexteCheminBFS.Size = new System.Drawing.Size(0, 13);
            this.TexteCheminBFS.TabIndex = 1;
            this.TexteCheminBFS.Visible = false;
            // 
            // BoutonAfficherGraphe
            // 
            this.BoutonAfficherGraphe.AutoSize = true;
            this.BoutonAfficherGraphe.Location = new System.Drawing.Point(154, 12);
            this.BoutonAfficherGraphe.Margin = new System.Windows.Forms.Padding(2);
            this.BoutonAfficherGraphe.Name = "BoutonAfficherGraphe";
            this.BoutonAfficherGraphe.Size = new System.Drawing.Size(138, 27);
            this.BoutonAfficherGraphe.TabIndex = 2;
            this.BoutonAfficherGraphe.Text = "Afficher Graphe";
            this.BoutonAfficherGraphe.UseVisualStyleBackColor = true;
            this.BoutonAfficherGraphe.Click += new System.EventHandler(this.BoutonGrapheClick);
            // 
            // PanelGraphe
            // 
            this.PanelGraphe.AutoSize = true;
            this.PanelGraphe.Location = new System.Drawing.Point(14, 36);
            this.PanelGraphe.Margin = new System.Windows.Forms.Padding(2);
            this.PanelGraphe.Name = "PanelGraphe";
            this.PanelGraphe.Padding = new System.Windows.Forms.Padding(30, 32, 30, 32);
            this.PanelGraphe.Size = new System.Drawing.Size(570, 325);
            this.PanelGraphe.TabIndex = 3;
            this.PanelGraphe.Visible = false;
            this.PanelGraphe.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TableauListeAdj
            // 
            this.TableauListeAdj.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TableauListeAdj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableauListeAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableauListeAdj.Location = new System.Drawing.Point(11, 102);
            this.TableauListeAdj.Margin = new System.Windows.Forms.Padding(2);
            this.TableauListeAdj.MaximumSize = new System.Drawing.Size(600, 650);
            this.TableauListeAdj.Name = "TableauListeAdj";
            this.TableauListeAdj.ReadOnly = true;
            this.TableauListeAdj.RowHeadersWidth = 51;
            this.TableauListeAdj.Size = new System.Drawing.Size(225, 153);
            this.TableauListeAdj.TabIndex = 0;
            this.TableauListeAdj.Visible = false;
            // 
            // BoutonListeAdj
            // 
            this.BoutonListeAdj.AutoSize = true;
            this.BoutonListeAdj.Location = new System.Drawing.Point(298, 12);
            this.BoutonListeAdj.Margin = new System.Windows.Forms.Padding(2);
            this.BoutonListeAdj.Name = "BoutonListeAdj";
            this.BoutonListeAdj.Size = new System.Drawing.Size(160, 27);
            this.BoutonListeAdj.TabIndex = 4;
            this.BoutonListeAdj.Text = "Afficher Liste d\'adjacence";
            this.BoutonListeAdj.UseVisualStyleBackColor = true;
            this.BoutonListeAdj.Click += new System.EventHandler(this.BoutonListeAdjClick);
            // 
            // BoutonCheminBFS
            // 
            this.BoutonCheminBFS.AutoSize = true;
            this.BoutonCheminBFS.Location = new System.Drawing.Point(462, 11);
            this.BoutonCheminBFS.Margin = new System.Windows.Forms.Padding(2);
            this.BoutonCheminBFS.Name = "BoutonCheminBFS";
            this.BoutonCheminBFS.Size = new System.Drawing.Size(138, 27);
            this.BoutonCheminBFS.TabIndex = 5;
            this.BoutonCheminBFS.Text = "Afficher Chemin BFS";
            this.BoutonCheminBFS.UseVisualStyleBackColor = true;
            this.BoutonCheminBFS.Click += new System.EventHandler(this.BoutonBFSClick);
            // 
            // BoutonProp
            // 
            this.BoutonProp.AutoSize = true;
            this.BoutonProp.Location = new System.Drawing.Point(604, 11);
            this.BoutonProp.Margin = new System.Windows.Forms.Padding(2);
            this.BoutonProp.Name = "BoutonProp";
            this.BoutonProp.Size = new System.Drawing.Size(138, 27);
            this.BoutonProp.TabIndex = 6;
            this.BoutonProp.Text = "Afficher Propriétés";
            this.BoutonProp.UseVisualStyleBackColor = true;
            this.BoutonProp.Click += new System.EventHandler(this.BoutonProp_Click);
            // 
            // BoutonMat
            // 
            this.BoutonMat.AutoSize = true;
            this.BoutonMat.Location = new System.Drawing.Point(746, 12);
            this.BoutonMat.Margin = new System.Windows.Forms.Padding(2);
            this.BoutonMat.Name = "BoutonMat";
            this.BoutonMat.Size = new System.Drawing.Size(152, 27);
            this.BoutonMat.TabIndex = 7;
            this.BoutonMat.Text = "Afficher Matrice d\'adjacence";
            this.BoutonMat.UseVisualStyleBackColor = true;
            this.BoutonMat.Click += new System.EventHandler(this.button1_Click);
            //
            // DataagridView pour la matrice d'adjacence
            //
            this.dataGridViewMatAdjacence.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMatAdjacence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMatAdjacence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatAdjacence.Location = new System.Drawing.Point(11, 102);
            this.dataGridViewMatAdjacence.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMatAdjacence.MaximumSize = new System.Drawing.Size(1600, 1650);
            this.dataGridViewMatAdjacence.Name = "dataGridViewMatAdjacence";
            this.dataGridViewMatAdjacence.ReadOnly = true;
            this.dataGridViewMatAdjacence.RowHeadersWidth = 51;
            this.dataGridViewMatAdjacence.TabIndex = 0;
            this.dataGridViewMatAdjacence.Visible = false;
            this.dataGridViewMatAdjacence.AutoSize = true;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1000, 366);
            this.Controls.Add(this.BoutonMat);
            this.Controls.Add(this.BoutonProp);
            this.Controls.Add(this.BoutonCheminBFS);
            this.Controls.Add(this.BoutonListeAdj);
            this.Controls.Add(this.TableauListeAdj);
            this.Controls.Add(this.PanelGraphe);
            this.Controls.Add(this.BoutonAfficherGraphe);
            this.Controls.Add(this.TexteCheminDFS);
            this.Controls.Add(this.BoutonCheminDFS);
            this.Controls.Add(this.TexteCheminBFS);
            this.Controls.Add(this.TexteProp);
            this.Controls.Add(this.dataGridViewMatAdjacence);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(304, 251);
            this.Name = "Form1";
            this.Text = "ProjetPSI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableauListeAdj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.Button BoutonCheminDFS;
        private System.Windows.Forms.Label TexteCheminDFS;
        private System.Windows.Forms.Button BoutonCheminBFS;
        private System.Windows.Forms.Label TexteCheminBFS;
        private System.Windows.Forms.Label TexteProp;
        private Button BoutonAfficherGraphe;
        private Panel PanelGraphe;
        private DataGridView TableauListeAdj;
        private Button BoutonListeAdj;
        private Button BoutonProp;
        private Button BoutonMat;
        private DataGridView dataGridViewMatAdjacence;

    }
}

