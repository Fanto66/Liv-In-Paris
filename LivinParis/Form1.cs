using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivinParis
{
    public partial class Form1 : Form
    {
        // Facteur d'échelle pour le redimensionnement du graphe
        private int facteurEchelle = 300;

        private bool connexe, cycle;

        private DataTable table = new DataTable();

        // Liste d'adjacence représentant le graphe
        private Dictionary<string, List<string>> listeAdj;
        // Indicateur pour savoir si le graphe doit être dessiné
        private bool doitDessiner = true;

        /// <summary>
        /// Constructeur de la classe Form1.
        /// Initialise les composants et la liste d'adjacence.
        /// </summary>
        /// <param name="listeAdj">Liste d'adjacence représentant le graphe</param>
        public Form1(Graphe graphe)
        {
            InitializeComponent();
            this.listeAdj = graphe.ListeAdjacence;
            // Create a DataTable to represent the adjacency list
            this.table.Columns.Add("Noeud", typeof(string));
            this.table.Columns.Add("Noueds Adjacents", typeof(string));

            // Populate the DataTable with the adjacency list data
            foreach (var noeud in listeAdj)
            {
                string adjacentNodes = string.Join(", ", noeud.Value);
                table.Rows.Add(noeud.Key, adjacentNodes);
            }

            // Bind the DataTable to the DataGridView
            TableauListeAdj.DataSource = table;

            int[,] matAdjacence = graphe.MatAdjacence;
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable
            int columnCount = matAdjacence.GetLength(1);
            for (int i = 0; i < columnCount; i++)
            {
                dataTable.Columns.Add($"Noeud {i}");
            }

            // Add rows to the DataTable
            int rowCount = matAdjacence.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < columnCount; j++)
                {
                    row[$"Noeud {j}"] = matAdjacence[i, j];
                }
                dataTable.Rows.Add(row);
            }

            // Set the DataSource of the DataGridView
            dataGridViewMatAdjacence.DataSource = dataTable;

            foreach (DataGridViewColumn column in dataGridViewMatAdjacence.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewMatAdjacence.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }


        public bool Connexe
        {
            get { return connexe; }
            set
            {
                connexe = value;
                TexteProp.Text = ((connexe) ? "Le graphe est connexe" : "Le graphe n'est pas connexe")+((cycle)? " et contient un cycle" : " et contient pas de cycle.");
            }
        }

        public bool Cycle
        {
            get { return cycle; }
            set
            {
                cycle = value;
                TexteProp.Text = ((connexe) ? "Le graphe est connexe" : "Le graphe n'est pas connexe") + ((cycle) ? " et contient un cycle" : " et contient pas de cycle.");
            }
        }



        /// <summary>
        /// Propriété pour obtenir ou définir le texte du label de chemin DFS.
        /// </summary>
        public string TexteCheminDFSLabel
        {
            get { return TexteCheminDFS.Text; }
            set { TexteCheminDFS.Text = "Chemin  DFS suivi: " + value; }
        }

        public string TexteCheminBFSLabel
        {
            get { return TexteCheminBFS.Text; }
            set { TexteCheminBFS.Text = "Chemin BFS suivi: " + value; }
        }

        /// <summary>
        /// Gestionnaire d'événements pour le clic sur le bouton de chemin DFS.
        /// Affiche ou cache le label de chemin DFS.
        /// </summary>
        private void BoutonDFSClick(object sender, EventArgs e)
        {
            TexteCheminDFS.Visible = !TexteCheminDFS.Visible;
            PanelGraphe.Visible = false;
            TableauListeAdj.Visible = false;
            TexteCheminBFS.Visible = false;
            TexteProp.Visible = false;
            dataGridViewMatAdjacence.Visible = false;

            BoutonCheminBFS.Text = (TexteCheminBFS.Visible) ? "Cacher Chemin BFS" : "Afficher Chemin BFS";
            BoutonCheminDFS.Text = (TexteCheminDFS.Visible) ? "Cacher Chemin DFS" : "Afficher Chemin DFS";
            BoutonAfficherGraphe.Text = (PanelGraphe.Visible) ? "Cacher Graphe" : "Afficher Graphe";
            BoutonListeAdj.Text = (TableauListeAdj.Visible) ? "Cacher Liste d'adjacence" : "Afficher Liste d'adjacence";
            BoutonProp.Text = (TexteProp.Visible) ? "Cacher Propriétés" : "Afficher Propriétés";
            BoutonMat.Text = (dataGridViewMatAdjacence.Visible) ? "Cacher Matrice d'adjacence" : "Afficher Matrice d'adjacence";

        }

        /// <summary>
        /// Gestionnaire d'événements pour le clic sur le bouton d'affichage du graphe.
        /// Affiche ou cache le panel du graphe.
        /// </summary>
        private void BoutonGrapheClick(object sender, EventArgs e)
        {
            PanelGraphe.Visible = !PanelGraphe.Visible;
            TexteCheminDFS.Visible = false;
            TableauListeAdj.Visible = false;
            TexteCheminBFS.Visible = false;
            TexteProp.Visible = false;
            dataGridViewMatAdjacence.Visible = false;

            BoutonCheminBFS.Text = (TexteCheminBFS.Visible) ? "Cacher Chemin BFS" : "Afficher Chemin BFS";
            BoutonCheminDFS.Text = (TexteCheminDFS.Visible) ? "Cacher Chemin DFS" : "Afficher Chemin DFS";
            BoutonAfficherGraphe.Text = (PanelGraphe.Visible) ? "Cacher Graphe" : "Afficher Graphe";
            BoutonListeAdj.Text = (TableauListeAdj.Visible) ? "Cacher Liste d'adjacence" : "Afficher Liste d'adjacence";
            BoutonProp.Text = (TexteProp.Visible) ? "Cacher Propriétés" : "Afficher Propriétés";
            BoutonMat.Text = (dataGridViewMatAdjacence.Visible) ? "Cacher Matrice d'adjacence" : "Afficher Matrice d'adjacence";


            if (PanelGraphe.Visible)
            {
                doitDessiner = true;
                PanelGraphe.Invalidate();
            }
        }

        private void BoutonListeAdjClick(object sender, EventArgs e)
        {
            PanelGraphe.Visible = false;
            TexteCheminDFS.Visible = false;
            TexteCheminBFS.Visible = false;
            TableauListeAdj.Visible = !TableauListeAdj.Visible;
            TexteProp.Visible = false;
            dataGridViewMatAdjacence.Visible = false;

            BoutonCheminBFS.Text = (TexteCheminBFS.Visible) ? "Cacher Chemin BFS" : "Afficher Chemin BFS";
            BoutonCheminDFS.Text = (TexteCheminDFS.Visible) ? "Cacher Chemin DFS" : "Afficher Chemin DFS";
            BoutonAfficherGraphe.Text = (PanelGraphe.Visible) ? "Cacher Graphe" : "Afficher Graphe";
            BoutonListeAdj.Text = (TableauListeAdj.Visible) ? "Cacher Liste d'adjacence" : "Afficher Liste d'adjacence";
            BoutonProp.Text = (TexteProp.Visible) ? "Cacher Propriétés" : "Afficher Propriétés";
            BoutonMat.Text = (dataGridViewMatAdjacence.Visible) ? "Cacher Matrice d'adjacence" : "Afficher Matrice d'adjacence";
        }


        private void BoutonBFSClick(object sender, EventArgs e)
        {
            TexteCheminBFS.Visible = !TexteCheminBFS.Visible;
            PanelGraphe.Visible = false;
            TableauListeAdj.Visible = false;
            TexteCheminDFS.Visible = false;
            TexteProp.Visible = false;
            dataGridViewMatAdjacence.Visible = false;

            BoutonCheminBFS.Text = (TexteCheminBFS.Visible) ? "Cacher Chemin BFS" : "Afficher Chemin BFS";
            BoutonCheminDFS.Text = (TexteCheminDFS.Visible) ? "Cacher Chemin DFS" : "Afficher Chemin DFS";
            BoutonAfficherGraphe.Text = (PanelGraphe.Visible) ? "Cacher Graphe" : "Afficher Graphe";
            BoutonListeAdj.Text = (TableauListeAdj.Visible) ? "Cacher Liste d'adjacence" : "Afficher Liste d'adjacence";
            BoutonProp.Text = (TexteProp.Visible) ? "Cacher Propriétés" : "Afficher Propriétés";
            BoutonMat.Text = (dataGridViewMatAdjacence.Visible) ? "Cacher Matrice d'adjacence" : "Afficher Matrice d'adjacence";
        }

        /// <summary>
        /// Gestionnaire d'événements pour le chargement du formulaire.
        /// Recalcule la taille du panel du graphe.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            RecalculerTaille();
        }

        /// <summary>
        /// Gestionnaire d'événements pour le dessin du panel du graphe.
        /// Dessine le graphe si nécessaire.
        /// </summary>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (doitDessiner)
            {
                DessinerGraphe(listeAdj, e);
                doitDessiner = false;
            }
        }

        /// <summary>
        /// Recalcule la taille du panel du graphe en fonction des positions des nœuds.
        /// </summary>
        private void RecalculerTaille()
        {
            int rayonNoeud = 20; // Garde le rayon des nœuds identique
            int marge = 100; // Ajoute une marge entre le bord du graphe et le bord du panel
            Dictionary<string, Point> positionsNoeuds = new Dictionary<string, Point>();

            int centreX = PanelGraphe.Width / 2;
            int centerY = PanelGraphe.Height / 2;
            double rayon = 2.5 * (Math.Min(centreX, centerY) - rayonNoeud - marge); // Augmente le facteur d'échelle à 2.5
            int nombreNoeuds = listeAdj.Count;
            double pasAngle = 2 * Math.PI / nombreNoeuds;
            int i = 0;

            foreach (var node in listeAdj.Keys)
            {
                double angle = i * pasAngle;
                int x = centreX + (int)(rayon * Math.Cos(angle));
                int y = centerY + (int)(rayon * Math.Sin(angle));
                positionsNoeuds[node] = new Point(x, y);
                i++;
            }

            // Calcule la boîte englobante du graphe
            int minX = positionsNoeuds.Values.Min(p => p.X) - rayonNoeud - marge;
            int minY = positionsNoeuds.Values.Min(p => p.Y) - rayonNoeud - marge;
            int maxX = positionsNoeuds.Values.Max(p => p.X) + rayonNoeud + marge;
            int maxY = positionsNoeuds.Values.Max(p => p.Y) + rayonNoeud + marge;

            // Redimensionne le panel pour s'adapter au graphe
            PanelGraphe.Size = new Size(maxX - minX + facteurEchelle, maxY - minY + facteurEchelle);
        }

        /// <summary>
        /// Dessine le graphe sur le panel.
        /// </summary>
        /// <param name="adjList">Liste d'adjacence représentant le graphe</param>
        /// <param name="e">Événement de dessin</param>
        private void DessinerGraphe(Dictionary<string, List<string>> adjList, PaintEventArgs e)
        {
            // Obtient l'objet Graphics pour dessiner sur le panel
            Graphics g = e.Graphics;
            // Efface le panel avant de dessiner
            g.Clear(PanelGraphe.BackColor);

            // Crée un stylo pour dessiner les lignes
            Pen stilo = new Pen(Color.Black, 2);
            // Crée un pinceau pour remplir les nœuds
            Brush pinceau = new SolidBrush(Color.Blue);
            // Définit la police pour dessiner les étiquettes des nœuds
            Font font = new Font("Arial", 12); // Augmente la taille de la police

            int rayonNoeud = 20; // Garde le rayon des nœuds identique
            int marge = 100; // Ajoute une marge entre le bord du graphe et le bord du panel
            Dictionary<string, Point> positionNoeud = new Dictionary<string, Point>();

            // Calcule le centre du panel
            int centreX = PanelGraphe.Width / 2;
            int centreY = PanelGraphe.Height / 2;
            // Calcule le rayon du cercle sur lequel les nœuds seront placés
            double rayon = 2.5 * (Math.Min(centreX, centreY) - rayonNoeud - marge - (facteurEchelle / 2)); // Augmente le facteur d'échelle à 2.5
            int nombreNoeud = adjList.Count;
            // Calcule l'angle entre chaque nœud
            double pasAngle = 2 * Math.PI / nombreNoeud;
            int i = 0;

            // Calcule les positions des nœuds sur le cercle
            foreach (var node in adjList.Keys)
            {
                double angle = i * pasAngle;
                int x = centreX + (int)(rayon * Math.Cos(angle));
                int y = centreY + (int)(rayon * Math.Sin(angle));
                positionNoeud[node] = new Point(x, y);
                i++;
            }

            // Dessine les arêtes entre les nœuds
            foreach (var node in adjList)
            {
                Point positionDepart = positionNoeud[node.Key];
                foreach (var voisins in node.Value)
                {
                    Point positionFinale = positionNoeud[voisins];
                    g.DrawLine(stilo, positionDepart, positionFinale);
                }
            }

            // Dessine les nœuds et leurs étiquettes
            foreach (var node in positionNoeud)
            {
                Point pos = node.Value;
                g.FillEllipse(pinceau, pos.X - rayonNoeud, pos.Y - rayonNoeud, rayonNoeud * 2, rayonNoeud * 2);
                g.DrawEllipse(stilo, pos.X - rayonNoeud, pos.Y - rayonNoeud, rayonNoeud * 2, rayonNoeud * 2);
                g.DrawString(node.Key, font, Brushes.White, pos.X - rayonNoeud / 2, pos.Y - rayonNoeud / 2);
            }
        }

        private void BoutonProp_Click(object sender, EventArgs e)
        {
            TexteProp.Visible = !TexteProp.Visible;
            TexteCheminBFS.Visible = false;
            PanelGraphe.Visible = false;
            TableauListeAdj.Visible = false;
            TexteCheminDFS.Visible = false;
            dataGridViewMatAdjacence.Visible = false;

            BoutonCheminBFS.Text = (TexteCheminBFS.Visible) ? "Cacher Chemin BFS" : "Afficher Chemin BFS";
            BoutonCheminDFS.Text = (TexteCheminDFS.Visible) ? "Cacher Chemin DFS" : "Afficher Chemin DFS";
            BoutonAfficherGraphe.Text = (PanelGraphe.Visible) ? "Cacher Graphe" : "Afficher Graphe";
            BoutonListeAdj.Text = (TableauListeAdj.Visible) ? "Cacher Liste d'adjacence" : "Afficher Liste d'adjacence";
            BoutonProp.Text = (TexteProp.Visible) ? "Cacher Propriétés" : "Afficher Propriétés";
            BoutonMat.Text = (dataGridViewMatAdjacence.Visible) ? "Cacher Matrice d'adjacence" : "Afficher Matrice d'adjacence";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Toggle the visibility of the DataGridView
            dataGridViewMatAdjacence.Visible = !dataGridViewMatAdjacence.Visible;

            // Hide other UI elements
            TexteCheminDFS.Visible = false;
            PanelGraphe.Visible = false;
            TableauListeAdj.Visible = false;
            TexteCheminBFS.Visible = false;
            TexteProp.Visible = false;

            // Update button texts
            BoutonCheminBFS.Text = (TexteCheminBFS.Visible) ? "Cacher Chemin BFS" : "Afficher Chemin BFS";
            BoutonCheminDFS.Text = (TexteCheminDFS.Visible) ? "Cacher Chemin DFS" : "Afficher Chemin DFS";
            BoutonAfficherGraphe.Text = (PanelGraphe.Visible) ? "Cacher Graphe" : "Afficher Graphe";
            BoutonListeAdj.Text = (TableauListeAdj.Visible) ? "Cacher Liste d'adjacence" : "Afficher Liste d'adjacence";
            BoutonProp.Text = (TexteProp.Visible) ? "Cacher Propriétés" : "Afficher Propriétés";
            BoutonMat.Text = (dataGridViewMatAdjacence.Visible) ? "Cacher Matrice d'adjacence" : "Afficher Matrice d'adjacence";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }
}
