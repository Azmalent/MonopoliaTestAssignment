using MonopoliaTestAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    [TestClass]
    public sealed class Box_Should
    {
        [TestMethod]
        public void Volume_IsProductOfDimensions()
        {
            var box = new Box() { Width = 2, Height = 1, Depth = 3 };
            Assert.AreEqual(6, box.Volume);
        }

        [TestMethod]
        public void ExpirationDate_IsManufacturingDatePlus100Days()
        {
            var manufacturingDate = new DateOnly(2024, 06, 1);
            var box = new Box() { Date = manufacturingDate, IsExpirationDate = false };

            Assert.AreEqual(manufacturingDate.AddDays(100), box.ExpirationDate);
        }
    }
}
