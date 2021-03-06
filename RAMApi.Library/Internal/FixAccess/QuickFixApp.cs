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
        Session _session = null;
        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
        }

        public void OnLogout(SessionID sessionID)
        {
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
        }


        public void OnMessage(QuickFix.FIX44.ExecutionReport m, SessionID s)
        {
            FillModel fill = new FillModel
            {
                AvgPx = m.Price.getValue(),
                ClOrderId = m.ClOrdID.getValue(),
                CumQty = (int)m.CumQty.getValue(),
                LastQty = (int)m.LastQty.getValue(),
                LeavesQty = (int)m.LeavesQty.getValue(),
                OrderQty = (int)m.OrderQty.getValue(),
                Side = m.Side.getValue(),
                OrdStatus = m.OrdStatus.getValue(),
                TickerSymbol = m.Symbol.getValue(),
                ExecId = m.ExecID.getValue(),
                ExecType = m.ExecType.getValue() - '0',
                OrderId = m.OrderID.getValue(),
            };
            FillReceived?.Invoke(this, fill);
        }

        public event EventHandler<FillModel> FillReceived;
        
        public void OnMessage(QuickFix.FIX44.OrderCancelReject m, SessionID s)
        {
        }

        public void SendOrder(OrderModel order)
        {
            var orderSingle = new QuickFix.FIX44.NewOrderSingle
            {
                Symbol = new Symbol(order.TickerSymbol),
                ClOrdID = new ClOrdID(order.ClOrderId),
                Side = new Side(order.Side),
                OrderQty = new OrderQty(order.Quantity),
                OrdType = new OrdType(order.Type),
                TimeInForce = new TimeInForce(order.TIF),
                Account = new Account(order.Allocation.ToString()),
                StopPx = new StopPx(order.StopPrice),
                Price = new Price(order.LimitPrice),
                Commission = new Commission(order.CommissionAndFees),
                TransactTime = new TransactTime(order.OrderDate)
            };

            if (_session != null)
                _ = _session.Send(orderSingle);

        }
    }
}
