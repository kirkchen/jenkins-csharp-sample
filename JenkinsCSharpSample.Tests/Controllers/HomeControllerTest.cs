using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JenkinsCSharpSample;
using JenkinsCSharpSample.Controllers;
using JenkinsCSharpSample.Models;
using Xunit;

namespace JenkinsCSharpSample.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void DefaultPriceIs100AndDefaultQtyIs1()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var actual = result.Model as ShoppingCart;

            // Assert
            Assert.Equal(100, actual.Price);
            Assert.Equal(1, actual.Qty);
            Assert.Equal(MemberType.VIP, actual.MemberType);
        }

        [Fact]
        public void NormalMemberTotalPriceLessThanOrEqualTo1000HasNoDiscount()
        {
            // Arrange
            HomeController controller = new HomeController();
            var model = new ShoppingCart();
            model.Price = 200;
            model.Qty = 3;
            model.MemberType = MemberType.Normal;

            // Act
            ViewResult result = controller.Index(model) as ViewResult;
            var actual = result.Model as ShoppingCart;

            // Assert
            Assert.Equal(600, actual.TotalPrice);
        }

        [Fact]
        public void NormalMemberTotalPriceGreaterThan1000Have20PercentDiscount()
        {
            // Arrange
            HomeController controller = new HomeController();
            var model = new ShoppingCart();
            model.Price = 300;
            model.Qty = 4;
            model.MemberType = MemberType.Normal;

            // Act
            ViewResult result = controller.Index(model) as ViewResult;
            var actual = result.Model as ShoppingCart;

            // Assert
            Assert.Equal(960, actual.TotalPrice);
        }

        [Fact]
        public void VIPMemberTotalPriceLessThanEqualTo500HasNoDiscount()
        {
            // Arrange
            HomeController controller = new HomeController();
            var model = new ShoppingCart();
            model.Price = 300;
            model.Qty = 1;
            model.MemberType = MemberType.VIP;

            // Act
            ViewResult result = controller.Index(model) as ViewResult;
            var actual = result.Model as ShoppingCart;

            // Assert
            Assert.Equal(300, actual.TotalPrice);
        }

        [Fact]
        public void VIPMemberTotalPriceGreaterThan500Has30PercentDiscount()
        {
            // Arrange
            HomeController controller = new HomeController();
            var model = new ShoppingCart();
            model.Price = 300;
            model.Qty = 2;
            model.MemberType = MemberType.VIP;

            // Act
            ViewResult result = controller.Index(model) as ViewResult;
            var actual = result.Model as ShoppingCart;

            // Assert
            Assert.Equal(420, actual.TotalPrice);
        }
    }
}
