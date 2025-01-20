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
        //Dictionary<string, Noeud> noeuds;
        List<Lien> liens;
        public Graphe (List<Lien> liens/*List<Lien> liens,Dictionary<string,Noeud> noeuds*/)
        {
            //this.noeuds = noeuds;
            this.liens = liens;
        }
        public List<Lien> Liens
        {
            get { return this.liens; }
        }
        /*public Dictionary<string, Noeud> Noeuds
        {
            get { return this.noeuds; }
        }
        */
    }
}
