﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    public interface IDBInterface
    {
        SQLiteAsyncConnection CreateConnection();
    }
}
