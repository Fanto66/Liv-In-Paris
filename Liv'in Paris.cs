using System.ComponentModel.Design;

namespace Liv_In_Paris
{
    internal class Program
    {
        /// <summary>
        /// Si les deux éléments sont égaux, on ajoute une fois en temps que clé et valeur
        /// Sinon 
        /// Si le premier item existe en temps que clé, on ajoute seulement la valeur à la liste déjà existante
        /// Sinon on crée la clé correspondant à au premier item et on crée la liste de valeurs adjacentes avec l'item2
        /// 
        /// De même pour l'item 2
        /// </summary>
        /// <param name="graphe">c'est le graphe que l'on a créé</param>
        /// <returns>On retourne la liste d'adjacence </returns>
        public static Dictionary<string,List<string>> ListeAdjacence(Graphe graphe)
        {
            Dictionary<string,List<string>> dico = new Dictionary<string,List<string>>();
            foreach(Lien lien in graphe.Liens)
            {
                if (lien.Couple.Item1.Nom== lien.Couple.Item2.Nom)
                {
                    if (dico.ContainsKey(lien.Couple.Item1.Nom))
                    {
                        dico[lien.Couple.Item1.Nom].Add(lien.Couple.Item1.Nom);

                    }
                    else
                    {
                        List<string> noeuds1 = new List<string>();
                        noeuds1.Add(lien.Couple.Item1.Nom);
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
                        List<string> noeuds1 = new List<string>();
                        noeuds1.Add(lien.Couple.Item2.Nom);
                        dico.Add(lien.Couple.Item1.Nom, noeuds1);
                    }
                    if (dico.ContainsKey(lien.Couple.Item2.Nom))
                    {
                        dico[lien.Couple.Item2.Nom].Add(lien.Couple.Item1.Nom);
                    }
                    else
                    {
                        List<string> noeuds2 = new List<string>();
                        noeuds2.Add(lien.Couple.Item1.Nom);
                        dico.Add(lien.Couple.Item2.Nom, noeuds2);
                    }
                }


            }
            return dico;

            
        }
        //Marche pour un graphe avec des sommets qui sont des entiers
        //C'est censé être symétrique normalement d'après le cours, il faudrait aussi que ça soit trié, ce qui n'est pas le cas ici
        public static int[,] MatriceAdjacence(Graphe graphe)
        {
            int[,] mat = new int[graphe.Liens.Count, graphe.Liens.Count];
            foreach(Lien lien1 in graphe.Liens)

            {
                foreach(Lien lien2 in graphe.Liens)
                {
                    mat[Convert.ToInt32(lien1.Couple.Item1.Nom), Convert.ToInt32(lien2.Couple.Item2.Nom)] = 1;
                }
                
            }
            return mat;
        }
        static void Main(string[] args)
        {
            //Comme le fichier est petit, on utilise ReadAllLines au lieu d'un streamReader
            //Le fichier est transformer en tableau de lignes
            string[] lignes = File.ReadAllLines(@"..\..\..\soc-karate.mtx");
            List<Lien> liens = new List<Lien>();
            
            //Pour chaque ligne du fichier
            foreach(string ligne in lignes)
            {
                
                if (ligne[0]!='%')
                {
                    string[] motsLigne = ligne.Split(' ');      //Pour chaque ligne, on la divise en tableau de mots
                    Noeud noeud1 = new Noeud(motsLigne[0]);
                    Noeud noeud2 = new Noeud(motsLigne[1]);     //On crée des noeuds
                    Lien lien = new Lien((noeud1,noeud2));      //Avec les noeuds on fait des liens
                    liens.Add(lien);                            //Qu'on ajoute dans la liste de liens
                }
            }
            Graphe graphe = new Graphe(liens);
            Dictionary<string, List<string>> lAdjacence = ListeAdjacence(graphe);

            //Affichage Liste Adjacence
            foreach(var ele in lAdjacence)
            {
                Console.Write(ele.Key +" : ");
                foreach(string noeud in ele.Value)
                {
                    Console.Write(noeud +" ");
                }
                
                Console.WriteLine();
            }

            int[,] mat = MatriceAdjacence(graphe);

            //Affichage Matrice Adjacence
            Console.WriteLine();

            for (int i =0; i < mat.GetLength(0);i++)
            {
                for (int j =0; j <mat.GetLength(1);j++)
                {
                    Console.Write(mat[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
