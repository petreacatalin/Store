using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test1
{
    public class ProductControllerTests
    {
        internal readonly Mock<IProductService> mockProductService;
        public ProductControllerTests()
        {
            mockProductService = new Mock<IProductService>();

        }


        [Fact]
        public void Should_Return_OK_onGetall()
        {

            mockProductService.Setup(x => x.GetAllProducts())
           .Returns(new List<ProductModel> { new ProductModel() });
            var controller = new ProductsController(mockProductService.Object);
            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<ProductModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            //  Assert.Equal(GetSampleEmployee().Count(), actual.Count());
            //var response = controller.Delete(21);
            //Assert.IsType<NoContentResult>(response);
        }


     
            //private ProductsController InitializeController() =>
            //new ProductsController(mockProductService.Object);
        }
    }
