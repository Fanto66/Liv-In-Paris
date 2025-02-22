using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivinParis
{
    internal class Noeud
    {
        //Un noeud à un nom
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
