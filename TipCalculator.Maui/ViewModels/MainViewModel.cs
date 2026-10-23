using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TipCalculator.Maui.Models;

namespace TipCalculator.Maui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        //variables de instancia para datos de entrada de la interfaz de usuario
        [ObservableProperty]
        private string _importeDeConsumo;
        [ObservableProperty]
        private string _numeroDePersonas;
        [ObservableProperty]
        private string _porcentajeDePropina;

        //variable de instancia para resultados de la IU
        [ObservableProperty]
        public string _importeDelConsumoPorPersona;
        [ObservableProperty]
        public string _importeDePropina;
        [ObservableProperty]
        public string _importeDePropinaPorPersona;
        [ObservableProperty]
        public string _importeTotalConPropina;
        [ObservableProperty]
        public string _importeTotalConPropinaPorPersona;
        [ObservableProperty]
        public string _importeDeConsumoDuplicado;


        public MainViewModel()
        {
            limpiar();

        }
        [RelayCommand]
        public void calcularPropina()
        {
            decimal importeDeConsumo;
            int numeroDePersonas;
            decimal porcentajeDePropina;

            bool importeDeConsumoValido =
                decimal.TryParse(ImporteDeConsumo, out importeDeConsumo);
            bool numeroDePersonasValido =
                int.TryParse(NumeroDePersonas, out numeroDePersonas);
            bool porcentajeDePropinaValido =
                decimal.TryParse(PorcentajeDePropina, out porcentajeDePropina);
            if (importeDeConsumoValido
                && numeroDePersonasValido
                && porcentajeDePropinaValido)
            {
                var consumo = new ConsumoCompartido(
                    importeDeConsumo,
                    numeroDePersonas,
                    porcentajeDePropina);
                ImporteDeConsumoDuplicado =
                    consumo.ImporteDeConsumo.ToString("C2");
                ImporteDelConsumoPorPersona =
                    consumo.ImporteDelConsumoPorPersona.ToString("C2");
                ImporteDePropina =
                    consumo.ImporteDePropina.ToString("C2");
                ImporteDePropinaPorPersona =
                    consumo.ImporteDePropinaPorPersona.ToString("C2");
                ImporteTotalConPropina =
                    consumo.ImporteTotalConPropina.ToString("C2");
                ImporteTotalConPropinaPorPersona =
                    consumo.ImporteTotalConPropinaPorPersona.ToString("C2");
            }
        }
        [RelayCommand]
        public void limpiar()
        {
            ImporteDeConsumoDuplicado = string.Empty;
            ImporteDeConsumo = string.Empty;
            NumeroDePersonas = "1";
            PorcentajeDePropina = "10";
            ImporteDelConsumoPorPersona = string.Empty;
            ImporteDePropina = string.Empty;
            ImporteDePropinaPorPersona = string.Empty;
            ImporteTotalConPropina = string.Empty;
            ImporteTotalConPropinaPorPersona = string.Empty;
        }
        [RelayCommand]
        public void ActualizarPorcentajeDePropina( string nuevoPorcentaje)
        {
            PorcentajeDePropina = nuevoPorcentaje;
        }
    }
}
