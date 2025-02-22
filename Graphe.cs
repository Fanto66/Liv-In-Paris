using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivinParis
{
    public class Graphe
    {
        //Un graphe correspond à un ensemble de liens
        private List<Lien> liens;
        private Dictionary<string, List<string>> listeAdjacence;
        private int[,] matAdjacence;
        public Graphe(List<Lien> liens)
        {

            this.liens = liens;
        }
        public List<Lien> Liens
        {
            get { return this.liens; }
        }

        public int[,] MatAdjacence
        {
            get { return this.matAdjacence; }


        }
        public Dictionary<string, List<string>> ListeAdjacence
        {
            get { return this.listeAdjacence; }
            set { this.listeAdjacence = value; }
        }
    }
}
