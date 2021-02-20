using QuickFix;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Internal.FixAccess
{
    public class FixDataAccess : MessageCracker, IApplication
    {
        public void FromAdmin(Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void FromApp(Message message, SessionID sessionID)
        {
            Crack(message, sessionID);
        }
        private SessionID MySessionID { get; set; }
        public void OnCreate(SessionID sessionID)
        {
            MySessionID = sessionID;
        }

        public void OnLogon(SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void OnLogout(SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void ToApp(Message message, SessionID sessionId)
        {
            throw new NotImplementedException();
        }
        public void OnMessage(
   QuickFix.FIX44.NewOrderSingle order,
   SessionID sessionID)
        {
            ProcessOrder(order.Price, order.OrderQty, order.Account);
        }

        public void OnMessage(
            QuickFix.FIX44.SecurityDefinition secDef,
            SessionID sessionID)
        {
            GotSecDef(secDef);
        }

        private void GotSecDef(QuickFix.FIX44.SecurityDefinition secDef)
        {
            throw new NotImplementedException();
        }

        protected void ProcessOrder(
        Price price,
        OrderQty quantity,
        Account account)
        {
            //...
        }
    }
}
