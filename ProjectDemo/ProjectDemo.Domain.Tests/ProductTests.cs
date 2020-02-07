using NUnit.Framework;
using ProjectDemo.Domain.Exceptions;
using ProjectDemo.Domain.Products;
using System;

namespace ProjectDemo.Domain.Tests
{
    public class ProductTests
    {
        [Test]
        public void Constructor_GivenValidParameters_ShouldCreateObject()
        {
            var name = "Pruduct name";
            var price = 1.00M;
            var product = new Product(name, price);

            Assert.IsFalse(product.Id == default);
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Constructor_GivenNullOrEmptyName_ShouldThrowException(string name)
        {
            Assert.Throws<ProjectDemoValidationException>(() => new Product(name, 0.00M));
        }

        [Test]
        public void Constructor_GivenTooLongName_ShouldThrowException()
        {
            Assert.Throws<ProjectDemoValidationException>(() => new Product(new string('*', 101), 0.00M));
        }

        [Test]
        public void Constrtuctor_GivenPriceBelowZero_ShouldThrowException()
        {
            Assert.Throws<ProjectDemoValidationException>(() => new Product("Product", -1.00M));
        }

        [TestCase("")]
        [TestCase(null)]
        public void SetName_GivenNullOrEmptyName_ShouldThrowException(string name)
        {
            var product = new Product("Product name", 1.00M);

            Assert.Throws<ProjectDemoValidationException>(() => product.SetName(name));
        }

        [Test]
        public void SetName_GivenTooLongName_ShouldThrowException()
        {
            var product = new Product("Product name", 1.00M);

            Assert.Throws<ProjectDemoValidationException>(() => product.SetName(new string('*', 101)));
        }

        [Test]
        public void SetPrice_GivenPriceBelowZero_ShouldThrowException()
        {
            var product = new Product("Product name", 1.00M);

            Assert.Throws<ProjectDemoValidationException>(() => product.SetPrice(-1.00M));
        }
    }
}