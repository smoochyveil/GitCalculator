using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalculator.Maui.Models
{
    public class ConsumoCompartido
    {
        public decimal ImporteDeConsumo { get; set; }  
        public int NumeroDePersonas { get; set; }
        public decimal PorcentajeDePropina { get; set; }

        //propiedades que guardan los calculos resultantes
        public decimal ImporteDelConsumoPorPersona
            => ImporteDeConsumo / NumeroDePersonas;
        public decimal ImporteDePropina
            => ImporteDeConsumo * (PorcentajeDePropina / 100.0m);
        public decimal ImporteDePropinaPorPersona
            => ImporteDePropina / NumeroDePersonas;
        public decimal ImporteTotalConPropina
            => ImporteDeConsumo + ImporteDePropina;
        public decimal ImporteTotalConPropinaPorPersona
            => ImporteTotalConPropina / NumeroDePersonas;

        public ConsumoCompartido(
            decimal importeDeConsumo, 
            int numeroDePersonas, 
            decimal porcentajeDePropina)
        {
            ImporteDeConsumo = importeDeConsumo;
            NumeroDePersonas = numeroDePersonas;
            PorcentajeDePropina = porcentajeDePropina;
        }
    }
}
