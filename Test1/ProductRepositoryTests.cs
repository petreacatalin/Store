using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyStore.Controllers;
using MyStore.Services;

namespace Test1
{
    public class ProductRepositoryTests
    {
        private ProductRepository _taxAvoidanceRepository;
        private StoreContext _userContext;

        public ProductRepositoryTests()
        {
            _userContext = new StoreContext();
        }


        [Fact]
        public void GetAllProducts()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Product> {
            new Product{
                Categoryid=1,
                Productname="test",
                Supplierid=2,
                Unitprice=10,
                Discontinued=true
            },
                new Product{
                Categoryid=2,
                Productname="test2",
                Supplierid=3,
                Unitprice=100,
                Discontinued=true
            }
            });


            var result = mockRepo.Object.GetAll();
            //var service = new Mock<IProductService>();
            //var controller = new ProductsController(service.Object);

            //// Act
            //var result = controller.Get();

            // Assert
            //   var model = Assert.IsAssignableFrom<IEnumerable<Product>>(result);
            Assert.Equal(2, result.Count());

        }

        //[Fact]
        //public void Add_WhenHaveNoProductName()
        //{
        //    IProductRepository sut = GetInMemoryProductRepository();
        //    Product product = new Product()
        //    {
        //        Productid = 1,
        //        Productname = "",
        //        Categoryid = 2
        //    };

        //    Product savedProduct = sut.Add(product);

        //    Assert.Equal(1, sut.GetAll().Count());
        //    Assert.Equal("fred", savedProduct.Productname);
        //    Assert.Equal(2, savedProduct.Categoryid);
        //}

        //private IProductRepository GetInMemoryProductRepository()
        //{

        //    var builder = new DbContextOptionsBuilder<StoreContext>();
        //    builder.UseInMemoryDatabase(databaseName: "LPInMemory");
        //    var options = builder.Options;
        //    StoreContext context = new StoreContext(options);
        //    context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();
        //    return new ProductRepository(context);
        //}

        //[Fact]
        //[Trait("TaxAvoidance", "GetAllAsync")]
        //public async Task Should_Return_Filtered_By_ClientId_Entries_On_GetAllAsync()
        //{
        //    await using var context = InMemoryContextHelpers.GetCleanInMemoryDbContext();
        //    await AddMultipleEntries(context);
        //    _taxAvoidanceRepository = new TaxAvoidanceRepository(context);

        //    ICollection<DbModels.TaxAvoidance> actuals = await _taxAvoidanceRepository
        //        .GetAllAsync(Guid.Parse(_userContext.TenantId), ValidData.ClientId, CurrentTaxYear);

        //    Assert.NotEqual(0, actuals.Count);
        //    Assert.True(actuals.All(x => x.TenantId.ToString() == ValidData.TenantId));
        //    Assert.True(actuals.All(x => x.ClientId == ValidData.ClientId));
        //}
    }
}
