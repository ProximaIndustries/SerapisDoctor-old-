using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Services.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
