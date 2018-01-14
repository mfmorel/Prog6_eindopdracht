using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prog6;
using Prog6.Controllers;
using Prog6.Models;
using Prog6.Respositories;
using Prog6.Respositories.Interfaces;

namespace Prog6.Tests.Controllers
{
    [TestClass]
    public class HotelkamerControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HotelkamersController controller = new HotelkamersController(new DummyHotekamerRepository());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            HotelkamersController controller = new HotelkamersController(new DummyHotekamerRepository());

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            HotelkamersController controller = new HotelkamersController(new DummyHotekamerRepository());

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePost()
        {
            IHotelkamerRepository hotelkamerRepository = new DummyHotekamerRepository();
            HotelkamersController controller = new HotelkamersController(hotelkamerRepository);

            HotelkamerModel newhotelkamer = new HotelkamerModel() {Type = "testkamer"};
            RedirectToRouteResult result = controller.Create(newhotelkamer) as RedirectToRouteResult;

            Assert.IsTrue(hotelkamerRepository.GetAll().Contains(newhotelkamer));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            HotelkamersController controller = new HotelkamersController(new DummyHotekamerRepository());

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditPost()
        {
            IHotelkamerRepository hotelkamerRepository = new DummyHotekamerRepository();
            HotelkamersController controller = new HotelkamersController(hotelkamerRepository);

            HotelkamerModel hot1 = hotelkamerRepository.Get(1);
            hot1.Type = "after update name";
            hot1.Prijs = 35;

            controller.Edit(hot1);

            Assert.AreEqual(hot1, hotelkamerRepository.Get(1));
        }

        [TestMethod]
        public void Delete()
        {
            HotelkamersController controller = new HotelkamersController(new DummyHotekamerRepository());

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteConfirmed()
        {
            IHotelkamerRepository hotelkamerRepository = new DummyHotekamerRepository();
            HotelkamersController controller = new HotelkamersController(hotelkamerRepository);

            HotelkamerModel subject = hotelkamerRepository.Get(2);
            controller.DeleteConfirmed(2);

            Assert.IsTrue(!hotelkamerRepository.GetAll().Contains(subject));
        }
    }
}
