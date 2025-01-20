using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace MSExamen.ViewModels
{
    public class LugarSeleccionadoViewModelMS : BaseViewModel
    {
        private Lugar _lugar;
        public Lugar Lugar
        {
            get => _lugar;
            set
            {
                _lugar = value;
                OnPropertyChanged();
            }
        }
        public ICommand GuardarLugarCommand { get; }
        public LugarSeleccionadoViewModelMS(Lugar lugar)

        {
            Lugar= lugar;
            GuardarLugarCommand = new Command(async () => await GuardarLugarAsync());
        }
        private async Task GuardarLugarAsync()
        {
            if (Lugar != null)
            {
                // Guardar el lugar en la base de datos SQLite
                await App.LugaresService.GuardarLugarAsync(Lugar);
                await Shell.Current.DisplayAlert("Éxito", "Lugar guardado correctamente.", "OK");
            }
        }
    }
}