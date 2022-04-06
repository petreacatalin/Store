using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public static class Consts
    {
        public static int CategoryId = 2;//use enums instead
        public static int TestProduct = 3;
        public static int TestSupplierId = 7;
        public static decimal TestUnitPrice = 100.23M;

        public const string ProductName = "Test Product name 1";
        public enum Categories
        {
            Condiments = 6,
            Confections = 3,
            Dairy,
            Grains,
            Meat
        }

    }
}
