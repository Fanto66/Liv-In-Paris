using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liv_In_Paris
{
    internal class Noeud
    {
        string nom;
        
        public Noeud(string nom)
        {
            this.nom = nom;
        }
        public string Nom
        {
            get { return this.nom; }
        }
    }
}
