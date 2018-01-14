using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prog6.Controllers;
using Prog6.Models;
using Prog6.Respositories;

namespace Prog6.Tests.Controllers
{
    [TestClass]
    public class TamagotchisControllerTest
    {
        [TestMethod]
        public void Index()
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());

            // Act
            ViewResult result = tamagotchisController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }

        [TestMethod]
        public void Create()
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }

        [TestMethod]
        public void Create(TamagotchiModel tamagotchi)
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }

        [TestMethod]
        public void Edit(int? id)
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }

        [TestMethod]
        public void Edit(TamagotchiModel tamagotchi)
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }

        [TestMethod]
        public void Delete(int? id)
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }

        [TestMethod]
        public void DeleteConfirmed(int id)
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());
        }
    }
}
