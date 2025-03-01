using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivinParis
{
    public class Program
    {
        #region Fonctions

        /// <summary>
        /// Affiche une matrice d'entiers.
        /// </summary>
        /// <param name="mat">Matrice à afficher.</param>
        static void AfficherMatrice(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Fonction auxiliaire pour le parcours en profondeur.
        /// </summary>
        /// <param name="adj">Liste d'adjacence du graphe.</param>
        /// <param name="depart">Noeud actuel.</param>
        /// <param name="visite">Tableau des noeuds visités.</param>
        /// <param name="chemin">Chemin suivi.</param>
        /// <returns>Liste des noeuds parcourus.</returns>
        static List<string> DFS_Rec(Dictionary<string, List<string>> adj, string depart, bool[] visite, List<string> chemin)
        {
            visite[int.Parse(depart) - 1] = true;
            chemin.Add(depart);

            foreach (string s in adj[depart])
            {
                if (!visite[int.Parse(s) - 1])
                {
                    DFS_Rec(adj, s, visite, chemin);
                }
            }
            return chemin;
        }

        /// <summary>
        /// Parcourt un graphe en profondeur.
        /// </summary>
        /// <param name="graphe">Graphe à parcourir.</param>
        /// <param name="depart">Noeud de départ.</param>
        /// <returns>Trajet effectué.</returns>
        public static List<string> DFS(Graphe graphe, string depart)
        {
            Dictionary<string, List<string>> listeAdj = graphe.ListeAdjacence;
            bool[] visite = new bool[listeAdj.Count];
            List<string> chemin = new List<string>();

            return DFS_Rec(listeAdj, depart, visite, chemin);
        }

        /// <summary>
        /// Crée la liste d'adjacence pour un graphe donné.
        /// </summary>
        /// <param name="graphe">Graphe à traiter.</param>
        /// <returns>Liste d'adjacence.</returns>
        public static Dictionary<string, List<string>> ListeAdjacence(Graphe graphe)
        {
            Dictionary<string, List<string>> dico = new Dictionary<string, List<string>>();
            foreach (Lien lien in graphe.Liens)
            {
                if (lien.Couple.Item1.Nom == lien.Couple.Item2.Nom)
                {
                    if (dico.ContainsKey(lien.Couple.Item1.Nom))
                    {
                        dico[lien.Couple.Item1.Nom].Add(lien.Couple.Item1.Nom);
                    }
                    else
                    {
                        List<string> noeuds1 = new List<string> { lien.Couple.Item1.Nom };
                        dico.Add(lien.Couple.Item1.Nom, noeuds1);
                    }
                }
                else
                {
                    if (dico.ContainsKey(lien.Couple.Item1.Nom))
                    {
                        dico[lien.Couple.Item1.Nom].Add(lien.Couple.Item2.Nom);
                    }
                    else
                    {
                        List<string> noeuds1 = new List<string> { lien.Couple.Item2.Nom };
                        dico.Add(lien.Couple.Item1.Nom, noeuds1);
                    }
                    if (dico.ContainsKey(lien.Couple.Item2.Nom))
                    {
                        dico[lien.Couple.Item2.Nom].Add(lien.Couple.Item1.Nom);
                    }
                    else
                    {
                        List<string> noeuds2 = new List<string> { lien.Couple.Item1.Nom };
                        dico.Add(lien.Couple.Item2.Nom, noeuds2);
                    }
                }
            }
            return dico;
        }

        /// <summary>
        /// Crée la matrice d'adjacence pour un graphe donné.
        /// </summary>
        /// <param name="lAdjacence">Liste d'adjacence du graphe.</param>
        /// <returns>Matrice d'adjacence.</returns>
        public static int[,] MatriceAdjacence(Dictionary<string, List<string>> lAdjacence)
        {
            int[,] mat = new int[lAdjacence.Count, lAdjacence.Count];
            foreach (string clef in lAdjacence.Keys)
            {
                foreach (string adja in lAdjacence[clef])
                {
                    mat[Convert.ToInt32(clef) - 1, Convert.ToInt32(adja) - 1] = 1;
                }
            }
            return mat;
        }

        /// <summary>
        /// Vérifie si le graphe contient un circuit.
        /// </summary>
        /// <param name="graphe">Graphe à vérifier.</param>
        /// <returns>Vrai si le graphe contient un circuit, sinon faux.</returns>
        static bool Circuit(Graphe graphe)
        {
            Dictionary<string, List<string>> listeAdj = graphe.ListeAdjacence;
            bool[] visite = new bool[listeAdj.Count];
            var keys = listeAdj.Keys.ToList();

            return Circuit_Rec(listeAdj, keys[0], null, visite);
        }

        /// <summary>
        /// Fonction récursive auxiliaire pour vérifier les circuits.
        /// </summary>
        /// <param name="Adj">Liste d'adjacence.</param>
        /// <param name="current">Noeud actuel.</param>
        /// <param name="parent">Noeud parent.</param>
        /// <param name="visite">Liste des noeuds visités.</param>
        /// <returns>Vrai ou faux.</returns>
        static bool Circuit_Rec(Dictionary<string, List<string>> Adj, string current, string parent, bool[] visite)
        {
            visite[int.Parse(current) - 1] = true;

            foreach (string enfant in Adj[current])
            {
                if (!visite[int.Parse(enfant) - 1])
                {
                    if (Circuit_Rec(Adj, enfant, current, visite))
                    {
                        return true;
                    }
                }
                else
                {
                    if (enfant != parent)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Vérifie si le graphe est connexe.
        /// </summary>
        /// <param name="graphe">Graphe à vérifier.</param>
        /// <returns>Vrai si le graphe est connexe, sinon faux.</returns>
        public static bool Connexe(Graphe graphe)
        {
            if (graphe == null || graphe.ListeAdjacence == null || graphe.ListeAdjacence.Count == 0)
            {
                return false;
            }

            // Sélectionne le premier noeud de la liste des noeuds comme noeud de départ
            Noeud startNode = graphe.Noeuds.First();

            var (visites, parents) = ParcoursLargeur(graphe.ListeAdjacence, startNode);

            return visites.Count == graphe.ListeAdjacence.Count;
        }

        /// <summary>
        /// Effectue un parcours en largeur sur le graphe.
        /// </summary>
        /// <param name="lAdjacence">Liste d'adjacence du graphe.</param>
        /// <param name="depart">Noeud de départ.</param>
        /// <returns>Tuple contenant la liste des noeuds visités et terminés.</returns>
        public static (List<string> visites, Dictionary<string, string> parents) ParcoursLargeur(Dictionary<string, List<string>> lAdjacence, Noeud depart)
        {
            var file = new Queue<Noeud>();
            var visites = new List<string>();
            var parents = new Dictionary<string, string>();

            file.Enqueue(depart);
            visites.Add(depart.Nom);
            parents[depart.Nom] = null; // Root node has no parent

            while (file.Count > 0)
            {
                var actuel = file.Dequeue();

                foreach (var adja in lAdjacence[actuel.Nom])
                {
                    if (!visites.Contains(adja))
                    {
                        visites.Add(adja);
                        file.Enqueue(new Noeud(adja));
                        parents[adja] = actuel.Nom; // Track the parent node
                    }
                }
            }

            return (visites, parents);
        }


        #endregion

        public static Graphe graphe;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Gestion du fichier
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "soc-karate.mtx");

            string[] lignes = File.ReadAllLines(filePath);
            List<Lien> liens = new List<Lien>();

            foreach (string ligne in lignes)
            {
                if (ligne[0] != '%')
                {
                    string[] motsLigne = ligne.Split(' ');      // Pour chaque ligne, on la divise en tableau de mots
                    Noeud noeud1 = new Noeud(motsLigne[0]);
                    Noeud noeud2 = new Noeud(motsLigne[1]);     // On crée des noeuds
                    Lien lien = new Lien((noeud1, noeud2));     // Avec les noeuds on fait des liens

                    liens.Add(lien);                            // Qu'on ajoute dans la liste de liens
                }
            }

            Graphe graphe = new Graphe(liens);                  // On crée un graphe avec les liens
            Dictionary<string, List<string>> listeAdj = ListeAdjacence(graphe);     // On crée la liste d'adjacence

            int[,] matAdj = MatriceAdjacence(listeAdj);         // On crée la matrice d'adjacence

            graphe.MatAdjacence = matAdj;                       // On ajoute la matrice d'adjacence au graphe
            graphe.ListeAdjacence = listeAdj;                   // On ajoute la liste d'adjacence au graphe

            List<string> cheminDFS = DFS(graphe, "34");         // On fait un parcours en profondeur
            #endregion

            bool circuit = Circuit(graphe);                    // On vérifie si le graphe a un circuit
            bool connexe = Connexe(graphe);                    // On vérifie si le graphe est connexe

            // Effectuer le parcours en largeur (BFS)
            Noeud noeudDepart = graphe.Noeuds.First();
            var visites = ParcoursLargeur(graphe.ListeAdjacence, noeudDepart);

            // Récupérer le chemin BFS du noeud de départ à un noeud spécifique

            Form1 form = new Form1(graphe);
            form.TexteCheminDFSLabel = String.Join(" -> ", cheminDFS);       // On affiche le chemin DFS dans le label1
            form.TexteCheminBFSLabel = string.Join(" -> ", visites.visites);     // On affiche le chemin BFS dans le label2
            form.Cycle = circuit;                                           // On affiche si le graphe a un circuit
            form.Connexe = connexe;                                         // On affiche si le graphe est connexe

            Application.Run(form);
        }

    }
}
