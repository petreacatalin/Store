using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    //public class BaseTests
    //{

    //    internal readonly Mock<IProductService> MockProductService;
    //    internal readonly Mock<IProductRepository> MockProductRepository;

    //    public BaseTests()
    //    {


    //        MockProductRepository = new Mock<IProductRepository>();
    //        MockProductRepository.Setup(x => x.GetById(1)).Returns(new Product
    //        {
    //            Categoryid = 1,
    //            Productname = "test",
    //            Supplierid = 2,
    //            Unitprice = 10,
    //            Discontinued = true,
    //            Productid = 1
    //        });

    //        MockProductService = new Mock<IProductService>(MockProductRepository);
    //        //MockProductService.Object = MockProductRepository;
    //    }
    //}
}
