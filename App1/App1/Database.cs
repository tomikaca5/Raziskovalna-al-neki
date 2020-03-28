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
        public Task<List<koordinate>> GetAllkoordinateAsync()
        {
            return dbConnection.Table<koordinate>().ToListAsync();
        }

        public Task<List<tocke>> GetAlltockeAsync()
        {
            return dbConnection.Table<tocke>().ToListAsync();
        }

        public Task<koordinate> GetavtobusnaAsync(int id)
        {
            return dbConnection.Table<koordinate>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<koordinate>> GetkoordinatepotAsync(int pot_id)
        {
            //probaj v DB Browser
            return dbConnection.QueryAsync<koordinate>("SELECT * FROM koordinate WHERE pot_id=" + pot_id + ";");
        }
        public Task<List<tocke>> GettockepotAsync(int pot_id)
        {
            //probaj v DB Browser
            return dbConnection.QueryAsync<tocke>("SELECT * FROM zanimivosti WHERE pot_id=" + pot_id + ";");
        }

    }
}
