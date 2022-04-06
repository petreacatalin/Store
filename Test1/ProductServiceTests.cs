using Moq;
using MyStore.Controllers;
using MyStore.Data;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test1
{
    public class ProductServiceTests
    {

        internal readonly Mock<IProductRepository> mockProductRepository;
        public ProductServiceTests()
        {
            mockProductRepository = new Mock<IProductRepository>();
            // mockProductService = new Mock<IProductService>(mockRepo.Object);

            //mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Product>
            //{
        }

        [Fact]
        public async Task Should_ReturnOk_Object_On_Get()
        {

            //  var controller = InitializeController();

            //MockTaxAvoidanceService.Setup(x => x.CreateAsync(It.IsAny<long>(), It.IsAny<ProductModel>()))
            //    .ReturnsAsync(ValidData.GenerateTaxAvoidanceDto());

            //var response = await controller.Post(ValidData.ClientId, ValidData.GeneratePostRequestModel());

            //Assert.IsType<ActionResult<TaxAvoidanceDto>>(response);
            //Assert.IsType<OkObjectResult>(response.Result);
        }

      

    }
}
