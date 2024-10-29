using DeliveryOrder.Model;

namespace DeliveryOrder.Tests.Model
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Constructor_DataOrder_NewOrde()
        {
            double weight = 15.5;
            string district = "Центральный";
            DateTime dateTime = new DateTime(2023, 12, 17, 08, 45, 09);

            Order order = new Order(weight, district, dateTime);

            Assert.AreEqual(weight, order.weight);
            Assert.AreEqual(district, order.district);
            Assert.AreEqual(dateTime, order.dateTime);
        }
    }
}
