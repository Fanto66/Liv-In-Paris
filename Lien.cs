﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liv_In_Paris
{
    internal class Lien
    {
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
