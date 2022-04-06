using MyStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test1
{
    public static class Constants
    {
        public const string MakeRequired = "Make is required.";
        public const string ModelRequired = "Model is required.";
        public const string ProductNameInvalid = "The Productname field is required.";
    }

    public class ProductModelDtoTests
    {
        public ProductModelDtoTests()
        {

        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(2, 2);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(2, 3);
        }

        [Fact]
        public void Should_Pass()
        {
            //arrange
            var result = new ProductModel
            {
                Categoryid = 1,
                Productname = "valid name",
                Supplierid = 2,
                Discontinued = false
            };
            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(result, new ValidationContext(result), validationResults, true);

            // Assert
            Assert.True(actual, "Expected validation to succeed.");
            //Assert.E(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Fact]
        public void Should_Fail_When_ProductName_IsEmpty()
        {
            //arrange
            var result = new ProductModel
            {
                Categoryid = 1,
                Productname = "",
                Supplierid = 2,
                Discontinued = false
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(result, new ValidationContext(result), validationResults, true);
            var msg = validationResults[0];

            // Assert
     
            Assert.Equal(Constants.ProductNameInvalid, msg.ErrorMessage);
        }

    }
}
