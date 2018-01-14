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
using Prog6.Respositories.Interfaces;

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

            // Act
            ViewResult result = tamagotchisController.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());

            // Act
            ViewResult result = tamagotchisController.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePost()
        {
            ITamagotchiRepository tamagotchiRepository = new DummyTamagotchiRepository();
            TamagotchisController tamagotchisController = new TamagotchisController(tamagotchiRepository);

            // Act
            TamagotchiModel newtamagotchi = new TamagotchiModel() {Naam = "testTamagochi"};
            RedirectToRouteResult result = tamagotchisController.Create(newtamagotchi) as RedirectToRouteResult;

            Assert.IsTrue(tamagotchiRepository.GetAll().Contains(newtamagotchi));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());

            // Act
            ViewResult result = tamagotchisController.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditPost()
        {
            ITamagotchiRepository tamagotchiRepository = new DummyTamagotchiRepository();
            TamagotchisController tamagotchisController = new TamagotchisController(tamagotchiRepository);
            TamagotchiModel tam1 = tamagotchiRepository.Get(1);
            tam1.Level = 85;
            tam1.Leeftijd = 72;

            tamagotchisController.Edit(tam1);

            Assert.AreEqual(tam1, tamagotchiRepository.Get(1));
        }

        [TestMethod]
        public void Delete()
        {
            TamagotchisController tamagotchisController = new TamagotchisController(new DummyTamagotchiRepository());

            // Act
            ViewResult result = tamagotchisController.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteConfirmed()
        {
            ITamagotchiRepository tamagotchiRepository = new DummyTamagotchiRepository();
            TamagotchisController tamagotchisController = new TamagotchisController(tamagotchiRepository);
            TamagotchiModel subject = tamagotchiRepository.Get(2);
            tamagotchisController.DeleteConfirmed(2);

            Assert.IsTrue(!tamagotchiRepository.GetAll().Contains(subject));
        }
    }
}
