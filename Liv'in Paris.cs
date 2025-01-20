using System.ComponentModel.Design;

namespace Liv_In_Paris
{
    internal class Program
    {
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
        static void Main(string[] args)
        {
            string[] lignes = File.ReadAllLines(@"..\..\..\soc-karate.mtx");
            List<Lien> liens = new List<Lien>();
            
            
            foreach(string ligne in lignes)
            {
                if (ligne[0]!='%')
                {
                    string[] motsLigne = ligne.Split(' ');
                    Noeud noeud1 = new Noeud(motsLigne[0]);
                    Noeud noeud2 = new Noeud(motsLigne[1]);
                    Lien lien = new Lien((noeud1,noeud2));
                    liens.Add(lien);
                }
            }
            Graphe graphe = new Graphe(liens);
            Dictionary<string, List<string>> lAdjacence = ListeAdjacence(graphe);

            //Affichage Liste Affichage
            foreach(var ele in lAdjacence)
            {
                Console.Write(ele.Key +" : ");
                foreach(string noeud in ele.Value)
                {
                    Console.Write(noeud +" ");
                }
                
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
