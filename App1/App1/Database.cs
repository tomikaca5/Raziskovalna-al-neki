using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace App1
{
    public class Database
    {
        SQLiteAsyncConnection dbConnection;
        public Database()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }
        public Task<List<avtobusna>> GetAllavtobusna_scvAsync()
        {
            return dbConnection.Table<avtobusna>().ToListAsync();
        }
        public Task<avtobusna> GetavtobusnaAsync(int id)
        {
            return dbConnection.Table<avtobusna>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }
    }
}
