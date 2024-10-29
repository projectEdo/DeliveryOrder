using DeliveryOrder.Model;

namespace DeliveryOrder.Tests.Model
{
    [TestClass]
    public class DistrictTests
    {
        District district;

        [TestInitialize]
        public void Setup()
        {
            district = new District("Центральный", 56.5, new DateTime(2023, 12, 17, 08, 45, 09));
        }

        [TestMethod]
        public void Constructor_DataDistrict_NewDistrict()
        {
            Assert.AreEqual("Центральный", district.Name);
            Assert.AreEqual("Центральный", district.orders[0].district);
            Assert.AreEqual(56.5, district.orders[0].weight);
            Assert.AreEqual(new DateTime(2023, 12, 17, 08, 45, 09), district.orders[0].dateTime);
        }

        [TestMethod]
        public void AddOrder_NewOrder_DistrictWithNewOrder()
        {
            double weight = 0.65;
            DateTime dateTime = new DateTime(2024, 08, 05, 05, 46, 36);
            
            district.AddOrder(weight, dateTime);
            int id = district.GetCount() - 1;

            Assert.AreEqual("Центральный", district.Name);
            Assert.AreEqual("Центральный", district.orders[id].district);
            Assert.AreEqual(weight, district.orders[id].weight);
            Assert.AreEqual(dateTime, district.orders[id].dateTime);
        }

        [TestMethod]
        public void GetCount_NewDistrictAndNewOrder_CountOrderSpecificDistrict()
        {
            District dst = new District("Автозаводский", 5.45, new DateTime(2024, 08, 05, 05, 46, 36));
            dst.AddOrder(35.65, new DateTime(2024, 02, 07, 08, 23, 37));

            Assert.AreEqual(1, district.GetCount());
            Assert.AreEqual(2, dst.GetCount());
        }

        [TestMethod]
        public void GetOrderCount_NewDistrictAndNewOrder_CountAllOrder()
        {
            District.SetOrderCount(1);
            District dst = new District("Автозаводский", 5.45, new DateTime(2024, 08, 05, 05, 46, 36));
            dst.AddOrder(35.65, new DateTime(2024, 02, 07, 08, 23, 37));

            Assert.AreEqual(3, District.GetOrderCount());
        }

        [TestMethod]
        public void SetOrderCount_X_GetOrderCountEqualsX()
        {
            District.SetOrderCount(10);

            Assert.AreEqual(10, District.GetOrderCount());
        }

    }
}
