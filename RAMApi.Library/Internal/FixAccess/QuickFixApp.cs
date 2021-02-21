using QuickFix;
using QuickFix.Fields;
using QuickFix.Fields.Converters;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.Internal.FixAccess
{
    public class QuickFixApp : MessageCracker, IApplication
    {
        public void FromAdmin(Message message, SessionID sessionID)
        {
           
        }

        public void FromApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("==Cracker exception==");
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }
        private SessionID SessionID { get; set; }
        public void OnCreate(SessionID sessionID)
        {
            SessionID = sessionID;
        }

        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("Logon - " + sessionID.ToString());
        }

        public void OnLogout(SessionID sessionID)
        {
            Console.WriteLine("Logout - " + sessionID.ToString());
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            
        }

        public void ToApp(Message message, SessionID sessionId)
        {
            try
            {
                bool possDupFlag = false;
                if (message.Header.IsSetField(Tags.PossDupFlag))
                {
                    possDupFlag = BoolConverter.Convert(
                        message.Header.GetString(Tags.PossDupFlag));
                }
                if (possDupFlag)
                    throw new DoNotSend();
            }
            catch (FieldNotFoundException)
            { }

            Console.WriteLine();
            Console.WriteLine("OUT: " + message.ToString());
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
            
        }

        protected void ProcessOrder(
        Price price,
        OrderQty quantity,
        Account account)
        {
            //...
        }

        public void SendOrder(OrderModel order)
        {
            var orderSingle = new QuickFix.FIX44.NewOrderSingle( new ClOrdID("1234"), new Symbol(order.TickerSymbol),
                new Side(Side.BUY), new TransactTime(order.OrderDate), new OrdType(OrdType.LIMIT));
            Session.SendToTarget(orderSingle, SessionID);
        }
    }
}
