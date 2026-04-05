using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.Logic;
using GameOfLife.Models;

namespace GameOfLife.Tests
{
    [TestClass]
    public class GameOfLifeLogicTests
    {
        private StandardRule _standardRule = new StandardRule();

        [TestMethod]
        public void StandardRule_Birth_ShouldOccurWithExactlyThreeNeighbors()
        {
            // naissance
            bool isAlive = false;
            int neighbors = 3;

            bool result = _standardRule.WillBeAlive(isAlive, neighbors);

            Assert.IsTrue(result, "Une cellule morte avec 3 voisins doit naître.");
        }

        [TestMethod]
        public void StandardRule_Survival_ShouldOccurWithTwoOrThreeNeighbors()
        {
            // survie
            bool isAlive = true;
            
            Assert.IsTrue(_standardRule.WillBeAlive(isAlive, 2), "Survie 2 voisins.");
            Assert.IsTrue(_standardRule.WillBeAlive(isAlive, 3), "Survie 3 voisins.");
        }

        [TestMethod]
        public void StandardRule_Death_ShouldOccurByIsolation()
        {
            // mort isolation
            bool isAlive = true;
            int neighbors = 1;

            bool result = _standardRule.WillBeAlive(isAlive, neighbors);

            Assert.IsFalse(result, "Une cellule avec moins de 2 voisins doit mourir.");
        }

        [TestMethod]
        public void StandardRule_Death_ShouldOccurByOvercrowding()
        {
            // mort surpopulation
            bool isAlive = true;
            int neighbors = 4;

            bool result = _standardRule.WillBeAlive(isAlive, neighbors);

            Assert.IsFalse(result, "Une cellule avec plus de 3 voisins doit mourir.");
        }

        [TestMethod]
        public void GameEngine_Blinker_ShouldOscillate()
        {
            // test moteur blinker
            var engine = new GameEngine(5, 5, _standardRule);
            
            // placement initial
            engine.Grid[2, 1].IsAlive = true;
            engine.Grid[2, 2].IsAlive = true;
            engine.Grid[2, 3].IsAlive = true;
            engine.NextGeneration();

            // vérif verticale
            Assert.IsTrue(engine.Grid[1, 2].IsAlive, "La cellule (1,2) devrait naître.");
            Assert.IsTrue(engine.Grid[2, 2].IsAlive, "La cellule centrale (2,2) devrait survivre.");
            Assert.IsTrue(engine.Grid[3, 2].IsAlive, "La cellule (3,2) devrait naître.");
            
            // vérif des morts
            Assert.IsFalse(engine.Grid[2, 1].IsAlive, "La cellule (2,1) devrait mourir.");
            Assert.IsFalse(engine.Grid[2, 3].IsAlive, "La cellule (2,3) devrait mourir.");
        }
    }
}