﻿using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;

namespace RAMDesktopUI.Library.Cache
{
    public interface IWatchlistCache
    {
        Dictionary<int, WatchlistTabModel> TabWiseData { get; }

        event EventHandler InitializationCompleted;
    }
}