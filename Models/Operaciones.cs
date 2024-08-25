using System;

namespace PC1_ORO.Models
{
    public class Operaciones
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Instrumento { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Igv { get; set; }
        public decimal? Total { get; set; }

        public void CalcularMonto()
        {
            if (Instrumento == "S&P")
            {
                Total = 500;
                Igv = 90;
            }
            else if (Instrumento == "Dow Jones")
            {
                Total = 300;
                Igv = 54;
            }
            else if (Instrumento == "Bonos US")
            {
                Total = 120;
                Igv = 21.60m;
            }
            else
            {
                Total = 0;
                Igv = 0;
            }
             
        }
        
    }
}
