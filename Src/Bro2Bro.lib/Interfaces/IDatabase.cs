﻿using System.Collections.Generic;

using Bro2Bro.lib.DAL;

namespace Bro2Bro.lib.Interfaces
{
    public interface IDatabase
    {
        List<Bros> GetBros(string searchQuery);
    }
}