﻿using RAMApi.Library.Models;
using System.Collections.Generic;

namespace RAMApi.Library.DataAccess
{
    public interface IFillData
    {
        List<FillModel> GetFillsByClOrderID();
        void SaveFill(FillModel fillInfo);
    }
}