using App.Constants;
using Models;

namespace App.Agents;

public class OrderAgent : IOrderAgent
{
    private const string path = $"{Routes.BASE_URL}/Order";

    public OrderAgent()
    {

    }

    public void CreateOrder(Order order)
    {
        MessageBox.Show("Ait order added");
    }

    public List<Order> GetOrders()
    {
        return new List<Order>() {
                new Order(0, "Jelle") { OrderDate = new DateTime(2022, 10, 5) },
                new Order(1, "Tom") { OrderDate = new DateTime(2021, 1, 2) },
                new Order(2, "Bjark") { OrderDate = new DateTime(2022, 5, 20) } };
    }
}
