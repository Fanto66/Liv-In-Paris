using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivinParis
{
    /// <summary>
    /// Représente un graphe composé de liens entre des noeuds.
    /// </summary>
    public class Graphe
    {
        // Liste des liens composant le graphe
        private List<Lien> liens;

        // Liste d'adjacence représentant les connexions entre les noeuds
        private Dictionary<string, List<string>> listeAdjacence;

        // Matrice d'adjacence représentant les connexions entre les noeuds sous forme de matrice
        private int[,] matAdjacence;

        // Liste des noeuds composant le graphe
        private List<Noeud> noeuds;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Graphe"/> avec une liste de liens.
        /// </summary>
        /// <param name="liens">Liste des liens composant le graphe.</param>
        public Graphe(List<Lien> liens)
        {
            this.liens = liens;
            this.noeuds = new List<Noeud>();

            // Remplit la liste des noeuds en se basant sur les liens
            foreach (var lien in liens)
            {
                if (!this.noeuds.Any(n => n.Nom == lien.Couple.Item1.Nom))
                {
                    this.noeuds.Add(lien.Couple.Item1);
                }
                if (!this.noeuds.Any(n => n.Nom == lien.Couple.Item2.Nom))
                {
                    this.noeuds.Add(lien.Couple.Item2);
                }
            }
        }

        /// <summary>
        /// Obtient la liste des liens composant le graphe.
        /// </summary>
        public List<Lien> Liens
        {
            get { return this.liens; }
        }

        /// <summary>
        /// Obtient ou définit la matrice d'adjacence représentant les connexions entre les noeuds.
        /// </summary>
        public int[,] MatAdjacence
        {
            set { matAdjacence = value; }
            get { return this.matAdjacence; }
        }

        /// <summary>
        /// Obtient ou définit la liste d'adjacence représentant les connexions entre les noeuds.
        /// </summary>
        public Dictionary<string, List<string>> ListeAdjacence
        {
            get { return this.listeAdjacence; }
            set { this.listeAdjacence = value; }
        }

        /// <summary>
        /// Obtient la liste des noeuds composant le graphe.
        /// </summary>
        public List<Noeud> Noeuds
        {
            get { return this.noeuds; }
        }
    }
}
