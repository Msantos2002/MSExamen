using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSExamen.Models;

using SQLite;

using System.Collections.Generic;

using System.IO;

using System.Threading.Tasks;

namespace MSExamen.Services

{

    public class DatabaseServiceMS

    {

        private readonly SQLiteAsyncConnection _database;

        public DatabaseServiceMS()

        {

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lugares.db");

            _database = new SQLiteAsyncConnection(databasePath);

            _database.CreateTableAsync<LugarGuardadoMS>().Wait();

        }

        public Task<List<LugarGuardadoMS>> ObtenerLugaresGuardados()

        {

            return _database.Table<LugarGuardadoMS>().ToListAsync();

        }

        public Task<int> GuardarLugar(LugarGuardadoMS lugar)

        {

            return _database.InsertAsync(lugar);

        }

    }

}
