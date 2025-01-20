using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MSExamen.Models
{
        public class LugarGuardadoMS
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double Latitud { get; set; }
            public double Longitud { get; set; }
        }
    }

