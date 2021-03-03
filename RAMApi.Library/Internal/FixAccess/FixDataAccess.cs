using QuickFix;
using QuickFix.Fields;
using QuickFix.Transport;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Internal.FixAccess
{
    public class FixDataAccess : IFixDataAccess
    {
        private readonly QuickFixApp fixApp;
        private int count = 0;
        public FixDataAccess()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + @"\Internal\FixAccess\tradeclient.cfg";
            SessionSettings settings = new SessionSettings(file);
            fixApp = new QuickFixApp();
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            SocketInitiator initiator = new SocketInitiator(
                fixApp,
                storeFactory,
                settings,
                logFactory);

            initiator.Start();
        }

        public void SendOrder(OrderModel order)
        {
            fixApp.SendOrder(order);
        }

        public string GetNewClOrderID()
        {
            count++;
            return DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + count.ToString("D3");
        }

    }
}
