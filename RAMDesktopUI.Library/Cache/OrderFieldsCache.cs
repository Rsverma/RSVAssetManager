using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMDesktopUI.Library.Cache
{
    public class OrderFieldsCache : IOrderFieldsCache
    {
        private readonly IOrderFieldsEndpoint _orderFields;
        public OrderFieldsCache(IOrderFieldsEndpoint orderFields)
        {
            _orderFields = orderFields;
            LoadCache();
        }

        public async void LoadCache()
        {
            _accounts = await _orderFields.GetAccounts();
            _brokers = await _orderFields.GetBrokers();
            _securities = await _orderFields.GetSecurities();
        }

        private List<SecurityModel> _securities;

        public List<SecurityModel> Securities
        {
            get { return _securities; }
        }
        private List<AccountModel> _accounts;

        public List<AccountModel> Accounts
        {
            get { return _accounts; }
        }

        private List<BrokerModel> _brokers;

        public List<BrokerModel> Brokers
        {
            get { return _brokers; }
        }

        private List<UserModel> _users;

        public List<UserModel> Users
        {
            get { return _users; }
        }

    }
}
