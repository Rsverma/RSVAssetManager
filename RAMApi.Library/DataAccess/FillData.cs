using RAMApi.Library.Internal.DataAccess;
using RAMApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAMApi.Library.DataAccess
{
    public class FillData : IFillData
    {
        private readonly ISqlDataAccess _sql;

        public FillData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<FillModel> GetFillsByClOrderID()
        {
            List<FillModel> output = _sql.LoadData<FillModel, dynamic>("dbo.spFill_GetByClOrderID", new { ClOrderIDs = "" }, "RAMData");
            return output;
        }

        public void SaveFill(FillModel fillInfo)
        {
            _ = _sql.SaveData("dbo.spFill_Insert", fillInfo, "RAMData");
        }

    }
}
