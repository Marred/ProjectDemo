using NUnit.Framework;
using ProjectDemo.Domain.Exceptions;
using ProjectDemo.Domain.Products;
using System;

namespace ProjectDemo.Domain.Tests
{
    public class Tests
    {
        [Test]
        public void ShouldCreateValidObjects()
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
        public void ShouldThrowOnCreatingWithNullOrEmptyName(string name)
        {
            Assert.Throws<ProjectDemoValidationException>(() => new Product(name, 0.00M));
        }

        [Test]
        public void ShouldThrowOnCreatingWithTooLongName()
        {
            Assert.Throws<ProjectDemoValidationException>(() => new Product(new string('*', 101), 0.00M));
        }

        [Test]
        public void ShouldThrowOnCreatingWithPriceBelowZero()
        {
            Assert.Throws<ProjectDemoValidationException>(() => new Product("Product", -1.00M));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowOnSettingNullOrEmptyName(string name)
        {
            var product = new Product("Product name", 1.00M);

            Assert.Throws<ProjectDemoValidationException>(() => product.SetName(name));
        }

        [Test]
        public void ShouldThrowOnSettingTooLongName()
        {
            var product = new Product("Product name", 1.00M);

            Assert.Throws<ProjectDemoValidationException>(() => product.SetName(new string('*', 101)));
        }

        [Test]
        public void ShouldThrowOnsettingPriceBelowZero()
        {
            var product = new Product("Product name", 1.00M);

            Assert.Throws<ProjectDemoValidationException>(() => product.SetPrice(-1.00M));
        }
    }
}