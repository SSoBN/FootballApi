using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballApi.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignmnt1;

namespace FootballApi.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {



        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            FootballPlayersManager _manager = new FootballPlayersManager();
            //Act
            int result = _manager.GetAll().Count;
            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //Arrange
            FootballPlayersManager _manager = new FootballPlayersManager();
            FootballPlayer player1 = _manager.GetById(2);
            //Act
            //Assert
            Assert.AreEqual(2, player1.Id);
            Assert.AreEqual(39, player1.ShirtNumber);
        }
        [TestMethod()]
        public void GetByIdTestDontExcist()
        {
            //Arrange
            FootballPlayersManager _manager = new FootballPlayersManager();
            //Act
            //Assert
            Assert.AreEqual(null, _manager.GetById(88));
        }


        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            FootballPlayersManager _manager = new FootballPlayersManager();
            FootballPlayer playerToAdd = new FootballPlayer(1,"Frank", 13, 88);
            //Act
            _manager.Add(playerToAdd);
            //Assert
            Assert.AreEqual(5, _manager.GetAll().Count);
            Assert.AreEqual(88, _manager.GetById(5).ShirtNumber);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            FootballPlayersManager _manager = new FootballPlayersManager();
            int beforeDelete = _manager.GetAll().Count;
            //Act
            FootballPlayer deletedPlayer = _manager.Delete(1);
            //Assert
            Assert.AreEqual(beforeDelete, _manager.GetAll().Count +1);
            Assert.AreEqual(13, deletedPlayer.ShirtNumber);
        }

    }
}