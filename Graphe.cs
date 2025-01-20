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
        List<Lien> liens;
        public Graphe (List<Lien> liens)
        {
            
            this.liens = liens;
        }
        public List<Lien> Liens
        {
            get { return this.liens; }
        }

    }
}
