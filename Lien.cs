using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivinParis
{
    public class Lien
    {
        //Un Lien est composé de deux sommets/noeuds
        (Noeud, Noeud) couple;
        public Lien((Noeud, Noeud) couple)
        {
            this.couple = couple;
        }
        public (Noeud, Noeud) Couple
        {
            get { return this.couple; }
        }
    }
}
