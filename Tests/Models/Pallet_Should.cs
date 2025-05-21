using MonopoliaTestAssignment.Models;

namespace Tests.Models
{
    [TestClass]
    public sealed class Pallet_Should
    {
        [TestMethod]
        public void Weight_Empty_Is30()
        {
            var pallet = new Pallet();
            Assert.AreEqual(30, pallet.Weight);
        }

        [TestMethod]
        [DataRow(new[] { 15 }, 45)]
        [DataRow(new[] { 10, 5, 20 }, 65)]
        public void Weight_NotEmpty_IsSumOfWeights(int[] boxWeights, int expectedWeight)
        {
            var pallet = new Pallet();

            for (int i = 0; i < boxWeights.Length; i++)
            {
                var box = new Box() { Weight = boxWeights[i] };
                pallet.Boxes.Add(box);
            }

            Assert.AreEqual(expectedWeight, pallet.Weight);
        }

        [TestMethod]
        public void Volume_Empty_IsProductOfDimensions()
        {
            var pallet = new Pallet() { Width = 2, Height = 1, Depth = 3 };
            Assert.AreEqual(6, pallet.Volume);
        }

        [TestMethod]
        public void Volume_NotEmpty_IsSumOfVolumes()
        {
            var pallet = new Pallet() { Width = 1, Height = 1, Depth = 1 };

            pallet.Boxes.Add(new Box() { Width = 2, Height = 2, Depth = 2 });
            pallet.Boxes.Add(new Box() { Width = 3, Height = 3, Depth = 3 });

            Assert.AreEqual(1 + 8 + 27, pallet.Volume);
        }

        [TestMethod]
        public void ExpirationDate_Empty_IsNull()
        {
            var pallet = new Pallet();
            Assert.IsNull(pallet.ExpirationDate);
        }

        [TestMethod]
        public void ExpirationDate_NotEmpty_IsMinOfBoxExpirationDates()
        {
            var pallet = new Pallet();

            var newBox = new Box() { Date = new DateOnly(2026, 1, 1), IsExpirationDate = true };
            var oldBox = new Box() { Date = new DateOnly(2024, 1, 1), IsExpirationDate = true };

            pallet.Boxes.Add(newBox);
            pallet.Boxes.Add(oldBox);

            Assert.AreEqual(pallet.ExpirationDate, oldBox.ExpirationDate);
        }
    }
}
