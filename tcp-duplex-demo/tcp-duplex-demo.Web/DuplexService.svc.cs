using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace tcp_duplex_demo.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    public class OrderService : IDuplexService
    {
        private IDuplexClient client;
        private string orderName;
        private int orderQuantity;

        public void Order(string name, int quantity)
        {
            client = OperationContext.Current.GetCallbackChannel<IDuplexClient>();
            orderName = name;
            orderQuantity = quantity;
            using (Timer timer = new Timer(new TimerCallback(CallClient), null, 5000, 5000))
            {
                Thread.Sleep(11000);
            }
        }

        private bool processed = false;

        private void CallClient(object o)
        {
            Order order = new Order();
            order.Payload = new List<string>();

            if (processed)
            {
                while (orderQuantity-- > 0)
                {
                    order.Payload.Add(orderName + orderQuantity);
                }
                order.Status = OrderStatus.Completed;
            }
            else
            {
                order.Status = OrderStatus.Processing;
                processed = true;
            }
            client.Receive(order);
        }
    }
}
