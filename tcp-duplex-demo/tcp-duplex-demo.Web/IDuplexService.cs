using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace tcp_duplex_demo.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDuplexService" in both code and config file together.
    [ServiceContract(Namespace = "Silverlight", CallbackContract = typeof(IDuplexClient))]
    public interface IDuplexService
    {
        [OperationContract]
        void Order(string name, int quantity);
    }

    [ServiceContract]
    public interface IDuplexClient
    {
        [OperationContract(IsOneWay = true)]
        void Receive(Order order);
    }

    public class Order
    {
        public OrderStatus Status { get; set; }
        public List<string> Payload { get; set; } 
    }

    public enum OrderStatus
    {
        Processing,
        Completed
    }
}
