using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LivinParis
{
    partial class Form1
    {
        #region Variables

        private string _texteCheminDFSLabel;

        public string TexteCheminDFSLabel
        {
            get { return _texteCheminDFSLabel; }
            set { _texteCheminDFSLabel = "Chemin suivi: " + value; }
        }




        #endregion


        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            TexteCheminDFS.Visible = true;
        }




        #endregion









        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Use the properties when the form loads
            TexteCheminDFS.Text = TexteCheminDFSLabel; // Example usage
        }


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
            this.BoutonCheminDFS = new System.Windows.Forms.Button();
            this.TexteCheminDFS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.BoutonCheminDFS.Location = new System.Drawing.Point(12, 12);
            this.BoutonCheminDFS.Name = "button1";
            this.BoutonCheminDFS.Size = new System.Drawing.Size(147, 26);
            this.BoutonCheminDFS.TabIndex = 0;
            this.BoutonCheminDFS.AutoSize = true;
            this.BoutonCheminDFS.Text = "Afficher Chemin DFS";
            this.BoutonCheminDFS.UseVisualStyleBackColor = true;
            this.BoutonCheminDFS.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.TexteCheminDFS.AutoSize = true;
            this.TexteCheminDFS.Location = new System.Drawing.Point(12, 41);
            this.TexteCheminDFS.Name = "label1";
            this.TexteCheminDFS.Size = new System.Drawing.Size(0, 16);
            this.TexteCheminDFS.TabIndex = 1;
            this.TexteCheminDFS.Visible = false;
            // 
            // Form1
            // 
            this.AutoSize = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TexteCheminDFS);
            this.Controls.Add(this.BoutonCheminDFS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BoutonCheminDFS;
        private System.Windows.Forms.Label TexteCheminDFS;
    }
}

