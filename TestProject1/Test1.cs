using System;
using System.Collections.Generic;
using LivinParis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitaires
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestNoeudConstructor()
        {
            string nom = "A";
            Noeud noeud = new Noeud(nom);
            Assert.AreEqual(nom, noeud.Nom);
        }

        [TestMethod]
        public void TestLienConstructor()
        {
            Noeud noeud1 = new Noeud("A");
            Noeud noeud2 = new Noeud("B");
            Lien lien = new Lien((noeud1, noeud2));
            Assert.AreEqual((noeud1, noeud2), lien.Couple);
        }

        [TestMethod]
        public void TestGrapheConstructor()
        {
            Noeud noeud1 = new Noeud("A");
            Noeud noeud2 = new Noeud("B");
            Lien lien = new Lien((noeud1, noeud2));
            List<Lien> liens = new List<Lien> { lien };
            Graphe graphe = new Graphe(liens);
            Assert.AreEqual(liens, graphe.Liens);
        }

        [TestMethod]
        public void TestListeAdjacence()
        {
            Noeud noeud1 = new Noeud("1");
            Noeud noeud2 = new Noeud("2");
            Lien lien = new Lien((noeud1, noeud2));
            List<Lien> liens = new List<Lien> { lien };
            Graphe graphe = new Graphe(liens);
            Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>
            {
                { "1", new List<string> { "2" } },
                { "2", new List<string> { "1" } }
            };
            Dictionary<string, List<string>> actual = Program.ListeAdjacence(graphe);
            CollectionAssert.AreEqual(expected["1"], actual["1"]);
            CollectionAssert.AreEqual(expected["2"], actual["2"]);
        }

        [TestMethod]
        public void TestMatriceAdjacence()
        {
            Dictionary<string, List<string>> listeAdjacence = new Dictionary<string, List<string>>
            {
                { "1", new List<string> { "2" } },
                { "2", new List<string> { "1" } }
            };
            int[,] expected = new int[,]
            {
                { 0, 1 },
                { 1, 0 }
            };
            int[,] actual = Program.MatriceAdjacence(listeAdjacence);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDFS()
        {
            Noeud noeud1 = new Noeud("1");
            Noeud noeud2 = new Noeud("2");
            Lien lien = new Lien((noeud1, noeud2));
            List<Lien> liens = new List<Lien> { lien };
            Graphe graphe = new Graphe(liens);
            graphe.ListeAdjacence = Program.ListeAdjacence(graphe);
            List<string> expected = new List<string> { "1", "2" };
            List<string> actual = Program.DFS(graphe, "1");
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
