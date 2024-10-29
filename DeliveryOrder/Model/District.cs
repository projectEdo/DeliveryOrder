namespace DeliveryOrder.Model
{
    public class District
    {
        public string Name { get; set; }
        public List<Order> orders = new List<Order>();


        public District(string name, double weight, DateTime dateTime)
        {
            this.Name = name;
            AddOrder(weight, dateTime);
        }

        public void AddOrder(double weight, DateTime dateTime)
        {
            orders.Add(new Order(weight, Name, dateTime));
        }

        public int GetCount() { return orders.Count; }

        public static int GetOrderCount() { return Order.orderCount; }
        public static void SetOrderCount(int i) { Order.orderCount = i; }
    }
}
