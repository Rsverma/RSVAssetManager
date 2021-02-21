using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Cache
{
    public class OrderFieldsCache : IOrderFieldsCache
    {
        private readonly IOrderFieldsEndpoint _orderFields;
        public OrderFieldsCache(IOrderFieldsEndpoint orderFields)
        {
            _orderFields = orderFields;
            _accounts = Task.Run(() => _orderFields.GetAccounts()).Result;
            _brokers = Task.Run(() => _orderFields.GetBrokers()).Result;
            _securities = Task.Run(() => _orderFields.GetSecurities()).Result;
        }

        private readonly List<SecurityModel> _securities;

        public List<SecurityModel> Securities
        {
            get { return _securities; }
        }
        private readonly List<AccountModel> _accounts;

        public List<AccountModel> Accounts
        {
            get { return _accounts; }
        }

        private readonly List<BrokerModel> _brokers;

        public List<BrokerModel> Brokers
        {
            get { return _brokers; }
        }

        private readonly List<UserModel> _users;

        public List<UserModel> Users
        {
            get { return _users; }
        }

    }
}
