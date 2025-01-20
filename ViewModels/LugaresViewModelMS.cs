using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSExamen.Models;
using MSExamen.Services;
using System.Collections.ObjectModel;


namespace MSExamen.ViewModels
{
        public class LugaresViewModelMS
        {
            private readonly GoogleMapsServiceMS _mapsService;
            public ObservableCollection<LugarMS> Lugares { get; set; }
            public LugaresViewModelMS()
            {
                _mapsService = new GoogleMapsServiceMS();
                Lugares = new ObservableCollection<LugarMS>();
            }
            public async Task CargarLugares(string apiKey)
            {
                var lugares = await _mapsService.ObtenerLugares(apiKey);
                Lugares.Clear();
                foreach (var lugar in lugares)
                {
                    Lugares.Add(lugar);
                }
            }
        }
    }
