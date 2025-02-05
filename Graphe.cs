using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liv_In_Paris
{
    internal class Graphe
    {
        //Un graphe correspond à un ensemble de liens
        private List<Lien> liens;
        private Dictionary<string, List<string>> listeAdjacence;
        private int[,] adjacence;
        public Graphe(List<Lien> liens)
        {

            this.liens = liens;
        }
        public List<Lien> Liens
        {
            get { return this.liens; }
        }

        public int[,] Adjacence
        {
            get { return this.adjacence; }

        }
        public Dictionary<string, List<string>> ListeAdjacence
        {
            get { return this.listeAdjacence; }
        }
    }
}
