using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignement_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballPlayerProject;

namespace Assignement_4.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        FootballPlayersManager manager = new FootballPlayersManager();

        private static int _nextId = 1;
        public List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer{Id=_nextId++, Name="Bob", Age=32, ShirtNumber=47},
            new FootballPlayer{Id=_nextId++, Name="Tim", Age=21, ShirtNumber=14},
            new FootballPlayer{Id=_nextId++, Name="Greg", Age=25, ShirtNumber=82},
            new FootballPlayer{Id=_nextId++, Name="Jhon", Age=30, ShirtNumber=53}
        };

        
        [TestMethod()]
        public void GetByIdTest()
        {
            //Arrange
            int id = 1;
            //Act
            FootballPlayer player = manager.GetById(id);
            //Assert
            Assert.AreEqual(id, player.Id);
        }

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            FootballPlayer player = new FootballPlayer() { Id = _nextId++, Name = "Rob", Age = 36, ShirtNumber = 29 };
            //Act
            FootballPlayer newPlayer = manager.Add(player);
            FootballPlayer foundPlayer = manager.GetById(newPlayer.Id);
            //Assert
            Assert.AreEqual(newPlayer.Name, foundPlayer.Name);
        }
    }
}