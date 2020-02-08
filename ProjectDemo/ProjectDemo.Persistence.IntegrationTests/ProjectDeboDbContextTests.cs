using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProjectDemo.Domain.Products;
using System;
using System.Threading.Tasks;

namespace ProjectDemo.Persistence.IntegrationTests
{
    public class ProjectDemoDbContextTests
    {
        private ProjectDemoDbContext _context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProjectDemoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ProjectDemoDbContext(options);
        }

        [Test]
        public async Task SaveChangesAsync_GivenProduct_ShouldSave()
        {
            var product = new Product("Product name", 1.00M);

            _context.Add(product);
            await _context.SaveChangesAsync();

            await _context.Products.SingleAsync(p => p.Id == product.Id);
        }
    }
}