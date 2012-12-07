using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using tcp_duplex_demo.DuplexClient;

namespace tcp_duplex_demo
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            EndpointAddress address = new EndpointAddress("http://localhost:2646/DuplexService.svc");

            PollingDuplexHttpBinding binding = new PollingDuplexHttpBinding(PollingDuplexMode.MultipleMessagesPerPoll);

            DuplexServiceClient proxy = new DuplexServiceClient(binding, address);

            proxy.ReceiveReceived += (sender, args) =>
                                         {
                                                if (args.order.Status == OrderStatus.Completed)
                                                {
                                                    String reply = "";
                                                    reply = "Here is the completed order:\n";
                                                    foreach (var order in args.order.Payload)
                                                    {
                                                        reply += order + "\n";
                                                    }
                                                    MessageBox.Show(reply);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("processing");

                                                }
                                         };
            proxy.OrderAsync("widget", 3);

        }
    }
}
