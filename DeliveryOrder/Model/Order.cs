namespace DeliveryOrder.Model
{
    public class Order
    {
        public static int orderCount = 0;
        public int id { get; set; }
        public double weight { get; set; }
        public string district { get; set; }
        public DateTime dateTime { get; set; }

        public Order(double weight, string district, DateTime dateTime)
        {
            this.id = orderCount;
            this.weight = weight;
            this.district = district;
            this.dateTime = dateTime;
            orderCount++;
        }
    }
}
