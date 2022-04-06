using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductControllerTests
    {
        private Mock<IProductService> mockProductService;

        public ProductControllerTests()
        {
            mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public void Should_Return_OK_OnGetAll()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts());

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProductModel>>(actualData);

        }

        [Fact]
        public void ShouldReturn_AllProducts()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts());

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            //assert
            Assert.Equal(MultipleProducts().Count(), actualData.Count());

        }


        [Fact]
        public async Task Should_Return_NoContent_On_Delete()
        {

            var service = new Mock<IProductService>();
            service.Setup(x => x.Delete(1)).Returns(true);
            service.Setup(x => x.Exists(1)).Returns(true);
            var controller = new ProductsController(service.Object);

            var response = controller.Delete(1);

            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Should_ReturnOk_Object_On_Update()
        {
            var service = new Mock<IProductService>();
            //service.Setup(x => x.UpdateProduct(new ProductModel())).(true);
            //service.Setup(x => x.Exists(1)).Returns(true);

            //var controller = new ProductsController(service.Object);

            //var response = await controller.Update(ValidData.ClientId,
            //    ValidData.DummyGuidString,
            //    ValidData.GenerateTaxAvoidanceDto());

            //Assert.IsType<ActionResult<ProductModel>>(response);
            //Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void ShouldReturn_Ok_On_Put()
        {
            ProductModel model = new ProductModel
            {
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Categoryid = (int)Consts.Categories.Condiments,
                Supplierid = Consts.TestSupplierId,
                Unitprice = Consts.TestUnitPrice,
                Discontinued = true
            };
            mockProductService.Setup(x => x.UpdateProduct(It.IsAny<ProductModel>())).Returns(model);

            mockProductService.Setup(x => x.Exists(Consts.TestProduct)).Returns(true);
         //   mockProductService.Setup(x => x.CheckPrice(model)).Returns(true);
            var controller = new ProductsController(mockProductService.Object);
            var response = controller.Put(Consts.TestProduct, model);
            var result = response.Result as OkObjectResult;
            var actualData = result.Value as ProductModel;
            ////assert
            Assert.IsType<OkObjectResult>(result);
        }



        private List<ProductModel> MultipleProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel
                {
                    Categoryid =(int) Consts.Categories.Condiments,
                    Productid= Consts.TestProduct,
                    Productname=Consts.ProductName, //hardcoded
                    Discontinued=false,
                    Supplierid=Consts.TestSupplierId,
                    Unitprice=Consts.TestUnitPrice
                },
                new ProductModel
                {
                    Categoryid = (int) Consts.Categories.Condiments,
                    Productid=Consts.TestProduct,
                    Productname= Consts.ProductName,
                    Discontinued=false,
                    Supplierid=Consts.TestSupplierId,
                    Unitprice=Consts.TestUnitPrice
                },
                new ProductModel
                {
                    Categoryid = (int) Consts.Categories.Condiments,
                    Productid=Consts.TestProduct,
                    Productname= Consts.ProductName,
                    Discontinued=false,
                    Supplierid=Consts.TestSupplierId,
                    Unitprice=Consts.TestUnitPrice
                },
            };
        }
    }
}
