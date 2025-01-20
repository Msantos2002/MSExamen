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
    public class LugaresGuardadosViewModelMS
    {
        private readonly DatabaseServiceMS _databaseService;
        public ObservableCollection<LugarGuardadoMS> LugaresGuardados { get; set; }
        public LugaresGuardadosViewModelMS()
        {
            _databaseService = new DatabaseServiceMS();
            LugaresGuardados = new ObservableCollection<LugarGuardadoMS>();
        }
        public async Task CargarLugaresGuardados()
        {
            var lugares = await _databaseService.ObtenerLugaresGuardados();
            LugaresGuardados.Clear();
            foreach (var lugar in lugares)
            {
                LugaresGuardados.Add(lugar);
            }
        }
        public async Task GuardarLugar(LugarGuardadoMS lugar)
        {
            await _databaseService.GuardarLugar(lugar);
        }
    }
}