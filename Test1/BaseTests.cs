using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{


    public class BaseTests
    {
        internal readonly IMapper Mapper;
        internal readonly Mock<IProductService> mockProductService;
        internal readonly Mock<IProductRepository> mockRepository;
        internal readonly MyStore.Domain.Entities.StoreContext StoreInternalContext;

        public BaseTests()
        {
            // Mapper = AutoMapperTestConfig.ConfigureMapper();
            mockProductService = new Mock<IProductService>();
            mockRepository = new Mock<IProductRepository>();
        }



    }

   
}