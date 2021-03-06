﻿using PhotoSafe.Data;
using PhotoSafe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Services
{
    public interface ISafeService
    {
        IEnumerable<Safe> GetSafes();

        Safe GetSafe(int id);

        Task CreateSafe(SafeViewModel safeViewModel);
    }
}
