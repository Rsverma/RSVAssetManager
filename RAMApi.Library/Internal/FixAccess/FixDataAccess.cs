using QuickFix;
using QuickFix.Fields;
using QuickFix.Transport;
using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Internal.FixAccess
{
    public class FixDataAccess : IFixDataAccess
    {
        private readonly QuickFixApp fixApp;
        private readonly ISqlDataAccess _sql;
        private int count = 0;
        public FixDataAccess(ISqlDataAccess sql)
        {
            _sql = sql;
            string file = AppDomain.CurrentDomain.BaseDirectory + @"\Internal\FixAccess\tradeclient.cfg";
            SessionSettings settings = new SessionSettings(file);
            fixApp = new QuickFixApp();
            fixApp.FillReceived += FixApp_FillReceived;
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            SocketInitiator initiator = new SocketInitiator(
                fixApp,
                storeFactory,
                settings,
                logFactory);

            initiator.Start();
        }

        private void FixApp_FillReceived(object sender, FillModel fill)
        {
            _ = _sql.SaveData("dbo.spFill_Insert", fill, "RAMData");
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
