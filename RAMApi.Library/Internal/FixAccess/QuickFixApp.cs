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


        public void OnMessage(QuickFix.FIX44.ExecutionReport m, SessionID s)
        {
            Console.WriteLine("Received execution report");
        }

        public void OnMessage(QuickFix.FIX44.OrderCancelReject m, SessionID s)
        {
            Console.WriteLine("Received order cancel reject");
        }


        public void SendOrder(OrderModel order)
        {
            var orderSingle = new QuickFix.FIX44.NewOrderSingle();
            orderSingle.ClOrdID = new ClOrdID("1234");
            orderSingle.Symbol = new Symbol(order.TickerSymbol);
            orderSingle.Side = new Side(order.OrderSide);
            orderSingle.OrderQty = new OrderQty(order.Quantity);
            orderSingle.OrdType = new OrdType(order.OrderType);
            orderSingle.TimeInForce = new TimeInForce(order.TIF);
            orderSingle.Account = new Account(order.Allocation.ToString());
            orderSingle.StopPx = new StopPx(order.StopPrice);
            orderSingle.Price = new Price(order.LimitPrice);
            orderSingle.StopPx = new StopPx(order.StopPrice);
            orderSingle.Commission = new Commission(order.CommissionAndFees);
            orderSingle.TransactTime = new TransactTime(order.OrderDate);

            Session.SendToTarget(orderSingle, SessionID);

        }
    }
}
